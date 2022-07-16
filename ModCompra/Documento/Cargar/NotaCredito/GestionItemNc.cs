using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.NotaCredito
{

    public class GestionItemNc : Controlador.IGestionItem
    {

        public event EventHandler ActualizarItemHnd;


        private List<dataItem> ldata;
        private BindingList<dataItem> bl;
        private BindingSource bs;
        private GestionAgregarItem gestionAgregarItem;


        public IEnumerable<object> Lista { get { return bl.ToList(); } }
        public BindingSource ItemSource { get { return bs; } }
        public int TItems { get { return bs.Count; } }
        public decimal TotalMonto { get { return bl.Sum(m => m.total); } }
        public decimal MontoIva { get { return bl.Sum(m => m.impuesto); } }
        public decimal MontoDivisa { get { return bl.Sum(m => m.totalDivisa); } }

        public decimal TotalMonto_Final { get { return bl.Sum(m => m.TotalFinal); } }
        public decimal MontoDivisa_Final { get { return bl.Sum(m => m.TotalDivisaFinal); } }
        public decimal MontoCargo_Final { get { return bl.Sum(m => m.MontoCargoFinal); } }
        public decimal MontoDescuento_Final { get { return bl.Sum(m => m.MontoDsctoFinal); } }
        public decimal MontoBase_Final { get { return bl.Sum(m => m.MontoBase_Final); } }
        public decimal MontoBase1_Final { get { return bl.Sum(m => m.MontoBase1_Final); } }
        public decimal MontoBase2_Final { get { return bl.Sum(m => m.MontoBase2_Final); } }
        public decimal MontoBase3_Final { get { return bl.Sum(m => m.MontoBase3_Final); } }
        public decimal MontoExento_Final { get { return bl.Sum(m => m.MontoExento_Final); } }
        public decimal MontoImpuesto_Final { get { return bl.Sum(m => m.MontoImpuesto_Final); } }
        public decimal MontoImpuesto1_Final { get { return bl.Sum(m => m.MontoImpuesto1_Final); } }
        public decimal MontoImpuesto2_Final { get { return bl.Sum(m => m.MontoImpuesto2_Final); } }
        public decimal MontoImpuesto3_Final { get { return bl.Sum(m => m.MontoImpuesto3_Final); } }


        public string Item_Producto
        {
            get
            {
                var rt = "";
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    rt = it.ProductoDetalle;
                }
                return rt;
            }
        }

        public decimal Item_Importe
        {
            get
            {
                var rt = 0.0m;
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    rt = it.importe;
                }
                return rt;
            }
        }

        public decimal Item_Impuesto
        {
            get
            {
                var rt = 0.0m;
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    rt = it.impuesto;
                }
                return rt;
            }
        }

        public decimal Item_Total
        {
            get
            {
                var rt = 0.0m;
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    rt = it.total;
                }
                return rt;
            }
        }

        public decimal Item_Cantidad
        {
            get
            {
                var rt = 0.0m;
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    //rt = it.cantidad;
                    rt = it.cantDev;
                }
                return rt;
            }
        }

        public decimal Item_CantidadUnd
        {
            get
            {
                var rt = 0.0m;
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    rt = it.CantidadUnd;
                }
                return rt;
            }
        }

        public decimal Item_CostoMoneda
        {
            get
            {
                var rt = 0.0m;
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    rt = it.costoMoneda;
                }
                return rt;
            }
        }

        public decimal Item_CostoMonedaUnd
        {
            get
            {
                var rt = 0.0m;
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    rt = it.costoMonedaUnd;
                }
                return rt;
            }
        }

        public decimal Item_CostoDivisa
        {
            get
            {
                var rt = 0.0m;
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    rt = it.costoDivisa;
                }
                return rt;
            }
        }

        public decimal Item_CostoDivisaUnd
        {
            get
            {
                var rt = 0.0m;
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    rt = it.costoDivisaUnd;
                }
                return rt;
            }
        }

        public string Item_EmpaqueCont
        {
            get
            {
                var rt = "";
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    rt = it.empaqueCont;
                }
                return rt;
            }
        }

        public string Item_CodRefPrv
        {
            get
            {
                var rt = "";
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    rt = it.CodRefPrv;
                }
                return rt;
            }
        }

        public decimal Item_Dscto
        {
            get
            {
                var rt = 0.0m;
                if (bs.Current != null)
                {
                    var it = (dataItem)bs.Current;
                    rt = it.DsctoMonto;
                }
                return rt;
            }
        }



        public GestionItemNc()
        {
            ldata = new List<dataItem>();
            bl = new BindingList<dataItem>(ldata);
            bs = new BindingSource();
            bs.CurrentItemChanged += bs_CurrentItemChanged;
            bs.DataSource = bl;
            gestionAgregarItem = new GestionAgregarItem();
        }

        private void bs_CurrentItemChanged(object sender, EventArgs e)
        {
            ActualizarDataItem();
        }

        private void ActualizarDataItem()
        {
            EventHandler hnd = ActualizarItemHnd;
            if (hnd != null)
            {
                hnd(this, null);
            }
        }

        public void LimpiarItems()
        {
            if (bl.Count > 0)
            {
                MessageBox.Show("OPCION NO APLICA A ESTE TIPO DE DOCUMENTO", "*** ALERTA ***", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        public void Limpiar()
        {
            bl.Clear();
            bs.CurrencyManager.Refresh();
        }

        public void EliminarItem()
        {
            if (bs.Current != null)
            {
                var it = (dataItem)bs.Current;
                var ms = MessageBox.Show("Estas Seguro De Querer Eliminar Este Item ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (ms == DialogResult.Yes)
                {
                    bl.Remove(it);
                    bs.CurrencyManager.Refresh();
                }
            }
        }

        public void EditarItem()
        {
            if (bs.Current != null)
            {
                var it = (dataItem)bs.Current;
                gestionAgregarItem.Editar(it);
                if (gestionAgregarItem.RegistroOk)
                {
                    bl.Remove(it);
                    InsertarItem(gestionAgregarItem.Item);
                    bs.CurrencyManager.Refresh();
                }
            }
        }

        public void AgregarItem(string autoPrd, string autoPrv, decimal factorDivisa)
        {
            gestionAgregarItem.NuevoItem();
            gestionAgregarItem.setAutoProveedor(autoPrv);
            gestionAgregarItem.setFactorDivisa(factorDivisa);
            gestionAgregarItem.setAutoPrd(autoPrd);
            gestionAgregarItem.Inicia();
            if (gestionAgregarItem.RegistroOk)
            {
                InsertarItem(gestionAgregarItem.Item);
            }
        }

        private void InsertarItem(dataItem item)
        {
            bl.Add(item);
            bs.CurrencyManager.Refresh();
        }

        public void setDescuentoFinal(decimal p)
        {
            foreach (var it in bl)
            {
                it.setDescuentoFinal(p);
            }
        }

        public void setCargoFinal(decimal p)
        {
            foreach (var it in bl)
            {
                it.setCargoFinal(p);
            }

        }

        public void CargarItems(List<OOB.LibCompra.Documento.GetData.FichaDetalle> list, decimal factorCambio)
        {
            foreach (var it in list)
            {
                var dt = new dataItem(it, factorCambio);
                InsertarItem(dt);
            }
        }

        public void AgregarListaItem(List<OOB.LibCompra.Documento.ListaItemImportar.Ficha> list, string idPrv, decimal factorDivisa)
        {
        }

        public void AgregarListaItem(List<OOB.LibCompra.Documento.Pendiente.Abrir.FichaDetalle> list, string idPrv, decimal factorDivisa)
        {
        }

    }

}