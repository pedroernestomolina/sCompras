﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCompra.Permiso
{
    
    public class Ficha
    {

        public string estatus { get; set; }
        public string seguridad { get; set; }
        public bool permisoHabilitado { get { return estatus.Trim().ToUpper() == "1"; } }
        public bool requiereClave { get { return seguridad.Trim().ToUpper() != "NINGUNA"; } }


        public bool IsHabilitado 
        {
            get 
            {
                var rt = false;
                if (estatus.Trim().ToUpper() == "1")
                {
                    rt = true;
                }
                return rt;
            }
        }

        public Enumerados.EnumNivelSeguridad NivelSeguridad 
        {
            get 
            {
                var rt = Enumerados.EnumNivelSeguridad.Niguna;
                switch (seguridad.Trim().ToUpper())
                {
                    case "MINIMA":
                        rt = Enumerados.EnumNivelSeguridad.Minima ;
                        break;
                    case "MEDIA":
                        rt = Enumerados.EnumNivelSeguridad.Media;
                        break;
                    case "MAXIMA":
                        rt = Enumerados.EnumNivelSeguridad.Maxima ;
                        break;
                }
                return rt;
            }
        }


        public Ficha()
        {
            estatus = "";
            seguridad = "";
        }

    }

}