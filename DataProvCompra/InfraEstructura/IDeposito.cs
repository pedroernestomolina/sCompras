using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IDeposito
    {

        OOB.ResultadoLista<OOB.LibCompra.Deposito.Data.Ficha> Deposito_GetLista(OOB.LibCompra.Deposito.Lista.Filtro filtro);
        OOB.ResultadoEntidad<OOB.LibCompra.Deposito.Data.Ficha> Deposito_GetFicha(string autoDeposito);

    }

}