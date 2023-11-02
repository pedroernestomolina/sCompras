using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.Tools.MetodosPago.Principal.Handler
{
    public class ImpMetPago: Vista.IMetPag
    {
        private decimal _montoPagarDiv;
        private decimal _montoPendDiv;
        private decimal _montoRecibidoDiv;
        private CompLista.ILista _lista;


        public BindingSource Get_Source { get { return _lista.Get_Source; } }
        public decimal Get_MontoPagar { get { return _montoPagarDiv; } }
        public decimal Get_MontoPend { get { return _montoPendDiv; } }
        public decimal Get_MontoRecibido { get { return _lista.Get_Importe; } }
        public decimal Get_ImporteMovCaja { get { return _lista.Get_ImporteMovCaja; } }


        public ImpMetPago()
        {
            _montoPendDiv = 0m;
            _montoPagarDiv = 0m;
            _montoRecibidoDiv = 0m;
            _lista = new CompLista.ImpLista();
            //
            _itemInfo_Metodo = "";
        }
        public void Inicializa()
        {
            _montoPendDiv = 0m;
            _lista.Inicializa();
            //
            _itemInfo_Metodo = "";
        }
        public void setMontoPagarDiv(decimal monto)
        {
            _montoPagarDiv = monto;
            _montoPendDiv = monto - _lista.Get_Importe;
        }

        public void AgregarMet()
        {
           CompAgregarEditarMet.Vista.IAgregar _agMet = new CompAgregarEditarMet.Handler.ImpAgregar();
            _agMet.Inicializa();
            _agMet.setMontoPend(_montoPendDiv);
            _agMet.Inicia();
            if (_agMet.ProcesarIsOK)
            {
                _lista.Agregar(_agMet.HndData);
                _montoPendDiv = _montoPagarDiv - _lista.Get_Importe;
            }
        }
        public void EditarMet()
        {
            if (_lista.ItemActual == null)
            {
                return;
            }
            var it = _lista.ItemActual;
            CompAgregarEditarMet.Vista.IEditar _edMet = new CompAgregarEditarMet.Handler.ImpEditar();
            _edMet.Inicializa();
            _edMet.setItemEditar(it);
            _edMet.setMontoPend(_montoPendDiv);
            _edMet.Inicia();
            if (_edMet.ProcesarIsOK)
            {
                _lista.EliminarItem(it);
                _lista.Agregar(_edMet.HndData);
                _montoPendDiv = _montoPagarDiv - _lista.Get_Importe;
            }
        }
        public void EliminarMet()
        {
            if (_lista.ItemActual == null)
            {
                return;
            }
            _lista.EliminarItemActual();
            _montoPendDiv = _montoPagarDiv - _lista.Get_Importe;
        }


        //
        private string _itemInfo_Metodo;
        private decimal _itemInfo_Monto;
        private string _itemInfo_AplicaFactorCambio;
        private string _itemInfo_Banco;
        private string _itemInfo_NroCta;
        private string _itemInfo_NroRef;
        private DateTime _itemInfo_FechaOperacion;
        private string _itemInfo_DetalleOperacion;
        public string Get_ItemInfo_Metodo { get { return _itemInfo_Metodo; } }
        public decimal Get_ItemInfo_Monto { get { return _itemInfo_Monto; } }
        public string Get_ItemInfo_AplicaFactorCambio { get { return _itemInfo_AplicaFactorCambio; } }
        public string Get_ItemInfo_Banco { get { return _itemInfo_Banco; } }
        public string Get_ItemInfo_NroCta { get { return _itemInfo_NroCta; } }
        public string Get_ItemInfo_NroRef { get { return _itemInfo_NroRef; } }
        public DateTime Get_ItemInfo_FechaOperacion { get { return _itemInfo_FechaOperacion; } }
        public string Get_ItemInfo_DetalleOperacion { get { return _itemInfo_DetalleOperacion; } }
        public void ActualizarItem()
        {
            _itemInfo_Metodo = "";
            _itemInfo_Monto = 0m;
            _itemInfo_AplicaFactorCambio = "";
            _itemInfo_Banco = "";
            _itemInfo_NroCta = "";
            _itemInfo_NroRef = "";
            _itemInfo_FechaOperacion = DateTime.Now.Date;
            _itemInfo_DetalleOperacion = "";
            if (_lista.ItemActual == null)
            {
                return;
            }
            var it = (CompAgregarEditarMet.Handler.ImpHndData)_lista.ItemActual;
            _itemInfo_Metodo = it.TitMedioPago;
            _itemInfo_Monto = it.TitMonto;
            _itemInfo_AplicaFactorCambio = it.Get_AplicaFactor ? "SI" : "NO";
            _itemInfo_Banco = it.Get_Banco;
            _itemInfo_NroCta = it.Get_NroCta;
            _itemInfo_NroRef = it.Get_CheqRefTrans;
            _itemInfo_FechaOperacion = it.Get_FechaOp;
            _itemInfo_DetalleOperacion = it.Get_DetalleOp;
        }
        public bool ProcesarIsOk()
        {
            if (_lista.Get_CntItems<=0)
            {
                Helpers.Msg.Alerta("DEBES INDICAR LOS MEDIOS DE PAGOS NECESARIOS");
                return false;
            }
            if (_montoPendDiv > 0m)
            {
                Helpers.Msg.Alerta("MEDIOS DE PAGOS INCOMPLETOS");
                return false;
            }
            return true;
        }
    }
}