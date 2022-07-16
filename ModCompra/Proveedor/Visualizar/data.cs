using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Proveedor.Visualizar
{
    
    public class data
    {

        public string CiRif { get; set; }
        public string Codigo { get; set; }
        public string NombreRazonSocial { get; set; }
        public string DirFiscal { get; set; }
        public string CodPostal { get; set; }
        public string Estado { get; set; }
        public string Pais { get; set; }
        public string Grupo { get; set; }
        public string Email { get; set; }
        public string Persona { get; set; }
        public string WebSite { get; set; }
        public string Telefono { get; set; }
        public string DenominacionFiscal { get; set; }
        public string RetencionIva { get; set; }


        public data() 
        {
            Inicializar();
        }


        public void Inicializar()
        {
            limpiar();
        }

        private void limpiar()
        {
            CiRif = "";
            Codigo = "";
            NombreRazonSocial = "";
            DirFiscal = "";
            Pais = "";
            Estado = "";
            CodPostal = "";
            Grupo = "";
            Persona = "";
            Email = "";
            WebSite = "";
            Telefono = "";
            DenominacionFiscal = "";
            RetencionIva = "";
        }

        public void setData(OOB.LibCompra.Proveedor.Data.Ficha ficha)
        {
            limpiar();
            CiRif = ficha.ciRif;
            Codigo = ficha.codigo;
            NombreRazonSocial = ficha.nombreRazonSocial;
            DirFiscal = ficha.direccionFiscal;
            Pais = ficha.identidad.pais;
            Estado = ficha.identidad.nombreEstado;
            CodPostal = ficha.identidad.codigoPostal;
            Grupo = ficha.identidad.nombreGrupo;
            Persona = ficha.identidad.nombreContacto;
            Telefono = ficha.identidad.telefono;
            Email = ficha.identidad.email;
            WebSite = ficha.identidad.website;
            DenominacionFiscal = ficha.identidad.denominacionFiscal;
            RetencionIva = ficha.identidad.retIva.ToString("n2") + "%";
        }

    }

}