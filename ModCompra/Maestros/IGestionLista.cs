using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Maestros 
{
    
    public interface IGestionLista
    {

        int TotalItems { get; }
        System.Windows.Forms.BindingSource Source { get; }
        object ItemActual { get; }

        void setLista(List<OOB.LibCompra.Maestros.Grupo.Ficha> list);
        void ActualizarItem(OOB.LibCompra.Maestros.Grupo.Ficha ficha);
        void Agregar(OOB.LibCompra.Maestros.Grupo.Ficha ficha);

    }

}