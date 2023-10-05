using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Planillas.RetIva
{
    public class Imp : IRepPlanilla
    {
        private string _idDoc;


        public Imp()
        {
        }
        public void setIdDoc(string idDoc)
        {
            _idDoc = idDoc;
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Compras_Planilla_RetIva(_idDoc);
                imprimir(r01.Entidad);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        private void imprimir(OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Iva.Ficha ficha)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Planillas\RepPlanilla_RetIva.rdlc";
            var ds = new DS_PLANILLA();


            DataRow rt = ds.Tables["RetIva"].NewRow();
            rt["comprobante_nro"] = ficha.comprobanteRet;
            rt["fecha"] = ficha.fechaRet;
            rt["ano_rel"] = ficha.anoRelRet;
            rt["mes_rel"] = ficha.mesRelRet;
            rt["prov_nombre"] = ficha.prvNombre;
            rt["prov_cirif"] = ficha.prvCiRif;
            ds.Tables["RetIva"].Rows.Add(rt);

            var _factura = "";
            var _ntDebito = "";
            var _ntCredito = "";
            switch (ficha.tipoDoc)
            {
                case "01":
                    _factura = ficha.numDoc;
                    break;
                case "02":
                    _ntDebito = ficha.numDoc;
                    break;
                case "03":
                    _ntCredito = ficha.numDoc;
                    break;
            }
            DataRow rtDt = ds.Tables["RetIva_Det"].NewRow();
            rtDt["operacion"] = "1";
            rtDt["fecha"] = ficha.fechaEmiDoc;
            rtDt["facturaNro"] = _factura;
            rtDt["ntDebitoNro"] = _ntDebito;
            rtDt["ntCReditoNro"] = _ntCredito;
            rtDt["controlNro"] = ficha.numControlDoc;
            rtDt["tipoTrans"] = "";
            rtDt["nroFactAfecta"] = ficha.aplica;
            rtDt["montoConIva"] = ficha.total;
            rtDt["montoExento"] = ficha.exento;
            var ln = false;
            if (ficha.base1 > 0)
            {
                ln = true;
                rtDt["montoBase"] = ficha.base1;
                rtDt["tasaAlicuota"] = ficha.tasa1;
                rtDt["impuestoIva"] = ficha.impuesto1;
                rtDt["tasaRetencion"] = ficha.tasaRet;
                rtDt["montoRetencion"] = ficha.retencion1;
                ds.Tables["RetIva_Det"].Rows.Add(rtDt);
            }
            if (ficha.base2 > 0)
            {
                if (ln) 
                {
                    rtDt = ds.Tables["RetIva_Det"].NewRow();
                    ln = true;
                }
                rtDt["montoBase"] = ficha.base2;
                rtDt["tasaAlicuota"] = ficha.tasa2;
                rtDt["impuestoIva"] = ficha.impuesto2;
                rtDt["tasaRetencion"] = ficha.tasaRet;
                rtDt["montoRetencion"] = ficha.retencion2;
                ds.Tables["RetIva_Det"].Rows.Add(rtDt);
            }
            if (ficha.base3 > 0)
            {
                if (ln)
                {
                    rtDt = ds.Tables["RetIva_Det"].NewRow();
                    ln = true;
                }
                rtDt["montoBase"] = ficha.base3;
                rtDt["tasaAlicuota"] = ficha.tasa3;
                rtDt["impuestoIva"] = ficha.impuesto3;
                rtDt["tasaRetencion"] = ficha.tasaRet;
                rtDt["montoRetencion"] = ficha.retencion3;
                ds.Tables["RetIva_Det"].Rows.Add(rtDt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMP_CIRIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMP_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("EMP_DIR", Sistema.Negocio.DireccionFiscal));
            Rds.Add(new ReportDataSource("RetIva", ds.Tables["RetIva"]));
            Rds.Add(new ReportDataSource("RetIva_Det", ds.Tables["RetIva_Det"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}