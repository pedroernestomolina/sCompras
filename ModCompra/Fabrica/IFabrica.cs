using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Fabrica
{
    public interface IFabrica
    {
        void Iniciar_FrmPrincipal(ModCompra.Gestion ctr);
    }
}