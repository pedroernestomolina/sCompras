using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public interface IReporte_CtasPendiente_Entidad
    {
        void setInfoEntidad(string info);
        void setData(Interfaces.IZufuLista lista);
        void Execute();
    }
}