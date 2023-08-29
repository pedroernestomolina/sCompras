using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Utils.Buscar
{
    public interface ICtrlLista: HlpGestion.IGestion
    {
        BindingSource Get_Data { get; }
        int Get_CntItem { get; }
        object ItemActual { get; }
        bool ItemSeleccionadoIsOk { get;  }
        object ItemSeleccionado { get; }

        void setDataCargar(IEnumerable<object> lst);
        void SeleccionarItem();
    }
}