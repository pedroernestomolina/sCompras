using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.Documento.Entidad
{
    public class Ficha
    {
        public Documento documento { get; set; }
        public List<Item> items { get; set; }
    }
}