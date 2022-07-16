using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.ReporteProv.Maestro
{
    
    public class Filtro
    {

        public string idGrupo { get; set; }
        public string idEstado { get; set; }
        public string estatus { get; set; }


        public Filtro()
        {
            idGrupo = "";
            idEstado = "";
            estatus = "";
        }

    }

}