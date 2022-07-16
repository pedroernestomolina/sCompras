using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class Precio
    {

        public enum enumModo { Financiero = 1, Lineal };
        public enum enumModoRedondeo { SinRedondeo = 1, Unidad, Decena };
        public enum enumPreferenciaPrecio { Neto = 1, Full };


        private enumModo modoCalculoUtilidad;
        private enumModoRedondeo modoRedondeo;
        private enumPreferenciaPrecio modoPrecio;
        private OOB.LibCompra.Producto.Utilidad.Ficha ficha;
        private decimal tasaCambioActual;
        private decimal costoDivisaUnd;


        public string autoPrd { get { return ficha.auto; } }
        public decimal pDivisaFull_1 
        {
            get 
            { 
                var rt = CalculoDivisaFull(ficha.utilidad_1, ficha.contenido_1, ficha.precio_1_habilitado); 
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero); 
                return rt; 
            }
        }
        public decimal pDivisaFull_2 
        {
            get
            {
                var rt = CalculoDivisaFull(ficha.utilidad_2, ficha.contenido_2, ficha.precio_2_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        public decimal pDivisaFull_3
        {
            get
            {
                var rt = CalculoDivisaFull(ficha.utilidad_3, ficha.contenido_3, ficha.precio_3_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        public decimal pDivisaFull_4
        {
            get
            {
                var rt = CalculoDivisaFull(ficha.utilidad_4, ficha.contenido_4, ficha.precio_4_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        public decimal pDivisaFull_5
        {
            get
            {
                var rt = CalculoDivisaFull(ficha.utilidad_5, ficha.contenido_5, ficha.precio_5_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        public decimal PrecioNeto_1 
        { 
            get 
            {
                var rt = CalculoPNeto(ficha.utilidad_1, ficha.contenido_1, ficha.precio_1_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            } 
        }
        public decimal PrecioNeto_2
        {
            get
            {
                var rt = CalculoPNeto(ficha.utilidad_2, ficha.contenido_2, ficha.precio_2_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        public decimal PrecioNeto_3
        {
            get
            {
                var rt = CalculoPNeto(ficha.utilidad_3, ficha.contenido_3, ficha.precio_3_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        public decimal PrecioNeto_4
        {
            get
            {
                var rt = CalculoPNeto(ficha.utilidad_4, ficha.contenido_4, ficha.precio_4_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        public decimal PrecioNeto_5
        {
            get
            {
                var rt = CalculoPNeto(ficha.utilidad_5, ficha.contenido_5, ficha.precio_5_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        //
        public decimal pDivisaFull_May_1
        {
            get
            {
                var rt = CalculoDivisaFull(ficha.utilidad_may_1, ficha.contenido_may_1, ficha.precio_may_1_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        public decimal pDivisaFull_May_2
        {
            get
            {
                var rt = CalculoDivisaFull(ficha.utilidad_may_2, ficha.contenido_may_2, ficha.precio_may_2_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        public decimal PrecioNeto_May_1
        {
            get
            {
                var rt = CalculoPNeto(ficha.utilidad_may_1, ficha.contenido_may_1, ficha.precio_may_1_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }
        public decimal PrecioNeto_May_2
        {
            get
            {
                var rt = CalculoPNeto(ficha.utilidad_may_2, ficha.contenido_may_2, ficha.precio_may_2_habilitado);
                rt = Math.Round(rt, 2, MidpointRounding.AwayFromZero);
                return rt;
            }
        }


        public Precio()
        {
            tasaCambioActual = 0.0m;
            costoDivisaUnd = 0.0m;
        }


        private decimal CalculoUtilidad(decimal ut, int contenido, bool habilitado=true) 
        {
            var rt = 0.0m;
            var ct = 0.0m;
            ct = costoDivisaUnd * contenido;

            if (ut == 0.0m)
                if (habilitado)
                    return ct;
                else
                    return 0.0m;

            if (modoCalculoUtilidad == enumModo.Lineal)
            {
                rt = ((ct * (ut / 100)) + ct);
            }
            if (modoCalculoUtilidad == enumModo.Financiero)
            {
                rt = ct;
                if (ut >= 0 && ut < 100)
                {
                    rt = (rt / ((100 - ut) / 100));
                }
            }

            return rt;
        }

        private decimal CalculoDivisaFull(decimal ut, int contenido, bool precio_habilitado=true)
        {
            var rt = 0.0m;
            rt = CalculoUtilidad(ut, contenido, precio_habilitado);
            //rt = CaculoIva(rt * contenido);
            rt = CaculoIva(rt);
            return rt;
        }

        private decimal CalculoPNeto(decimal ut, int contenido, bool precio_habilitado=true)
        {
            var rt = 0.0m;
            rt = CalculoUtilidad(ut, contenido, precio_habilitado);
            //rt = CalculaPrecio(rt*contenido);
            rt = CalculaPrecio(rt);
            return rt;
        }

        private decimal CalculaPrecio(decimal p)
        {
            var rt = 0.0m;
            rt = p * tasaCambioActual;
            if (modoPrecio == enumPreferenciaPrecio.Full) 
            {
                rt = CaculoIva(rt);
                switch (modoRedondeo)
                {
                    case enumModoRedondeo.Unidad:
                        rt = Helpers.MetodosExtension.RoundUnidad((int)rt);
                        break;
                    case enumModoRedondeo.Decena:
                        rt = Helpers.MetodosExtension.RoundDecena((int)rt);
                        break;
                }
                rt = CalculaNeto(rt);
            }
            else
            {
                switch (modoRedondeo)
                {
                    case enumModoRedondeo.Unidad:
                        rt = Helpers.MetodosExtension.RoundUnidad((int)rt);
                        break;
                    case enumModoRedondeo.Decena:
                        rt = Helpers.MetodosExtension.RoundDecena((int)rt);
                        break;
                }
            }
            return rt;
        }

        private decimal CalculaNeto(decimal p)
        {
            var rt = 0.0m;
            rt = p / ((ficha.tasaIva / 100) + 1);
            return rt;
        }

        private decimal CaculoIva(decimal mt)
        {
            var rt = 0.0m;
            rt = mt + (mt * ficha.tasaIva / 100);
            return rt;
        }

        public Precio(OOB.LibCompra.Producto.Utilidad.Ficha ficha)
        {
            this.ficha = ficha;
        }

        public void setCostoDivisaUnd(decimal costo)
        {
            costoDivisaUnd = costo;
        }

        public void setTasaCambioActual(decimal tasaCambio)
        {
            tasaCambioActual = tasaCambio;
        }

        public void setRedondeo(OOB.LibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta forzarRedondeo)
        {
            switch (forzarRedondeo) 
            {
                case OOB.LibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.SinRedeondeo:
                    modoRedondeo = enumModoRedondeo.SinRedondeo;
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Unidad:
                    modoRedondeo = enumModoRedondeo.Unidad;
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumForzarRedondeoPrecioVenta.Decena:
                    modoRedondeo = enumModoRedondeo.Decena;
                    break;
            }
        }

        public void setCalculoUtilidad(OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad metodoCalculoUtilidad)
        {
            switch (metodoCalculoUtilidad)
            {
                case OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Lineal:
                    modoCalculoUtilidad = enumModo.Lineal;
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Financiero: 
                    modoCalculoUtilidad = enumModo.Financiero;
                    break;
            }
        }

        public void setPreferenciaRegistroPrecio(OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio preferencia)
        {
            switch (preferencia)
            {
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Neto :
                    modoPrecio=  enumPreferenciaPrecio.Neto;
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaRegistroPrecio.Full :
                    modoPrecio=  enumPreferenciaPrecio.Full;
                    break;
            }
        }

    }

}