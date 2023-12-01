using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion.Islr
{
    public class Ficha: baseFicha
    {
        public string dirFiscal { get; set; }
        public string conceptoDoc { get; set; }
        public string conceptoCod { get; set; }
        public decimal subtRet { get; set; }
        public decimal sustraendoRet { get; set; }
        public string codXmlIslr { get; set; }
        public string descXmlIslr { get; set; }
    }
}