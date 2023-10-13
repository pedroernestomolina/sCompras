using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Beneficiario.Mov.Agregar
{
    public class MovCaja
    {
        public int idCaja { get; set; }
        public string descCaja { get; set; }
        public string codCaja { get; set; }
        public string esDivisa { get; set; }
        public decimal monto { get; set; }
        public CajaMovimiento movimientoCaja { get; set; }
    }
}