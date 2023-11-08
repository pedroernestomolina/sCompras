using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.General
{
    public class Filtro: baseFiltro
    {
        public int IdAliado { get; set; }
        public enumerados.EstatusDoc EstatusDoc { get; set; }
    }
}