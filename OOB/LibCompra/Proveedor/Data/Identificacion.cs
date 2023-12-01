using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Proveedor.Data
{
    
    public class Identificacion
    {

        public string auto { get; set; }
        public string autoGrupo { get; set; }
        public string autoEstado { get; set; }

        public string ciRif { get; set; }
        public string codigo { get; set; }
        public string nombreRazonSocial { get; set; }
        public string dirFiscal { get; set; }
        public string telefono { get; set; }
        public string nombreGrupo { get; set; }
        public string nombreEstado { get; set; }
        public string nombreContacto { get; set; }
        public Enumerados.EnumEstatus estatus { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string pais { get; set; }
        public string codigoPostal { get; set; }
        public decimal retIva { get; set; }
        public string denominacionFiscal { get; set; }
        public DateTime fechaAlta { get; set; }
        public DateTime fechaUltCompra { get; set; }
        public DateTime fechaBaja { get; set; }
        public string codXmlIslr { get; set; }
        public string descXmlIslr { get; set; }

        public Enumerados.EnumDenominacionFiscal modoDenominacionFiscal 
        {
            get 
            {
                var modo = Enumerados.EnumDenominacionFiscal.SnDefinir;
                if (denominacionFiscal.Trim().ToUpper() == "CONTRIBUYENTE")
                    modo = Enumerados.EnumDenominacionFiscal.Contribuyente;
                else
                    modo = Enumerados.EnumDenominacionFiscal.NoContribuyente;
                return modo;
            }
        }


        public Identificacion()
        {
            auto = "";
            autoGrupo = "";
            autoEstado = "";
            ciRif = "";
            codigo = "";
            nombreRazonSocial = "";
            dirFiscal = "";
            telefono = "";
            nombreGrupo = "";
            nombreEstado = "";
            nombreContacto = "";
            estatus = Enumerados.EnumEstatus.SnDefinir;
            email = "";
            website = "";
            pais = "";
            codigoPostal = "";
            retIva = 0.0m;
            denominacionFiscal = "";
            fechaAlta = DateTime.Now.Date;
            fechaUltCompra = new DateTime(2000, 01, 01).Date;
            fechaBaja = new DateTime(2000, 01, 01).Date;
            codXmlIslr = "";
            descXmlIslr = "";
        }
    }
}