using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.CxpDoc.GetInfoEntidad
{
    public class Ficha
    {
        public Entidad Entidad { get; set; }
        public List<DocPendiente> DocPendentes { get; set; }
    }
}
