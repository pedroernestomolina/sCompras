using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Documento.Anular.CompraGastoAliado.GetData
{
    public class Ficha
    {
        public Documento documento { get; set; }
        public List<RetDoc> retencionDoc{ get; set; }
    }
}