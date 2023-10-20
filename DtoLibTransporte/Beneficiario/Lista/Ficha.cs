using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Beneficiario.Lista
{
    public class Ficha
    {
        public int id { get; set; }
        public string cirif { get; set; }
        public string nombreRazonSocial { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string estatus { get; set; }
    }
}