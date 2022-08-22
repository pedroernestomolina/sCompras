using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.Listar
{
    
    public class Gestion: IListar
    {

        private List<data> _lst;
        private BindingSource _bs;


        public data ItemSeleccionado { get; set; }
        public event EventHandler ItemSeleccionadoOk;


        public Gestion()
        {
            ItemSeleccionado = null;
            _lst = new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _lst;
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

        
        public void setLista(List<OOB.LibCompra.Proveedor.Data.Ficha> xlist)
        {
            _lst.Clear();
            foreach (var rg in xlist) 
            {
                _lst.Add(new data(rg));
            }
            _bs.CurrencyManager.Refresh();
        }

        public void SeleccionarItem()
        {
            var it = (data)_bs.Current;
            if (it != null)
            {
                if (!it.IsActivo) 
                {
                    Helpers.Msg.Error("PROVEEDOR SELECCIONADO SE ENCUENTRA EN ESTADO INACTIVO");
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

        public void EsconderVentana()
        {
            frm.Hide();
        }

        public void Inicializa()
        {
            ItemSeleccionado = null;
            _lst.Clear();
        }


        public BindingSource GetSource { get { return _bs; } }
        public int GetCntItem { get { return _bs.Count; } }
        public data ItemActual { get { return (data)_bs.Current; } }


        public void Cerrar()
        {
            CerrarFrm();
        }

        public void LimpiarSeleccion()
        {
            ItemSeleccionado = null;
        }

    }

}