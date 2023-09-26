using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Aliado.Anticipo.Anular
{
    public class Ficha
    {
        public int idMov { get; set; }
        public int idAliado { get; set; }
        public decimal monto { get; set; }
        public decimal montoRet { get; set; }
        public List<caja> cajas { get; set; }
    }
}