using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Compras.LibroSeniat
{
    public class Ficha
    {
        public DateTime fechaEmision { get; set; }
        public string prvCiRif { get; set; }
        public string prvRazonSocial { get; set; }
        public string numDoc { get; set; }
        public string numControl { get; set; }
        public string numDocAplica { get; set; }
        public decimal totalDoc { get; set; }
        public decimal montoExento { get; set; }
        public decimal montoBase1 { get; set; }
        public decimal montoIva1 { get; set; }
        public decimal tasa1 { get; set; }
        public decimal montoBase2 { get; set; }
        public decimal montoIva2 { get; set; }
        public decimal tasa2 { get; set; }
        public decimal montoBase3 { get; set; }
        public decimal montoIva3 { get; set; }
        public decimal tasa3 { get; set; }
        public string comprobanteRetencion { get; set; }
        public string maquinaFiscal { get; set; }
        public string codTipoDoc { get; set; }
    }
}