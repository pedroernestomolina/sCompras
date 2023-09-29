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


        public HndEnt()
        {
            _montoMov = 0m;
            _factorCambio = 0m;
            _fechaServidor = DateTime.Now.Date;
            _notas = "";
            _caja = new Utils.Control.TipoCombo.Caja.Imp();
            _tipoMov= new Utils.Control.TipoCombo.TipoMovCaja.Imp();
        }
        public void Inicializa()
        {
            _montoMov = 0m;
            _factorCambio = 0m;
            _fechaServidor = DateTime.Now.Date;
            _notas = "";
            _caja.Inicializa();
            _tipoMov.Inicializa();
        }
        public void CargarData()
        {
            _caja.ObtenerData();
            _tipoMov.ObtenerData();
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