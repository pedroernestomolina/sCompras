using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Documentos.LibroSeniat
{
    public class Imp: srcTransporte.Reportes.IRepFiltro
    {
        private OOB.LibCompra.Transporte.Reportes.Compras.LibroSeniat.Filtro _filtro;


        public Imp()
        {
        }
        public void setFiltros(object filtros)
        {
            var _ft= (Reportes.RepFiltro.Vista.IFiltros)filtros;
            _filtro = new OOB.LibCompra.Transporte.Reportes.Compras.LibroSeniat.Filtro()
            {
            };
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Compras_LibroSeniat_GetLista(_filtro);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Compras.LibroSeniat.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Documentos\RepDoc_LibroSeniat.rdlc";
            var ds = new DS_REPDOC();

            var _op = 0;
            foreach (var rg in list)
            {
                var _prvTipo = "PN";
                if (rg.prvCiRif.Trim().ToUpper().Contains("J"))
                {
                    _prvTipo = "PJ";
                }
                var _nrFactura = "";
                var _ntCredito = "";
                var _ntDebito= "";
                switch (rg.codTipoDoc.Trim().ToUpper())
                {
                    case "01":
                        _nrFactura= rg.numDoc;
                        break;
                    case "02":
                        _ntDebito= rg.numDoc;
                        break;
                    case "03":
                        _ntCredito = rg.numDoc;
                        break;
                }
                _op++;
                DataRow rt = ds.Tables["Libro"].NewRow();
                rt["operacionNro"] = _op;
                rt["fechaEmision"] = rg.fechaEmision;
                rt["prvRif"] = rg.prvCiRif;
                rt["prvNombre"] = rg.prvRazonSocial;
                rt["prvTipo"] = _prvTipo;
                rt["docNro"] = _nrFactura;
                rt["controlNro"] = rg.numControl;
                rt["maqFiscal"] = rg.maquinaFiscal;
                rt["ntCredito"] = _ntCredito;
                rt["ntDebito"] = _ntDebito;
                rt["aplica"] = rg.numDocAplica;
                rt["tipoReg"] = "REG";
                rt["total"] = rg.totalDoc;
                rt["exento"] = rg.montoExento;
                rt["base1"] = rg.montoBase1;
                rt["iva1"] = rg.montoIva1;
                rt["base2"] = rg.montoBase2;
                rt["iva2"] = rg.montoIva2;
                rt["base3"] = rg.montoBase3;
                rt["iva3"] = rg.montoIva3;
                rt["comprobanteRet"] = rg.comprobanteRetencion;

                //if (rg.estatusDoc.Trim().ToUpper() == "1")
                //{
                //    rt["neto"] = 0m;
                //    rt["totalDoc"] = 0m;
                //    rt["montoIva"] = 0m;
                //    rt["montoExento"] = 0m;
                //    rt["montoIgtf"] = 0m;
                //    rt["montoBase"] = 0m;
                //}
                ds.Tables["Libro"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("Libro", ds.Tables["Libro"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}