using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Maestros
{
    
    public class data
    {

        public string id { get; set; }
        public string codigo { get; set; }
        public string descripcion { get; set; }


        public data()
        {
            id = "";
            codigo = "";
            descripcion = "";
        }


        public data(OOB.LibCompra.Maestros.Grupo.Ficha it)
            :this()
        {
            id = it.auto;
            codigo = it.codigo;
            descripcion = it.nombre;
        }

    }

}