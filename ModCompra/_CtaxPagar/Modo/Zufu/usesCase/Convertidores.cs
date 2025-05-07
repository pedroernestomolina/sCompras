using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public class Convertidores
    {
        internal static List<handlers.dataItemDocPend>
            convertToDataItem(IEnumerable<object> enumerable)
        {
            var lst = new List<handlers.dataItemDocPend>();
            foreach (var rg in enumerable) 
            {
                lst.Add((handlers.dataItemDocPend)rg);
            }
            return lst;
        }
        internal static List<_CtaxPagar.Interfaces.IdataItemDocPend>
            convertToDataItemDocPend(IEnumerable<object> enumerable)
        {
            var lst = new List<_CtaxPagar.Interfaces.IdataItemDocPend>();
            foreach (var rg in enumerable)
            {
                lst.Add((handlers.dataItemDocPend)rg);
            }
            return lst;
        }

        internal static List<_CtaxPagar.Interfaces.IdataItemCtaPendEntidad>
            convertToDataItemCtaPendEntidad(IEnumerable<object> enumerable)
        {
            var lst = new List<_CtaxPagar.Interfaces.IdataItemCtaPendEntidad>();
            foreach (var rg in enumerable)
            {
                lst.Add((handlers.dataItemCtaPendEntidad)rg);
            }
            return lst;
        }
    }
}