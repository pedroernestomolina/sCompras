using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar.PagoPorRetencion
{
    public class DocRetencionDet
    {
        public string numDocRefRet { get; set; }
        public string numControlDocRefRet { get; set; }
        public string numAplicaDocRefRet { get; set; }
        public DateTime fechaDocRefRet { get; set; }
        public string ciRifDocRefRet { get; set; }
        public string sistTipoDocRefRet { get; set; }
        public decimal montoExento { get; set; }
        public decimal montoBase { get; set; }
        public decimal montoImpuesto { get; set; }
        public decimal montoTotal { get; set; }
        public decimal base1 { get; set; }
        public decimal base2 { get; set; }
        public decimal base3 { get; set; }
        public decimal impuesto1 { get; set; }
        public decimal impuesto2 { get; set; }
        public decimal impuesto3 { get; set; }
        public decimal tasa1 { get; set; }
        public decimal tasa2 { get; set; }
        public decimal tasa3 { get; set; }
        public decimal tasaRetencion { get; set; }
        public decimal montoRetencion { get; set; }
        public decimal sustraendoRetencion { get; set; }
        public decimal totalRetencion { get; set; }
        public decimal retIva1 { get; set; }
        public decimal retIva2 { get; set; }
        public decimal retIva3 { get; set; }
        //
        public string sistAutoDocRet { get; set; }
        public string sistTipoDocRet { get; set; }
        public int sistSignoDocRet { get; set; }
    }
}