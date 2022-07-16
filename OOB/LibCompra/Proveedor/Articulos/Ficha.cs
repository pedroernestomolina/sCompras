using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Proveedor.Articulos
{
    
    public class Ficha
    {

        public string codigoPrd { get; set; }
        public string nombrePrd { get; set; }
        public DateTime fecha { get; set; }
        public string documento { get; set; }
        public decimal cantidad { get; set; }
        public decimal cantUnd { get; set; }
        public string empaque { get; set; }
        public string estatus { get; set; }
        public int contenidoEmp { get; set; }
        public string codTipoDoc { get; set; }
        public string nombreTipoDoc { get; set; }
        public string serie { get; set; }
        public decimal tasaCambio { get; set; }
        public decimal costoUnd { get; set; }
        public decimal costo { get; set; }
        public int signo { get; set; }
        public string EmpaqueCont { get { return empaque.Trim() + "( " + contenidoEmp.ToString() + " )"; } }
        public decimal CostoDivisa { get { return Math.Round( costo / tasaCambio, 2, MidpointRounding.AwayFromZero); } }
        public bool IsAnulado { get { return estatus.Trim().ToUpper() == "0" ? false : true; } }

    }

}