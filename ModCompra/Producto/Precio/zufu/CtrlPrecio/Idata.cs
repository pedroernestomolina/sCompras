using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.zufu.CtrlPrecio
{
    public interface Idata
    {
        decimal Utilidad { get; set; }
        decimal PNeto { get; set; }
        decimal PFull { get; set; }
        decimal CostoxUnd { get; set; }
        int ContEmpVta { get; set; }
        decimal TasaIva { get; set; }
        enumerados.enumMetCalculoUtilidad MetCalculoUt { get; set; }
        //
        decimal UtilidadAnterior { get; }
        bool UtilidadIsError { get; }
        bool CambioPrecioIsOk { get; }
        string Descripcion { get; }
        decimal PrecioViejoParaComprar { get; }
        bool PrecioViejoParaComprarIsNeto { get; }
        //
        void Inicializa();
        void UtilidadVieja(decimal utilidad);
        void setPrecioViejo(decimal precio, bool isNeto);
        void setDescripcion(string desc);
    }
}