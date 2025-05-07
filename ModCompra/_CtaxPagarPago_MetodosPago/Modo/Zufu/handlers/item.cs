using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.Modo.Zufu.handlers
{
    public class item: _CtaxPagarPago_MetodosPago.Interfaces.IItem
    {
        public decimal Monto { get; set; }
        public decimal FactorCambio { get; set; }
        public string Banco { get; set; }
        public string NroCta { get; set; }
        public string CheqRefTranf { get; set; }
        public string DetalleOp { get; set; }
        public DateTime FechaOp { get; set; }
        public bool AplicaFactor { get; set; }
        public string Referencia { get; set; }
        public string Lote { get; set; }
        public decimal ImporteMonDiv { get; set; }
        public decimal ImporteMonAct { get; set; }
        public string DescMetCobro { get; set; }
        public LibUtilitis.Opcion.IData MedioPago { get; set; }
    }
}