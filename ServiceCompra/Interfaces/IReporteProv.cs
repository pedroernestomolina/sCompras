using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces
{

    public interface IReporteProv
    {

        DtoLib.ResultadoLista<DtoLibCompra.Reportes.Proveedor.Maestro.Ficha> ReportesProv_Maestro(DtoLibCompra.Reportes.Proveedor.Maestro.Filtro filtro);

    }

}