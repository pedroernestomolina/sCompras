using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Utils.Maestro
{
    public interface ILista
    {
        BindingSource DataSource_Get { get; }
        Idata ItemActual { get; }
        int CntItems_Get { get; }

        void Inicializa();
        void setDataCargar(IEnumerable<Idata> lst);
        void AgregarItem(Idata ficha);
        void RemoverItemBy(Idata ficha);
    }
}