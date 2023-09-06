using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Documento.Anular.CompraGasto.Anular
{
    public class Ficha
    {
        public string autoDocCompra { get; set; }
        public string autoDocCxP { get; set; }
        public List<Auditoria> auditoria { get; set; }
        public Proveedor proveedor { get; set; }
        public List<Retencion> retenciones { get; set; }
    }
}