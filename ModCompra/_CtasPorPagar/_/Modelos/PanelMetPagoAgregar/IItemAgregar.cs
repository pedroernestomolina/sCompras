using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Modelos.PanelMetPagoAgregar
{
    public interface IItemAgregar
    {
        decimal Monto { get; set; }
        decimal FactorCambio { get; set; }
        bool AplicaFactor { get; set; }
        decimal MontoAplica { get; set; }
        string Banco { get; set; }
        string NroCta { get; set; }
        string CheqRefTranf { get; set; }
        string DetalleOp { get; set; }
        DateTime FechaOp { get; set; }
        string Referencia { get; set; }
        string Lote { get; set; }
        decimal ImporteMonDiv { get; set; }
        decimal ImporteMonAct { get; set; }
        string IdMedioPago { get; set; }
        string CodigoMedioPago { get; set; }
        string DescMedioPago { get; set; }
    }
}