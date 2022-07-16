using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class GestionAgregarItem
    {


        private dataItem item;
        private string autoPrd;
        private string autoProveedor;


        public string Producto { get { return item.ProductoDetalle; } }
        public string ProductoTasaIvaDesc { get { return item.ProductoTasaIvaDesc; } }
        public string ProductoAdmDivisaDesc { get { return item.ProductoAdmDivisaDesc; } }
        public string ProductoEmpaqueDesc { get { return item.ProductoEmpaqueDesc; } }
        public string ProductoContEmpaqueDesc { get { return item.ProductoContEmpaqueDesc; } }
        public decimal ProductoCosto { get { return item.ProductoCosto; } }
        public decimal ProductoCostoDivisa { get { return item.ProductoCostoDivisa; } }

        public decimal FactorCompraDivisa { get { return item.FactorCpmpraDivisa; } }
        public decimal MontoImporte { get { return item.importe; } }
        public decimal MontoImpuesto { get { return item.impuesto; } }
        public decimal MontoTotal { get { return item.total; } }

        public string CodigoRefProveedor { get { return item.CodRefPrv; } set { item.CodRefPrv = value; } }
        public decimal Cantidad { get { return item.cantidad; } set { item.cantidad = value; item.CalculaDscto(); } }
        public decimal CostoMoneda { get { return item.costoMoneda; } set { item.costoMoneda = value; ActualizarCostoDivisa(); } }
        public decimal CostoDivisa { get { return item.costoDivisa; } set { item.costoDivisa = value; ActualizarCosto(); } }
        public decimal Dscto_1 { get { return item.dsct_1_p; } set { item.dsct_1_p = value; item.CalculaDscto(); } }
        public decimal Dscto_2 { get { return item.dsct_2_p; } set { item.dsct_2_p = value; item.CalculaDscto(); } }
        public decimal Dscto_3 { get { return item.dsct_3_p; } set { item.dsct_3_p = value; item.CalculaDscto(); } }
        public decimal Dscto_1_Monto { get { return item.dsct_1_m; } }
        public decimal Dscto_2_Monto { get { return item.dsct_2_m; } }
        public decimal Dscto_3_Monto { get { return item.dsct_3_m; } } 


        public decimal CostoMonedaUnd { get { return item.costoMonedaUnd; } }
        public decimal CostoDivisaUnd { get { return item.costoDivisaUnd; } }
        public decimal CantidadUnd { get { return item.CantidadUnd; } }

        public bool SalidaOk { get; set; }
        public bool RegistroOk { get; set; }
        public dataItem Item { get { return item; } }
        

        public GestionAgregarItem()
        {
            NuevoItem();
        }


        public void setAutoPrd(string autoPrd)
        {
            this.autoPrd = autoPrd;
        }

        public void setAutoProveedor(string autoPrv)
        {
            this.autoProveedor = autoPrv;
        }

        public void setFactorDivisa(decimal p)
        {
            item.setFactorDivisa(p);
        }

        public void Inicia()
        {
            SalidaOk = false;
            RegistroOk = false;
            if (CargarData())
            {
                item.Limpiar();
                var frm = new Formulario.ItemFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Producto_GetFicha(autoPrd);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            item.setProducto(r01.Entidad);

            var filtro = new OOB.LibCompra.Producto.CodRefProveedor.Filtro() { autoPrd = this.autoPrd, autoPrv = this.autoProveedor };
            var r02 = Sistema.MyData.Producto_GetCodigoRefProveedor(filtro);
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            item.CodRefPrv = r02.Entidad;
            item.CodRefPrvActual = r02.Entidad;

            return rt;
        }

        private  void ActualizarCosto()
        {
            item.ActualizarCosto();
        }

        private void ActualizarCostoDivisa()
        {
            item.ActualizarCostoDivisa();
        }

        public void Aceptar()
        {
            RegistroOk = false;
            SalidaOk = false;
            if (MontoImporte > 0) 
            {
                var ms = MessageBox.Show("Insertar Registro ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (ms == DialogResult.Yes) 
                {
                    RegistroOk = true;
                    SalidaOk = true;
                }
            }
        }

        public void Salir()
        {
            SalidaOk = false;
            RegistroOk = false;
            var ms = MessageBox.Show("Salir y Abandonar Cambios ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ms == DialogResult.Yes)
            {
                SalidaOk = true;
            }
        }

        public void NuevoItem()
        {
            item = new dataItem();
            autoPrd = "";
            autoProveedor = "";
        }

        public void Editar(dataItem it)
        {
            SalidaOk = false;
            RegistroOk = false;

            item = new dataItem(it);
            var frm = new Formulario.ItemFrm();
            frm.setControlador(this);
            frm.ShowDialog();
        }


        public decimal VerificarCantidad(decimal cnt)
        {
            var rt = cnt;
            if (item.Producto.decimales == "0") 
            {
                return (int)cnt;
            }
            return rt;
        }

    }

}