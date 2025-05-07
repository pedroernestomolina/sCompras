using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagarPago_MetodosPago.Modo.Zufu.usesCase
{
    public class Convertidores
    {
        internal static List<handlers.item>
            convertToItem(IEnumerable<object> enumerable)
        {
            var lst = new List<handlers.item>();
            foreach (var rg in enumerable) 
            {
                lst.Add((handlers.item)rg);
            }
            return lst;
        }
    }
}