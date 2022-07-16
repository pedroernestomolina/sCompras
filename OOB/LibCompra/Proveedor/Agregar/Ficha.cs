using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Proveedor.Agregar
{
    
    public class Ficha
    {

        public string idGrupo { get; set; }
        public string idEstado { get; set; }
        public string codigo { get; set; }
        public string razonSocial { get; set; }
        public string ciRif { get; set; }
        public string dirFiscal { get; set; }
        public string contacto { get; set; }
        public string telefono { get; set; }
        public string email { get; set; }
        public string webSite { get; set; }
        public string pais { get; set; }
        public string denFiscal { get; set; }
        public string codPostal { get; set; }
        public decimal retIva { get; set; }
        public string estatus { get; set; }
        //
        public decimal saldo { get { return 0.0m; } }
        public decimal anticipos { get { return 0.0m; } }
        public decimal creditos { get { return 0.0m; } }
        public decimal debitos { get { return 0.0m; } }
        public decimal disponible { get { return 0.0m; } }
        public string ctaBanco { get { return ""; } }
        public string benficiarioCtaBanco { get { return ""; } }
        public decimal retISLR { get { return 0.0m; } }
        public string idCtaIngreso { get { return "0000000001"; } }
        public string idCtaCobrar { get { return "0000000001"; } }
        public string idCtaAnticipos { get { return "0000000001"; } }
        public string advertencia { get { return ""; } }
        public string memo { get { return ""; } }
        public string nombre { get { return ""; } }
        public string nj { get { return ""; } }
        public string rif { get { return "";} }


        public Ficha()
        {
            idGrupo = "";
            idEstado = "";
            codigo = "";
            razonSocial = "";
            ciRif = "";
            dirFiscal = "";
            contacto = "";
            telefono = "";
            email = "";
            webSite = "";
            pais = "";
            codPostal = "";
            retIva = 0.0m;
        }

    }

}