using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Documento.Anular.CompraGasto.GetData
{
    public class Documento
    {
        public string documento { get; set; }
        public string autoPrv { get; set; }
        public string autoCxp { get; set; }
        public decimal total { get; set; }
        public string codigoTipoDoc { get; set; }
        public string tipoDocumentoCompra { get; set; }
        public string autoSistemaDoc { get; set; }
        public string autoSistemaDocCxp { get; set; }
    }
}