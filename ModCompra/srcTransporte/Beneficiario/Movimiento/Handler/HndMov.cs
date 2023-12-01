using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.Beneficiario.Movimiento.Handler
{
    public class HndMov: Vistas.IHndMov
    {
        private decimal _montoMov;
        private decimal _factorCambio;
        private DateTime _fechaServidor;
        private string _notas;
        private decimal _montoMonAct;
        private DateTime _fechaMov;
        private Utils.FiltrosCB.ICtrlConBusqueda _beneficiario;
        private Utils.FiltrosCB.ICtrlConBusqueda _concepto;


        public Utils.FiltrosCB.ICtrlConBusqueda Beneficiario { get { return _beneficiario; } }
        public Utils.FiltrosCB.ICtrlConBusqueda Concepto { get { return _concepto; } }
        public decimal  Get_FactorCambio { get { return _factorCambio; } }
        public decimal Get_MontoMov { get { return _montoMov; } }
        public DateTime Get_FechaServidor { get { return _fechaServidor; } }
        public string Get_Notas { get { return _notas; } }
        public decimal Get_MontoMonAct { get { return _montoMonAct; } }
        public object Get_BeneficiarioFicha { get { return _beneficiario.GetItem; } }
        public object Get_ConceptoFicha { get { return _concepto.GetItem; } }
        public DateTime Get_FechaMovimiento { get { return _fechaMov; } }


        public HndMov()
        {
            _montoMov = 0m;
            _factorCambio = 0m;
            _fechaServidor = DateTime.Now.Date;
            _fechaMov = DateTime.Now.Date;
            _notas = "";
            _beneficiario = new Utils.FiltrosCB.ConBusqueda.Beneficiario.Imp();
            _concepto = new Utils.FiltrosCB.ConBusqueda.Concepto.Imp();
        }
        public void Inicializa()
        {
            _montoMonAct = 0m;
            _montoMov = 0m;
            _factorCambio = 0m;
            _fechaMov = DateTime.Now.Date;
            _notas = "";
            _beneficiario.Inicializa();
            _concepto.Inicializa();
        }
        public void CargarData()
        {
            _beneficiario.ObtenerData();
            _concepto.ObtenerData();
        }
        public void setBeneficiarioById(string id)
        {
            _beneficiario.setFichaById(id);
        }
        public void setConceptoById(string id)
        {
            _concepto.setFichaById(id);
        }
        public void setFactorCambio(decimal monto)
        {
            _factorCambio = monto;
            calculaMonto();
        }
        public void setMontoMov(decimal monto)
        {
            _montoMov = monto;
            calculaMonto();
        }
        public void setFechaMov(DateTime fecha)
        {
            _fechaMov=fecha;
        }
        public void setFechaServidor(DateTime fecha)
        {
            _fechaServidor = fecha;
            _fechaMov = fecha;
        }
        public void setNotas(string desc)
        {
            _notas= desc;
        }
        public bool DataIsOk()
        {
            if (_beneficiario.GetItem == null || _beneficiario.GetId == "")
            {
                Helpers.Msg.Alerta("CAMPO [ BENEFICIARIO ] DEBE SER SELECCIONADO");
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


        private void calculaMonto()
        {
            _montoMonAct = _factorCambio * _montoMov;
        }
    }
}