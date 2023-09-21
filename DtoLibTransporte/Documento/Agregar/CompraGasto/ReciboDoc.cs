using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Documento.Agregar.CompraGasto
{
    public class ReciboDoc
    {
        public string siglasDocumentoAfecta { get; set; }
        public string numDocumentoAfecta { get; set; }
        public decimal importe { get; set; }
        public string tipoOperacionRealizar { get; set; }
    }
}