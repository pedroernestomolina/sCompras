using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Interfaces.PanelMetPagoAgregar
{
    public interface IPanelAgregarEditar: HlpGestion.IGestion
    {
        string GetTituloFicha { get; }
        Object GetSourceMedPago { get; }
        decimal GetMonto { get; }
        decimal GetFactor { get; }
        bool GetAplicaFactor { get; }
        decimal GetMontoAplica { get; }
        string GetBanco { get; }
        string GetNroCta { get; }
        string GetCheqRefTrans { get; }
        DateTime GetFechaOp { get; }
        string GetDetalleOp { get; }
        string GetIdMedPago { get; }
        string GetReferencia { get; }
        string GetLote { get; }
        object GetMedioPago { get; }
        decimal GetImporteMonact { get; }
        decimal GetImporteMonDiv { get; }
        //
        void setMedPago(string id);
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
        bool ProcesarIsOK { get; }
        bool AbandonarIsOK { get; }
        void AbandonarFicha();
        void Procesar();

        //
        void CargarFactorCambio(decimal factor);
        void CargarMediosPago(IEnumerable<Modelos.GestionPago.IMedioPago> mediosPag);
    }
}