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

        public DtoLib.ResultadoLista<DtoLibCompra.Reportes.Proveedor.Maestro.Ficha> ReportesProv_Maestro(DtoLibCompra.Reportes.Proveedor.Maestro.Filtro filtro)
        {
            return ServiceProv.ReportesProv_Maestro(filtro);
        }

    }

}