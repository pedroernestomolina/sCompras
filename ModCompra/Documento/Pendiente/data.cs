using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Pendiente
{
    
    public class data
    {

        public int id { get; set; }
        public string entidadCiRif { get; set; }
        public string entidadNombre { get; set; }
        public DateTime docFecha{ get; set; }
        public string docNombre { get; set; }
        public string docNumero { get; set; }
        public string docControl { get; set; }
        public decimal monto { get; set; }
        public decimal montoDivisa { get; set; }


        public data() 
        {
            id = -1;
            entidadCiRif = "";
            entidadNombre = "";
            docFecha = DateTime.Now.Date;
            docNombre = "";
            docControl = "";
            docNumero = "";
            monto = 0.0m;
            montoDivisa = 0.0m;
        }

        public data(OOB.LibCompra.Documento.Pendiente.Lista.Ficha rg) :
            this()
        {
            id = rg.id;
            entidadCiRif = rg.entidadCiRif;
            entidadNombre = rg.entidadNombre;
            docFecha = rg.docFecha;
            docNombre = rg.docNombre;
            docControl = rg.docControl;
            docNumero = rg.docNumero;
            monto = rg.docMonto;
            montoDivisa = rg.docMontoDivisa;
        }

    }

}