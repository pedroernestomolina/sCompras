using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.zufu.ActualizarPrecio.Handler
{
    public class dataProducto: Vista.IdataProducto
    {
        public string idPrd { get; set; }
        public decimal tasaIva { get; set; }
        public string descPrd { get; set; }
        public string codigoPrd { get; set; }
        public int contEmpCompra { get; set; }
        public decimal costoCompra { get; set; }
        public string empaqueDesc { get; set; }
        public string tasaIvaDesc { get; set; }
        public bool metCalculoUtilidadIsLineal { get; set; }
        public bool admDivisa { get; set; }
        public decimal tasaCambio { get; set; }
        public decimal costoUnid 
        {
            get {
                var rt = 0m;
                if (contEmpCompra > 0) 
                {
                    rt = costoCompra / contEmpCompra; 
                }
                return rt; 
            } 
        }
        public decimal CostoxUnidad { get { return costoUnid; } }
        //
        public dataProducto()
        {
        }
        public string ProductoDesc { get { return codigoPrd + Environment.NewLine + descPrd; } }
        public string EmpCompraDesc { get { return "( "+empaqueDesc+" / "+ contEmpCompra.ToString().Trim() +" )"; } }
        public string CostoEmpCompraDesc { get { return "Costo Compra: "+Environment.NewLine + costoCompra.ToString("n2"); } }
        public string MetodoCalculoUtilidadDesc { get { return metCalculoUtilidadIsLineal ? "LINEAL" : "FINANCIERO"; } }
        public string CostoUndDesc { get { return "Csoto Und: " + Environment.NewLine + costoUnid.ToString("n2"); } }
        public string EsDivisaDesc { get { return admDivisa ? "SI" : "NO"; } }
        public string TasaCambioDesc { get { return "Tasa Cambio: " + Environment.NewLine + tasaCambio.ToString("n2"); } }
        public string TasaIvaDesc { get { return "Tasa Iva: " + Environment.NewLine + tasaIvaDesc; } }
    }
}