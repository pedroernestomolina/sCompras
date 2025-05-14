using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.Interfaces.PanelMetPagoListar
{
    public interface IPanel: HlpGestion.IGestion 
    {
        object GetDataSource { get; }
        int GetCntItems { get; }
        decimal GetMontoRecibido { get; }
        string GetMetodoPagoOp { get; }
        decimal GetMontoOp { get; }
        DateTime GetFechaOp { get; }
        string GetDetalleOp { get; }
        string GetNroCtaOp { get; }
        string GetRefOp { get; }
        string GetBancoOp { get; }
        string GetAplicaFactorOp { get; }
        //
        IEnumerable<IItem> GetItems { get; }
        //
        void EliminarItem();
        void EditarItem();
        void AdicionarItem(object item);
    }
}