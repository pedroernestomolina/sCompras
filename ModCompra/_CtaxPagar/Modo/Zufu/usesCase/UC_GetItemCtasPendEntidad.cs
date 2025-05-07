using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public class UC_GetItemCtasPendEntidad: IGetItemsCtaPendEntidad
    {
        private IEnumerable<object> _data;
        //
        public void setData(IEnumerable<object> data)
        {
            _data = data;
        }
        public List<_CtaxPagar.Interfaces.IdataItemCtaPendEntidad> GetItems()
        {
            return Convertidores.convertToDataItemCtaPendEntidad(_data);
        }
    }
}
