using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura
{

    public interface IReporteProv
    {

        OOB.ResultadoLista<OOB.LibCompra.ReporteProv.Maestro.Ficha> ReportesProv_Maestro(OOB.LibCompra.ReporteProv.Maestro.Filtro filtro);

    }

}