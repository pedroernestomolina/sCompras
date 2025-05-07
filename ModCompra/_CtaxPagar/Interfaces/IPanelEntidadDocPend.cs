using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra._CtaxPagar.Interfaces
{
    public interface IPanelEntidadDocPend : HlpGestion.IGestion
    {
        string GetTituloFrm { get; }
        string GetEntidadData { get; }
        decimal GetMontoImporte { get; }
        decimal GetMontoAcumulado { get; }
        decimal GetMontoResta { get; }
        int GetCantDoc { get; }
        Object GetDataSource { get; }
        string GetNotas { get; }
        bool AbandonarIsOK { get; }
        //
        void setIdEntidad(string id);
        void setEntidadInfo(string info);
        //
        void ReporteDocPend();
        void VisualizarDocumento();
        void AbandonarFicha();
    }
}