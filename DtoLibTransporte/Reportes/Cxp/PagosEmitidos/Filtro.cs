using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Cxp.PagosEmitidos
{
    public class Filtro: baseFiltro
    {
        public enumerados.EstatusDoc EstatusDoc { get; set; }
        public string IdProveedor { get; set; }
    }
}