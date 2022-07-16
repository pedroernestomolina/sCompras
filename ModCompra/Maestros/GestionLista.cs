using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Maestros 
{
    
    public class GestionLista: IGestionLista
    {

        private List<data> lLista;
        private BindingList<data> blLista;
        private BindingSource bsLista;


        public BindingSource Source { get { return bsLista; } }
        public object ItemActual { get { return bsLista.Current; } }


        public GestionLista()
        {
            lLista = new List<data>();
            blLista = new BindingList<data>(lLista);
            bsLista = new BindingSource();
            bsLista.DataSource = blLista;
        }


        public int TotalItems
        {
            get { return blLista.Count; }
        }

        public void setLista(List<data> list)
        {
        }


        public void setLista(List<OOB.LibCompra.Maestros.Grupo.Ficha> list)
        {
            blLista.Clear();
            foreach (var it in list.OrderBy(o => o.nombre).ToList())
            {
                blLista.Add(new data(it));
            }
            bsLista.CurrencyManager.Refresh();
        }

        public void ActualizarItem(OOB.LibCompra.Maestros.Grupo.Ficha ficha)
        {
            var it = blLista.FirstOrDefault(f => f.id == ficha.auto);
            if (it != null)
                blLista.Remove(it);
            Agregar(ficha);
        }

        public void Agregar(OOB.LibCompra.Maestros.Grupo.Ficha ficha)
        {
            blLista.Add(new data(ficha));
            bsLista.CurrencyManager.Refresh();
        }

    }

}