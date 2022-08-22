using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor> 
            Configuracion_PreferenciaBusquedaProveedor()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor>();

            var r01 = MyData.Configuracion_PreferenciaBusquedaProveedor();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProveedor)s;

            return rt;
        }
        public OOB.ResultadoEntidad<decimal> 
            Configuracion_TasaCambioActual()
        {
            var rt = new OOB.ResultadoEntidad<decimal>();

            var r01 = MyData.Configuracion_TasaCambioActual();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var cnf = r01.Entidad;
            var m1 = 0.0m;
            if (cnf.Trim() != "")
            {
                var style = NumberStyles.AllowDecimalPoint | NumberStyles.AllowThousands;
                var culture = CultureInfo.CreateSpecificCulture("es-ES");
                //var culture = CultureInfo.CreateSpecificCulture("en-EN");
                Decimal.TryParse(cnf, style, culture, out m1);
            }
            rt.Entidad = m1;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto> 
            Configuracion_PreferenciaBusquedaProducto()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto>();

            var r01 = MyData.Configuracion_PreferenciaBusquedaProducto();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto)s;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad> 
            Configuracion_MetodoCalculoUtilidad()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad>();

            var r01 = MyData.Configuracion_MetodoCalculoUtilidad();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad)s;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta> 
            Configuracion_ForzarRedondeoPrecioVenta()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta>();

            var r01 = MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta)s;

            return rt;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio> 
            Configuracion_PreferenciaRegistroPrecio()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio>();

            var r01 = MyData.Configuracion_PreferenciaRegistroPrecio();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            rt.Entidad = (OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio)s;

            return rt;
        }

        public OOB.ResultadoEntidad<bool> 
            Configuracion_GetPermitirCambiarPrecioAlRegistrarDocCompra()
        {
            var rt = new OOB.ResultadoEntidad<bool>();

            var r01 = MyData.Configuracion_GetPermitirCambiarPrecioAlRegistrarDocCompra();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }
            rt.Entidad = r01.Entidad.Trim().ToUpper()=="SI";

            return rt;
        }
        public OOB.Resultado 
            Configuracion_SetPermitirCambiarPrecioAlRegistrarDocCompra(bool cnf)
        {
            var rt = new OOB.Resultado();

            var dto = cnf ? "Si" : "No";
            var r01 = MyData.Configuracion_SetPermitirCambiarPrecioAlRegistrarDocCompra(dto);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            return rt;
        }

    }

}