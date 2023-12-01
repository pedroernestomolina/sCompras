using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Planillas.ReciboCxpPagoEmitido
{
    public class Imp : IRepPlanilla
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
                var r01 = Sistema.MyData.Transporte_Reportes_Cxp_PagoEmitido_Planilla(_idDoc);
                imprimir(r01.Entidad);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private void imprimir(OOB.LibCompra.Transporte.Reportes.Cxp.PagosEmitidos.Planilla.Ficha ficha)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Planillas\RepPlanilla_CxpPagoEmitido.rdlc";
            var ds = new DS_PLANILLA();

            DataRow rt = ds.Tables["CxpPagoDoc"].NewRow();
            rt["reciboNro"] = ficha.reciboNro;
            rt["fecha"] = ficha.fechaMov;
            rt["tasaCambio"] = ficha.tasaCambio;
            rt["montoPago"] = ficha.importeDiv;
            rt["notas"] = ficha.notasMov ;
            rt["proveedor"] = ficha.ciRifProv + Environment.NewLine + ficha.nombreProv;
            rt["isAnulado"] = ficha.estatusMov.Trim().ToUpper() == "1" ? "ANULADO" : "";
            ds.Tables["CxpPagoDoc"].Rows.Add(rt);
            //
            var _montoDiv = 0m;
            foreach (var sv in ficha.caja)
            {
                _montoDiv = sv.monto;
                if (sv.esDivisa.Trim().ToUpper() != "1")
                {
                    _montoDiv/=ficha.tasaCambio;
                }
                DataRow rtCja = ds.Tables["CxpPagoDoc_Caja"].NewRow();
                rtCja["desc"] = "( " + sv.cjCod.Trim() + " ) " + sv.cjDesc;
                rtCja["monto"] = sv.monto;
                rtCja["esDivisa"] = sv.esDivisa.Trim().ToUpper() == "1" ? "$" : "";
                rtCja["montoDiv"] = _montoDiv;
                ds.Tables["CxpPagoDoc_Caja"].Rows.Add(rtCja);
            }
            foreach (var sv in ficha.doc)
            {
                DataRow rtDoc = ds.Tables["CxpPagoDoc_Doc"].NewRow();
                rtDoc["documento"] = sv.numeroDoc;
                rtDoc["fecha"] = sv.fechaEmisionDoc;
                rtDoc["siglas"] = sv.siglasDoc;
                rtDoc["montoDiv"] = sv.montoDiv;
                ds.Tables["CxpPagoDoc_Doc"].Rows.Add(rtDoc);
            }
            //
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMP_CIRIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMP_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMP_DIR", Sistema.Negocio.DireccionFiscal));
            Rds.Add(new ReportDataSource("CxpPagoDoc", ds.Tables["CxpPagoDoc"]));
            Rds.Add(new ReportDataSource("CxpPagoDoc_Doc", ds.Tables["CxpPagoDoc_Doc"]));
            Rds.Add(new ReportDataSource("CxpPagoDoc_Caja", ds.Tables["CxpPagoDoc_Caja"]));
            //
            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}