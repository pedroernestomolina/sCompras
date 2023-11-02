using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.MetodosPago.CompAgregarEditarMet.Handler
{
    public class ImpHndData: Vista.IHndData
    {
        private decimal _imonto;
        private decimal _ifactor;
        private string _ibanco;
        private string _inroCta;
        private string _icheqRefTransf;
        private string _idetalleOp;
        private DateTime _ifechaOp;
        private bool _iaplicaFactor;
        private string _ilote;
        private string _ireferencia;
        private bool _iaplicaMovCaja;
        private decimal _iimporte;
        private Utils.FiltrosCB.SinBusqueda.MedioPago.IMedioPago _medioPag;
        private decimal _montoPend;


        public decimal Get_MontoResta { get { return _montoPend; } }
        public decimal Get_Monto { get { return _imonto; } }
        public decimal Get_Factor{ get { return _ifactor; } }
        public string Get_Banco { get { return _ibanco; } }
        public string Get_NroCta { get { return _inroCta; } }
        public string Get_CheqRefTrans { get { return _icheqRefTransf; } }
        public string Get_DetalleOp { get { return _idetalleOp; } }
        public DateTime Get_FechaOp { get { return _ifechaOp; } }
        public bool Get_AplicaFactor { get { return _iaplicaFactor; } }
        public decimal Get_Tasa { get { return _ifactor; } }
        public string Get_Referencia { get { return _ireferencia; } }
        public string Get_Lote { get { return _ilote; } }
        public Utils.FiltrosCB.SinBusqueda.MedioPago.IMedioPago MedioPago { get { return _medioPag; } }
        public bool Get_AplicaMovCaja { get { return _iaplicaMovCaja; } }


        public ImpHndData()
        {
            _montoPend = 0m;
            limpiar();
            _medioPag = new Utils.FiltrosCB.SinBusqueda.MedioPago.Imp();
        }


        public void Inicializa()
        {
            limpiar();
            _medioPag.Inicializa();
        }
        public void Cargardata()
        {
            _medioPag.ObtenerData();
        }
        public bool DataIsOK()
        {
            if (_medioPag.GetItem == null)
            {
                Helpers.Msg.Error("CAMPO [ MEDIO DE PAGO ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_iimporte > _montoPend  || _iimporte <=0m)
            {
                Helpers.Msg.Error("CAMPO [MONTO] INCORRECTO");
                return false;
            }
            return true;
        }


        public void setMonto(decimal monto)
        {
            _imonto = monto;
            calculaImporte();
        }
        public void setFactor(decimal factor)
        {
            _ifactor = factor;
            calculaImporte();
        }
        public void setBanco(string banco)
        {
            _ibanco = banco;
        }
        public void setCtaNro(string cta)
        {
            _inroCta = cta;
        }
        public void setChequeRefTranf(string cheqRefTranf)
        {
            _icheqRefTransf = cheqRefTranf;
        }
        public void setFechaOperacion(DateTime fecha)
        {
            _ifechaOp = fecha;
        }
        public void setDetalleOperacion(string detalleOp)
        {
            _idetalleOp = detalleOp;
        }
        public void setAplicaFactor(bool p)
        {
            _iaplicaFactor = p;
            calculaImporte();
        }
        public void setLote(string lote)
        {
            _ilote = lote;
        }
        public void setReferencia(string referenc)
        {
            _ireferencia = referenc;
        }
        public void setAplicaMovCaja(bool modo)
        {
            _iaplicaMovCaja = modo;
        }
        public void setMontoResta(decimal monto)
        {
            _montoPend = monto;
        }


        private void limpiar()
        {
            _imonto = 0m;
            _ifactor = 1m;
            _ibanco = "";
            _inroCta = "";
            _icheqRefTransf = "";
            _idetalleOp = "";
            _ifechaOp = DateTime.Now.Date;
            _ireferencia = "";
            _ilote = "";
            _iaplicaMovCaja = false;
            _iimporte = 0m;
        }
        private void calculaImporte()
        {
            _iimporte = _imonto;
            if (_iaplicaFactor) 
            {
                _iimporte =0m;
                if (_ifactor >0m)
                {
                    _iimporte = _imonto / _ifactor;
                    _iimporte = Math.Round(_iimporte, 2, MidpointRounding.AwayFromZero);
                }
            }
        }

        //
        // PARA SOLO DESPLEGAR 
        public string TitMedioPago { get { return _medioPag.GetItem.desc; } }
        public decimal TitMonto { get { return _imonto; } }
        public decimal TitTasa { get { return _ifactor; } }
        public decimal TitImporte { get { return _iimporte; } }
    }
}