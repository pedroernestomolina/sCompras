﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibCompra.Reportes.CompraPorDepartamento
{
    
    public class Filtro: BaseFiltro
    {

        public Filtro()
        {
            autoProveedor = "";
            desde = DateTime.Now.Date;
            hasta = DateTime.Now.Date;
            codSucursal = "";
        }

    }

}