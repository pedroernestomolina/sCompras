using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Interfaces.PanelDocumentos
{
    public interface IPanel: HlpGestion.IGestion
    {
        string GetTituloFrm { get; }
        string GetEntidadInfo { get; }
        decimal GetMontoImporte { get; }
        decimal GetMontoAcumulado { get; }
        decimal GetMontoResta { get; }
        int GetCantDoc { get; }
        string GetNotasDocumento { get; }
        Object GetDataSource { get; }
        //
        bool AbandonarIsOK { get; }
        void AbandonarFicha();
        //
        void setItemCargar(IItemDesplegar item);
        //
        void VisualizarDocumento();
        void ReporteDocumentos();
    }
}
