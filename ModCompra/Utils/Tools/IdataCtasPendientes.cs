using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Utils.Tools
{
    public interface IdataCtasPendientes
    {
        BindingSource GetSource { get; }
        decimal Get_MontoPendiente { get; }
        object ItemActual { get; }
        int Get_CntItem { get; }
        IEnumerable<object> Get_Items { get; }
        string Get_TextoBuscar { get; }
        //
        void Inicializa();
        void CargarCtas();
        void setTextoBuscar(string textBuscar);
    }
}