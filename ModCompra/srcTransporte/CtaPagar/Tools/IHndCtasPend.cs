using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.Tools
{
    public interface IHndCtasPend
    {
        BindingSource Get_Source { get; }
        decimal Get_MontoPendiente { get; }
        object Get_ItemActual { get; }
        int Get_CntItem { get; }
        IEnumerable<object> Get_Items { get; }
        //
        void Inicializa();
        void CargarCtas();
    }
}