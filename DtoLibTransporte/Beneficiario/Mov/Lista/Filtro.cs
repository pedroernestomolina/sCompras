using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Beneficiario.Mov.Lista
{
    public class Filtro
    {
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public string Estatus { get; set; }
    }
}