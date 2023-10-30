using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Compras.GeneralDoc
{
    public class Filtro: baseFiltro
    {
        public Filtro()
            :base()
        {
        }
        public string IdProveedor { get; set; }
        public int IdConcepto { get; set; }
        public string EstatusDoc { get; set; }
    }
}