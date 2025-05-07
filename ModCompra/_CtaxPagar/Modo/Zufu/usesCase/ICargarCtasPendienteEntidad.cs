using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public interface ICargarCtasPendienteEntidad
    {
        void setIdEntidad(string idEntidad);
        void setListaDestino(Interfaces.IZufuLista listaDestino);
        void Execute();
    }
}