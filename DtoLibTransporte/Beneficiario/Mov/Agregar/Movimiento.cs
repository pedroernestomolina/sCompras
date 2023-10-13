using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Beneficiario.Mov.Agregar
{
    public class Movimiento
    {
        public int idBeneficiario { get; set; }
        public int idConcepto { get; set; }
        public DateTime fechaMov { get; set; }
        public string nombreBeneficiario { get; set; }
        public string ciRifBeneficiario { get; set; }
        public string descConcepto { get; set; }
        public string codConcepto { get; set; }
        public decimal montoMonDiv { get; set; }
        public decimal factorTasa { get; set; }
        public string notasMov { get; set; }
    }
}