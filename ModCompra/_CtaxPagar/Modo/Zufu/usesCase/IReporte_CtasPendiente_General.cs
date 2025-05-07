using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public interface IReporte_CtasPendiente_General
    {
        void setData(Interfaces.IZufuLista _listaDocPend);
        void Execute();
    }
}