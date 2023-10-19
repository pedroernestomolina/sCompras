using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Beneficiario.Movimiento
{
    public class Ficha
    {
        public DateTime fechaReg { get; set; }
        public string nombreBene { get; set; }
        public string cirifBene { get; set; }
        public decimal montoDiv { get; set; }
        public string estatusAnulado { get; set; }
        public string descConcepto { get; set; }
        public string codConcepto { get; set; }
    }
}