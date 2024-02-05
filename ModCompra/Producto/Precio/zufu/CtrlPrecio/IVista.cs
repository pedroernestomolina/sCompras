using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.zufu.ActualizarPrecio.Vista
{
    public interface IVista: HlpGestion.IGestion
    {
        Utils.Control.Boton.Procesar.IProcesar BtProcesar { get; }
        Utils.Control.Boton.Abandonar.IAbandonar BtAbandonar { get; }
        IdataProducto Data { get; }
        IMatPrecio PrecioEmp1 { get; }
        IMatPrecio PrecioEmp2 { get; }
        IMatPrecio PrecioEmp3 { get; }
        IMatPrecio[] DataExportar { get; }
        //
        void setProductoCargar(IdataProducto fichaPrd);
        void setImportarPrecios(IMatPrecio[] matPrecios);
        //
        void Procesar();
    }
}