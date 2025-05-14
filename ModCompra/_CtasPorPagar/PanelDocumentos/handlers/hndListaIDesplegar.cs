using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelDocumentos.handlers
{
    public class hndListaIDesplegar: 
        ModCompra.__.Handlers.baseLista<_CtasPorPagar.__.Modelos.PanelDocumentos.IItemDesplegar>,
        interfaces.IListaItems
    {
        public hndListaIDesplegar()
            : base()
        {
        }
        public override void CargarItems(IEnumerable<__.Modelos.PanelDocumentos.IItemDesplegar> items)
        {
            _lst.Clear();
            _lst.AddRange(items);
            actualizarFuente();
        }
    }
}