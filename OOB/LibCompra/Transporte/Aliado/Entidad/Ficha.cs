using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Aliado.Entidad
{
    public class Ficha
    {
        public int id { get; set; }
        public string codigo { get; set; }
        public string ciRif { get; set; }
        public string nombreRazonSocial { get; set; }
        public string dirFiscal { get; set; }
        public string personaContacto { get; set; }
        public decimal montoAnticiposDiv { get; set; }
        public decimal montoAnticiposAnuladoDiv { get; set; }
        public decimal montoAnticipoRetDiv { get ;set; }
        public decimal montoAnticipoRetAnuladoDiv { get; set; }
        public decimal AnticiposDiv { get { return montoAnticiposDiv - montoAnticiposAnuladoDiv; } }
        public decimal AnticipoRetDiv { get { return montoAnticipoRetDiv - montoAnticipoRetAnuladoDiv; } }
        public string Info { get { return ciRif.Trim() + Environment.NewLine + nombreRazonSocial; } }
        public decimal MontoTotalPorAnticipo { get { return AnticiposDiv + AnticipoRetDiv; } }
    }
}