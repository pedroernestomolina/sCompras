using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Filtros
{
    
    public class tipoDoc
    {


        public string descripcion { get; set; }
        public string id { get; set; }


        public tipoDoc(string id, string desc)
        {
            this.id = id;
            this.descripcion = desc;
        }

    }

}