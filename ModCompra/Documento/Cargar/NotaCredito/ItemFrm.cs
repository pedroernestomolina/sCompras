using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.NotaCredito
{

    public partial class ItemFrm : Form
    {

        private NotaCredito.GestionAgregarItem _controlador;


        public ItemFrm()
        {
            InitializeComponent();
        }


        public void setControlador(NotaCredito.GestionAgregarItem ctr)
        {
            _controlador = ctr;
        }


        private void ItemFrm_Load(object sender, EventArgs e)
        {
            L_PRODUCTO.Text = _controlador.Producto;
            L_TASA_IVA_PRD.Text = _controlador.ProductoTasaIvaDesc;
            L_EMPQ_PRD.Text = _controlador.ProductoEmpaqueDesc;
            L_CONT_EMPQ.Text = _controlador.ProductoContEmpaqueDesc;

            L_DSCTO_1.Text = _controlador.Dscto_1.ToString("n2");
            L_DSCTO_2.Text = _controlador.Dscto_2.ToString("n2");
            L_DSCTO_3.Text = _controlador.Dscto_3.ToString("n2");

            L_CANTIDAD_UND.Text = _controlador.CantidadUnd.ToString("n0");
            L_CANTIDAD_DEV_UND.Text = _controlador.CantidadDevUnd.ToString("n0");
            L_COSTO_MONEDA_UND.Text = _controlador.CostoMonedaUnd.ToString("n2");
            L_COSTO_DIVISA_UND.Text = _controlador.CostoDivisaUnd.ToString("n2");
            L_FACTOR_COMPRA_DIVISA.Text = _controlador.FactorCompraDivisa.ToString("n2");

            TB_COD_REF_PRV.Enabled = true;
            if (_controlador.CodigoRefProveedor.Trim() != "")
                TB_COD_REF_PRV.Enabled = false;

            TB_COD_REF_PRV.Text = _controlador.CodigoRefProveedor;
            TB_CNT.Text = _controlador.Cantidad.ToString();
            TB_CNT_DEV.Text = _controlador.CantidadDev.ToString();
            var _costoMoneda = Math.Round(_controlador.CostoMoneda, 2, MidpointRounding.AwayFromZero);
            var _costoDivisa = Math.Round(_controlador.CostoDivisa, 4, MidpointRounding.AwayFromZero);
            TB_COSTO_MONEDA.Text = _costoMoneda.ToString();
            TB_COSTO_DIVISA3.Text = _costoDivisa.ToString();
            TB_DSCTO_1.Text = _controlador.Dscto_1.ToString();
            TB_DSCTO_2.Text = _controlador.Dscto_2.ToString();
            TB_DSCTO_3.Text = _controlador.Dscto_3.ToString();

            ActualizarImporte();
        }

        private void Ctr_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SelectNextControl((Control)sender, true, true, true, true);
            }
        }

        private void BT_SALIR_Click(object sender, EventArgs e)
        {
            Salir();
        }

        private void Salir()
        {
            _controlador.Salir();
        }

        private void TB_CNT_Leave(object sender, EventArgs e)
        {
            _controlador.Cantidad = decimal.Parse(TB_CNT.Text);
            ActualizarImporte();
        }

        private void TB_CNT_DEV_Leave(object sender, EventArgs e)
        {
            var cnt = decimal.Parse(TB_CNT_DEV.Text);
            cnt = _controlador.VerificarCantidad(cnt);
            _controlador.CantidadDev = cnt;
            TB_CNT_DEV.Text = cnt.ToString();
            //_controlador.CantidadDev = decimal.Parse(TB_CNT_DEV.Text);
            ActualizarImporte();
        }

        private void TB_COSTO_MONEDA_Leave(object sender, EventArgs e)
        {
            _controlador.CostoMoneda = decimal.Parse(TB_COSTO_MONEDA.Text);
            TB_COSTO_DIVISA3.Text = _controlador.CostoDivisa.ToString("n2").Replace(".", "");
            ActualizarImporte();
        }

        private void TB_COSTO_DIVISA3_Leave(object sender, EventArgs e)
        {
            _controlador.CostoDivisa = decimal.Parse(TB_COSTO_DIVISA3.Text);
            TB_COSTO_MONEDA.Text = _controlador.CostoMoneda.ToString("n2").Replace(".", "");
            ActualizarImporte();
        }

        private void TB_DSCTO_1_Leave(object sender, EventArgs e)
        {
            _controlador.Dscto_1 = decimal.Parse(TB_DSCTO_1.Text);
            ActualizarImporte();
        }

        private void TB_DSCTO_2_Leave(object sender, EventArgs e)
        {
            _controlador.Dscto_2 = decimal.Parse(TB_DSCTO_2.Text);
            ActualizarImporte();
        }

        private void TB_DSCTO_3_Leave(object sender, EventArgs e)
        {
            _controlador.Dscto_3 = decimal.Parse(TB_DSCTO_3.Text);
            ActualizarImporte();
        }

        private void ActualizarImporte()
        {
            L_CANTIDAD_UND.Text = _controlador.CantidadUnd.ToString("n0");
            L_CANTIDAD_DEV_UND.Text = _controlador.CantidadDevUnd.ToString("n0");

            L_COSTO_DIVISA_UND.Text = _controlador.CostoDivisaUnd.ToString("n2");
            L_COSTO_MONEDA_UND.Text = _controlador.CostoMonedaUnd.ToString("n2");

            L_DSCTO_1.Text = _controlador.Dscto_1_Monto.ToString("n2");
            L_DSCTO_2.Text = _controlador.Dscto_2_Monto.ToString("n2");
            L_DSCTO_3.Text = _controlador.Dscto_3_Monto.ToString("n2");

            L_IMPORTE.Text = _controlador.MontoImporte.ToString("n2");
            L_IMPUESTO.Text = _controlador.MontoImpuesto.ToString("n2");
            L_TOTAL.Text = _controlador.MontoTotal.ToString("n2");
        }

        private void BT_ACEPTAR_Click(object sender, EventArgs e)
        {
            Aceptar();
        }

        private void Aceptar()
        {
            _controlador.Aceptar();
        }

        private void ItemFrm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            if (_controlador.SalidaOk)
            {
                e.Cancel = false;
            }
        }

        private void TB_COD_REF_PRV_Leave(object sender, EventArgs e)
        {
            _controlador.CodigoRefProveedor = TB_COD_REF_PRV.Text;
        }

        private void TB_CNT_DEV_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = _controlador.IsCantDevolverValido;
        }

    }

}