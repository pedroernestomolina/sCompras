using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Producto.Listar
{
    
    public class Gestion
    {


        private List<data> list;
        private BindingSource bs;


        public data ItemSeleccionado { get; set; }
        public event EventHandler ItemSeleccionadoOk;
        public BindingSource Source { get { return bs; } }
        public int TItems { get { return bs.Count; } }


        public Gestion()
        {
            ItemSeleccionado = null;
            list = new List<data>();
            bs = new BindingSource();
            bs.DataSource = list;
        }


        ListaFrm frm;
        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new ListaFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return true;
        }

        private void Limpiar()
        {
            ItemSeleccionado = null;
        }


        public void setLista(List<OOB.LibCompra.Producto.Data.Ficha> xlist)
        {
            this.list.Clear();
            foreach (var rg in xlist.OrderBy(o=>o.descripcion).ToList())
            {
                list.Add(new data(rg));
            }
            bs.CurrencyManager.Refresh();
        }

        public void SeleccionarItem()
        {
            var it = (data)bs.Current;
            if (it != null)
            {
                if (!it.isActivo)
                {
                    Helpers.Msg.Error("PRODUCTO SELECCIONADO SE ENCUENTRA EN ESTADO INACTIVO");
                    return;
                }

                ItemSeleccionado = it;
                if (ItemSeleccionadoOk != null)
                {
                    EventHandler hnd = ItemSeleccionadoOk;
                    hnd(this, null);
                }
            }
        }

        public void CerrarFrm()
        {
            frm.Close();
        }

    }

}