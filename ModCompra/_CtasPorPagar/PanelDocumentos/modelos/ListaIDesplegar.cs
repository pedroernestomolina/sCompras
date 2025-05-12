using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelDocumentos.modelos
{
    public class ListaIDesplegar: 
        ModCompra.__.Handlers.baseLista<_CtasPorPagar.__.Modelos.PanelDocumentos.IItemDesplegar>,
        _CtasPorPagar.__.Modelos.PanelDocumentos.IListaIDesplegar
    {
        public ListaIDesplegar()
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