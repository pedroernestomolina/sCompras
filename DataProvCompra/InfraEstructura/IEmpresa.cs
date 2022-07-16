using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{
    
    public interface IEmpresa
    {

        OOB.ResultadoEntidad<OOB.LibCompra.Empresa.Data.Ficha> Empresa_Datos();
        OOB.ResultadoEntidad<OOB.LibCompra.Empresa.Fiscal.Ficha> Empresa_GetTasas();

    }

}