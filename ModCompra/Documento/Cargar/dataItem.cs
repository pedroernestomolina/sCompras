using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar
{
    
    public class dataItem
    {


        private decimal factorDivisa;
        private decimal _dscto_1_m;
        private decimal _dscto_2_m;
        private decimal _dscto_3_m;
        private OOB.LibCompra.Producto.Data.Ficha producto;
        private bool _modoNCActivo;


        public OOB.LibCompra.Producto.Data.Ficha Producto { get { return producto; } }
        public decimal FactorCpmpraDivisa { get { return factorDivisa; } }
        public string codigoPrd { get { return producto.codigo; } }
        public string descripcionPrd { get { return producto.descripcion; } }
        public string cnt { get { return cantidad.ToString("n"+producto.decimales); } }
        public string cntDev { get { return cantDev.ToString("n" + producto.decimales); } }
        public string empaqueCont { get { return producto.empaqueCompra.Trim() + "/ " + producto.contenidoCompra.ToString("n0").Trim(); } }
        public string costoCompra { get { return costoMoneda.ToString("n2"); } }
        public string costoDivisaCompra { get { return costoDivisa.ToString("n2"); } }
        public string tasaIvaPrd { get { return producto.tasaIva.ToString("n2").Trim()+"%"; } }
        public decimal DsctoMonto { get { return _dscto_1_m + _dscto_2_m + _dscto_3_m; } }

        public string CodRefPrvActual { get; set; }
        public string CodRefPrv { get; set; }
        public decimal cantidad { get; set; }
        public decimal costoMoneda { get; set; }
        public decimal costoDivisa { get; set; }
        public decimal dsct_1_m { get { return _dscto_1_m; } }
        public decimal dsct_2_m { get { return _dscto_2_m; } }
        public decimal dsct_3_m { get { return _dscto_3_m; } }
        public decimal dsct_1_p { get; set; }
        public decimal dsct_2_p { get; set; }
        public decimal dsct_3_p { get; set; }
        public decimal costoMoneda_2 { get; set; }
        public decimal costoDivisa_2 { get; set; }

        public decimal CantidadUnd
        {
            get
            {
                var rt = 0m;
                //if (_modoNCActivo)
                //    rt = (int)cantDev * Producto.contenidoCompra;
                //else
                //    rt = (int) cantidad* Producto.contenidoCompra;

                //rt = (int)cantidad * Producto.contenidoCompra;
                rt = cantidad * Producto.contenidoCompra;
                if (producto.decimales == "0")
                { 
                    rt=(int)rt;
                }
                return rt;
            }
        }

        public decimal CantidadDevUnd
        {
            get
            {
                var rt = 0m;
                rt = cantDev * Producto.contenidoCompra;
                if (producto.decimales == "0")
                {
                    rt = (int)rt;
                }
                return rt;
            }
        }

        public decimal costoMonedaUnd 
        {
            get 
            {
                var rt = 0.0m;
                rt = costoMoneda / Producto.contenidoCompra;
                return rt;
            } 
        }

        public decimal costoMoneda_2_Und
        {
            get
            {
                var rt = 0.0m;
                rt = costoMoneda_2 / Producto.contenidoCompra;
                return rt;
            }
        }

        public decimal costoDivisaUnd 
        {
            get 
            {
                var rt = 0.0m;
                rt = costoDivisa / Producto.contenidoCompra;
                return rt;
            } 
        }

        public decimal subTotal_1 
        {
            get 
            {
                var rt = 0.0m;
                if (_modoNCActivo)
                    rt = cantDev * costoMoneda;
                else
                    rt = cantidad * costoMoneda;
                return rt;
            }
        }

        public decimal subTotal_2
        {
            get
            {
                var rt = 0.0m;
                if (_modoNCActivo)
                    rt = cantDev * costoMoneda_2;
                else
                    rt = (cantidad * costoMoneda_2);
                return rt;
            }
        }

        public decimal importe 
        { 
            get 
            {
                var rt = 0.0m;
                rt = subTotal_2;
                return rt; 
            } 
        }

        public decimal impuesto 
        { 
            get 
            {
                var rt = 0.0m;
                rt = importe * producto.tasaIva / 100;
                return rt; 
            } 
        }

        public decimal total 
        { 
            get 
            {
                var rt = 0.0m;
                rt = importe + impuesto;
                return rt; 
            } 
        }

        public decimal totalDivisa
        {
            get
            {
                var rt = 0.0m;
                rt = total / factorDivisa;
                return rt;
            }
        }

        public string ProductoDetalle 
        { 
            get 
            {
                var rt = "";
                if (Producto != null) 
                {
                    rt += Producto.codigo + Environment.NewLine + Producto.descripcion;
                }
                return rt;
            } 
        }

        public string ProductoTasaIvaDesc 
        {
            get 
            {
                var rt = "";
                if (Producto != null)
                {
                    if (Producto.tasaIva == 0)
                        rt = "EXENTO";
                    else
                        rt = Producto.tasaIva.ToString("n2").Trim()+"%, "+Producto.nombreTasaIva;
                }
                return rt;
            } 
        }

        public string ProductoAdmDivisaDesc 
        {
            get 
            {
                var rt = "";
                if (Producto != null)
                {
                    rt = Producto.AdmPorDivisa.ToString();
                }
                return rt;
            } 
        }

        public string ProductoEmpaqueDesc 
        {
            get 
            {
                var rt = "";
                if (Producto != null)
                {
                    rt = Producto.empaqueCompra;
                }
                return rt;
            } 
        }

        public string ProductoContEmpaqueDesc
        {
            get
            {
                var rt = "";
                if (Producto != null)
                {
                    rt = Producto.contenidoCompra.ToString("n0");
                }
                return rt;
            }
        }

        public decimal ProductoCosto 
        {
            get
            {
                var rt = 0.0m;
                if (Producto != null)
                {
                    rt = Producto.costo;
                }
                return rt;
            }
        }

        public decimal ProductoCostoDivisa
        {
            get
            {
                var rt = 0.0m;
                if (Producto != null)
                {
                    rt = Producto.costoDivisa;
                }
                return rt;
            }
        }


        // NOTA DE CREDITO 
        private OOB.LibCompra.Documento.GetData.FichaDetalle itemDocumento;
        public decimal cantDev { get; set; }


        public dataItem()
        {
            factorDivisa = 0.0m;
            producto = null;
        }

        public dataItem(dataItem it)
        {
            this._modoNCActivo = it._modoNCActivo;
            this.factorDivisa = it.factorDivisa;
            this.producto = it.producto;
            this.CodRefPrv = it.CodRefPrv;
            this.cantidad = it.cantidad;
            this.costoMoneda = it.costoMoneda;
            this.costoDivisa = it.costoDivisa;
            this.dsct_1_p = it.dsct_1_p;
            this.dsct_2_p = it.dsct_2_p;
            this.dsct_3_p = it.dsct_3_p;
            ActualizarCosto();
            ActualizarCostoDivisa();
            CalculaDscto();
        }

        public dataItem(OOB.LibCompra.Documento.GetData.FichaDetalle it, decimal factorCambio)
        {
            this._modoNCActivo = true;
            this.itemDocumento = it;
            this.factorDivisa = factorCambio;
            this.producto = new OOB.LibCompra.Producto.Data.Ficha(it);
            this.CodRefPrv = it.CodRefPrv;
            this.cantidad = it.cntFactura;
            this.costoMoneda = it.precioFactura;
            this.costoDivisa = it.precioFactura/factorCambio;
            this.dsct_1_p = it.dscto1p ;
            this.dsct_2_p = it.dscto2p;
            this.dsct_3_p = it.dscto3p;
            this.cantDev = 0;

            ActualizarCosto();
            ActualizarCostoDivisa();
            CalculaDscto();
        }

        public dataItem(OOB.LibCompra.Documento.ListaItemImportar.Ficha it, decimal factorDivisa)
        {
            this._modoNCActivo = false;
            this.factorDivisa = factorDivisa;
            this.producto = new OOB.LibCompra.Producto.Data.Ficha(it);
            this.CodRefPrv = it.codRefProv ;
            this.cantidad = it.cntFactura ;
            this.costoMoneda = it.precioFactura;
            this.costoDivisa = it.precioFactura / factorDivisa;
            this.dsct_1_p = it.dscto1p ;
            this.dsct_2_p = it.dscto2p ;
            this.dsct_3_p = it.dscto3p ;
            ActualizarCosto();
            ActualizarCostoDivisa();
            CalculaDscto();
        }

        public dataItem(OOB.LibCompra.Documento.Pendiente.Abrir.FichaDetalle it, decimal factorDivisa)
        {
            this._modoNCActivo = false;
            this.factorDivisa = factorDivisa;
            this.producto = new OOB.LibCompra.Producto.Data.Ficha(it);
            this.CodRefPrv = it.codRefProv;
            this.cantidad = it.cntFactura;
            this.costoMoneda = it.precioFactura;
            this.costoDivisa = it.precioFacturaDivisa;
            this.dsct_1_p = it.dscto1p;
            this.dsct_2_p = it.dscto2p;
            this.dsct_3_p = it.dscto3p;
            ActualizarCosto();
            ActualizarCostoDivisa();
            CalculaDscto();
        }


        public void setFactorDivisa(decimal p)
        {
            this.factorDivisa = p;
        }

        public void setProducto(OOB.LibCompra.Producto.Data.Ficha prd) 
        {
            this.producto = prd;
        }

        public void ActualizarCosto()
        {
            costoMoneda = costoDivisa * factorDivisa;
            CalculaDscto();
        }

        public void ActualizarCostoDivisa()
        {
            costoDivisa = costoMoneda  / factorDivisa;
            CalculaDscto();
        }

        public void CalculaDscto()
        {
            var rt = 0.0m;
            rt = costoMoneda;
            if (dsct_1_p >= 0) 
            {
                _dscto_1_m = (rt * dsct_1_p / 100);
                rt -= _dscto_1_m ;
            }
            if (dsct_2_p >= 0)
            {
                _dscto_2_m = (rt * dsct_2_p / 100);
                rt -= _dscto_2_m ;
            }
            if (dsct_3_p >= 0)
            {
                _dscto_3_m = (rt * dsct_3_p / 100);
                rt -= _dscto_3_m ;
            }
            costoMoneda_2 = rt;
        }

        public void Limpiar()
        {
            itemDocumento = null;
            cantDev = 0.0m;
            cantidad = 0.0m;
            costoMoneda = 0.0m;
            costoDivisa = 0.0m;
            dsct_1_p = 0.0m;
            dsct_2_p = 0.0m;
            dsct_3_p = 0.0m;
            ActualizarCosto();
            ActualizarCostoDivisa();
            CalculaDscto();
        }

        /// <summary>
        ///  TOTALIZAR
        /// </summary>
        /// 

        private decimal _porct_dscto_final;
        private decimal _porct_cargo_final;
        private decimal _dscto_final;
        private decimal _cargo_final;
        private decimal _total_final;


        public decimal MontoDsctoFinal 
        {
            get 
            {
                return _dscto_final;
            }
        }

        public decimal MontoCargoFinal
        {
            get
            {
                return _cargo_final;
            }
        }
        
        public decimal TotalFinal
        {
            get
            {
                return _total_final;
            }
        }

        public decimal TotalDivisaFinal
        {
            get
            {
                var rt = 0.0m;
                rt = (TotalFinal / factorDivisa);
                return rt;
            }
        }

        public decimal MontoBase_Final 
        {
            get 
            {
                var rt = 0.0m;
                if (!producto.EsExento) 
                {
                    rt = importe;
                    rt = rt - (rt * _porct_dscto_final / 100);
                    rt = rt + (rt * _porct_cargo_final / 100);
                }
                return rt;
            }
        }

        public decimal MontoBase1_Final
        {
            get
            {
                var rt = 0.0m;
                if (!producto.EsExento)
                {
                    if (producto.tasaTipoIva == "1") 
                    {
                        rt = importe;
                        rt = rt - (rt * _porct_dscto_final / 100);
                        rt = rt + (rt * _porct_cargo_final / 100);
                    }
                }
                return rt;
            }
        }

        public decimal MontoBase2_Final 
        {
            get
            {
                var rt = 0.0m;
                if (!producto.EsExento)
                {
                    if (producto.tasaTipoIva == "2")
                    {
                        rt = importe;
                        rt = rt - (rt* _porct_dscto_final / 100);
                        rt = rt + (rt * _porct_cargo_final / 100);
                    }
                }
                return rt;
            }
        }

        public decimal MontoBase3_Final 
        {
            get
            {
                var rt = 0.0m;
                if (!producto.EsExento)
                {
                    if (producto.tasaTipoIva == "3")
                    {
                        rt = importe;
                        rt = rt - (rt * _porct_dscto_final / 100);
                        rt = rt + (rt * _porct_cargo_final / 100);
                    }
                }
                return rt;
            }
        }

        public decimal MontoExento_Final
        {
            get
            {
                var rt = 0.0m;
                if (producto.EsExento)
                {
                    rt = subTotal_2;
                    rt = rt - (rt * _porct_dscto_final / 100);
                    rt = rt + (rt * _porct_cargo_final / 100);
                }
                return rt;
            }
        }

        public decimal MontoImpuesto_Final 
        {
            get
            {
                var rt = 0.0m;
                rt = (MontoImpuesto1_Final + MontoImpuesto2_Final+ MontoImpuesto3_Final) ;
                return rt;
            }
        }

        public decimal MontoImpuesto1_Final
        {
            get
            {
                var rt = 0.0m;
                if (producto.tasaTipoIva=="1")
                    rt = MontoBase1_Final * producto.tasaIva / 100;
                return rt;
            }
        }

        public decimal MontoImpuesto2_Final
        {
            get
            {
                var rt = 0.0m;
                if (producto.tasaTipoIva == "2")
                    rt = MontoBase2_Final * producto.tasaIva / 100;
                return rt;
            }
        }

        public decimal MontoImpuesto3_Final
        {
            get
            {
                var rt = 0.0m;
                if (producto.tasaTipoIva == "3")
                    rt = MontoBase3_Final * producto.tasaIva / 100;
                return rt;
            }
        }

        public decimal CostoFinal
        {
            get
            {
                var rt = 0.0m;
                rt = costoMoneda_2;
                rt = rt - (rt * _porct_dscto_final / 100);
                rt = rt + (rt * _porct_cargo_final / 100);
                return rt;
            }
        }

        public decimal CostoFinal_Und
        {
            get
            {
                var rt = 0.0m;
                rt = CostoFinal / Producto.contenidoCompra; 
                return rt;
            }
        }

        public decimal CostoDivisaFinal
        {
            get
            {
                var rt = 0.0m;
                rt = CostoFinal / factorDivisa;
                return rt;
            }
        }

        public decimal CostoDivisaFinal_Und
        {
            get
            {
                var rt = 0.0m;
                rt = CostoDivisaFinal / Producto.contenidoCompra;
                return rt;
            }
        }


        public void setDescuentoFinal(decimal p)
        {
            _porct_dscto_final = p;
            CalculaTotalFinal();
        }

        public void setCargoFinal(decimal p)
        {
            _porct_cargo_final = p;
            CalculaTotalFinal();
        }

        public void CalculaTotalFinal()
        {
            _dscto_final = 0.0m;
            _cargo_final = 0.0m;
            _total_final = 0.0m;
            _dscto_final = (total * _porct_dscto_final / 100);
            _cargo_final = (total - _dscto_final) * (_porct_cargo_final / 100);
            _total_final = (total - _dscto_final + _cargo_final);
        }


        private bool _actualizarPrecio;
        private ModCompra.Producto.Precio.Actualizar.dataGuardar _dataPrecios;
        public bool GetActualizarPrecio { get { return _actualizarPrecio; } }
        public ModCompra.Producto.Precio.Actualizar.dataGuardar GetDataPrecios { get { return _dataPrecios; } }
        public void setActualizarPrecio(bool p)
        {
            _actualizarPrecio = p;
        }
        public void setDataPrecios(ModCompra.Producto.Precio.Actualizar.dataGuardar dataGuardar)
        {
            _dataPrecios = dataGuardar;
        }

    }

}