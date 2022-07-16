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

        public DtoLib.ResultadoLista<DtoLibCompra.Maestros.Estado.Ficha> Estado_GetLista()
        {
            return ServiceProv.Estado_GetLista();
        }

    }

}