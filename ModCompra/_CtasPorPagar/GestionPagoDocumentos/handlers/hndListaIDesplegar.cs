using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.GestionPagoDocumentos.handlers
{
    public class hndListaIDesplegar: 
        ModCompra.__.Handlers.baseLista<_CtasPorPagar.__.Modelos.GestionPagoDocumentos.IItemDesplegar>,
        interfaces.IListaItems
    {
        public hndListaIDesplegar()
            : base()
        {
        }
        public override void CargarItems(IEnumerable<__.Modelos.GestionPagoDocumentos.IItemDesplegar> items)
        {
            _lst.Clear();
            _lst.AddRange(items);
            actualizarFuente();
        }
        public void ActualizarFuente()
        {
            actualizarFuente();
        }
    }
}