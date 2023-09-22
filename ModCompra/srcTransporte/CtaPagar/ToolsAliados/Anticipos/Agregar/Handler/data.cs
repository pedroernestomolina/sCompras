using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Anticipos.Agregar.Handler
{
    public class data: Vistas.Idata
    {
        private decimal _montoAnticipoMonDiv;
        private decimal _tasaFactorCambio;
        private string _motivo;
        private DateTime _fechaAnticipo;
        private decimal _montoAnticipoMonAct;
        private OOB.LibCompra.Transporte.Aliado.Entidad.Ficha _aliado;
        private decimal _tasaRet;
        private decimal _montoSustraendo;
        private decimal _montoRetencion;
        private bool _aplicaRet;
        private decimal _montoAbonoMonAct;
        private decimal _montoAbonoMonDiv;
        private DateTime _fechaServidor;


        public decimal Get_MontoAnticipoMonAct { get { return _montoAnticipoMonAct; } }
        public decimal Get_MontoAnticipoMonDiv { get { return _montoAnticipoMonDiv; } }
        public decimal Get_TasaFactorCambio { get { return _tasaFactorCambio; } }
        public string Get_Motivo { get { return _motivo; } }
        public DateTime Get_FechaAnticipo { get { return _fechaAnticipo; } }
        public decimal Get_TasaRetencion { get { return _tasaRet; } }
        public decimal Get_MontoSustraendo { get { return _montoSustraendo; } }
        public decimal Get_MontoRetencion { get { return _montoRetencion; } }
        public bool Get_AplicaRet { get { return _aplicaRet; } }
        public decimal Get_MontoAbonoMonAct { get { return _montoAbonoMonAct; } }
        public decimal Get_MontoAbonoMonDiv { get { return _montoAbonoMonDiv; } }
        public DateTime Get_FechaServidor { get { return _fechaServidor; } }
        public OOB.LibCompra.Transporte.Aliado.Entidad.Ficha Get_Aliado { get { return _aliado; } }
        public decimal Get_TotalRetencionMonAct { get { return _montoRetencion; } }
        public decimal Get_TotalRetencionMonDiv 
        {
            get 
            {
                var rt = 0m;
                if (_tasaFactorCambio > 0m)
                {
                    rt = _montoRetencion / _tasaFactorCambio;
                }
                return rt; 
            } 
        }
        public decimal Get_AliadoAnticipos { get { return _aliado != null ? _aliado.AnticiposDiv : 0m; } }
        public string Get_AliadoInfo { get { return _aliado != null ? _aliado.Info : ""; } }


        public data()
        {
            _fechaServidor = DateTime.Now.Date;
            inicializar();
        }
        public void Inicializa()
        {
            inicializar();
        }
        public void CargarData()
        {
        }
        public void setFechaAnticipo(DateTime fecha)
        {
            _fechaAnticipo = fecha;
        }
        public void setTasaFactorCambio(decimal monto)
        {
            _tasaFactorCambio = monto;
            calculaMonto();
        }
        public void setMontoAnticipoMonDiv(decimal monto)
        {
            _montoAnticipoMonDiv = monto;
            calculaMonto();
        }
        public void setMotivo(string desc)
        {
            _motivo = desc;
        }
        public void setAliado(OOB.LibCompra.Transporte.Aliado.Entidad.Ficha ficha)
        {
            _aliado = ficha;
        }
        public void setTasaRet(decimal monto)
        {
            _tasaRet = monto;
            calculoRet();
        }
        public void setMontoSustraendo(decimal monto)
        {
            _montoSustraendo = monto;
            calculoRet();
        }
        public void setAplicaRet(bool aplica)
        {
            _aplicaRet = !_aplicaRet;
            if (!_aplicaRet) 
            {
                _montoSustraendo = 0m;
                _tasaRet = 0m;
                _montoRetencion = 0m;
            }
            calculoRet();
        }
        public void setFechaServidor(DateTime fecha)
        {
            _fechaServidor = fecha;
        }
        public bool VerificarData()
        {
            if (_aliado == null) 
            {
                Helpers.Msg.Error("ALIADO NO DEFINIDO");
                return false;
            }
            if (_montoAnticipoMonDiv <= 0m)
            {
                Helpers.Msg.Error("Monto AboNo No Puede ser Cero(0)");
                return false;
            }
            if (_tasaFactorCambio <= 0m)
            {
                Helpers.Msg.Error("Tasa / Factor Cambio No Puede ser Cero(0)");
                return false;
            }
            if (_motivo.Trim()=="")
            {
                Helpers.Msg.Error("Motivo No Puede estar Vacio");
                return false;
            }
            if (_aplicaRet)
            {
                if (_montoRetencion <= 0m)
                {
                    Helpers.Msg.Error("Monto Retención No Puede ser Cero (0)");
                    return false;
                }
            }
            return true;
        }


        private void inicializar()
        {
            _montoAnticipoMonAct = 0m;
            _montoAnticipoMonDiv = 0m;
            _tasaFactorCambio = 0m;
            _motivo = "";
            _fechaAnticipo = DateTime.Now.Date;
            _montoSustraendo = 0m;
            _tasaRet = 0m;
            _montoRetencion = 0m;
            _aplicaRet = false;
            _montoAbonoMonAct = 0m;
            _montoAbonoMonDiv = 0m;
            _aliado = null;
        }
        private void calculaMonto()
        {
            _montoAnticipoMonAct = _montoAnticipoMonDiv * _tasaFactorCambio;
            calculoRet();
        }
        private void calculoRet()
        {
            _montoAbonoMonDiv = 0m;
            _montoRetencion = (_montoAnticipoMonAct * _tasaRet / 100) + _montoSustraendo;
            _montoAbonoMonAct = _montoAnticipoMonAct - _montoRetencion;
            if (_tasaFactorCambio > 0m) 
            {
                _montoAbonoMonDiv = _montoAbonoMonAct / _tasaFactorCambio;
            }
        }
        public bool IsOk()
        {
            if (_aliado == null) 
            {
                Helpers.Msg.Alerta("ALIADO NO IDENTIFICADO");
                return false;
            }
            if (_montoAnticipoMonDiv <= 0m) 
            {
                Helpers.Msg.Alerta("MONTO A PAGAR NO PUEDE SER CERO (0)");
                return false;
            }
            if (_motivo.Trim()=="")
            {
                Helpers.Msg.Alerta("POR FAVOR LLENAR EL CAMPO [ MOTIVO ]");
                return false;
            }
            if (_tasaFactorCambio == 0m)
            {
                Helpers.Msg.Alerta("TASA / FACTOR CAMBIO NO PUEDE SER CERO [ 0 ]");
                return false;
            }
            if (_aplicaRet && _tasaRet == 0m) 
            {
                Helpers.Msg.Alerta("SI APLICA RETENCION, ESTA NO PUEDE SER CERO [ 0 ]");
                return false;
            }
            return true;
        }
    }
}