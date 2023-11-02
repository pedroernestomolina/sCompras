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
        decimal Get_Importe { get; }
        decimal Get_ImporteMovCaja { get; }
        int Get_CntItems { get; }

        void Inicializa();
        void Agregar(object data);
        void EliminarItemActual();
        void EliminarItem(object it);
    }
}