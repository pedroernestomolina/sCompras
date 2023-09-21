using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Anticipos.Agregar.Handler
{
    public class Imp: Vistas.IAnticipo
    {
        private bool _procesarIsOK;
        private bool _abandonarIsOK;
        private int _idAliado;
        private Vistas.Idata _data;
        private Vistas.Icaja _caja;


        public Vistas.Idata data { get { return _data; } }
        public Vistas.Icaja caja { get { return _caja; } }


        public Imp()
        {
            _idAliado = -1;
            _procesarIsOK = false;
            _abandonarIsOK = false;
            _data = new data();
            _caja = new caja();
        }


        public void Inicializa()
        {
            _idAliado = -1;
            _procesarIsOK = false;
            _abandonarIsOK = false;
            _data.Inicializa();
            _caja.Inicializa();
        }
        Vistas.Frm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null)
                {
                    frm = new Vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public bool ProcesarIsOK { get { return _procesarIsOK; } }
        public void Procesar()
        {
            _procesarIsOK = false;
            if (_data.VerificarData()) 
            {
                var _monto= Math.Round(_data.Get_MontoAbonoMonAct, 2, MidpointRounding.AwayFromZero);
                if (caja.MontoCajaPago == _monto)
                {
                    if (Helpers.Msg.Procesar())
                    {
                        GuardarFicha();
                    }
                }
                else 
                {
                    Helpers.Msg.Alerta("MONTO PAGO CAJA INCORRECTOS");
                }
            }
        }

        public bool AbandonarIsOK { get { return _abandonarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonarIsOK = Helpers.Msg.Abandonar();
        }


        private bool cargarData()
        {
            try
            {
                var r00 = Sistema.MyData.Transporte_Aliado_GetFichaById(_idAliado);
                _data.setAliado(r00.Entidad);
                //
                var r01 = Sistema.MyData.FechaServidor();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                _data.setFechaServidor(r01.Entidad);
                _data.setFechaAnticipo(r01.Entidad);
                //
                var r02 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
                _data.setTasaFactorCambio(r02.Entidad);
                //
                var _lst = new List<Vistas.IdataCaja>();
                var r03 = Sistema.MyData.Transporte_Caja_GetLista();
                foreach (var rg in r03.Lista.OrderBy(o => o.descripcion).ToList())
                {
                    var nr = new dataCaja(rg);
                    _lst.Add(nr);
                }
                _caja.setDataCargar(_lst);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        public void setAliadoCargar(int id)
        {
            _idAliado = id;
        }
        public void ActualizarSaldoCaja()
        {
            _caja.setFactorCambio(_data.Get_TasaFactorCambio);
            _caja.setMontoPendDiv(_data.Get_MontoAbonoMonDiv);
            _caja.ActualizarSaldosPend();
        }


        private void GuardarFicha()
        {
            try
            {
                var fichaOOB = new OOB.LibCompra.Transporte.Aliado.Anticipo.Agregar.Ficha();
                fichaOOB.movimiento = new OOB.LibCompra.Transporte.Aliado.Anticipo.Agregar.Movimiento()
                {
                    aplicaRet = _data.Get_AplicaRet ? "1" : "0",
                    ciRifAliado = _data.Get_Aliado.ciRif,
                    fechaEmision = _data.Get_FechaAnticipo,
                    idAliado = _data.Get_Aliado.id,
                    montoNetoMonAct = _data.Get_MontoAnticipoMonAct,
                    montoNetoMonDiv = _data.Get_MontoAnticipoMonDiv,
                    montoPagoMonAct = _data.Get_MontoAbonoMonAct,
                    montoPagoMonDiv = _data.Get_MontoAbonoMonDiv,
                    montoRet = _data.Get_MontoRetencion,
                    motivo = _data.Get_Motivo,
                    nombreAliado = _data.Get_Aliado.nombreRazonSocial,
                    sustraendoRet = _data.Get_MontoSustraendo,
                    tasaFactor = _data.Get_TasaFactorCambio,
                    tasaRet = _data.Get_TasaRetencion,
                };
                fichaOOB.aliadoAbonar = new OOB.LibCompra.Transporte.Aliado.Anticipo.Agregar.AliadoAbonar()
                {
                    idAliado = _data.Get_Aliado.id,
                    montoAbonar = _data.Get_MontoAnticipoMonDiv,
                    montoRetAbonar = _data.Get_TotalRetencionMonDiv,
                };
                var _lstCaja = new List<OOB.LibCompra.Transporte.Aliado.Anticipo.Agregar.AliadoCaja>();
                foreach (var rg in _caja.Get_Lista.Where(w=>w.montoAbonar>0).ToList()) 
                {
                    var cj = (dataCaja)rg;
                    var nr = new OOB.LibCompra.Transporte.Aliado.Anticipo.Agregar.AliadoCaja()
                    {
                        idAliado = _data.Get_Aliado.id,
                        idCaja = cj.Get_Ficha.id,
                        monto = cj.montoAbonar,
                        movimientoCaja = new OOB.LibCompra.Transporte.Aliado.Anticipo.Agregar.CajaMovimiento()
                        {
                            descMov = _data.Get_Motivo,
                            factorCambio = _data.Get_TasaFactorCambio,
                            fechaMov = _data.Get_FechaAnticipo,
                            montoMovMonAct = cj.esDivisa ? cj.montoAbonar * _data.Get_TasaFactorCambio : cj.montoAbonar,
                            montoMovMonDiv = cj.esDivisa ? cj.montoAbonar : cj.montoAbonar / _data.Get_TasaFactorCambio,
                            tipoMov = "E",
                            movFueDivisa = cj.esDivisa,
                        }
                    };
                    _lstCaja.Add(nr);
                }
                fichaOOB.alidoCaja = _lstCaja;
                var r01 = Sistema.MyData.Transporte_Aliado_Anticipo_Agregar(fichaOOB);
                _procesarIsOK = true;
                Helpers.Msg.AgregarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return;
            }
        }
    }
}