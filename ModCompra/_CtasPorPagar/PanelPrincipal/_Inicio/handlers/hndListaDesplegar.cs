using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelPrincipal._Inicio.handlers
{
    public class hndListaDesplegar: 
        ModCompra.__.Handlers.baseLista<IItemDesplegar>,
        interfaces.IListaItemsDesplegar
    {
        public hndListaDesplegar()
            : base()
        {
        }
        public override void CargarItems(IEnumerable<IItemDesplegar> items)
        {
            _lst.Clear();
            _lst.AddRange(items);
            actualizarFuente();
        }
    }
}