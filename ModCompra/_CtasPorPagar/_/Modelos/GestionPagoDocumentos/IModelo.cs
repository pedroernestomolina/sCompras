using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Modelos.GestionPagoDocumentos
{
    public interface IModelo
    {
        string GetEntidadInfo { get; }
        int GetCantDocPend { get; }
        decimal GetMontoPend { get; }
        int GetCantDocAbonado { get; }
        decimal GetMontoAbonado { get; }
        IEnumerable<IItemDesplegar> GetItems { get; }
        //
        void Inicializa();
        void setDataCargar(string p, IEnumerable<GestionPago.IDoc> doc);
        void LimpiarAbonos();
    }
}
