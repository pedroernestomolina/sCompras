using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Beneficiario.Planilla
{
    public class Ficha
    {
        public string numRecibo { get; set; }
        public DateTime fechaEmision { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string ciRifBene { get; set; }
        public string nombreBene { get; set; }
        public decimal montoSolicitado { get; set; }
        public decimal tasaFactor { get; set; }
        public string motivo { get; set; }
        public string descConcepto { get; set; }
        public string codConcepto { get; set; }
        public List<Caja> caja { get; set; }
    }
}