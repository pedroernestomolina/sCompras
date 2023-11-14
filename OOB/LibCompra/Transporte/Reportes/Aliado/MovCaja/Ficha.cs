using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Reportes.Aliado.MovCaja
{
    public class Ficha
    {
        public int idAliado { get; set; }
        public int idCaja { get; set; }
        public int idCajaMov { get; set; }
        public string cajaDescripcion { get; set; }
        public DateTime fechaMov { get; set; }
        public string conceptoMov { get; set; }
        public decimal montoMonAct { get; set; }
        public decimal montoMonDiv { get; set; }
        public int signo { get; set; }
        public string reciboNro { get; set; }
        public decimal tasaFactor { get; set; }
        public string nombreAliado { get; set; }
        public string ciRifAliado { get; set; }
        public string tipoMov { get; set; }
    }
}