using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Interfaces
{
    public interface IPanelPrincipal: HlpGestion.IGestion
    {
        string GetTituloPanel { get; }
        object GetItemActual { get; }
        object GetDataSource { get; }
        bool AbandonarFichaIsOK { get; }
        decimal GetMontoPendiente { get; }
        int GetCntItems { get; }
        string GetTextoBuscar { get; }
        //
        void setTextoBuscar(string _texto);
        void BuscarCtasPendientes();
        void Proveedor_CtasPend();
        void Reporte_CtasPendiente_General();
        void GestionPago();
        void AbandonarFicha();
    }
}