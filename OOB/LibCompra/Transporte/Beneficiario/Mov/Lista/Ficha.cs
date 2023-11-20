using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Beneficiario.Mov.Lista
{
    public class Ficha
    {
        public int idMov { get; set; }
        public string reciboNro { get; set; }
        public DateTime fechaReg { get; set; }
        public string nombreBene { get; set; }
        public string cirifBene { get; set; }
        public decimal montoDiv { get; set; }
        public string estatusAnulado { get; set; }
        public string descConcepto { get; set; }
        public string codConcepto { get; set; }
    }
}