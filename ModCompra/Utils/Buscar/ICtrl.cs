using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Buscar
{
    public interface ICtrl
    {
        string Get_Inf { get; }
        string Get_Buscar { get; }
        ICtrlLista Lista { get; }

        void Inicializa();
        void SetBuscar(string desc);
        void Buscar();
    }
}