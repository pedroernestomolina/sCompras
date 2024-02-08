using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.zufu.CtrlPrecio
{
    public interface IPrecio
    {
        Idata Data { get; }
        //
        void setUtilidad(decimal ut);
        void setNeto(decimal neto);
        void setFull(decimal full);
        void setUtilidadVieja(decimal utAnterior);
        void setPrecioViejo(decimal precioViejo, bool isNeto);
        void setDescripcion(string desc);
        //
        void Inicializa();
        void ActualizarImportacion();
        //
        bool VerificarPrecio(decimal costoUnd);
    }
}