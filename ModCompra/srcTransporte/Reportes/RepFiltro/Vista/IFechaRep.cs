using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.RepFiltro.Vista
{
    public interface IFechaRep: Utils.FiltroFecha.IFecha
    {
        bool Get_ActivarCheck { get; }
        void setActivarCheck(bool modo);
    }
}