using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.PanelMetPagoLista.handlers
{
    public class hndLista: 
        ModCompra.__.Handlers.baseLista<__.Modelos.PanelMetPagoAgregar.IItemAgregar>,
        interfaces.ILista
    {
        public hndLista()
        {
        }
        public void EliminarItem(__.Modelos.PanelMetPagoAgregar.IItemAgregar item)
        {
            _lst.Remove(item);
            actualizarFuente();
        }
        public void AgregarItem(__.Modelos.PanelMetPagoAgregar.IItemAgregar item)
        {
            _lst.Add(item);
            actualizarFuente();
        }
        public override void CargarItems(IEnumerable<__.Modelos.PanelMetPagoAgregar.IItemAgregar> items)
        {
            _lst.Clear();
            _lst.AddRange(items);
            actualizarFuente();
        }
    }
}