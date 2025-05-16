using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelAbonarPago.handlers
{
    public class hndPanelPorMonto: interfaces.IPanelPorMonto
    {
        private decimal _montoPendiente;
        private decimal _montoAbonar;
        private string _detallesAbono;
        private Utils.Control.Boton.Abandonar.IAbandonar _abandonarFicha;
        private Utils.Control.Boton.Procesar.IProcesar _procesarFicha;
        //
        public string GetTituloPanel { get { return "ANTICIPO/Abonar"; } }
        public bool MontoAbonarIsOk { get { return false; } }
        public decimal GetMontoPendiente { get { return _montoPendiente; } }
        public decimal GetMontoAbonar { get { return _montoAbonar; } }
        public string GetDetalle { get { return _detallesAbono; } }
        //
        public hndPanelPorMonto()
        {
            _montoPendiente = 0m;
            _montoAbonar = 0m;
            _detallesAbono = "";
            _abandonarFicha = new Utils.Control.Boton.Abandonar.Imp();
            _procesarFicha = new Utils.Control.Boton.Procesar.Imp();
        }
        public void Inicializa()
        {
            _montoPendiente = 0m;
            _montoAbonar = 0m;
            _detallesAbono = "";
            _abandonarFicha.Inicializa();
            _procesarFicha.Inicializa();
        }
        public void setDetalle(string notas)
        {
            _detallesAbono = notas;
        }
        public void setMontoDisponible(decimal monto)
        {
            _montoPendiente = monto;
        }
        public void setMontoAbonar(decimal monto)
        {
            _montoAbonar = monto;
        }
        public void setMontoCargar(decimal monto)
        {
            _montoPendiente = monto ;
            setMontoAbonar(monto );
            setDetalle("");
        }
        //
        vistas.Frm frm;
        public void Inicia()
        {
            if (frm == null) 
            {
                frm = new vistas.Frm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }

        //
        public bool ProcesarIsOK { get { return _procesarFicha.OpcionIsOK; } }
        public bool AbandonarIsOK { get { return _abandonarFicha.OpcionIsOK; } }
        public void ProcesarFicha()
        {
            if (_montoAbonar > _montoPendiente)
            {
                Helpers.Msg.Alerta("Monto Abonar Incorrecto, Verifique Por Favor");
                return;
            }
            _procesarFicha.Opcion();
            if (_procesarFicha.OpcionIsOK) 
            {
            }
        }
        public void AbandonarFicha()
        {
            _abandonarFicha.Opcion();
        }
    }
}