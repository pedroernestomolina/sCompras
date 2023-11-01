using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.srcTransporte.CtaPagar.Tools.MetodosPago.CompLista
{
    public interface ILista
    {
        BindingSource Get_Source { get; }
        object ItemActual { get; }

        void Inicializa();
    }
}