using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.PagoDoc.Handler
{
    public class HndData: Vista.IHndData
    {
        private decimal _tasaCambioActual;
        private DateTime _fechaServidor;
        private OOB.LibCompra.Transporte.CxpDoc.DocEntidad.Ficha _docPagar;
        private string _provInfo;
        private DateTime _ifechaPag;
        private decimal _imontoPag;
        private decimal _ifactorCambio;
        private string _imotivo;
        private decimal _imontoMonAct;
        private string _infoDocNro;
        private DateTime _infoDocFechaEmi;
        private string _infoDocControl;
        private string _infoDocCondicion;
        private string _infoDocConcepto;
        private string _infoDocMotivo;


        public DateTime Get_FechaServidor { get { return _fechaServidor; } }
        public string Get_ProvInfo { get { return _provInfo; } }
        public DateTime Get_FechaPag { get { return _ifechaPag; } }
        public decimal Get_MontoPag { get { return _imontoPag; } }
        public string Get_Motivo { get { return _imotivo; } }
        public decimal Get_TasaFactorCambio { get { return _ifactorCambio; } }
        public decimal Get_MontoPagMonAct { get { return _imontoMonAct; } }
        public string Get_InfoDoc_Nro { get { return _infoDocNro; } }
        public DateTime Get_InfoDoc_FechaEmision { get { return _infoDocFechaEmi; } }
        public string Get_InfoDoc_Control { get { return _infoDocControl; } }
        public string Get_InfoDoc_Condicion { get { return _infoDocCondicion; } }
        public string Get_InfoDoc_Concepto { get { return _infoDocConcepto; } }
        public string Get_InfoDoc_Motivo { get { return _infoDocMotivo; } }


        public HndData()
        {
            _tasaCambioActual = 0m;
            _fechaServidor = DateTime.Now.Date;
            _docPagar = null;
            _provInfo = "";
            _ifactorCambio = 0m;
            _ifechaPag = DateTime.Now.Date;
            _imontoPag = 0m;
            _imotivo = "";
            _imontoMonAct = 0m;
            _infoDocCondicion = "";
            _infoDocControl = "";
            _infoDocFechaEmi = DateTime.Now.Date;
            _infoDocNro = "";
            _infoDocConcepto = "";
            _infoDocMotivo = "";
        }
        public void Inicializa()
        {
            _provInfo = "";
            _ifactorCambio = 0m;
            _ifechaPag = DateTime.Now.Date;
            _imontoPag = 0m;
            _imotivo = "";
            _imontoMonAct = 0m;
            _infoDocCondicion = "";
            _infoDocControl = "";
            _infoDocFechaEmi = DateTime.Now.Date;
            _infoDocNro = "";
            _infoDocConcepto = "";
            _infoDocMotivo = "";
        }
        public void setTasaCambioActual(object tasaActual)
        {
            _tasaCambioActual = (decimal)tasaActual;
            _ifactorCambio = _tasaCambioActual;
        }
        public void setDocPagar(object ficha)
        {
            _docPagar = (OOB.LibCompra.Transporte.CxpDoc.DocEntidad.Ficha)ficha;
            _imontoPag = _docPagar.restaDiv;
            calculoMontoMonAct();
            _provInfo = _docPagar.ciRif.Trim() + Environment.NewLine + _docPagar.nombreRazonSocial.Trim();
            _infoDocNro = _docPagar.docNro;
            _infoDocControl = _docPagar.docNroControl;
            _infoDocFechaEmi = _docPagar.fechaEmision;
            _infoDocCondicion = _docPagar.condicion + " " + _docPagar.diasCredito.ToString("n0") + " Dias, Vence: " + _docPagar.fechaVence.ToShortDateString();
            _infoDocConcepto = "(" + _docPagar.conceptoCod.Trim() + "), " + _docPagar.conceptoDesc;
            _infoDocMotivo = _docPagar.descripcionDoc;
        }
        public void setFechaServidor(object fecha)
        {
            _fechaServidor = (DateTime)fecha;
            _ifechaPag = _fechaServidor;
        }
        public void setMotivo(string desc)
        {
            _imotivo = desc;
        }
        public void setFechaPag(DateTime fecha)
        {
            _ifechaPag = fecha;
        }
        public void setMontoPag(decimal monto)
        {
            _imontoPag = monto;
            calculoMontoMonAct();
        }
        public void setTasaFactorCambio(decimal monto)
        {
            _ifactorCambio =monto;
            calculoMontoMonAct();
        }


        private void calculoMontoMonAct()
        {
            _imontoMonAct = _ifactorCambio * _imontoPag;
        }
    }
}