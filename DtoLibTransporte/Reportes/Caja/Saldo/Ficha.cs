using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Caja.Saldo
{
    public class Ficha
    {
        public decimal? montoMonAct { get; set; }
        public decimal? montoMonDiv { get; set; }
        public string esDivisa { get; set; }
        public decimal saldoIni { get; set; }
    }
}