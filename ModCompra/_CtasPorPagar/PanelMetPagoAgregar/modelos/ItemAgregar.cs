using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelMetPagoAgregar.modelos
{
    public class ItemAgregar: __.Modelos.PanelMetPagoAgregar.IItemAgregar
    {
        public decimal Monto { get; set; }
        public decimal FactorCambio { get; set; }
        public bool AplicaFactor { get; set; }
        public decimal MontoAplica { get; set; }
        public string Banco { get; set; }
        public string NroCta { get; set; }
        public string CheqRefTranf { get; set; }
        public string DetalleOp { get; set; }
        public DateTime FechaOp { get; set; }
        public string Referencia { get; set; }
        public string Lote { get; set; }
        public decimal ImporteMonDiv { get; set; }
        public decimal ImporteMonAct { get; set; }
        public string IdMedioPago { get; set; }
        public string CodigoMedioPago { get; set; }
        public string DescMedioPago { get; set; }
    }
}
