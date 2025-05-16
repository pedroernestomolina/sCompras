using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPago.usesCase
{
    public class uc_VisualizarReciboPago: __.UsesCase.GestionPago.IVisualizarReciboPago
    {
        void __.UsesCase.GestionPago.IVisualizarReciboPago.Execute(string idRecibo)
        {
            srcTransporte.Reportes.IRepPlanilla _rep = new srcTransporte.Reportes.Planillas.ReciboCxpPagoEmitido.Imp();
            _rep.setIdDoc(idRecibo);
            _rep.Generar();
        }
    }
}
