using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Documento.Agregar.CompraGasto
{
    public class Ficha
    {
        public Documento documento { get; set; }
        public Proveedor proveedor { get; set; }
        public CxP cxp { get; set; }
        public CxP retIva { get; set; }
        public CxP retISLR { get; set; }
        public Recibo recRetIva { get; set; }
        public Recibo recRetIslr { get; set; }
        public Ficha()
        {
            documento = new Documento();
            proveedor = new Proveedor();
            cxp = new CxP();
        }
    }
}