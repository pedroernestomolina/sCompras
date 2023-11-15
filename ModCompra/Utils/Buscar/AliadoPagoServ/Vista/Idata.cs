using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Utils.Buscar.AliadoPagoServ.Vista
{
    public interface Idata
    {
        string ERecibo { get; set; }
        DateTime EFecha { get; set; }
        string EMotivo { get; set; }
        decimal EImporte { get; set; }
        int ECntServPag { get; set; }
    }
}