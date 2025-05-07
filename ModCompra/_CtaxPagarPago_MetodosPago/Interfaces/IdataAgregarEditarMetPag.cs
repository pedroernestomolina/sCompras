﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.Interfaces
{
    public interface IdataAgregarEditarMetPag
    {
        decimal GetMonto { get; }
        decimal GetFactorCambio { get; }
        bool GetAplicaFactor { get; }
        decimal GetMontoAplica { get; }
        string GetBanco { get; }
        string GetNroCta { get; }
        string GetCheqRefTranf { get; }
        string GetDetalleOp { get; }
        DateTime GetFechaOp { get; }
        decimal GetTasa { get; }
        string GetReferencia { get; }
        string GetLote { get; }
        decimal ImporteMonDiv { get; }
        decimal ImporteMonAct { get; }
        LibUtilitis.Opcion.IData GetMetCobro { get; }
        //
        void setMetCobro(LibUtilitis.Opcion.IData data);
        void setMonto(decimal monto);
        void setFactor(decimal factor);
        void setBanco(string banco);
        void setCtaNro(string cta);
        void setChequeRefTranf(string cheqRefTranf);
        void setFechaOperacion(DateTime fecha);
        void setDetalleOperacion(string detalleOp);
        void setAplicaFactor(bool p);
        void setLote(string lote);
        void setReferencia(string referenc);
        //
        void Inicializa();
        bool IsValido();
    }
}