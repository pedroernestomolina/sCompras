using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Aliado.Anticipo.General
{
    public class Ficha
    {
        public int idMov { get; set; }
        public int idAliado { get; set; }
        public string nombreAliado { get; set; }
        public string ciRifAliado { get; set; }
        public DateTime fecha { get; set; }
        public string numRecibo { get; set; }
        public string motivo { get; set; }
        public decimal montoAntSolicitadoDiv { get; set; }
        public string aplicaRet { get; set; }
        public decimal tasaRet { get; set; }
        public decimal sustraendoMonAct { get; set; }
        public decimal montoRetMonAct { get; set; }
        public decimal montoPagoDiv { get; set; }
        public string estatusAnulado { get; set; }
        public decimal factorCambio { get; set; }
    }
}