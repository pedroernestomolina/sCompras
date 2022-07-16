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

        public DtoLib.ResultadoLista<DtoLibCompra.Deposito.Lista.Resumen> Deposito_GetLista(DtoLibCompra.Deposito.Lista.Filtro filtro)
        {
            return ServiceProv.Deposito_GetLista(filtro);
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Deposito.Data.Ficha> Deposito_GetFicha(string autoDeposito)
        {
            return ServiceProv.Deposito_GetFicha(autoDeposito);
        }

    }

}