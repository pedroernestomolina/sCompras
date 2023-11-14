using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Buscar.AliadoPagoServ.Handler
{
    public class data: Vista.Idata
    {
        private OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha rg;


        public data(OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha rg)
        {
            this.rg = rg;
        }
    }
}