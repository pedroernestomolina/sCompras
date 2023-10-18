using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Beneficiario.Mov.Anular
{
    public class Ficha
    {
        public int idMov { get; set; }
        public List<caja> cajas { get; set; }
    }
}