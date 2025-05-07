using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago
{
    public abstract class basePanelAgregarEditarItem: Interfaces.IPanelAgregarEditarItem
    {
        private bool _procesarIsOk;
        private Utils.Control.Boton.Abandonar.IAbandonar _abandonarFicha;
        private Utils.Control.Boton.Procesar.IProcesar _procesarFicha;
        private Interfaces.IdataAgregarEditarMetPag _data;
        private Utils.FiltrosCB.ICtrlSinBusqueda _medPago;
        //
        private usesCase.CargarMediosPago.IUC _ucCargarMediosPago;
        private usesCase.CargarFactorCambio.Iuc _ucCargarFactorCambio;
        //
        public bool AbandonarIsOK { get { return _abandonarFicha.OpcionIsOK; } }
        public bool ProcesarIsOK { get { return _procesarIsOk; } }
        //
        abstract public string GetTituloFicha { get; }
        //
        public object GetSourceMedPago { get { return _medPago.GetSource; } }
        public string GetIdMedPago { get { return _medPago.GetId; } }
        public decimal GetMonto { get { return _data.GetMonto; } }
        public decimal GetFactor { get { return _data.GetFactorCambio; } }
        public bool GetAplicaFactor { get { return _data.GetAplicaFactor; } }
        public decimal GetMontoAplica { get { return _data.GetMontoAplica; } }
        public string GetBanco { get { return _data.GetBanco; } }
        public string GetNroCta { get { return _data.GetNroCta; } }
        public string GetCheqRefTrans { get { return _data.GetCheqRefTranf; } }
        public DateTime GetFechaOp { get { return _data.GetFechaOp; } }
        public string GetDetalleOp { get { return _data.GetDetalleOp; } }
        public string GetReferencia { get { return _data.GetReferencia; } }
        public string GetLote { get { return _data.GetLote; } }
        public object GetMedioPago { get { return _data.GetMetCobro; } }
        public decimal GetImporteMonact { get { return _data.ImporteMonAct; } }
        public decimal GetImporteMonDiv { get { return _data.ImporteMonDiv; } }
        //
        public basePanelAgregarEditarItem()
        {
            _procesarIsOk = false;
            _abandonarFicha = new Utils.Control.Boton.Abandonar.Imp();
            _procesarFicha = new Utils.Control.Boton.Procesar.Imp();
            _medPago = new Utils.FiltrosCB.SinBusqueda.General.Imp();
            _data = new dataAgregarEditarMetPag();
            //
            _ucCargarMediosPago = new usesCase.CargarMediosPago.UC();
            _ucCargarFactorCambio = new usesCase.CargarFactorCambio.uc();
        }
        public virtual void Inicializa()
        {
            _procesarIsOk = false;
            _procesarFicha.Inicializa();
            _abandonarFicha.Inicializa();
            _medPago.Inicializa();
            _data.Inicializa();
        }
        abstract public void Inicia();
        //
        public void setMedPago(string id)
        {
            _medPago.setFichaById(id);
            _data.setMetCobro(_medPago.GetItem);
        }
        public void setMonto(decimal monto)
        {
            _data.setMonto(monto);
        }
        public void setFactor(decimal factor)
        {
            _data.setFactor(factor);
        }
        public void setBanco(string banco)
        {
            _data.setBanco(banco);
        }
        public void setCtaNro(string cta)
        {
            _data.setCtaNro(cta);
        }
        public void setChequeRefTranf(string cheqRefTranf)
        {
            _data.setChequeRefTranf(cheqRefTranf);
        }
        public void setFechaOperacion(DateTime fecha)
        {
            _data.setFechaOperacion(fecha);
        }
        public void setDetalleOperacion(string detalleOp)
        {
            _data.setDetalleOperacion(detalleOp);
        }
        public void setAplicaFactor(bool p)
        {
            _data.setAplicaFactor(p);
        }
        public void setLote(string lote)
        {
            _data.setLote(lote);
        }
        public void setReferencia(string referenc)
        {
            _data.setReferencia(referenc);
        }
        public void AbandonarFicha()
        {
            _abandonarFicha.Opcion();
        }
        public void Procesar()
        {
            _procesarIsOk = false;
            if (_data.IsValido())
            {
                _procesarFicha.Opcion();
                _procesarIsOk = _procesarFicha.OpcionIsOK;
            }
        }
        //
        public virtual bool CargarDta()
        {
            try
            {
                var lst = _ucCargarMediosPago.Execute();
                _medPago.CargarData(lst);
                //
                var _factorCambio = _ucCargarFactorCambio.Execute();
                setFactor(_factorCambio);
                //
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}