using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Documento.GetData.AplicarRetencion
{
    public enum TipoDocumentoCompra 
    {
        SinDefinir=-1,
        Factura=1,
        NotaDebito=2,
        NotaCredito=3,
        Otro=4,
    }
    public class Ficha: BaseFicha
    {
        public string idDocCxp { get; set; }
        public bool AplicaRetencionIva { get; set; }
        public bool AplicaRetencionISLR { get; set; }
        public TipoDocumentoCompra GetTipoDocumentoCompra 
        { 
            get 
            {
                var _getTipoDoc= TipoDocumentoCompra.SinDefinir;
                switch (documentoTipo.Trim().ToUpper()) 
                {
                    case "01":
                        _getTipoDoc= TipoDocumentoCompra.Factura;
                        break;
                    case "03":
                        _getTipoDoc= TipoDocumentoCompra.NotaCredito;
                        break;
                    case "02":
                        _getTipoDoc= TipoDocumentoCompra.NotaDebito;
                        break;
                    default:
                        _getTipoDoc= TipoDocumentoCompra.Otro;
                        break;
                }
                return _getTipoDoc;
            } 
        }
    }
}