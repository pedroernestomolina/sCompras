using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelAbonarPago.handlers
{
    public class hndPanel: interfaces.IPanel
    {
        private decimal _montoPendiente;
        private decimal _montoAbonar;
        private string _detallesAbono;
        private __.Modelos.GestionPagoDocumentos.IItemDesplegar _item;
        private Utils.Control.Boton.Abandonar.IAbandonar _abandonarFicha;
        private Utils.Control.Boton.Procesar.IProcesar _procesarFicha;
        //
        public bool MontoAbonarIsOk { get { return false; } }
        public decimal GetMontoPendiente { get { return _montoPendiente; } }
        public decimal GetMontoAbonar { get { return _montoAbonar; } }
        public string GetDetalle { get { return _detallesAbono; } }
        //
        public hndPanel()
        {
            _item = null;
            _montoPendiente = 0m;
            _montoAbonar = 0m;
            _detallesAbono = "";
            _abandonarFicha = new Utils.Control.Boton.Abandonar.Imp();
            _procesarFicha = new Utils.Control.Boton.Procesar.Imp();
        }
        public void Inicializa()
        {
            _item = null;
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
        public void setMontoAbonar(decimal monto)
        {
            _montoAbonar = monto;
        }
        public void setItemCargar(__.Modelos.GestionPagoDocumentos.IItemDesplegar item)
        {
            _item = item;
            _montoPendiente = item.Resta;
            setMontoAbonar(item.MontoAAbonar);
            setDetalle(item.NotasDelAbono);
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
                _item.MontoAAbonar = _montoAbonar;
                _item.NotasDelAbono = _detallesAbono;
            }
        }
        public void AbandonarFicha()
        {
            _abandonarFicha.Opcion();
        }
    }
}