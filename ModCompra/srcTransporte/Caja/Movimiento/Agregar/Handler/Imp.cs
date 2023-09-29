using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Movimiento.Agregar.Handler
{
    public class Imp: Vistas.IMov
    {
        private bool _abandonarIsOK;
        private bool _procesarIsOK;
        private Vistas.IHndEnt _hnd;


        public Vistas.IHndEnt Hnd { get { return _hnd; } }


        public Imp()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _hnd = new HndEnt();
        }
        public void Inicializa()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _hnd.Inicializa();
        }
        Vistas.Frm frm;
        public void Inicia()
        {
            if (cargarDataIsOk()) 
            {
                if (frm == null) 
                {
                    frm = new Vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public bool AbandonarIsOK { get { return _abandonarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonarIsOK = Helpers.Msg.Abandonar();
        }

        public bool ProcesarIsOK { get { return _procesarIsOK; } }
        public void Procesar()
        {
            _procesarIsOK = false;
            if (_hnd.DataIsOk()) 
            {
                if (Helpers.Msg.Procesar()) 
                {
                    guardarMov();
                }
            }
        }


        private bool cargarDataIsOk()
        {
            try
            {
                var r01 = Sistema.MyData.FechaServidor();
                var r02 = Sistema.MyData.Configuracion_TasaCambioActual();
                //
                _hnd.setFechaServidor(r01.Entidad);
                _hnd.setFactorCambio(r02.Entidad);
                _hnd.CargarData();
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void guardarMov()
        {
            try
            {
                var _tipoMov = _hnd.Get_TipoMovId=="1"?"I":"E";
                var _signoMov= _hnd.Get_TipoMovId=="1"?1:-1;
                var _cja = (Utils.Control.TipoCombo.Caja.data)_hnd.Get_Caja;
                var _montoMonAct=0m;
                var _montoMonDiv=0m;
                var _esDivisa = _cja.Ficha.esDivisa == "1";
                if (_cja.Ficha.esDivisa=="1")
                {
                    _montoMonDiv=_hnd.Get_MontoMov;
                    _montoMonAct=_hnd.Get_MontoMov*_hnd.Get_FactorCambio;
                }
                else
                {
                    _montoMonAct=_hnd.Get_MontoMov;
                    _montoMonDiv=_hnd.Get_MontoMov/_hnd.Get_FactorCambio;
                }
                var ficha = new OOB.LibCompra.Transporte.Caja.Movimiento.Crud.Agregar.Ficha()
                {
                    descMov = _hnd.Get_Notas,
                    factorCambio = _hnd.Get_FactorCambio,
                    idCaja = _cja.Ficha.id,
                    montoMov = _hnd.Get_MontoMov,
                    montoMovMonAct = _montoMonAct,
                    montoMovMonDiv = _montoMonDiv,
                    movFueDivisa = _esDivisa,
                    signoMov = _signoMov,
                    tipoMov = _tipoMov,
                };
                var r01 = Sistema.MyData.Transporte_Caja_Movimientos_Agregar(ficha);
                _procesarIsOK = true;
                Helpers.Msg.AgregarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
    }
}