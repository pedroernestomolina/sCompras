using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Planillas.ReciboBeneficiario
{
    public class Imp : IRepPlanilla
    {
        private int _idDoc;


        public Imp()
        {
        }
        public void setIdDoc(object idDoc)
        {
            _idDoc = (int)idDoc;
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Beneficiario_Planilla(_idDoc);
                imprimir(r01.Entidad);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private void imprimir(OOB.LibCompra.Transporte.Reportes.Beneficiario.Planilla.Ficha ficha)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Planillas\RepPlanilla_Beneficiario.rdlc";
            var ds = new DS_PLANILLA();

            DataRow rt = ds.Tables["Beneficiario"].NewRow();
            rt["reciboNro"] = ficha.numRecibo;
            rt["fecha"] = ficha.fechaEmision;
            rt["tasaFactor"] = ficha.tasaFactor;
            rt["montoPago"] = ficha.montoSolicitado;
            rt["beneficiario"] = ficha.ciRifBene + Environment.NewLine + ficha.nombreBene;
            rt["notas"] = ficha.motivo;
            rt["concepto"] = "(" + ficha.codConcepto.Trim() + ") " + ficha.descConcepto;
            ds.Tables["Beneficiario"].Rows.Add(rt);
            foreach (var sv in ficha.caja)
            {
                DataRow rtDt = ds.Tables["PagoAliado_Caja"].NewRow();
                rtDt["desc"] = sv.cjDesc;
                rtDt["monto"] = sv.monto;
                rtDt["esDivisa"] = sv.esDivisa.Trim().ToUpper() == "1" ? "$" : "";
                ds.Tables["PagoAliado_Caja"].Rows.Add(rtDt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMP_CIRIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMP_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMP_DIR", Sistema.Negocio.DireccionFiscal));
            Rds.Add(new ReportDataSource("Beneficiario", ds.Tables["Beneficiario"]));
            Rds.Add(new ReportDataSource("PagoAliado_Caja", ds.Tables["PagoAliado_Caja"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}
