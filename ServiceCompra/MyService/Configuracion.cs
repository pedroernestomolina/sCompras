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

        public DtoLib.ResultadoEntidad<DtoLibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor> Configuracion_PreferenciaBusquedaProveedor()
        {
            return ServiceProv.Configuracion_PreferenciaBusquedaProveedor();
        }

        public DtoLib.ResultadoEntidad<string> Configuracion_TasaCambioActual()
        {
            return ServiceProv.Configuracion_TasaCambioActual();
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto> Configuracion_PreferenciaBusquedaProducto()
        {
            return ServiceProv.Configuracion_PreferenciaBusquedaProducto();
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad> Configuracion_MetodoCalculoUtilidad()
        {
            return ServiceProv.Configuracion_MetodoCalculoUtilidad();
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> Configuracion_ForzarRedondeoPrecioVenta()
        {
            return ServiceProv.Configuracion_ForzarRedondeoPrecioVenta();
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio> Configuracion_PreferenciaRegistroPrecio()
        {
            return ServiceProv.Configuracion_PreferenciaRegistroPrecio();
        }

    }

}