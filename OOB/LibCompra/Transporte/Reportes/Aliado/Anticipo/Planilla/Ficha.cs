using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Aliado.Anticipo.Planilla
{
    public class Ficha
    {
        public DateTime fechaEmision { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string ciRifAliado { get; set; }
        public string nombreAliado { get; set; }
        public decimal montoSolicitado { get; set; }
        public decimal tasaFactor { get; set; }
        public string motivo { get; set; }
        public string aplicaRet { get; set; }
        public decimal tasaRet { get; set; }
        public decimal sustraendo { get; set; }
        public decimal montoRet { get; set; }
        public decimal montoPagado { get; set; }
        public string numRecibo { get; set; }
    }
}