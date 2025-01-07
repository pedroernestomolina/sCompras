using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.NotaCredito.Remision
{
    public class Gestion
    {
        public event EventHandler ItemSeleccionadoOk;
        //
        private List<OOB.LibCompra.Documento.ListaRemision.Ficha> litems;
        private BindingSource bs;
        private OOB.LibCompra.Proveedor.Data.Ficha _proveedor;
        //
        public OOB.LibCompra.Documento.ListaRemision.Ficha ItemRemisionSeleccionado { get; set; }
        public string ItemEncontrados 
        { 
            get 
            {
                var rt = "";
                rt = "Items Encontrados: "+litems.Count().ToString("n0");
                return rt;
            } 
        }
        public string Proveedor 
        {
            get 
            {
                var rt = "";
                rt = _proveedor.ciRif + Environment.NewLine + _proveedor.nombreRazonSocial;
                return rt;
            }
        }
        public BindingSource Source { get { return bs; } }
        //
        public Gestion()
        {
            ItemRemisionSeleccionado = null;
            litems = new List<OOB.LibCompra.Documento.ListaRemision.Ficha>();
            bs = new BindingSource();
            bs.DataSource = litems;
        }
        RemisionFrm frm;
        public void Inicia() 
        {
            ItemRemisionSeleccionado = null;
            if (CargarData()) 
            {
                if (frm == null)
                {
                    frm = new RemisionFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setProveedor(OOB.LibCompra.Proveedor.Data.Ficha ficha)
        {
            _proveedor = ficha ;
        }

        private bool CargarData()
        {
            var rt = true;

            var filtro = new OOB.LibCompra.Documento.ListaRemision.Filtro()
            {
                autoProveedor = _proveedor.autoId,
            };
            var r01 = Sistema.MyData.Compra_DocumentoGetListaRemision(filtro);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error (r01.Mensaje);
                return false;
            }
            litems.Clear();
            litems.AddRange(r01.Lista.OrderByDescending(o=>o.fechaEmision).ToList());
            bs.CurrencyManager.Refresh();

            return rt;
        }

        public void SeleccionarItem()
        {
            var it = (OOB.LibCompra.Documento.ListaRemision.Ficha)bs.Current;
            if (it != null)
            {
                ItemRemisionSeleccionado = it;
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