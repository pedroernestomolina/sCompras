using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_DocPend.Modo.Zufu.handlers
{
    public class hndPanel: basePanel, Interfaces.IZufuPanel
    {
        public override int Get_DocSeleccionadosAPagar_Cnt { get { return 3; } }
        public override decimal Get_DocSeleccionadosAPagar_Monto { get { return 1000; } }
        public override decimal Get_DocPendPorPagar_DeudaTotal { get { return 5000; } }
        public override decimal GetTotalMontoCtasPendientes { get { return 0m; } }
        //
        public hndPanel()
            : base()
        {
        }
        public override void Inicializa()
        {
        }
        public override void ListarCtasPagar()
        {
        }
    }
}