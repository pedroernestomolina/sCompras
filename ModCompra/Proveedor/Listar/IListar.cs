using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.Listar
{
    
    public interface IListar: HlpGestion.IGestion
    {

        event EventHandler ItemSeleccionadoOk;
        BindingSource GetSource { get; }
        void SeleccionarItem();
        int GetCntItem { get; }
        void setLista(List<OOB.LibCompra.Proveedor.Data.Ficha> lst);
        void Cerrar();
        data ItemActual { get; }
        void LimpiarSeleccion();

    }

}