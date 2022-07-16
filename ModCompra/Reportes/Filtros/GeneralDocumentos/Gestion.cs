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
            if (filtrarPor.hasta < filtrarPor.desde) 
            {
                Helpers.Msg.Error("Fechas Incorrectas, Verifique Por Favor");
                return;
            }
            var filtro = new OOB.LibCompra.Reportes.GeneralDocumentos.Filtro()
            {
                desde = filtrarPor.desde,
                hasta = filtrarPor.hasta,
            };
            xfiltro += "Desde: " + filtrarPor.desde.ToShortDateString() + ", Hasta: " + filtrarPor.hasta.ToShortDateString();
            if (filtrarPor.sucursal != null)
            {
                filtro.codSucursal = filtrarPor.sucursal.codigo;
                xfiltro += ", Cod/Suc: " + filtrarPor.sucursal.codigo;
            }
            if (filtrarPor.estatus != null)
            {
                filtro.estatus = OOB.LibCompra.Reportes.Enumerados.EnumEstatus.Activo; 
                if (filtrarPor.estatus.Id=="02")
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