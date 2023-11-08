using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Aliado.PagoServ.General
{
    public class Filtro: baseFiltro
    {
        public enumerados.EstatusDoc EstatusDoc { get; set; }
        public int IdAliado { get; set; }
    }
}