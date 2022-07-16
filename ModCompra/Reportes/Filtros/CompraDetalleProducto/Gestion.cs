using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.Filtros.CompraDetalleProducto
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
            if (filtrarPor.hasta < filtrarPor.desde)
            {
                Helpers.Msg.Error("Fechas Incorrectas, Verifique Por Favor");
                return;
            }

            var filtro = new OOB.LibCompra.Reportes.CompraPorProductoDetalle.Filtro()
            {
                desde = filtrarPor.desde,
                hasta = filtrarPor.hasta,
            };
            xfiltro += "Desde: " + filtrarPor.desde.ToShortDateString() + ", Hasta: " + filtrarPor.hasta.ToShortDateString();

            var xr1 = Sistema.MyData.Reportes_CompraPorProductoDetalle(filtro);
            if (xr1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr1.Mensaje);
                return;
            }
            Reporte(xr1.Lista,xfiltro);
        }

        private void Reporte(List<OOB.LibCompra.Reportes.CompraPorProductoDetalle.Ficha> list, string xfiltro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\CompraDetallePrd.rdlc";
            var ds = new DS();
            foreach (var it in list.ToList().OrderBy(o => o.nombrePrd).ThenByDescending(o=>o.fecha).ToList())
            {
                DataRow rt = ds.Tables["CompraDetPrd"].NewRow();
                rt["producto"] = it.nombrePrd+Environment.NewLine+it.codigoPrd;
                rt["documento"] = it.documento;
                rt["fecha"] = it.fecha;
                rt["nombreDoc"] = it.nombreDoc;
                rt["serieDoc"] = it.serieDoc;
                rt["cantUnd"] = it.cantUnd*it.signoDoc;
                rt["costoUnd"] = it.costoUnd;
                rt["costoUndDivisa"] = it.costoUnd/it.factor;
                rt["total"] = it.total * it.signoDoc;
                rt["totalDivisa"] = it.totalDivisa*it.signoDoc;
                rt["factor"] = it.factor;
                ds.Tables["CompraDetPrd"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("Filtros", xfiltro));
            Rds.Add(new ReportDataSource("CompraDetPrd", ds.Tables["CompraDetPrd"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}