using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCompra.Auditoria.Entidad
{
    
    public class Busqueda
    {
        public string autoDoc { get; set; }
        public string  autoTipoDoc { get; set; }

        
        public Busqueda()
        {
            autoDoc = "";
            autoTipoDoc = "";
        }
    }

}