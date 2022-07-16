using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Corrector.Documento
{
    
    public class data
    {

        public string documentoNro { get; set; }
        public DateTime fechaDocumento { get; set; }
        public string nombreRazonSocialProveedor { get; set; }
        public string direccionFiscalProveedor { get; set; }
        public string ciRifProveedor { get; set; }
        public string notaDocumento { get; set; }
        public string controlNro { get; set; }


        public data()
        {
            documentoNro = "";
            fechaDocumento = new DateTime();
            nombreRazonSocialProveedor = "";
            direccionFiscalProveedor = "";
            ciRifProveedor = "";
            notaDocumento = "";
            controlNro = "";
        }

        public bool IsOk()
        {
            var rt = true;
            if (documentoNro == "")
            {
                Helpers.Msg.Error("CAMPO [NUMERO DE DOCUMENTO] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (controlNro == "")
            {
                Helpers.Msg.Error("CAMPO [NUMERO DE CONTROL] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (ciRifProveedor == "")
            {
                Helpers.Msg.Error("CAMPO [CI/RIF] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (nombreRazonSocialProveedor == "")
            {
                Helpers.Msg.Error("CAMPO [NOMBRE/RAZON SOCIAL] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (direccionFiscalProveedor == "")
            {
                Helpers.Msg.Error("CAMPO [DIRECCION FISCAL] NO PUEDE ESTAR VACIO");
                return false;
            }

            return rt;
        }


    }

}
