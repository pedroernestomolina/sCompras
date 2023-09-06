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
        OOB.Resultado 
            AnularDocCompra_Factura(string idDoc, string motivo);
        OOB.Resultado 
            AnularDocCompra_NotaDebito(string idDoc, string motivo);
        OOB.Resultado 
            AnularDocCompra_NotaCredito(string idDoc, string motivo);
    }
}