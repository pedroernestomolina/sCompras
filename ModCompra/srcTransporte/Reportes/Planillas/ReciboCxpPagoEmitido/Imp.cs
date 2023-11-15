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
            //foreach (var sv in ficha.serv)
            //{
            //    DataRow rtDt = ds.Tables["PagoAliado_Serv"].NewRow();
            //    rtDt["cliente"] = sv.cliCiRif + Environment.NewLine + sv.cliNombre;
            //    rtDt["servicio"] = sv.codServ + Environment.NewLine + sv.descServ + Environment.NewLine + sv.detServ;
            //    rtDt["documento"] = sv.docNumero + Environment.NewLine + sv.docFecha.ToShortDateString() + Environment.NewLine + sv.docNombre;
            //    rtDt["monto"] = sv.montoPago;
            //    ds.Tables["PagoAliado_Serv"].Rows.Add(rtDt);
            //}
            //if (ficha.anticipo > 0m)
            //{
            //    DataRow rtDt = ds.Tables["PagoAliado_Caja"].NewRow();
            //    rtDt["desc"] = "ANTICIPO";
            //    rtDt["monto"] = ficha.anticipo;
            //    rtDt["esDivisa"] = "$";
            //    ds.Tables["PagoAliado_Caja"].Rows.Add(rtDt);
            //}
            foreach (var sv in ficha.caja)
            {
                DataRow rtDt = ds.Tables["CxpPagoDoc_Caja"].NewRow();
                rtDt["desc"] = "( "+sv.cjCod.Trim()+" ) " + sv.cjDesc;
                rtDt["monto"] = sv.monto;
                rtDt["esDivisa"] = sv.esDivisa.Trim().ToUpper() == "1" ? "$" : "";
                ds.Tables["CxpPagoDoc_Caja"].Rows.Add(rtDt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMP_CIRIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMP_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMP_DIR", Sistema.Negocio.DireccionFiscal));
            Rds.Add(new ReportDataSource("CxpPagoDoc", ds.Tables["CxpPagoDoc"]));
            //Rds.Add(new ReportDataSource("PagoAliado_Serv", ds.Tables["PagoAliado_Serv"]));
            Rds.Add(new ReportDataSource("CxpPagoDoc_Caja", ds.Tables["CxpPagoDoc_Caja"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}