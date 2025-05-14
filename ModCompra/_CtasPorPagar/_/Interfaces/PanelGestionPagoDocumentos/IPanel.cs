using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Interfaces.PanelGestionPagoDocumentos
{
    public interface IPanel: HlpGestion.IGestion
    {
        string GetTituloFrm { get; }
        string GetEntidadInfo { get; }
        int GetCntDocPendiente { get; }
        decimal GetMontoPendiente { get; }
        decimal GetMontoAbonado { get; }
        int GetCntDocAbonado { get; }
        string GetNotasAbono { get; }
        Object GetDataSource { get; }
        //
        bool AbandonarIsOK { get; }
        void AbandonarFicha();
        //
        void setDataCargar(string p, IEnumerable<Modelos.GestionPago.IDoc> enumerable);
        void setTituloPanel(string titulo);
        //
        void AbonarCta();
        void VisualizarDocumento();
        void LimpiarAbonos();
    }
}
