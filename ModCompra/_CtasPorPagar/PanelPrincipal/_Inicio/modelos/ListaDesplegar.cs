using ModCompra._CtasPorPagar.__.Modelos.PanelPrincipal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelPrincipal._Inicio.modelos
{
    public class ListaDesplegar: 
        ModCompra.__.Handlers.baseLista<IItemDesplegar>,
        IListaDesplegar
    {
        public ListaDesplegar()
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