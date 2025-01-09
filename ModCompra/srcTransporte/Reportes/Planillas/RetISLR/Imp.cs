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
        private OOB.LibCompra.Transporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha _fichaCorrector;
        //
        public Imp()
        {
        }
        public void setIdDoc(object idDoc)
        {
            Type tipo = idDoc.GetType();
            if (tipo == typeof(string))
            {
                _idDoc = (string)idDoc;
            }
            else if (tipo == typeof(OOB.LibCompra.Transporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha))
            {
                _fichaCorrector = (OOB.LibCompra.Transporte.DocumentoRet.Crud.Corrector.ObtenerData.Ficha)idDoc;
            }
        }
        public void Generar()
        {
            try
            {
                OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha _ficha=null;
                if (_idDoc!=null) 
                {
                    var r01 = Sistema.MyData.Transporte_Reportes_Compras_Planilla_RetIslr(_idDoc);
                    _ficha = r01.Entidad;
                }
                else if (_fichaCorrector != null) 
                {
                    _ficha = new OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Islr.Ficha(_fichaCorrector);
                }
                if (_ficha != null) 
                {
                    imprimir(_ficha);
                }
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
            //
            DataRow rt = ds.Tables["RetIslr"].NewRow();
            rt["comprobante_nro"] = ficha.comprobanteRet;
            rt["fecha"] = ficha.fechaRet;
            rt["prov_nombre"] = ficha.prvNombre;
            rt["prov_cirif"] = ficha.prvCiRif;
            rt["prov_dir"] = ficha.dirFiscal;
            rt["concepto_cod"] = ficha.codXmlIslr;
            rt["concepto_desc"] = ficha.descXmlIslr;
            ds.Tables["RetIslr"].Rows.Add(rt);
            //
            DataRow rtDt = ds.Tables["RetIslr_Det"].NewRow();
            rtDt["fechaDoc"] = ficha.fechaEmiDoc;
            rtDt["numeroDoc"] = ficha.numDoc;
            rtDt["numeroControl"] = ficha.numControlDoc;
            rtDt["montoTotalDoc"] = ficha.total;
            rtDt["montoBaseRet"] = (ficha.exento + ficha.base1 + ficha.base2 + ficha.base3);
            if (ficha.subtBase > 0m) 
            {
                rtDt["montoBaseRet"] = ficha.subtBase;
            }
            rtDt["tasaRet"] = ficha.tasaRet;
            rtDt["sustraendo"] = ficha.sustraendoRet;
            rtDt["montoRet"] = ficha.totalRet;
            ds.Tables["RetIslr_Det"].Rows.Add(rtDt);
            //
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMP_CIRIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMP_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("EMP_DIR", Sistema.Negocio.DireccionFiscal));
            Rds.Add(new ReportDataSource("RetIslr", ds.Tables["RetIslr"]));
            Rds.Add(new ReportDataSource("RetIslr_Det", ds.Tables["RetIslr_Det"]));
            //
            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}