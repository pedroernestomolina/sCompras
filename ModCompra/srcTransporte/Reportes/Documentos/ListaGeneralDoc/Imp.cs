using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Documentos.ListaGeneralDoc
{
    public class Imp: IRepFiltro
    {
        private OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Filtro _filtro;


        public Imp()
        {
        }
        public void setFiltros(Idata data)
        {
            _filtro = new OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Filtro()
            {
            };
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Compras_GeneralDoc_GetLista(_filtro);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Documentos\RepDoc_General.rdlc";
            var ds = new DS_REPDOC();

            foreach (var rg in list)
            {
                DataRow rt = ds.Tables["General"].NewRow();
                rt["fechaDoc"] = rg.fechaDoc;
                rt["siglasDoc"] = rg.siglasDoc;
                rt["documento"] = rg.numeroDoc;
                rt["prov"] = rg.prvCiRif + Environment.NewLine + rg.prvNombre;
                rt["neto"] = rg.netoDoc;
                rt["totalDoc"] = rg.totalDoc;
                rt["montoExento"] = rg.montoExento;
                rt["montoBase"] = rg.montoBase;
                rt["montoIva"] = rg.montoImpuesto;
                rt["montoIgtf"] = rg.montoIgtf;
                rt["estatus"] = rg.estatusDoc == "1" ? "ANULADO" : "";
                if (rg.estatusDoc.Trim().ToUpper() == "1")
                {
                    rt["neto"] = 0m;
                    rt["totalDoc"] = 0m;
                    rt["montoIva"] = 0m;
                    rt["montoExento"] = 0m;
                    rt["montoIgtf"] = 0m;
                    rt["montoBase"] = 0m;
                }
                ds.Tables["General"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("General", ds.Tables["General"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}