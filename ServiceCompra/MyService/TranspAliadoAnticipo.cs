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
        public DtoLib.Resultado 
            Transporte_Aliado_Anticipo_Agregar(DtoLibTransporte.Aliado.Anticipo.Agregar.Ficha ficha)
        {
            return ServiceProv.Transporte_Aliado_Anticipo_Agregar(ficha);
        }
    }
}
