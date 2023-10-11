﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.Beneficiario.Lista
{
    public class Ficha
    {
        public int id { get; set; }
        public string cirif { get; set; }
        public string nombreRazonSocial { get; set; }


        public Ficha()
        {
        }
        public Ficha(Crud.Entidad.Ficha ficha)
        {
            id = ficha.id;
            cirif = ficha.ciRif;
            nombreRazonSocial = ficha.nombreRazonSocial;
        }
    }
}