using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Caja.Movimiento.Crud.Anular
{
    public class Ficha
    {
        public int idMov { get; set; }
        public int idCaja { get; set; }
        public decimal monto { get; set; }
        public int signoMov { get; set; }
    }
}