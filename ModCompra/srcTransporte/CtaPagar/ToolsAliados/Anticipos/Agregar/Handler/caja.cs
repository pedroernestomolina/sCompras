﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Anticipos.Agregar.Handler
{
    public class caja: Vistas.Icaja
    {
        private decimal _factorCambio;
        private decimal _montoPendDiv;
        private decimal _montoPendMonAct;
        private decimal _montoPendMonDiv;
        private List<Vistas.IdataCaja> _lst;
        private BindingList<Vistas.IdataCaja> _bl;
        private BindingSource _bs;


        public BindingSource Get_CajaSource { get { return _bs; } }
        public IEnumerable <Vistas.IdataCaja> Get_Lista { get { return _bl.ToList(); } }
        public IEnumerable<Vistas.IdataCaja> Get_CajasUsadas { get { return _bl.Where(w => w.montoAbonar > 0).ToList(); } }


        public caja()
        {
            _factorCambio = 0m;
            _montoPendDiv = 0m;
            _montoPendMonAct = 0m;
            _montoPendMonDiv = 0m;
            _lst = new List<Vistas.IdataCaja>();
            _bl = new BindingList<Vistas.IdataCaja>(_lst);
            _bs = new BindingSource();
            _bs.DataSource = _bl;
            _bs.CurrencyManager.Refresh();
            _activarFactorCambioAnticipo = false;
            _tasaFactorCambioAnticipo = 0m;
        }
        public void Inicializa()
        {
            _montoPendDiv = 0m;
            _montoPendMonAct = 0m;
            _montoPendMonDiv = 0m;
            _activarFactorCambioAnticipo = false;
            _tasaFactorCambioAnticipo = 0m;
            _lst.Clear();
            _bl.Clear();
            _bs.CurrencyManager.Refresh();
        }
        public void CargarData()
        {
            try
            {
                var _lst = new List<Vistas.IdataCaja>();
                var r01 = Sistema.MyData.Transporte_Caja_GetLista();
                foreach (var rg in r01.Lista.OrderBy(o => o.descripcion).ToList())
                {
                    var nr = new dataCaja(rg);
                    _lst.Add(nr);
                }
                setDataCargar(_lst);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        public void setDataCargar(IEnumerable<Vistas.IdataCaja> lst)
        {
            _lst.Clear();
            _bl.Clear();
            foreach (var rg in lst)
            {
                _lst.Add((dataCaja)rg);
            }
            _bs.CurrencyManager.Refresh();
        }
        public void EditarMontoAbonar()
        {
            if (_bs.Current != null) 
            {
                var item = (dataCaja)_bs.Current;
                var _monto= pedirMontoAbonar(item.montoAbonar);
                if (_monto  >= 0m)
                {
                    item.setMontoAbonar(_monto);
                }
                _bs.CurrencyManager.Refresh();
            }
        }


        private Utils.Componente.Monto.Vistas.IMonto _montoAbonar;
        private decimal pedirMontoAbonar(decimal monto)
        {
            if (_montoAbonar == null)
            {
                _montoAbonar = new Utils.Componente.Monto.Handler.Imp();
            }
            _montoAbonar.Inicializa();
            _montoAbonar.setMonto(monto);
            _montoAbonar.Inicia();
            if (_montoAbonar.ProcesarIsOK) 
            {
                return _montoAbonar.Get_Monto;
            }
            return 0m;
        }
        public void setFactorCambio(decimal factor)
        {
            _factorCambio = factor;
        }
        public void setMontoPendDiv(decimal montoDiv)
        {
            _montoPendDiv = montoDiv;
        }

        public decimal Get_MontoPendMonAct { get { return _montoPendMonAct; } }
        public decimal Get_MontoPendMonDiv { get { return _montoPendMonDiv; } }


        private decimal _restPend;
        private bool _activarFactorCambioAnticipo = false;
        private decimal _tasaFactorCambioAnticipo = 0m;
        public void ActualizarSaldosPend()
        {
            _restPend = _montoPendDiv;
            //
            var _xmontoConAnticiposMonDiv = 0m;
            var _xmontoConAnticiposMonAct = 0m; 
            if (_activarFactorCambioAnticipo)
            {
                foreach (var mov in _lst)
                {
                    var pg = (dataCaja)mov;
                    if (pg.Get_Ficha.id < 0)
                    {
                        _xmontoConAnticiposMonDiv += pg.montoAbonar;
                    }
                }
                _xmontoConAnticiposMonAct = _xmontoConAnticiposMonDiv * _tasaFactorCambioAnticipo;
                _restPend = _montoPendDiv - _xmontoConAnticiposMonDiv;
            }
            //
            var _pgMonDiv = _lst.Where(w => w.esDivisa).Sum(s => s.montoAbonar);
            _pgMonDiv -= _xmontoConAnticiposMonDiv;
            _restPend -= _pgMonDiv;
            var _pgMonAct = _lst.Where(w => !w.esDivisa).Sum(s => s.montoAbonar);
            if (_factorCambio > 0m)
            {
                _restPend -= Math.Round(_pgMonAct / _factorCambio, 2, MidpointRounding.AwayFromZero);
            }
            _montoPendMonDiv = _restPend;
            _montoPendMonAct = Math.Round(_restPend * _factorCambio, 2, MidpointRounding.AwayFromZero);

            //var _pgTotal = (_pgMonDiv * _factorCambio) + _pgMonAct + _xmontoConAnticiposMonAct;
            //_pgTotal = Math.Round(_pgTotal, 2, MidpointRounding.AwayFromZero);
            //_restPend = (_montoPendDiv * _factorCambio) - _pgTotal;
            //_restPend = Math.Round(_restPend,2, MidpointRounding.AwayFromZero);
            //_montoPendMonAct = _restPend; 
            //_montoPendMonDiv = 0m;
            //if (_factorCambio > 0m) 
            //{
            //    _montoPendMonDiv = Math.Round(_restPend / _factorCambio, 2, MidpointRounding.AwayFromZero);
            //}
        }


        public decimal MontoCajaPago { get { return montoCajaPago(); } }
        private decimal montoCajaPago()
        {
            var _pgMonDiv = _lst.Where(w => w.esDivisa).Sum(s => s.montoAbonar);
            var _pgMonAct = _lst.Where(w => !w.esDivisa).Sum(s => s.montoAbonar);
            var _pgTotal = (_pgMonDiv * _factorCambio) + _pgMonAct;
            return _pgTotal;
        }
        public bool IsOk()
        {
            if (Math.Abs(_montoPendMonAct)>0m)
            {
                Helpers.Msg.Alerta("HAY MONTOS PENDIENTES");
                return false;
            }
            if (Math.Abs(_montoPendMonDiv) > 0m)
            {
                Helpers.Msg.Alerta("HAY MONTOS PENDIENTES");
                return false;
            }
            return true;
        }
        //
        public decimal GetTasaAplicarFactorCambioParaAnticipo { get { return _tasaFactorCambioAnticipo; } }
        public void setAplicaFactorCambioParaAnticipo(bool aplica)
        {
            _activarFactorCambioAnticipo = aplica;
        }
        public void setTasaAplicarFactorCambioParaAnticipo(decimal factor)
        {
            _tasaFactorCambioAnticipo = factor;
        }
    }
}