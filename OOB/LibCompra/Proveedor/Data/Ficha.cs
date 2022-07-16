using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Proveedor.Data
{
    
    public class Ficha
    {

        public Identificacion identidad { get; set; }
        public string autoId { get { return identidad.auto; } }
        public string ciRif { get { return identidad.ciRif; } }
        public string nombreRazonSocial { get { return identidad.nombreRazonSocial; } }
        public string direccionFiscal { get { return identidad.dirFiscal; } }
        public string codigo { get { return identidad.codigo; } }
        public string RifNombrePrv { get { return ciRif + Environment.NewLine + nombreRazonSocial; } }
        public bool IsActivo { get { return identidad.estatus == Enumerados.EnumEstatus.Activo ? true : false; } }
        public DateTime fechaAlta { get { return identidad.fechaAlta; } }
        public DateTime fechaUltCompra { get { return identidad.fechaUltCompra; } }
        public DateTime fechaBaja { get { return identidad.fechaBaja; } }
        public string estatus { get { return identidad.estatus == Enumerados.EnumEstatus.Activo ? "Activo" : "Inactivo"; } }


        public Ficha()
        {
            identidad = new Identificacion();
        }

        public Ficha(String id, string cirif, string razonSocial, string dirFiscal, string codigo) :
            this()
        {
            this.identidad.auto = id;
            this.identidad.ciRif = cirif;
            this.identidad.nombreRazonSocial = razonSocial;
            this.identidad.dirFiscal = dirFiscal;
            this.identidad.codigo = codigo;
        }

    }

}