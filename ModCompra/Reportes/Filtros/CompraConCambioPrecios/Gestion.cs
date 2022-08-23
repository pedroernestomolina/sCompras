using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.Filtros.CompraConCambioPrecios
{

    public class Gestion : IReporte
    {

        private IFiltros filtros;
        private Reportes.Filtros.data filtrarPor;


        public IFiltros Filtros
        {
            get { return filtros; }
        }


        public Gestion()
        {
            filtros = new Filtros();
        }


        public void setDataFiltros(data filtros)
        {
            filtrarPor = filtros;
        }

        public void Generar()
        {
            var xfiltro = "";
            var filtro = new OOB.LibCompra.Reportes.CompraConCambioPrecios.Filtro()
            {
                desde = filtrarPor.GetDesde,
                hasta = filtrarPor.GetHasta,
            };
            xfiltro += "Desde: " + filtrarPor.GetDesde.ToShortDateString() + ", Hasta: " + filtrarPor.GetHasta.ToShortDateString();
            if (filtrarPor.GetSucursalId != "")
            {
                var rt1 = Sistema.MyData.Sucursal_GetFicha(filtrarPor.GetSucursalId);
                if (rt1.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(rt1.Mensaje);
                    return;
                }
                filtro.codSucursal = rt1.Entidad.codigo;
                xfiltro += ", Cod/Suc: " + rt1.Entidad.nombre + "(" + rt1.Entidad.codigo + ")";
            }
            if (filtrarPor.GetProveedorId != "")
            {
                filtro.autoProveedor = filtrarPor.GetProveedorId;
                xfiltro += ", Proveedor: " + filtrarPor.GetProveedorDesc;
            }
            var xr1 = Sistema.MyData.Reportes_CompraConCambioPrecios(filtro);
            if (xr1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr1.Mensaje);
                return;
            }
            Reporte(xr1.Lista, xfiltro);
        }

        private void Reporte(List<OOB.LibCompra.Reportes.CompraConCambioPrecios.Ficha> list, string xfiltro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\CompraConCambioPrecios.rdlc";
            var ds = new DS();
            foreach (var it in list.ToList().OrderBy(o => o.fecha).ThenBy(o => o.documento).ToList())
            {
                DataRow rt = ds.Tables["GeneralDoc"].NewRow();
                rt["fecha"] = it.fecha;
                rt["serie"] = it.serieDoc;
                rt["documentoNro"] = it.documento;
                rt["controlNro"] = it.control;
                rt["proveedor"] = it.provCiRif + Environment.NewLine + it.provNombre;
                rt["renglones"] = it.renglones;
                rt["total"] = it.total * it.signoDoc;
                rt["totalDivisa"] = it.totalDivisa * it.signoDoc;
                rt["factor"] = it.factorDoc;
                rt["estatus"] = it.EsAnulado ? "ANULADO" : "";
                rt["signo"] = it.signoDoc == 1 ? "+" : "-";
                ds.Tables["GeneralDoc"].Rows.Add(rt);
            }
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("Filtros", xfiltro));
            Rds.Add(new ReportDataSource("GeneralDoc", ds.Tables["GeneralDoc"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}