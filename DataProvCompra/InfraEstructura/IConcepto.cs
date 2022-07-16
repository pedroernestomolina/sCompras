using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IConcepto
    {

        OOB.ResultadoEntidad<OOB.LibCompra.Concepto.Ficha> Concepto_PorMovCompra();
        OOB.ResultadoEntidad<OOB.LibCompra.Concepto.Ficha> Concepto_PorMovDevCompra();

    }

}