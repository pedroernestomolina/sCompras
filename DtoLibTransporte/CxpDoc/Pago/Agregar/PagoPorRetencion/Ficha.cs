using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.CxpDoc.Pago.Agregar.PagoPorRetencion
{
    public class Ficha
    {
        public string autoEntCompra { get; set; }
        public string autoEntCxP { get; set; }
        public List<Documento.Agregar.CompraGasto.DocRetencion> Documentos { get; set; }
    }
}