using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IConfiguracion
    {

        OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor> 
            Configuracion_PreferenciaBusquedaProveedor();
        OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto> 
            Configuracion_PreferenciaBusquedaProducto();
        OOB.ResultadoEntidad<decimal> 
            Configuracion_TasaCambioActual();
        OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad> 
            Configuracion_MetodoCalculoUtilidad();
        OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> 
            Configuracion_ForzarRedondeoPrecioVenta();
        OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio> 
            Configuracion_PreferenciaRegistroPrecio();
        
        OOB.ResultadoEntidad<bool> 
            Configuracion_GetPermitirCambiarPrecioAlRegistrarDocCompra();
        OOB.Resultado 
            Configuracion_SetPermitirCambiarPrecioAlRegistrarDocCompra(bool cnf);

    }

}