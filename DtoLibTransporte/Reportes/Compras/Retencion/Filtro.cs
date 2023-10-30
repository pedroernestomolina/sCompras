using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Compras.Retencion
{
    public class Filtro: baseFiltro
    {
        public Filtro()
            :base()
        {
        }
        public string IdProveedor { get; set; }
        public enumerados.tipoRetencion tipoRet { get; set; }
        public string EstatusDoc { get; set; }
    }
}