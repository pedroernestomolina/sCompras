using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.Interfaces
{
    public interface IPanel
    {
        decimal GetMontoRecibido { get; }
        int GetCntMetRecibido { get; }
        IEnumerable<object> GetListaMetPago {get;}
        //
        void Inicializa();
        void AgregarMetPago();
        void ListarMetPago();
        //
        void setFactorDivisa(decimal fact);
    }
}