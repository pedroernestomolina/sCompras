using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Tools
{
    public interface IdataTools
    {
        IdataCtasPendientes CtasPendientes { get; }
        void AgregarAnticipo();
        void ServPrestado();
        void ImprimirLista();
    }
}