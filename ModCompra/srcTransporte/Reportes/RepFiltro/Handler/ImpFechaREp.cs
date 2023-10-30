using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.RepFiltro.Handler
{
    public class ImpFechaRep: Utils.FiltroFecha.Imp, Vista.IFechaRep
    {
        private bool _activarCheck;


        public bool Get_ActivarCheck { get { return _activarCheck; } }


        public ImpFechaRep()
            :base()
        {
            _activarCheck = false;
        }
        public void setActivarCheck(bool modo)
        {
            _activarCheck = modo;
        }
    }
}
