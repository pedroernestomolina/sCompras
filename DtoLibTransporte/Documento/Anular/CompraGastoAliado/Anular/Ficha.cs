using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Documento.Anular.CompraGastoAliado.Anular
{
    public class Ficha
    {
        public string autoDocCompra { get; set; }
        public int idPagoServicio { get; set; }
        public int idRelCompraPago { get; set; }
        public Proveedor proveedor { get; set; }
        public List<Auditoria> auditoria { get; set; }
        public List<DocRetCompra> docRetCompra { get; set; }
    }
}