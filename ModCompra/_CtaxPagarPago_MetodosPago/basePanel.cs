using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago
{
    abstract public class basePanel: Interfaces.IPanel
    {
        abstract public decimal GetMontoRecibido { get; }
        abstract public int GetCntMetRecibido { get; }
        abstract public IEnumerable<object> GetListaMetPago { get; }
        //
        public basePanel()
        {
        }
        abstract public void Inicializa();
        abstract public void AgregarMetPago();
        abstract public void ListarMetPago();
        abstract public void setFactorDivisa(decimal fact);
    }
}
