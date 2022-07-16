using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Documento.Lista
{
    
    public class Ficha
    {

        public string auto { get; set; }
        public DateTime fechaEmision { get; set; }
        public string codigoTipo { get; set; }
        public string tipoDocNombre { get; set; }
        public string documentoNro { get; set; }
        public DateTime fechaRegistro { get; set; }
        public string codigoSuc { get; set; }
        public string provNombre { get; set; }
        public string provCiRif { get; set; }
        public decimal monto { get; set; }
        public decimal montoDivisa { get; set; }
        public string situacion { get; set; }
        public bool esAnulado {get;set;}
        public Enumerados.enumTipoDocumento tipoDoc {get;set;}
        public int Signo { get; set; }
        public string ControlNro { get; set; }
        public string Aplica { get; set; }

    }

}