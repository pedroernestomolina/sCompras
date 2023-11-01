using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.CxpDoc.DocEntidad
{
    public class Ficha: baseFicha
    {
        public string autoProv { get; set; }
        public string codProv { get; set; }
        public DateTime fechaReg { get; set; }
        public string codTipoDoc { get; set; }
        public string descripcionDoc { get; set; }
        public string mesRelacion { get; set; }
        public string anoRelacion { get; set; }
        public string docNroControl { get; set; }
        public string conceptoCod { get; set; }
        public string conceptoDesc { get; set; }
        public string condicion { get; set; }


        public Ficha()
            :base()
        {
        }
    }
}