using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Beneficiario.Movimiento
{
    public class Fitro
    {
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public string Estatus { get; set; }
        public int IdBeneficiario { get; set; }
    }
}