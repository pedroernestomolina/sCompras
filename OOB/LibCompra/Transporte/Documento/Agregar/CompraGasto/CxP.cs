using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto
{
    public class CxP
    {
        public DateTime fechaEmision { get; set; }
        public string siglasTipoDocumento { get; set; }
        public string documentoNro { get; set; }
        public DateTime fechaVencimiento { get; set; }
        public decimal importe { get; set; }
        public decimal acumulado { get; set; }
        public string autoProveedor { get; set; }
        public string nombreRazonSocialProveedor { get; set; }
        public string ciRifProveedor { get; set; }
        public string codigoProveedor { get; set; }
        public decimal resta { get; set; }
        public int signoTipoDocumento { get; set; }
        public int diasCredito { get; set; }
        public decimal importeDivisa { get; set; }
        public decimal acumuladoDivisa { get; set; }
        public decimal restaDivisa { get; set; }
        public decimal tasaDivisa { get; set; }
        public string notas { get; set; }
    }
}