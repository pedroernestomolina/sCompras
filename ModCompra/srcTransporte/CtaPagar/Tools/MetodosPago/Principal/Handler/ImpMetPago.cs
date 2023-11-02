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
        }
        public void Inicializa()
        {
            _montoPendDiv = 0m;
            _lista.Inicializa();
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
    }
}