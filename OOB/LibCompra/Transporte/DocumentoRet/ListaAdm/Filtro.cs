﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.DocumentoRet.ListaAdm
{
    public class Filtro
    {
        public DateTime? Desde { get; set; }
        public DateTime? Hasta { get; set; }
        public string IdProveedor { get; set; }
        public string Estatus { get; set; }
        public string TipoRetencion { get; set; }
    }
}