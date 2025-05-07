using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.Interfaces
{
    public interface IAgregarEditar : HlpGestion.IGestion
    {
        string GetTituloFicha { get; }
        Object GetMetCobroSource { get; }
        decimal GetMonto { get; }
        decimal GetFactor { get; }
        string GetBanco { get; }
        string GetNroCta { get; }
        string GetCheqRefTrans { get; }
        DateTime GetFechaOp { get; }
        string GetDetalleOp { get; }
        bool GetAplicaFactor { get; }
        string GetMetCobroID { get; }
        string GetReferencia { get; }
        string GetLote { get; }
        //
        void setMetCobro(string id);
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
    }
}