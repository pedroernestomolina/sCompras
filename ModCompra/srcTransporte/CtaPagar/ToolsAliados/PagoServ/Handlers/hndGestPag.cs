﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Handlers
{
    public class hndGestPag: Vistas.IGestPag
    {
        private Vistas.Idata _hndData;
        private Anticipos.Agregar.Vistas.Icaja _hndCaja;
        private OOB.LibCompra.Transporte.Aliado.Entidad.Ficha _aliado;


        public decimal Get_TasaFactorCambio { get { return _hndData.Get_TasaFactorCambio; } }
        public DateTime Get_FechaPag { get { return _hndData.Get_FechaAnticipo; } }
        public string Get_AliadoInfo { get { return _hndData.Get_AliadoInfo; } }
        public decimal Get_AliadoAnticipos { get { return _hndData.Get_AliadoAnticipos; } }
        public string Get_Motivo { get { return _hndData.Get_Motivo; } }
        public decimal Get_MontoPag { get { return _hndData.Get_MontoAnticipoMonDiv; } }
        public DateTime Get_FechaServidor { get { return _hndData.Get_FechaServidor; } }
        public decimal Get_MontoPagMonAct { get { return _hndData.Get_MontoAnticipoMonAct; } }
        public decimal Get_MontoRetencion { get { return _hndData.Get_MontoRetencion; } }
        public decimal Get_MontoAbonoMonDiv { get { return _hndData.Get_MontoAbonoMonDiv; } }
        public decimal Get_MontoAbonoMonAct { get { return _hndData.Get_MontoAbonoMonAct; } }
        public decimal Get_TasaRetencion { get { return _hndData.Get_TasaRetencion; } }
        public bool Get_AplicaRet { get { return _hndData.Get_AplicaRet; } }
        public decimal Get_MontoSustraendo { get { return _hndData.Get_MontoSustraendo; } }
        public BindingSource Get_CajaSource { get { return _hndCaja.Get_CajaSource; } }
        public decimal CajaGet_MontoPendMonDiv { get { return _hndCaja.Get_MontoPendMonDiv; } }
        public decimal CajaGet_MontoPendMonAct { get { return _hndCaja.Get_MontoPendMonAct; } }
        public OOB.LibCompra.Transporte.Aliado.Entidad.Ficha Get_Aliado { get { return _hndData.Get_Aliado; } }
        public decimal Get_TotalRetMonAct { get { return _hndData.Get_TotalRetencionMonAct; } }
        public decimal Get_TotalRetMonDiv { get { return _hndData.Get_TotalRetencionMonDiv;  } }
        public IEnumerable<object> Get_CajasUsadas { get { return hndCaja.Get_CajasUsadas; } }
        public Vistas.Idata hndData { get { return _hndData; } }
        public Anticipos.Agregar.Vistas.Icaja hndCaja { get { return _hndCaja; } }


        public hndGestPag()
        {
            _aliado = null;
            _hndData = new ImpData();
            _hndCaja = new Anticipos.Agregar.Handler.caja();
        }
        public void Inicializa()
        {
            _aliado = null;
            _hndData.Inicializa();
            _hndCaja.Inicializa();
        }
        public void CargarData()
        {
            _hndData.CargarData();
            _hndCaja.CargarData();
            if (_aliado == null) 
            {
                throw new Exception("ALIADO NO DEFINIDO");
            }
            _hndCaja.setAplicaFactorCambioParaAnticipo(true);
            _hndCaja.setTasaAplicarFactorCambioParaAnticipo(_aliado.tasaPromAnticipo);
        }
        public void setFechaPag(DateTime fecha)
        {
            _hndData.setFechaAnticipo(fecha);
        }
        public void setTasaFactorCambio(decimal monto)
        {
            _hndData.setTasaFactorCambio(monto);
        }
        public void setFechaServidor(DateTime fecha)
        {
            _hndData.setFechaServidor(fecha);
        }
        public void setAliado(OOB.LibCompra.Transporte.Aliado.Entidad.Ficha ficha)
        {
            _aliado = ficha;
            _hndData.setAliado(ficha);
        }
        public void setMotivo(string desc)
        {
            _hndData.setMotivo(desc);
        }
        public void setMontoPagDiv(decimal monto)
        {
            _hndData.setMontoAnticipoMonDiv(monto);
        }
        public void setAplicaRet(bool aplica)
        {
            _hndData.setAplicaRet(aplica);
        }
        public void setTasaRet(decimal monto)
        {
            _hndData.setTasaRet(monto);
        }
        public void setMontoSustraendo(decimal monto)
        {
            _hndData.setMontoSustraendo(monto);
        }
        public void ActualizarSaldoCaja()
        {
            var _montoAnt = 0m;
            foreach (var rg in _hndCaja.Get_CajasUsadas)
            {
                var xrg = (Anticipos.Agregar.Handler.dataCaja)rg;
                if (xrg.Get_Ficha.id == -1 || xrg.Get_Ficha.id == -2) 
                {
                    _montoAnt += xrg.montoAbonar;
                }
            }
            if (_montoAnt > 0m) 
            {
                if (_montoAnt >= _hndData.Get_MontoAnticipoMonDiv)
                {
                    //28/12/2024, MIENTRAS SE ARREGLE, 
                    //ESTA TOMANDO TODOS LOS ANTICIPOS , 
                    //Y DEBERIA HABER UNA OPCION QUE ME PERMITA SUMAR SOLO LOS ANTICIPOS VIGENTES 
                    //_hndData.setTasaFactorCambio(_hndData.Get_Aliado.tasaPromAnticipo);
                    //_hndData.setTasaFactorCambio(_hndData.Get_TasaFactorCambio);
                }
                else 
                {
                    /*
                    var _xant = _hndData.Get_Aliado.tasaPromAnticipo * _montoAnt;
                    var _xnor = (_hndData.Get_MontoAnticipoMonDiv- _montoAnt)* _hndData.Get_TasaFactorCambio;
                    var _xprom = (_xnor + _xant) / _hndData.Get_MontoAnticipoMonDiv;
                    _hndData.setTasaFactorCambio(_xprom);
                     */
                }
            }
            _hndCaja.setFactorCambio(_hndData.Get_TasaFactorCambio);
            _hndCaja.setMontoPendDiv(_hndData.Get_MontoAbonoMonDiv);
            _hndCaja.ActualizarSaldosPend();
        }
        public void CajaEditarMontoAbonar()
        {
            _hndCaja.EditarMontoAbonar();
        }
        public bool IsOk()
        {
            var rt= true;
            if (!_hndData.IsOk())
            {
                return false;
            }
            if (!_hndCaja.IsOk())
            {
                return false;
            }
            return rt; 
        }
    }
}