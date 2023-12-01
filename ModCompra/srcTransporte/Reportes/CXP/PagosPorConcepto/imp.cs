using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using ModCompra.srcTransporte.Reportes.ListaAdm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.CXP.PagosPorConcepto
{
    public class Imp : IRepFiltro
    {
        private OOB.LibCompra.Transporte.Reportes.Cxp.PagoPorConceptos.Filtro _filtro;


        public Imp()
        {
        }
        public void setFiltros(object filtros)
        {
            var ft = (Reportes.RepFiltro.Vista.IFiltros)filtros;
            _filtro = new OOB.LibCompra.Transporte.Reportes.Cxp.PagoPorConceptos.Filtro()
            {
                Desde = ft.Desde,
                Hasta = ft.Hasta,
                IdConcepto = ft.IdConcepto,
            };
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Cxp_PagosPorConcepto(_filtro);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Cxp.PagoPorConceptos.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\CxP\RepCxp_PagoPorConcepto.rdlc";
            var ds = new DS_ADM();

            foreach (var rg in list)
            {
                DataRow rt = ds.Tables["CxpPagoPorConcepto"].NewRow();
                rt["entidad"] = rg.entidadCiRif.Trim()+Environment.NewLine+rg.entidadNombre.Trim();
                rt["fecha"] = rg.recFecha;
                rt["montoDiv"] = rg.importeDiv;
                rt["recibo"] = rg.recNro;
                rt["documento"] = rg.siglasDoc+Environment.NewLine+rg.numeroDoc;
                rt["tasaFactor"] = rg.tasaFactor ;
                rt["concepto"] = rg.conceptoCod + Environment.NewLine + rg.conceptoDesc;
                ds.Tables["CxpPagoPorConcepto"].Rows.Add(rt);
            }
            //
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("CxpPagoPorConcepto", ds.Tables["CxpPagoPorConcepto"]));
            //
            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}