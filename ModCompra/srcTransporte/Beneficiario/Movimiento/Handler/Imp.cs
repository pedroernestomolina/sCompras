using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Beneficiario.Movimiento.Handler
{
    public class Imp: Vistas.IHnd
    {
        private bool _abandonarIsOK;
        private bool _procesarIsOK;
        private Vistas.IHndMov _mov;
        private Utils.Componente.CajaMonto.Vista.IHnd _caj;


        public Vistas.IHndMov Mov { get { return _mov; } }
        public Utils.Componente.CajaMonto.Vista.IHnd caja { get { return _caj; } }


        public Imp()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _mov = new HndMov();
            _caj = new Utils.Componente.CajaMonto.Handler.Hnd();
        }
        public void Inicializa()
        {
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _mov.Inicializa();
            _caj.Inicializa();
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
            if (_mov.DataIsOk()) 
            {
                if (caja.IsOk())
                {
                    if (Helpers.Msg.Procesar())
                    {
                        guardarMov();
                    }
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
                _mov.setFechaServidor(r01.Entidad);
                _mov.setFactorCambio(r02.Entidad);
                _mov.CargarData();
                //
                _caj.CargarData();
                //
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
                var _itemBeneficiario = (Utils.FiltrosCB.ConBusqueda.Beneficiario.data)_mov.Beneficiario.GetItem;
                var _itemConcepto= (Utils.FiltrosCB.ConBusqueda.Concepto.data )_mov.Concepto.GetItem;
                var _beneficiario = (OOB.LibCompra.Transporte.Beneficiario.Lista.Ficha)_itemBeneficiario.Ficha;
                var _concepto = (OOB.LibCompra.Transporte.Documento.Concepto.Entidad.Ficha)_itemConcepto.Ficha;

                var _notMovCaja = "Beneficiario: " + _beneficiario.cirif.Trim();
                _notMovCaja+=Environment.NewLine+ _beneficiario.nombreRazonSocial.Trim();
                _notMovCaja+=Environment.NewLine+ "Por Concepto De: "+_concepto.descripcion.Trim();
                var _lstCaja = new List<OOB.LibCompra.Transporte.Beneficiario.Mov.Agregar.MovCaja>();
                foreach (var rg in _caj.Get_Lista.Where(w => w.montoAbonar > 0).ToList())
                {
                    var cj = (Utils.Componente.CajaMonto.Handler.data)rg;
                    var nr = new OOB.LibCompra.Transporte.Beneficiario.Mov.Agregar.MovCaja()
                    {
                        idCaja = cj.Get_Ficha.id,
                        codCaja = cj.Get_Ficha.codigo,
                        descCaja = cj.Get_Ficha.descripcion,
                        esDivisa = cj.esDivisa ? "1" : "0",
                        monto = cj.montoAbonar,
                        movimientoCaja = new OOB.LibCompra.Transporte.Beneficiario.Mov.Agregar.CajaMovimiento()
                        {
                            descMov = _notMovCaja,
                            factorCambio = _mov.Get_FactorCambio,
                            montoMovMonAct = cj.esDivisa ? cj.montoAbonar * _mov.Get_FactorCambio : cj.montoAbonar,
                            montoMovMonDiv = cj.esDivisa ? cj.montoAbonar : cj.montoAbonar / _mov.Get_FactorCambio,
                            movFueDivisa = cj.esDivisa,
                        }
                    };
                    _lstCaja.Add(nr);
                }

                var _movimiento = new OOB.LibCompra.Transporte.Beneficiario.Mov.Agregar.Movimiento()
                {
                    ciRifBeneficiario = _beneficiario.cirif,
                    codConcepto = _concepto.codigo,
                    descConcepto = _concepto.descripcion,
                    factorTasa = _mov.Get_FactorCambio,
                    fechaMov = _mov.Get_FechaMovimiento,
                    idBeneficiario = _beneficiario.id,
                    idConcepto = _concepto.id,
                    montoMonDiv = _mov.Get_MontoMov,
                    nombreBeneficiario = _beneficiario.nombreRazonSocial,
                    notasMov = _mov.Get_Notas,
                };
                var ficha = new OOB.LibCompra.Transporte.Beneficiario.Mov.Agregar.Ficha()
                {
                    mov = _movimiento,
                    movCaja = _lstCaja,
                };
                var r01 = Sistema.MyData.Transporte_Beneficiario_Mov_Agregar(ficha);
                _procesarIsOK = true;
                visualizarItem(r01.Id);
                Helpers.Msg.AgregarOk();
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }

        public void ActualizarSaldoCaja()
        {
            _caj.setFactorCambio(_mov.Get_FactorCambio );
            _caj.setMontoPendDiv(_mov.Get_MontoMov);
            _caj.ActualizarSaldosPend();
        }

        private void visualizarItem(int it)
        {
            srcTransporte.Reportes.IRepPlanilla _rep = new srcTransporte.Reportes.Planillas.ReciboBeneficiario.Imp();
            _rep.setIdDoc(it);
            _rep.Generar();
        }
    }
}