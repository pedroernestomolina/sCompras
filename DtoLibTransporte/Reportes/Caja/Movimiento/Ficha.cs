using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Reportes.Caja.Movimiento
{
    public class Ficha
    {
        public int idCaja { get; set; }
        public int idMov { get; set; }
        public string cjDesc { get; set; }
        public string cjEsDivisa { get; set; }
        public DateTime fechaMov { get; set; }
        public string motivoMov { get; set; }
        public string tipoMov { get; set; }
        public int signoMov { get; set; }
        public decimal montoMonAct { get; set; }
        public decimal montoMonDiv { get; set; }
        public decimal factorCambio { get; set; }
        public string estatusAnulado { get; set; }
        public string movFueDivisa { get; set; }
    }
}