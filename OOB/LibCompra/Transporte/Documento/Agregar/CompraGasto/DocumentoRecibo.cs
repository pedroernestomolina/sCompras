using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Documento.Agregar.CompraGasto
{
    public class DocumentoRecibo
    {
        public string siglasDocumentoAfecta { get; set; }
        public string numDocumentoAfecta { get; set; }
        public decimal importe { get; set; }
        public string tipoOperacionRealizar { get; set; }
    }
}