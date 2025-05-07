using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public interface ICargarCtasPendientes
    {
        void setFiltro(OOB.LibCompra.Transporte.CxpDoc.DocPend.Filtro filtro);
        void setListaDestino(Interfaces.IZufuLista listaDestino);
        void Execute();
    }
}