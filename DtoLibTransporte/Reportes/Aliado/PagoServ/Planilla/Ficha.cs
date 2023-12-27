using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Aliado.PagoServ.Planilla
{
    public class Ficha
    {
        public DateTime fechaEmision { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string nombreAliado { get; set; }
        public string ciRifAliado { get; set; }
        public string numRecibo { get; set; }
        public int cntServ { get; set; }
        public string motivo { get; set; }
        public decimal montoAPagar { get; set; }
        public decimal tasaFactor{ get; set; }
        public string aplicaRet { get; set; }
        public decimal tasaRet { get; set; }
        public decimal retencion { get; set; }
        public decimal sustraendo { get; set; }
        public decimal montoRetMonAct { get; set; }
        public decimal montoRetMonDiv { get; set; }
        public decimal totalPago { get; set; }
        public decimal anticipo { get; set; }
        public decimal  montoAPagarMonAct { get; set; }
        public decimal tasaPromFactorAnticipo { get; set; }
        public List<Serv> serv { get; set; }
        public List<Caja> caja { get; set; }
    }
}