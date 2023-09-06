using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Documento.Entidad
{
    public class Documento
    {
        public string docAuto { get; set; }
        public string docAutoCxp { get; set; }
        //
        public string prvAuto { get; set; }
        public string prvNombre { get; set; }
        public string prvCiRif { get; set; }
        public string prvCodigo { get; set; }
        public string prvDirFiscal { get; set; }
        public string prvTelefono { get; set; }
        //
        public string docNumero { get; set; }
        public string docControl { get; set; }
        public string docNumOrdenCompra { get; set; }
        public DateTime docFechaRegistro { get; set; }
        public string docHoraRegistro { get; set; }
        public DateTime docFechaEmision { get; set; }
        public DateTime docFechaVencimiento { get; set; }
        public int docDiasCredito { get; set; }
        public string docMesRelacion { get; set; }
        public string docAnoRelacion { get; set; }
        public string docNotas { get; set; }
        public int docCntRenglones { get; set; }
        public string docEstatus { get; set; }
        public string docTipoDocCompra { get; set; }
        public string docEstatusFiscal { get; set; }
        public string docCondicionPago { get; set; }
        public string docAplicaNumRef { get; set; }
        public string docAplicaCodDocRef { get; set; }
        //
        public decimal subTotalNeto { get; set; }
        public decimal montoExento { get; set; }
        public decimal montoBase { get; set; }
        public decimal montoImpuesto { get; set; }
        public decimal subTotal { get; set; }
        public decimal montoIGTF { get; set; }
        public decimal montoTotal { get; set; }
        public decimal montoBase1 { get; set; }
        public decimal montoBase2 { get; set; }
        public decimal montoBase3 { get; set; }
        public decimal montoIva1 { get; set; }
        public decimal montoIva2 { get; set; }
        public decimal montoIva3 { get; set; }
        public decimal tasaIva1 { get; set; }
        public decimal tasaIva2 { get; set; }
        public decimal tasaIva3 { get; set; }
        public decimal factorCambio { get; set; }
        public decimal montoDivisa { get; set; }
        public decimal montoNeto { get; set; }
        public decimal subTotalImpuesto { get; set; }
        //
        public decimal tasaRetIva { get; set; }
        public decimal montoRetIva { get; set; }
        public decimal tasaRetIslr { get; set; }
        public decimal montoRetIslr { get; set; }
        public decimal sustraendoRetIslr { get; set; }
        public decimal totalRetIslr { get; set; }
        //
        public string equipoEstacion { get; set; }
        //
        public string sistDocAuto { get; set; }
        public string sistDocCodigo { get; set; }
        public string sistDocNombre { get; set; }
        public string sistDocModulo { get; set; }
        public string sistDocSiglas { get; set; }
        public int sistDocSigno { get; set; }
        //
        public string usuAuto{ get; set; }
        public string usuNombre { get; set; }
        public string usuCodigo { get; set; }
        //
        public int conceptoAuto { get; set; }
        public string conceptoCodigo { get; set; }
        public string conceptoDesc { get; set; }
        //
        public string sucAuto { get; set; }
        public string sucCodigo { get; set; }
        public string sucDesc { get; set; }
    }
}
