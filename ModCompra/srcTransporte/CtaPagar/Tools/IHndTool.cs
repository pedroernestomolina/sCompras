using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools
{
    public interface IHndTool
    {
        IHndCtasPend CtasPendiente { get; }

        void Inicializa();
        void GestionPago();
        void AdmDocPagos();
        void ImprimirLista();
    }
}