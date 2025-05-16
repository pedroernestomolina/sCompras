using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.CxpDoc.Pago.Anular
{
    public class Ficha
    {
        public string autoPago { get; set; }
        public string autoRecibo { get; set; }
        public string autoProveedor { get; set; }
        public decimal importeDiv { get; set; }
        public string tipoDoc { get; set; }
        public int cntMetPago { get; set; }
        public Auditoria auditoria { get; set; }
        public List<Documento> documentos { get; set; }
        public List<Caja> cajas { get; set; }
        //
        public decimal anticipoUsado { get; set; }
        public decimal anticipoGuardado { get; set; }
    }
}