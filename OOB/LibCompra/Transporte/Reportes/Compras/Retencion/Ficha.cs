using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Compras.Retencion
{
    public class Ficha
    {
        public string idDoc { get; set; }
        public string numDoc { get; set; }
        public DateTime fechaDoc { get; set; }
        public string prvNombre { get; set; }
        public string prvCiRif { get; set; }
        public decimal totalDoc { get; set; }
        public decimal montoExento { get; set; }
        public decimal montoBase1 { get; set; }
        public decimal montoBase2 { get; set; }
        public decimal montoBase3 { get; set; }
        public decimal montoImp1 { get; set; }
        public decimal montoImp2 { get; set; }
        public decimal montoImp3 { get; set; }
        public decimal tasaRet { get; set; }
        public decimal totalRet { get; set; }
        public decimal retMonto { get; set; }
        public decimal retSustraendo { get; set; }
        public string estatusAnulado { get; set; }
    }
}