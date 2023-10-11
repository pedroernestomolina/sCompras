using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Beneficiario.Crud
{
    abstract public class baseAgregarEditar
    {
        public string ciRif { get; set; }
        public string nombreRazonSocial { get; set; }
        public string direccion { get; set; }
        public string telefono { get; set; }
    }
}
