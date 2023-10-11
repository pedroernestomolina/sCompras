using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Planillas.ReciboAnticipoAliado
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
                var r01 = Sistema.MyData.Transporte_Reportes_Aliado_Anticipos_Planilla(_idDoc);
                imprimir(r01.Entidad);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private void imprimir(OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.Planilla.Ficha ficha)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Planillas\RepPlanilla_AnticipoAliado.rdlc";
            var ds = new DS_PLANILLA();

            DataRow rt = ds.Tables["PagoAliado"].NewRow();
            rt["reciboNro"] = ficha.numRecibo;
            rt["fecha"] = ficha.fechaEmision;
            rt["tasaFactor"] = ficha.tasaFactor;
            rt["montoPago"] = ficha.montoSolicitado;
            rt["aliadoCiRif"] = ficha.ciRifAliado + Environment.NewLine + ficha.nombreAliado;
            rt["aliadoNombre"] = ficha.nombreAliado;
            rt["conceptoMotivo"] = ficha.motivo;
            rt["retTasa"] = ficha.tasaRet;
            rt["retSustraendo"] = ficha.sustraendo;
            rt["retencion"] = ficha.montoRet;
            rt["retMonto"] = ficha.montoRet/ficha.tasaFactor;
            rt["montoPagado"] = ficha.montoPagado;
            rt["isAnulado"] = "";
            ds.Tables["PagoAliado"].Rows.Add(rt);
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
            Rds.Add(new ReportDataSource("PagoAliado", ds.Tables["PagoAliado"]));
            Rds.Add(new ReportDataSource("PagoAliado_Caja", ds.Tables["PagoAliado_Caja"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}
