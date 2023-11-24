using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Planillas.ReciboPagoAliado
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
                var r01 = Sistema.MyData.Transporte_Reportes_Aliado_PagoServ_Planilla(_idDoc);
                imprimir(r01.Entidad);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private void imprimir(OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.Planilla.Ficha ficha)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Planillas\RepPlanilla_PagoAliado.rdlc";
            var ds = new DS_PLANILLA();

            DataRow rt = ds.Tables["PagoAliado"].NewRow();
            rt["reciboNro"] = ficha.numRecibo;
            rt["fecha"] = ficha.fechaEmision;
            rt["tasaFactor"] = ficha.tasaFactor;
            rt["montoPago"] = ficha.montoAPagar;
            rt["aliadoCiRif"] = ficha.ciRifAliado + Environment.NewLine + ficha.nombreAliado;
            rt["aliadoNombre"] = ficha.nombreAliado;
            rt["conceptoMotivo"] = ficha.motivo;
            rt["retTasa"] = ficha.tasaRet;
            rt["retSustraendo"] = ficha.sustraendo;
            rt["retencion"] = ficha.retencion;
            rt["retMonto"] = ficha.montoRetMonDiv;
            rt["montoPagado"] = ficha.totalPago;
            rt["isAnulado"] = "";
            ds.Tables["PagoAliado"].Rows.Add(rt);
            foreach (var sv in ficha.serv)
            {
                DataRow rtDt = ds.Tables["PagoAliado_Serv"].NewRow();
                rtDt["cliente"] = sv.cliCiRif+Environment.NewLine+sv.cliNombre;
                rtDt["servicio"] = sv.codServ+Environment.NewLine+sv.descServ+Environment.NewLine+sv.detServ;
                rtDt["documento"] = sv.docNumero+Environment.NewLine+sv.docFecha.ToShortDateString()+Environment.NewLine+sv.docNombre;
                rtDt["monto"] = sv.montoPago;
                ds.Tables["PagoAliado_Serv"].Rows.Add(rtDt);
            }
            if (ficha.anticipo > 0m) 
            {
                DataRow rtDt = ds.Tables["PagoAliado_Caja"].NewRow();
                rtDt["desc"] = "ANTICIPO";
                rtDt["monto"] = ficha.anticipo;
                rtDt["montoDiv"] = ficha.anticipo;
                rtDt["esDivisa"] = "$";
                ds.Tables["PagoAliado_Caja"].Rows.Add(rtDt);
            }
            var _montoDiv = 0m;
            foreach (var sv in ficha.caja)
            {
                _montoDiv = sv.monto;
                if (sv.esDivisa.Trim().ToUpper() != "1") 
                {
                    _montoDiv /= ficha.tasaFactor;
                }
                DataRow rtDt = ds.Tables["PagoAliado_Caja"].NewRow();
                rtDt["desc"] = sv.cjDesc;
                rtDt["monto"] = sv.monto;
                rtDt["montoDiv"] = _montoDiv;
                rtDt["esDivisa"] = sv.esDivisa.Trim().ToUpper() == "1" ? "$" : "";
                ds.Tables["PagoAliado_Caja"].Rows.Add(rtDt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMP_CIRIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMP_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMP_DIR", Sistema.Negocio.DireccionFiscal));
            Rds.Add(new ReportDataSource("PagoAliado", ds.Tables["PagoAliado"]));
            Rds.Add(new ReportDataSource("PagoAliado_Serv", ds.Tables["PagoAliado_Serv"]));
            Rds.Add(new ReportDataSource("PagoAliado_Caja", ds.Tables["PagoAliado_Caja"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}