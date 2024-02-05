using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ILibCompras
{
    public interface IProducto
    {
        DtoLib.ResultadoLista<DtoLibCompra.Producto.Lista.Resumen>
            Producto_GetLista(DtoLibCompra.Producto.Lista.Filtro filtro);
        DtoLib.ResultadoEntidad<DtoLibCompra.Producto.Data.Ficha> 
            Producto_GetFicha(string autoPrd);
        DtoLib.ResultadoEntidad<string> 
            Producto_GetCodigoRefProveedor(DtoLibCompra.Producto.CodigoRefProveedor.Filtro filtro);
        DtoLib.ResultadoEntidad<DtoLibCompra.Producto.Utilidad.Ficha> 
            Producto_GetUtilidadPrecio(string auto);
        DtoLib.Resultado 
            Producto_VerificaDepositoAsignado(DtoLibCompra.Producto.VerificarDepositoAsignado.Ficha ficha);
        DtoLib.ResultadoEntidad<DtoLibCompra.Producto.Precio.Capturar.Ficha>
            Producto_Precio_GetCapturar_ById(string idPrd);
        DtoLib.ResultadoLista<DtoLibCompra.Producto.EmpaqueMedida.Lista.Ficha>
            Producto_EmpaqueMedida_GetLista();
        //
        DtoLib.ResultadoEntidad<DtoLibCompra.Producto.EmpaqueCompra.Ficha>
            Producto_EmpaquesCompra_GetFicha(string idPrd);
        //
        DtoLib.ResultadoEntidad<DtoLibCompra.Producto.ActualizarPrecioVenta.ObtenerData.Ficha>
            Producto_ActualizarPreciosVenta_ObtenerData_GetById(string idPrd);
    }
}