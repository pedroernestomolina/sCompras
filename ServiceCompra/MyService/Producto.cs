using ServiceCompra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.MyService
{
    
    public partial class Service: IService
    {

        public DtoLib.ResultadoLista<DtoLibCompra.Producto.Lista.Resumen> 
            Producto_GetLista(DtoLibCompra.Producto.Lista.Filtro filtro)
        {
            return ServiceProv.Producto_GetLista (filtro);
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Producto.Data.Ficha> 
            Producto_GetFicha(string autoPrd)
        {
            return ServiceProv.Producto_GetFicha(autoPrd);
        }
        public DtoLib.ResultadoEntidad<string> 
            Producto_GetCodigoRefProveedor(DtoLibCompra.Producto.CodigoRefProveedor.Filtro filtro)
        {
            return ServiceProv.Producto_GetCodigoRefProveedor(filtro);
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Producto.Utilidad.Ficha> 
            Producto_GetUtilidadPrecio(string auto)
        {
            return ServiceProv.Producto_GetUtilidadPrecio(auto);
        }
        public DtoLib.Resultado 
            Producto_VerificaDepositoAsignado(DtoLibCompra.Producto.VerificarDepositoAsignado.Ficha ficha)
        {
            return ServiceProv.Producto_VerificaDepositoAsignado(ficha);
        }
        public DtoLib.ResultadoEntidad<DtoLibCompra.Producto.Precio.Capturar.Ficha> 
            Producto_Precio_GetCapturar_ById(string idPrd)
        {
            return ServiceProv.Producto_Precio_GetCapturar_ById(idPrd);
        }
        public DtoLib.ResultadoLista<DtoLibCompra.Producto.EmpaqueMedida.Lista.Ficha> 
            Producto_EmpaqueMedida_GetLista()
        {
            return ServiceProv.Producto_EmpaqueMedida_GetLista();
        }

        //
        public DtoLib.ResultadoEntidad<DtoLibCompra.Producto.EmpaqueCompra.Ficha> 
            Producto_EmpaquesCompra_GetFicha(string idPrd)
        {
            return ServiceProv.Producto_EmpaquesCompra_GetFicha(idPrd);
        }
    }

}