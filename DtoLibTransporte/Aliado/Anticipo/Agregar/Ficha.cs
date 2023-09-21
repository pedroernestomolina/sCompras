using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Aliado.Anticipo.Agregar
{
    public class Ficha
    {
        public Movimiento movimiento { get; set; }
        public AliadoAbonar aliadoAbonar { get; set; }
        public List<AliadoCaja>  alidoCaja { get; set; }
    }
}