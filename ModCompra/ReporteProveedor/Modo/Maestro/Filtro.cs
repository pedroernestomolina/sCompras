using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.ReporteProveedor.Modo.Maestro
{

    public class Filtro: ReporteProveedor.Filtro.IFiltro 
    {

        public bool ActivarGrupo
        {
            get { return true; }
        }

        public bool ActivarEstado
        {
            get { return true; }
        }

        public bool ActivarEstatus
        {
            get { return true; }
        }

    }

}