using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Planillas.RetISLR
{
    public class Imp: IRepPlanilla
    {
        private string _idDoc;


        public Imp()
        {
        }
        public void setIdDoc(object idDoc)
        {
            _idDoc = (string)idDoc;
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Compras_Planilla_RetIslr(_idDoc);
                imprimir(r01.Entidad);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private void imprimir(OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha ficha)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Planillas\RepPlanilla_RetIslr.rdlc";
            var ds = new DS_PLANILLA();

            DataRow rt = ds.Tables["RetIslr"].NewRow();
            rt["comprobante_nro"] = ficha.comprobanteRet;
            rt["fecha"] = ficha.fechaRet;
            rt["prov_nombre"] = ficha.prvNombre;
            rt["prov_cirif"] = ficha.prvCiRif;
            rt["prov_dir"] = ficha.dirFiscal;
            rt["concepto_cod"] = ficha.conceptoCod;
            rt["concepto_desc"] = ficha.conceptoDoc;

            ds.Tables["RetIslr"].Rows.Add(rt);

            DataRow rtDt = ds.Tables["RetIslr_Det"].NewRow();
            rtDt["fechaDoc"] = ficha.fechaEmiDoc;
            rtDt["numeroDoc"] = ficha.numDoc;
            rtDt["numeroControl"] = ficha.numControlDoc;
            rtDt["montoTotalDoc"] = ficha.total;
            rtDt["montoBaseRet"] = (ficha.exento+ficha.base1+ficha.base2+ficha.base3);
            rtDt["tasaRet"] = ficha.tasaRet;
            rtDt["sustraendo"] = ficha.sustraendoRet;
            rtDt["montoRet"] = ficha.totalRet;
            ds.Tables["RetIslr_Det"].Rows.Add(rtDt);

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMP_CIRIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMP_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("EMP_DIR", Sistema.Negocio.DireccionFiscal));
            Rds.Add(new ReportDataSource("RetIslr", ds.Tables["RetIslr"]));
            Rds.Add(new ReportDataSource("RetIslr_Det", ds.Tables["RetIslr_Det"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}