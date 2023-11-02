using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.Tools.MetodosPago.Principal.Vista
{
    public interface IMetPag
    {
        BindingSource Get_Source { get; }
        decimal Get_MontoPagar { get; }
        decimal Get_MontoPend { get; }
        decimal Get_MontoRecibido { get; }
        decimal Get_ImporteMovCaja { get; }

        void Inicializa();
        void AgregarMet();
        void EditarMet();
        void EliminarMet();

        void setMontoPagarDiv(decimal monto);
    }
}