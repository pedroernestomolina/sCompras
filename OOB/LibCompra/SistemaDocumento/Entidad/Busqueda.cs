using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.SistemaDocumento.Entidad
{
    
    public class Busqueda
    {
        public string codigoDoc { get; set; }
        public string TipoDoc { get; set; }


        public Busqueda()
        {
            codigoDoc= "";
            TipoDoc = "";
        }
    }

}