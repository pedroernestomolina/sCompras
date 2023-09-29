using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Caja.Crud
{
    abstract public class baseAgregarEditar
    {
        public string codigo { get; set; }
        public string descripcion { get; set; }
        public decimal saldoInicial { get; set; }
        public bool esDivisa { get; set; }
    }
}
