using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Interfaces.PanelPrincipal
{
    public interface IPanel: HlpGestion.IGestion
    {
        string GetTituloPanel { get; }
        IItemDesplegar GetItemActual { get; }
        object GetDataSource { get; }
        bool AbandonarFichaIsOK { get; }
        decimal GetMontoPendiente { get; }
        int GetCntItems { get; }
        string GetTextoBuscar { get; }
        //
        void setTextoBuscar(string _texto);
        //
        void BuscarCtasPendientes();
        void Proveedor_CtasPend();
        void Reporte_CtasPendiente_General();
        void GestionPago();
        void AbandonarFicha();
    }
}