using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.RepFiltro.Vista
{
    public class enumerados
    {
        public enum EstatusDoc { SinDefinir = -1, Activo = 0, Inactivo = 1 };
    }
    public interface IFiltros
    {
        enumerados.EstatusDoc EstatusDocumento { get; set; }
        int IdAliado { get; set; }
    }
}