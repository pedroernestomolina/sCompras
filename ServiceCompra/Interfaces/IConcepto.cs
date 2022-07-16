using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces
{
    
    public interface IConcepto
    {

        DtoLib.ResultadoEntidad<DtoLibCompra.Concepto.Ficha> Concepto_PorMovCompra();
        DtoLib.ResultadoEntidad<DtoLibCompra.Concepto.Ficha> Concepto_PorMovDevCompra();

    }

}