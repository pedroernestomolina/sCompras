using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Beneficiario.Mov.Agregar
{
    public class Ficha
    {
        public Movimiento mov { get; set; }
        public List<MovCaja> movCaja { get; set; } 
    }
}