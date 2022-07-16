using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Producto.Utilidad
{
    
    public class Ficha
    {

        public string auto { get; set; }
        public bool admDivisa { get; set; }
        public decimal tasaIva { get; set; }
        public int contenido_1 { get; set; }
        public int contenido_2 { get; set; }
        public int contenido_3 { get; set; }
        public int contenido_4 { get; set; }
        public int contenido_5 { get; set; }
        public decimal utilidad_1 { get; set; }
        public decimal utilidad_2 { get; set; }
        public decimal utilidad_3 { get; set; }
        public decimal utilidad_4 { get; set; }
        public decimal utilidad_5 { get; set; }
        public decimal precio_1 { get; set; }
        public decimal precio_2 { get; set; }
        public decimal precio_3 { get; set; }
        public decimal precio_4 { get; set; }
        public decimal precio_5 { get; set; }
        public bool precio_1_habilitado { get { return precio_1 > 0; } }
        public bool precio_2_habilitado { get { return precio_2 > 0; } }
        public bool precio_3_habilitado { get { return precio_3 > 0; } }
        public bool precio_4_habilitado { get { return precio_4 > 0; } }
        public bool precio_5_habilitado { get { return precio_5 > 0; } }
        //
        public int contenido_may_1 { get; set; }
        public int contenido_may_2 { get; set; }
        public decimal utilidad_may_1 { get; set; }
        public decimal utilidad_may_2 { get; set; }
        public decimal precio_may_1 { get; set; }
        public decimal precio_may_2 { get; set; }
        public bool precio_may_1_habilitado { get { return precio_may_1 > 0; } }
        public bool precio_may_2_habilitado { get { return precio_may_2 > 0; } }


        public Ficha()
        {
            auto = "";
            admDivisa = false;
            tasaIva = 0.0m;
            contenido_1 = 0;
            contenido_2 = 0;
            contenido_3 = 0;
            contenido_4 = 0;
            contenido_5 = 0;
            utilidad_1 = 0.0m;
            utilidad_2 = 0.0m;
            utilidad_3 = 0.0m;
            utilidad_4 = 0.0m;
            utilidad_5 = 0.0m;
            precio_1 = 0.0m;
            precio_2 = 0.0m;
            precio_3 = 0.0m;
            precio_4 = 0.0m;
            precio_5 = 0.0m;
            //
            contenido_may_1 = 0;
            contenido_may_2 = 0;
            utilidad_may_1 = 0.0m;
            utilidad_may_2 = 0.0m;
            precio_may_1 = 0.0m;
            precio_may_2 = 0.0m;
        }

    }

}