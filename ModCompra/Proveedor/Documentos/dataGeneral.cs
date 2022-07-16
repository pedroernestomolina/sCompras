using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Proveedor.Documentos
{

    public class dataGeneral
    {

        public string id { get; set; }
        public string descripcion { get; set; }


        public dataGeneral() 
        {
            id = "";
            descripcion = "";
        }

        public dataGeneral(string id, string desc)
        {
            this.id= id;
            this.descripcion = desc;
        }

    }

}