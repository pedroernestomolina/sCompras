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

        public DtoLib.ResultadoEntidad<DtoLibCompra.Concepto.Ficha> Concepto_PorMovCompra()
        {
            return ServiceProv.Concepto_GetFicha("0000000002");
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Concepto.Ficha> Concepto_PorMovDevCompra()
        {
            return ServiceProv.Concepto_GetFicha("0000000004");
        }

    }

}