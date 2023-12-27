using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Compras.Planilla.Retencion
{
    public abstract class baseFicha
    {
        public string anoRelRet { get; set; }
        public string mesRelRet { get; set; }
        public DateTime fechaRet { get; set; }
        public string prvNombre { get; set; }
        public string prvCiRif { get; set; }
        public string prvDirFiscal { get; set; }
        public string comprobanteRet { get; set; }
        public string numDoc { get; set; }
        public DateTime fechaEmiDoc { get; set; }
        public string numControlDoc { get; set; }
        public string tipoDoc { get; set; }
        public string aplica { get; set; }
        public decimal total { get; set; }
        public decimal exento { get; set; }
        public decimal base1 { get; set; }
        public decimal base2 { get; set; }
        public decimal base3 { get; set; }
        public decimal impuesto1 { get; set; }
        public decimal impuesto2 { get; set; }
        public decimal impuesto3 { get; set; }
        public decimal tasa1 { get; set; }
        public decimal tasa2 { get; set; }
        public decimal tasa3 { get; set; }
        public decimal retencion1 { get; set; }
        public decimal retencion2 { get; set; }
        public decimal retencion3 { get; set; }
        public decimal tasaRet { get; set; }
        public decimal totalRet { get; set; }
        public string maquinaFiscal { get; set; }
    }
}