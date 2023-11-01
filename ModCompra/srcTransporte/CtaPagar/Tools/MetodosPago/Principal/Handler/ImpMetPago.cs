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
        public decimal Get_MontoRecibido { get { return _montoRecibidoDiv; } }


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
            _montoPendDiv = monto;
        }


        public void AgregarMet()
        {
        }
        public void EliminarMet()
        {
        }
    }
}