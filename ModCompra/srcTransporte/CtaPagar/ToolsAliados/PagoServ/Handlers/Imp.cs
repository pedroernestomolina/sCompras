using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Handlers
{
    public class Imp: Vistas.IPagServ
    {
        private bool _abandonarIsOK;
        private bool _procesarIsOK;
        private int _idAliado;
        private Vistas.IEnt _data;


        public Vistas.IEnt data { get { return _data; } }


        public Imp()
        {
            _idAliado = -1;
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _data = new hndEnt();
        }
        public void Inicializa()
        {
            _idAliado = -1;
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _data.Inicializa();
        }
        Vistas.Frm frm;
        public void Inicia()
        {
            if (cargarData())
            {
                frm = new Vistas.Frm();
                frm.setControlador(this);
                frm.ShowDialog();
            } 
        }


        public void setServiciosAliado(int idAliado)
        {
            _idAliado = idAliado;
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
            if (_data.GestPago.IsOk()) 
            {
                if (Helpers.Msg.Procesar())
                {
                    guardarPago();
                }
            }
        }


        private bool cargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Aliado_GetFichaById(_idAliado);
                _data.setAliado(r01.Entidad);
                var r02 = Sistema.MyData.Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(_idAliado);
                _data.setServicios(r02.Lista.OrderBy(o=>o.idAliadoServ).ToList());
                var r03 = Sistema.MyData.Configuracion_TasaCambioActual();
                _data.setTasaCambio(r03.Entidad);
                if (r03.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(r03.Mensaje);
                }
                var r04 = Sistema.MyData.FechaServidor();
                _data.setFechaServidor(r04.Entidad);
                if (r04.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(r04.Mensaje);
                }
                //
                _data.CargarData();
                var _lst = new List<Anticipos.Agregar.Vistas.IdataCaja>();
                if ((r01.Entidad.montoAnticiposDiv - r01.Entidad.AnticipoRetDiv) > 0m) 
                {
                    var _caja = new OOB.LibCompra.Transporte.Caja.Lista.Ficha()
                    {
                        descripcion = "ANTICIPOS ($)",
                        esDivisa = "1",
                        estatusAnulado = "",
                        id = -1,
                        montoPorAnulaciones = 0m,
                        montoPorEgresos = 0m,
                        montoPorIngresos = r01.Entidad.AnticiposDiv,
                        saldoInicial = 0m,
                    };
                    _lst.Add(new Anticipos.Agregar.Handler.dataCaja(_caja));
                }
                if (r01.Entidad.AnticipoRetDiv > 0m)
                {
                    var _caja = new OOB.LibCompra.Transporte.Caja.Lista.Ficha()
                    {
                        descripcion = "RET/ANTICIPOS ($)",
                        esDivisa = "1",
                        estatusAnulado = "",
                        id = -2,
                        montoPorAnulaciones = 0m,
                        montoPorEgresos = 0m,
                        montoPorIngresos = r01.Entidad.AnticipoRetDiv,
                        saldoInicial = 0m,
                    };
                    _lst.Add(new Anticipos.Agregar.Handler.dataCaja(_caja));
                }
                var r05 = Sistema.MyData.Transporte_Caja_GetLista();
                foreach (var rg in r05.Lista.OrderBy(o => o.descripcion).ToList())
                {
                    var nr = new Anticipos.Agregar.Handler.dataCaja(rg);
                    _lst.Add(nr);
                }
                _data.GestPago.hndCaja.setDataCargar(_lst);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void guardarPago()
        {
            try
            {
                var ficha = new OOB.LibCompra.Transporte.Aliado.PagoServ.AgregarPago.Ficha();
                var mov = new OOB.LibCompra.Transporte.Aliado.PagoServ.AgregarPago.Movimiento()
                {
                    aplicaRet = _data.GestPago.Get_AplicaRet,
                    ciRifAliado = _data.GestPago.Get_Aliado.ciRif,
                    cntServ = _data.Servicios.Get_CntItemSeleccionados,
                    codigoAliado = _data.GestPago.Get_Aliado.codigo,
                    fechaEmision = _data.GestPago.Get_FechaPag,
                    idAliado = _data.GestPago.Get_Aliado.id,
                    montoMonAct = _data.GestPago.Get_MontoPagMonAct,
                    montoMonDiv = _data.GestPago.Get_MontoPag,
                    montoRetMonAct = _data.GestPago.Get_TotalRetMonAct,
                    montoRetMonDiv = _data.GestPago.Get_TotalRetMonDiv,
                    motivo = _data.GestPago.Get_Motivo,
                    nombreAliado = _data.GestPago.Get_Aliado.nombreRazonSocial,
                    retencion = (_data.GestPago.Get_MontoRetencion - _data.GestPago.Get_MontoSustraendo),
                    sustraendo = _data.GestPago.Get_MontoSustraendo,
                    tasaFactorCambio = _data.GestPago.Get_TasaFactorCambio,
                    tasaRet = _data.GestPago.Get_TasaRetencion,
                    totalPagMonAct = _data.GestPago.Get_MontoAbonoMonAct,
                    totalPagMonDiv = _data.GestPago.Get_MontoAbonoMonDiv
                };
                var det = new List<OOB.LibCompra.Transporte.Aliado.PagoServ.AgregarPago.Detalle>();
                foreach (var rg in _data.Servicios.Get_ListaItemsSeleccionados) 
                {
                    var it = (dataServ)rg;
                    var nr = new OOB.LibCompra.Transporte.Aliado.PagoServ.AgregarPago.Detalle()
                    {
                        idAliadoDoc = it.Ficha.idAliadoDoc,
                        idAliadoDocServ = it.Ficha.idAliadoServ,
                        motnoDocSerMonDiv = it.pendiente,
                    };
                    det.Add(nr);
                }
                var caj = new List<OOB.LibCompra.Transporte.Aliado.PagoServ.AgregarPago.Caja>();
                foreach (var rg in _data.GestPago.Get_CajasUsadas) 
                {
                    var it= (Anticipos.Agregar.Handler.dataCaja)rg;
                    var nr = new OOB.LibCompra.Transporte.Aliado.PagoServ.AgregarPago.Caja()
                    {
                        descCaja = it.descripcion,
                        esDivisa = it.esDivisa,
                        idCaja = it.Get_Ficha.id,
                        montoUsado = it.montoAbonar,
                        montoUsadoMonAct = 
                            !it.esDivisa ? 
                            it.montoAbonar :
                            it.montoAbonar * _data.GestPago.Get_TasaFactorCambio,
                        montoUsadoMonDiv = 
                            it.esDivisa ? 
                            it.montoAbonar : 
                            (_data.GestPago.Get_TasaFactorCambio > 0m ? it.montoAbonar / _data.GestPago.Get_TasaFactorCambio : 0m),
                    };
                    if (it.Get_Ficha.id > 0)  //CAJAS REALES
                    {
                        caj.Add(nr);
                    }
                    else //ANTICIPO, RETENCIONES POR ANTICIPO
                    {
                        if (it.Get_Ficha.id == -1) //ANTICPO
                        {
                            ficha.MontoPorAnticipoUsado = it.montoAbonar;
                        }
                        if (it.Get_Ficha.id == -2) //RETENCIONES POR ANTICIPO
                        {
                            ficha.MontoPorRetAnticipoUsado = it.montoAbonar;
                        }
                    }
                }
                //
                mov.detalles=det;
                mov.cajas = caj;
                ficha.movimiento=mov;
                var r01 = Sistema.MyData.Transporte_Aliado_PagoServ_AgregarPago(ficha);
                _procesarIsOK = true;
                Helpers.Msg.AgregarOk();
                visuliazarPago(r01.Id);
            }
            catch (Exception e)
            {
               Helpers.Msg.Error(e.Message);
            }
        }

        private void visuliazarPago(int idMov)
        {
            srcTransporte.Reportes.IRepPlanilla _rep = new srcTransporte.Reportes.Planillas.ReciboPagoAliado.Imp();
            _rep.setIdDoc(idMov);
            _rep.Generar();
        }
    }
}