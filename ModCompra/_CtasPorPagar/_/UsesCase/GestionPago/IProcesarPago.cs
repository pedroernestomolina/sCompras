using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtasPorPagar.__.UsesCase.GestionPago
{
    public interface IProcesarPago
    {
        string Execute(
            Modelos.GestionPago.IModelo modelo, 
            IEnumerable<Modelos.GestionPagoDocumentos.IItemDesplegar> docDeudaConPago, 
            IEnumerable<Modelos.GestionPagoDocumentos.IItemDesplegar> docNCConPago 
            );
    }
}