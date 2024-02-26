using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Caja.Movimiento.Agregar.Handler
{
    public class HndEnt: Vistas.IHndEnt
    {
        private Utils.Control.TipoCombo.ICtrl _caja;
        private Utils.Control.TipoCombo.ICtrl _tipoMov;
        private decimal _montoMov;
        private decimal _factorCambio;
        private DateTime _fechaServidor;
        private string _notas;
        private Utils.FiltrosCB.ICtrlConBusqueda _concepto;
        private DateTime _fechaEmisionMov;
        //
        public Utils.FiltrosCB.ICtrlConBusqueda Concepto { get { return _concepto; } }
        public BindingSource Get_Caja_Source { get { return _caja.GetSource; } }
        public BindingSource Get_TipoMov_Source { get { return _tipoMov.GetSource; } }
        public string Get_CajaID { get { return _caja.GetId; } }
        public string Get_TipoMovId { get { return _tipoMov.GetId; } }
        public decimal  Get_FactorCambio { get { return _factorCambio; } }
        public decimal Get_MontoMov { get { return _montoMov; } }
        public DateTime Get_FechaServidor { get { return _fechaServidor; } }
        public string Get_Notas { get { return _notas; } }
        public string Get_CajaInfo { get { return infoCaja(); } }
        public object Get_Caja { get { return _caja.GetItem; } }
        public DateTime Get_FechaEmision { get { return _fechaEmisionMov; } }
        //
        public HndEnt()
        {
            _montoMov = 0m;
            _factorCambio = 0m;
            _fechaServidor = DateTime.Now.Date;
            _notas = "";
            _fechaEmisionMov = _fechaServidor;
            _caja = new Utils.Control.TipoCombo.Caja.Imp();
            _tipoMov= new Utils.Control.TipoCombo.TipoMovCaja.Imp();
            _concepto = new Utils.FiltrosCB.ConBusqueda.Concepto.Imp();
        }
        public void Inicializa()
        {
            _montoMov = 0m;
            _factorCambio = 0m;
            _notas = "";
            _fechaEmisionMov = _fechaServidor;
            _caja.Inicializa();
            _tipoMov.Inicializa();
            _concepto.Inicializa();
        }
        public void CargarData()
        {
            _caja.ObtenerData();
            _tipoMov.ObtenerData();
            _concepto.ObtenerData();
        }
        public void setCajaById(string id)
        {
            _caja.setFichaById(id);
        }
        public void setTipoMovById(string id)
        {
            _tipoMov.setFichaById(id);
        }
        public void setFactorCambio(decimal monto)
        {
            _factorCambio = monto;
        }
        public void setMontoMov(decimal monto)
        {
            _montoMov = monto;
        }
        public void setFechaServidor(DateTime fecha)
        {
            _fechaServidor = fecha;
        }
        public void setNotas(string desc)
        {
            _notas= desc;
        }
        public void setFechaEmisionMov(DateTime fecha)
        {
            _fechaEmisionMov = fecha;
        }
        private string infoCaja()
        {
            var rt = "";
            if (_caja !=null && _caja.GetItem!=null)
            {
                try
                {
                    var _it = (Utils.Control.TipoCombo.Caja.data)_caja.GetItem;
                    var r01 = Sistema.MyData.Transporte_Caja_GetById(_it.Ficha.id);
                    rt = r01.Entidad.descripcion + Environment.NewLine;
                    rt += "Saldo Actual: " + Environment.NewLine+ r01.Entidad.SaldoActual.ToString("n2")+ Environment.NewLine;
                    rt += (r01.Entidad.IsDivisa ? "En Divisa($)" : "");
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
            return rt;
        }
        public bool DataIsOk()
        {
            if (_caja.GetItem == null || _caja.GetId=="") 
            {
                Helpers.Msg.Alerta("CAMPO [ CAJA ] DEBE SER SELECCIONADO");
                return false;
            }
            if (_tipoMov.GetItem == null || _tipoMov.GetId == "")
            {
                Helpers.Msg.Alerta("CAMPO [ TIPO MOVIMIENTO ] DEBE SER SELECCIONADO");
                return false;
            }
            if (_concepto.GetItem == null || _concepto.GetId == "")
            {
                Helpers.Msg.Alerta("CAMPO [ CONCEPTO MOVIMIENTO ] DEBE SER SELECCIONADO");
                return false;
            }
            if (_montoMov == 0m) 
            {
                Helpers.Msg.Alerta("CAMPO [ MONTO MOVIMIENTO ] INCORRECTO");
                return false;
            }
            if (_factorCambio == 0m)
            {
                Helpers.Msg.Alerta("CAMPO [ TASA/FACTOR CAMBIO ] INCORRECTO");
                return false;
            }
            if (_notas.Trim()=="")
            {
                Helpers.Msg.Alerta("CAMPO [ NOTAS ] NO PUEDE ESTAR VACIO");
                return false;
            }
            return true;
        }
    }
}