using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular
{
    public class Auditoria
    {
        public string autoDoc { get; set; }
        public string autoSistemaDocumento { get; set; }
        public string autoUsuario { get; set; }
        public string nombreUsuario { get; set; }
        public string codigoUsuario { get; set; }
        public string estacion { get; set; }
        public string motivo { get; set; }
        public string ip { get; set; }
    }
}