using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Documento.Anular
{
    
    public abstract class FichaBase
    {

        public string autoSistemaDocumento { get; set; }
        public string autoUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string codigoUsuario { get; set; }
        public string estacion { get; set; }
        public string motivo { get; set; }

    }

}