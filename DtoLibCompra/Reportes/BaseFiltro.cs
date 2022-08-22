﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCompra.Reportes
{
    
    public abstract class BaseFiltro
    {

        public string autoProveedor { get; set; }
        public string codSucursal { get; set; }
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }

    }

}