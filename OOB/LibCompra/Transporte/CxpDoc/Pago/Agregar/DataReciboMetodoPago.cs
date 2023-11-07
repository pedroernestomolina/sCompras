using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar
{
    public class DataReciboMetodoPago
    {
        public string autoMedPago { get; set; }
        public string codigoMedPago { get; set; }
        public string descMedPago { get; set; }
        public string autoUsuario { get; set; }
        public string OpLote { get; set; }
        public string OpRef { get; set; }
        public string OpBanco { get; set; }
        public string OpNroCta { get; set; }
        public string OpNroTransf { get; set; }
        public DateTime OpFecha { get; set; }
        public string OpDetalle { get; set; }
        public decimal OpMonto { get; set; }
        public decimal OpTasa { get; set; }
        public bool OpAplicaConversion { get; set; }
    }
}