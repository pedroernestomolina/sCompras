using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IProducto
    {

        OOB.ResultadoLista<OOB.LibCompra.Producto.Data.Ficha> 
            Producto_GetLista(OOB.LibCompra.Producto.Lista.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibCompra.Producto.Data.Ficha> 
            Producto_GetFicha(string autoPrd);
        OOB.ResultadoEntidad<string> 
            Producto_GetCodigoRefProveedor(OOB.LibCompra.Producto.CodRefProveedor.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibCompra.Producto.Utilidad.Ficha> 
            Producto_GetUtilidadPrecio(string auto);
        OOB.Resultado 
            Producto_VerificaDepositoAsignado(OOB.LibCompra.Producto.VerificarDepositoAsignado.Ficha ficha);
        OOB.ResultadoLista<OOB.LibCompra.Producto.EmpaqueMedida.Lista.Ficha>
            Producto_EmpaqueMedida_GetLista();
        OOB.ResultadoEntidad<OOB.LibCompra.Producto.Precio.Capturar.Ficha>
            Producto_Precio_GetCapturar_ById(string idPrd);

    }

}