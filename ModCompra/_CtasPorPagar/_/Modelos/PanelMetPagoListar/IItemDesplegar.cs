﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Modelos.PanelMetPagoListar
{
    public interface IItemDesplegar
    {
        decimal Monto { get; set; }
        decimal FactorCambio { get; set; }
        string Banco { get; set; }
        string NroCta { get; set; }
        string CheqRefTranf { get; set; }
        string DetalleOp { get; set; }
        DateTime FechaOp { get; set; }
        bool AplicaFactor { get; set; }
        string Referencia { get; set; }
        string Lote { get; set; }
        decimal ImporteMonDiv { get; set; }
        decimal ImporteMonAct { get; set; }
        string DescMetCobro { get; set; }
    }
}
