using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.zufu.ActualizarPrecio.Vista
{
    public interface IdataProducto
    {
        string idPrd { get; set; }
        string descPrd { get; set; }
        string codigoPrd { get; set; }
        int contEmpCompra { get; set; }
        decimal costoCompra { get; set; }
        decimal tasaIva { get; set; }
        string empaqueDesc { get; set; }
        bool metCalculoUtilidadIsLineal { get; set; }
        decimal tasaCambio { get; set; }
        //
        decimal CostoxUnidad { get; }
        string ProductoDesc { get; }
        string EmpCompraDesc { get; }
        string CostoEmpCompraDesc { get; }
        string MetodoCalculoUtilidadDesc { get; }
        string CostoUndDesc { get; }
        string EsDivisaDesc { get; }
        string TasaCambioDesc { get; }
        string TasaIvaDesc { get; }
    }
}