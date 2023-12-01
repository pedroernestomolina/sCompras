using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Caja.Movimiento.Crud.Agregar
{
    public class Ficha
    {
        public int idCaja { get; set; }
        public string descMov { get; set; }
        public decimal montoMovMonAct { get; set; }
        public decimal montoMovMonDiv { get; set; }
        public bool movFueDivisa { get; set; }
        public decimal factorCambio { get; set; }
        public string tipoMov { get; set; }
        public int signoMov { get; set; }
        public decimal montoMov { get; set; }
        //
        public string conceptoCodigo { get; set; }
        public string conceptoDesc { get; set; }
        public int conceptoId { get; set; }
    }
}