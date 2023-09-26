using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Utils.Componente.Administrador.Vistas
{
    public interface ILista
    {
        BindingSource Get_Source { get; }
        int Get_CntItem { get; }

        void Inicializa();
    }
}