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

        public DtoLib.ResultadoLista<DtoLibCompra.Sucursal.Lista.Resumen> Sucursal_GetLista()
        {
            return ServiceProv.Sucursal_GetLista();
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Sucursal.Data.Ficha> Sucursal_GetFicha(string autoSucursal)
        {
            return ServiceProv.Sucursal_GetFicha(autoSucursal);
        }

    }

}