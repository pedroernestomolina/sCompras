﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DtoLibTransporte.DocumentoRet.Crud.Anular.ObtenerData
{
    public class Ficha
    {
        public string idProveedor { get; set; }
        public string tipoRetencion { get; set; }
        public string idCxP_Origen { get; set; }
        public string idCxp_IR { get; set; }
        public string idCxp_IR_Recibo { get; set; }
        public decimal montoRetMonAct { get; set; }
        public decimal montoRetMonDiv { get; set; }
        public string idSistemaDoc_CompraRet { get; set; }
    }
}