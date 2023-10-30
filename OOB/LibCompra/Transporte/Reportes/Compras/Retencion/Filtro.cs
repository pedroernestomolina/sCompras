using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Compras.Retencion
{
    public class Filtro: baseFiltro
    {
        public Filtro()
            :base()
        {
        }
        public enumerados.tipoRetencion tipoRet { get; set; }
        public string IdProveedor { get; set; }
        public string EstatusDoc { get; set; }
    }
}