using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Aliado.Anticipo.Agregar
{
    public class Movimiento
    {
        public int idAliado { get; set; }
        public string ciRifAliado { get; set; }
        public string nombreAliado { get; set; }
        public DateTime fechaEmision { get; set; }
        public decimal montoNetoMonAct { get; set; }
        public decimal montoNetoMonDiv { get; set; }
        public decimal tasaFactor { get; set; }
        public string motivo { get; set; }
        public string aplicaRet { get; set; }
        public decimal tasaRet { get; set; }
        public decimal sustraendoRet { get; set; }
        public decimal montoRet { get; set; }
        public decimal montoPagoMonAct { get; set; }
        public decimal montoPagoMonDiv { get; set; }
    }
}