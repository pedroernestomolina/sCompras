using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public interface IGetItemsDocPend
    {
        List<_CtaxPagar.Interfaces.IdataItemDocPend> GetItems();
        //
        void setData(IEnumerable<object> data);
    }
}
