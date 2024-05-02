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
        private OOB.LibCompra.Empresa.Fiscal.Ficha _tasaFiscal;
        private string pd;
        private string ph;
        //
        public Imp()
        {
            _tasaFiscal = null;
            pd = "";
            ph = "";

        }
        public void setFiltros(object filtros)
        {
            var ft= (Reportes.RepFiltro.Vista.IFiltros)filtros;
            _filtro = new OOB.LibCompra.Transporte.Reportes.Compras.LibroSeniat.Filtro()
            {
                Desde = ft.Desde,
                Hasta = ft.Hasta,
            };
            pd = "Desde " + ft.Desde.Value.ToShortDateString();
            ph = "Hasta " + ft.Hasta.Value.ToShortDateString();
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Compras_LibroSeniat_GetLista(_filtro);
                var r02 = Sistema.MyData.Empresa_GetTasas();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
                _tasaFiscal = r02.Entidad;
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        //
        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Compras.LibroSeniat.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Documentos\RepDoc_LibroSeniat.rdlc";
            var ds = new DS_REPDOC();
            //
            var _op = 0;
            var lst = list.OrderBy(o => o.fechaEmision).ToList();
            foreach (var rg in lst)
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
                var _fechaRetencion = rg.fechaRet.ToShortDateString();
                if (rg.fechaRet== new DateTime(2000,1,1))
                {
                    _fechaRetencion = "";
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
                rt["fechaRet"] = _fechaRetencion;
                rt["porctRet"] = rg.tasaRet;
                rt["montoRet"] = rg.montoRet;
                ds.Tables["Libro"].Rows.Add(rt);
            }
            DataRow rt2 = ds.Tables["LibroEnc"].NewRow();
            rt2["periodo_desde"] = pd;
            rt2["periodo_hasta"] = ph;
            rt2["tipo_contribuyente"] = "ESPECIAL";
            rt2["titulo"] = "Libro de Compras "+pd+", "+ph;
            rt2["nombreRazonSocial"] = Sistema.Negocio.Nombre.Trim();
            rt2["ciRif"] = Sistema.Negocio.CiRif.Trim();
            rt2["dirFiscal"] = Sistema.Negocio.DireccionFiscal.Trim();
            rt2["descTasa1"] = "Tasa General  " + _tasaFiscal.Tasa1.ToString("n2");
            rt2["descTasa2"] = "Tasa Reducida " + _tasaFiscal.Tasa2.ToString("n2");
            rt2["descTasa3"] = "Tasa Gen+Adic " + _tasaFiscal.Tasa3.ToString("n2");
            ds.Tables["LibroEnc"].Rows.Add(rt2);
            //
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("Libro", ds.Tables["Libro"]));
            Rds.Add(new ReportDataSource("LibroEnc", ds.Tables["LibroEnc"]));
            //
            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}