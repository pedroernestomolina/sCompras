using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Usuario.Data
{
    
    public class Ficha
    {

        public string autoUsu { get; set; }
        public string autoGru { get; set; }
        public string nombreUsu { get; set; }
        public string apellidoUsu { get; set; }
        public string codigoUsu { get; set; }
        public string nombreGru { get; set; }
        public bool isActivo { get; set; }


        public Ficha()
        {
            autoUsu = "";
            autoGru = "";
            nombreUsu = "";
            nombreGru = "";
            codigoUsu = "";
            nombreUsu = "";
            nombreGru = "";
            isActivo = true;
        }

    }

}