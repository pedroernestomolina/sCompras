using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Documento.Cargar.Factura
{
    
    public class FichaPrdPrecios
    {

        public string autoPrd { get; set; }
        public FichaPrecio precio1_Emp1 { get; set; }
        public FichaPrecio precio1_Emp2 { get; set; }
        public FichaPrecio precio1_Emp3 { get; set; }
        public FichaPrecio precio2_Emp1 { get; set; }
        public FichaPrecio precio2_Emp2 { get; set; }
        public FichaPrecio precio2_Emp3 { get; set; }
        public FichaPrecio precio3_Emp1 { get; set; }
        public FichaPrecio precio3_Emp2 { get; set; }
        public FichaPrecio precio3_Emp3 { get; set; }
        public FichaPrecio precio4_Emp1 { get; set; }
        public FichaPrecio precio4_Emp2 { get; set; }
        public FichaPrecio precio4_Emp3 { get; set; }
        public FichaPrecio precio5_Emp1 { get; set; }
        public FichaPrecio precio5_Emp2 { get; set; }
        public FichaPrecio precio5_Emp3 { get; set; }


        public FichaPrdPrecios()
        {
            autoPrd = "";
            precio1_Emp1 = null;
            precio1_Emp2 = null;
            precio1_Emp3 = null;
            precio2_Emp1 = null;
            precio2_Emp2 = null;
            precio2_Emp3 = null;
            precio3_Emp1 = null;
            precio3_Emp2 = null;
            precio3_Emp3 = null;
            precio4_Emp1 = null;
            precio4_Emp2 = null;
            precio4_Emp3 = null;
            precio5_Emp1 = null;
            precio5_Emp2 = null;
            precio5_Emp3 = null;
        }

    }

}
