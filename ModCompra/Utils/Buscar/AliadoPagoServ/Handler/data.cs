using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Buscar.AliadoPagoServ.Handler
{
    public class data: Vista.Idata
    {
        private OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha _ficha;


        public string ERecibo { get; set; }
        public DateTime EFecha { get; set; }
        public string EMotivo { get; set; }
        public decimal EImporte { get; set; }
        public int ECntServPag { get; set; }
        public OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha Ficha { get { return _ficha; } }


        public data(OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha rg)
        {
            _ficha = rg;
            ERecibo = rg.numRecibo;
            EFecha = rg.fecha;
            EMotivo = rg.motivo;
            EImporte = rg.montoPagoSelMonDiv;
            ECntServPag = rg.cntServPag;
        }
    }
}