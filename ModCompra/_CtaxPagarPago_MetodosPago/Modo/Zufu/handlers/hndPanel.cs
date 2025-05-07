using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.Modo.Zufu.handlers
{
    public class hndPanel: basePanel, Interfaces.IZufuPanel
    {
        public override decimal GetMontoRecibido { get { return 0m; } }
        public override int GetCntMetRecibido { get { return 0; } }
        public override IEnumerable<object> GetListaMetPago { get { return null; } }
        public hndPanel()
            : base()
        {
        }
        public override void Inicializa()
        {
        }
        public override void AgregarMetPago()
        {
        }
        public override void ListarMetPago()
        {
        }
        public override void setFactorDivisa(decimal fact)
        {
        }
    }
}