using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCompra.SistemaDocumento.Entidad
{
    
    public class Busqueda
    {
        public string codigoDoc { get; set; }
        public string tipoDoc { get; set; }


        public Busqueda()
        {
            codigoDoc = "";
            tipoDoc = "";
        }
    }

}