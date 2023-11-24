using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.CxpDoc.Pago.Anular
{
    public class Auditoria
    {
        public string autoUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string codigoUsuario { get; set; }
        public string motivo { get; set; }
        public string estacionEquipo { get; set; }
    }
}