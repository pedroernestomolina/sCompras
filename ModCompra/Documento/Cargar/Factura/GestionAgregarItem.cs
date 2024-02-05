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
        private Producto.Precio.Actualizar.IEditar _gPrecioVentaEditar;
        private Producto.Precio.zufu.ActualizarPrecio.Vista.IVista _gPrecioEditar;
        private BindingSource _bsEmpCompra;
        private List<dataEmpCompra> _lstEmpCompra;
        //
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
            _gPrecioVentaEditar = new ModCompra.Producto.Precio.Actualizar.Editar();
            _lstEmpCompra = new List<dataEmpCompra>();
            _bsEmpCompra = new BindingSource();
            _bsEmpCompra.DataSource = _lstEmpCompra;
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
            try
            {
                var r01 = Sistema.MyData.Producto_GetFicha(autoPrd);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }
                var filtro = new OOB.LibCompra.Producto.CodRefProveedor.Filtro() { autoPrd = this.autoPrd, autoPrv = this.autoProveedor };
                var r02 = Sistema.MyData.Producto_GetCodigoRefProveedor(filtro);
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return false;
                }
                var r03 = Sistema.MyData.Configuracion_GetPermitirCambiarPrecioAlRegistrarDocCompra();
                if (r03.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r03.Mensaje);
                    return false;
                }
                var _id = 0;
                _lstEmpCompra.Clear();
                var r04 = Sistema.MyData.Producto_EmpaqueCompra_GetLista(autoPrd);
                foreach (var r in r04.Lista) 
                {
                    _id++;
                    var rg = new dataEmpCompra(r, _id.ToString());
                    _lstEmpCompra.Add(rg);
                }
                _bsEmpCompra.DataSource = _lstEmpCompra;
                _bsEmpCompra.CurrencyManager.Refresh();

                item.setProducto(r01.Entidad);
                item.CodRefPrv = r02.Entidad;
                item.CodRefPrvActual = r02.Entidad;
                //

                if (_lstEmpCompra != null)
                {
                    if (_lstEmpCompra.Count > 0)
                    {
                        var empCompraPreDeterminado = _lstEmpCompra.First();
                        item.setEmpCompra(empCompraPreDeterminado);
                    }
                }

                _actualizarPrecioIsActivo = r03.Entidad;
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }

        private void ActualizarCosto()
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

            if (item.IdEmpaqueCompra == "") 
            {
                Helpers.Msg.Alerta("DEBES INDICAR EL EMPAQUE DE COMPRA");
                return;
            }
            if (MontoImporte > 0)
            {
                var ms = MessageBox.Show("Insertar Registro ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (ms == DialogResult.Yes)
                {
                    if (_actualizarPrecioIsActivo)
                    {
                        var r01 = Sistema.MyData.Permiso_RegistrarFactura_CambiarPrecioVenta(Sistema.UsuarioP.autoGru);
                        if (r01.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(r01.Mensaje);
                            return;
                        }
                        if (Seguridad.Gestion.SolicitarClave(r01.Entidad))
                        {
                            if (item.IsEmpCompraPredeterminado)
                            {
                                //var _fichaPrd = new ModCompra.Producto.Precio.Actualizar.dataPrdEditar()
                                //{
                                //    AdmDivisa = item.Producto.AdmPorDivisa == OOB.LibCompra.Producto.Enumerados.EnumAdministradorPorDivisa.Si,
                                //    AutoPrd = item.Producto.auto,
                                //    CodigoPrd = item.Producto.codigo,
                                //    ContEmpCompra = item.Producto.contenidoCompra,
                                //    CostoMonedaDivisa = item.CostoDivisaFinal,
                                //    CostoMonedaLocal = item.CostoFinal,
                                //    DescripcionPrd = item.Producto.descripcion,
                                //    EmpCompraDescripcion = item.Producto.empaqueCompra,
                                //    TasaIva = item.Producto.tasaIva,
                                //};
                                //_gPrecioVentaEditar.Inicializa();
                                //_gPrecioVentaEditar.setPrdEditar(_fichaPrd);
                                //_gPrecioVentaEditar.Inicia();
                                //if (_gPrecioVentaEditar.IsEditarPrecioIsOk)
                                //{
                                //    item.setActualizarPrecio(true);
                                //    item.setDataPrecios(_gPrecioVentaEditar.DataPrecios);
                                //}

                                Producto.Precio.zufu.ActualizarPrecio.Vista.IdataProducto _fichaPrd = new Producto.Precio.zufu.ActualizarPrecio.Handler.dataProducto()
                                {
                                    idPrd = item.Producto.auto,
                                    tasaIva = item.Producto.tasaIva,
                                    codigoPrd = item.Producto.codigo,
                                    descPrd = item.Producto.descripcion,
                                    contEmpCompra = item.Producto.contenidoCompra,
                                    costoCompra = item.CostoDivisaFinal,
                                    empaqueDesc = item.Producto.empaqueCompra,
                                    tasaIvaDesc = item.Producto.nombreTasaIva,
                                    admDivisa = item.Producto.AdmPorDivisa == OOB.LibCompra.Producto.Enumerados.EnumAdministradorPorDivisa.Si,
                                };
                                if (_gPrecioEditar == null) 
                                {
                                    _gPrecioEditar = new Producto.Precio.zufu.ActualizarPrecio.Handler.Imp();
                                }
                                _gPrecioEditar.Inicializa();
                                _gPrecioEditar.setProductoCargar(_fichaPrd);
                                if (item.DataPrecioExp != null) 
                                {
                                    _gPrecioEditar.setImportarPrecios(item.DataPrecioExp);
                                }
                                _gPrecioEditar.Inicia();
                                if (_gPrecioEditar.BtProcesar.OpcionIsOK)
                                {
                                    item.setActualizarPrecio(true);
                                    item.setDataPrecios(_gPrecioEditar.DataExportar);
                                }
                            }
                        }
                    }
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
            _actualizarPrecioIsActivo = false;

            //
            setAutoPrd(it.Producto.auto);

            var r01 = Sistema.MyData.Configuracion_GetPermitirCambiarPrecioAlRegistrarDocCompra();
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            _actualizarPrecioIsActivo = r01.Entidad;


            var _id = 0;
            _lstEmpCompra.Clear();
            var r02 = Sistema.MyData.Producto_EmpaqueCompra_GetLista(autoPrd);
            foreach (var r in r02.Lista)
            {
                _id++;
                var rg = new dataEmpCompra(r, _id.ToString());
                _lstEmpCompra.Add(rg);
            }
            _bsEmpCompra.DataSource = _lstEmpCompra;
            _bsEmpCompra.CurrencyManager.Refresh();


            item = new dataItem(it);
            setEmpCompra(it.IdEmpaqueCompra);
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


        private bool _actualizarPrecioIsActivo;
        public bool GetActualizarPrecioVenta { get { return _actualizarPrecioIsActivo; } }
        public void setActualizarPrecioVenta()
        {
            _actualizarPrecioIsActivo = !_actualizarPrecioIsActivo;
        }


        //
        public BindingSource GetEmpCompra_Source { get { return _bsEmpCompra; } }
        public string GetEmpaqueCompra_ID { get { return item.IdEmpaqueCompra; } }
        public void setEmpCompra(string id)
        {
            var it = _lstEmpCompra.FirstOrDefault(f => f.id == id);
            if (it!=null)
            {
                item.setEmpCompra(it);
            }
        }

    }

}