using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Documento.Agregar.CompraGasto
{
    public class Documento
    {
        public string numeroDoc { get; set; }
        public string numeroControlDoc { get; set; }
        public DateTime fechaEmisDoc { get; set; }
        public DateTime fechaVencDoc { get; set; }
        public string codicionPagoDoc { get; set; }
        public int diasCreditoDoc { get; set; }
        public string notasDoc { get; set; }
        //
        public string codTipoDoc { get; set; }
        public int signoDoc { get; set; }
        public string siglasDoc { get; set; }
        public string moduloDoc { get; set; }
        public string nombreDoc { get; set; }
        //
        public string autoProv { get; set; }
        public string codigoProv { get; set; }
        public string nombreProv{ get; set; }
        public string dirFiscalProv { get; set; }
        public string ciRifProv { get; set; }
        public string telefonoProv { get; set; }
        //
        public string autoUsuario{ get; set; }
        public string nombreUsuario { get; set; }
        public string codigoUsuario { get; set; }
        //
        public decimal montoExento { get; set; }
        public decimal montoBase1 { get; set; }
        public decimal montoBase2 { get; set; }
        public decimal montoBase3 { get; set; }
        public decimal montoImpuesto1 { get; set; }
        public decimal montoImpuesto2 { get; set; }
        public decimal montoImpuesto3 { get; set; }
        public decimal montoBase { get; set; }
        public decimal montoImpuesto { get; set; }
        public decimal montoTotal { get; set; }
        public decimal tasaIva1 { get; set; }
        public decimal tasaIva2 { get; set; }
        public decimal tasaIva3 { get; set; }
        //
        public decimal subTotalNeto { get; set; }
        public decimal subTotalImpuesto { get; set; }
        public decimal montoNeto { get; set; }
        public decimal subTotal { get; set; }
        public decimal montoDivisa { get; set; }
        public decimal factorCambio { get; set; }
        //
        public decimal tasaRetencionIva { get; set; }
        public decimal tasaRetencionISLR { get; set; }
        public decimal montoRetencionIva { get; set; }
        public decimal montoRetencionISLR { get; set; }
        //
        public string aplicaNumeroDoc { get; set; }
        public DateTime aplicaFechaDoc{ get; set; }
        public string aplicaCodTipoDoc { get; set; }
        //
        public string codigoSucursal { get; set; }
        public string autoSucursal { get; set; }
        public string descSucursal { get; set; }
        public string estacionEquipo { get; set; }
        //
        public string comprobanteRetencionNro { get; set; }
        public string comprobanteRetencionISLR { get; set; }
        public DateTime fechaRetencion { get; set; }
        //
        public string estatusFiscal { get; set; }
        public int idComprasConcepto { get; set; }
        public string descComprasConcepto { get; set; }
        public string codigoComprasConcepto { get; set; }
        //
        public decimal saldoPendiente { get; set; }
    }
}