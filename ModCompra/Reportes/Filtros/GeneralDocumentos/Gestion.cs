using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.Filtros.GeneralDocumentos
{
    
    public class Gestion : IReporte
    {

        private IFiltros filtros;
        private Reportes.Filtros.data filtrarPor;


        public IFiltros Filtros
        {
            get { return filtros;}
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
            var filtro = new OOB.LibCompra.Reportes.GeneralDocumentos.Filtro()
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
            if (filtrarPor.GetProveedorId  != "")
            {
                filtro.autoProveedor = filtrarPor.GetProveedorId;
                xfiltro += ", Proveedor: " + filtrarPor.GetProveedorDesc;
            }
            if (filtrarPor.GetEstatusId != "")
            {
                filtro.estatus = OOB.LibCompra.Reportes.Enumerados.EnumEstatus.Activo;
                if (filtrarPor.GetEstatusId == "02")
                    filtro.estatus = OOB.LibCompra.Reportes.Enumerados.EnumEstatus.Anulado;
                xfiltro += ", Estatus: " + filtro.estatus.ToString();
            }

            var xr1 = Sistema.MyData.Reportes_ComprasDocumento(filtro);
            if (xr1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr1.Mensaje);
                return;
            }
            Reporte(xr1.Lista, xfiltro);
        }

        private void Reporte(List<OOB.LibCompra.Reportes.GeneralDocumentos.Ficha> list, string xfiltro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\GeneralDocumentos.rdlc";
            var ds = new DS();
            foreach (var it in list.ToList().OrderBy(o => o.fecha).ThenBy(o=>o.documento).ToList())
            {
                DataRow rt = ds.Tables["GeneralDoc"].NewRow();
                rt["fecha"] = it.fecha;
                rt["serie"] = it.serieDoc;
                rt["documentoNro"] = it.documento;
                rt["controlNro"] = it.control;
                rt["proveedor"] = it.provCiRif + Environment.NewLine + it.provNombre;
                rt["renglones"] = it.renglones;
                rt["montoDscto"] = it.montoDscto*it.signoDoc;
                rt["montoCargo"] = it.montoCargo*it.signoDoc;
                rt["total"] = it.total*it.signoDoc;
                rt["totalDivisa"] = it.totalDivisa*it.signoDoc;
                rt["factor"] = it.factorDoc;
                rt["estatus"] = it.EsAnulado?"ANULADO":"";
                rt["signo"] = it.signoDoc==1 ? "+": "-";

                if (it.EsAnulado) 
                {
                    rt["montoDscto"] = 0.0m;
                    rt["montoCargo"] = 0.0m;
                    rt["total"] = 0.0m ;
                    rt["totalDivisa"] = 0.0m;
                }

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