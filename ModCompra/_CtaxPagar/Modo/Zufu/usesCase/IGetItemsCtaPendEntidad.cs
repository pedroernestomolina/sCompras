using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public interface IGetItemsCtaPendEntidad
    {
        List<_CtaxPagar.Interfaces.IdataItemCtaPendEntidad> GetItems();
        //
        void setData(IEnumerable<object> data);
    }
}
