using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.General
{
    public class Ficha
    {
        public int idMov { get; set; }
        public int idAliado { get; set; }
        public string nombreAliado { get; set; }
        public string codigoAliado { get; set; }
        public string cirifAliado { get; set; }
        public string numRecibo { get; set; }
        public DateTime fecha { get; set; }
        public string motivo { get; set; }
        public decimal tasaFactor { get; set; }
        public decimal montoPagoSelMonDiv { get; set; }
        public string aplicaRet { get; set; }
        public decimal tasaRet { get; set; }
        public decimal retencion { get; set; }
        public decimal sustraendo { get; set; }
        public decimal montoRetMonAct { get; set; }
        public decimal totalPagoMonDiv { get; set; }
        public string estatusAnulado { get; set; }
        public int cntServPag { get; set; }
        public string estatusProcesado { get; set; }
    }
}