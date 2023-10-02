using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.DocumentoRet.ListaAdm
{
    public class Ficha
    {
        public string auto { get; set; }
        public string autoDocRef { get; set; }
        public DateTime fechaEmision { get; set; }
        public string documentoNro { get; set; }
        public string provNombre { get; set; }
        public string provCiRif { get; set; }
        public decimal retMonto { get; set; }
        public decimal retTasa { get; set; }
        public string estatusAnulado { get; set; }
        public string tipoRetCod { get; set; }
        public string tipoRetDesc { get; set; }
    }
}