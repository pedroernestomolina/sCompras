using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.ReporteProveedor.Filtro
{

    public class general
    {

        public string Id { get; set; }
        public string Descripcion { get; set; }


        public general()
        {
            Id = "";
            Descripcion = "";
        }

        public general(string id, string desc)
            :this()
        {
            this.Id = id;
            this.Descripcion = desc;
        }

    }

}