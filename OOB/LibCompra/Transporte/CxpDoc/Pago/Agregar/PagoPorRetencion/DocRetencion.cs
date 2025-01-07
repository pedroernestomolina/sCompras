using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion
{
    public class DocRetencion
    {
        public string PrvAuto { get; set; }
        public string PrvCodigo { get; set; }
        public string PrvNombre { get; set; }
        public string PrvDirFiscal { get; set; }
        public string PrvCiRif { get; set; }
        public decimal MontoExento { get; set; }
        public decimal MontoBase1 { get; set; }
        public decimal MontoImpuesto1 { get; set; }
        public decimal MontoBase2 { get; set; }
        public decimal MontoImpuesto2 { get; set; }
        public decimal MontoBase3 { get; set; }
        public decimal MontoImpuesto3 { get; set; }
        public decimal MontoTotal { get; set; }
        public decimal TasaRetencion { get; set; }
        public decimal MontoRetencion { get; set; }
        public string SistDocCodigo { get; set; }
        public string SistDocNombre { get; set; }
        public string SistDocAuto { get; set; }
        public decimal retMonto { get; set; }
        public decimal retSustraendo { get; set; }
        public List<DocRetencionDet> docRetDetalle { get; set; }
        public CxP cxpRetencion { get; set; }
        public Recibo cxpReciboRetencion { get; set; }
        public bool EsIva { get; set; }
    }
}