﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Transporte.CxpDoc.Pago.Agregar
{
    public class DataRecibo
    {
        public DateTime fechaEmision { get; set; }
        public decimal importeMonAct { get; set; }
        public decimal montoRecibidoMonAct { get; set; }
        public decimal tasaCambio { get; set; }
        public string usuarioNombre { get; set; }
        public string usuarioAuto { get; set; }
        public string prvAuto { get; set; }
        public string prvNombre { get; set; }
        public string prvCiRif { get; set; }
        public string prvCodigo { get; set; }
        public string prvDirFiscal { get; set; }
        public string prvTlf { get; set; }
        public string nota { get; set; }
        public decimal importeDivisa { get; set; }
        public decimal montoRecibidoDivisa { get; set; }
        public string autoSistemaDoc { get; set; }
        public string codSistemaDoc { get; set; }
        public List<DataReciboDoc> reciboDoc { get; set; }
        public List<DataReciboMetodoPago> metpago { get; set; }
        public decimal anticipoUsado { get; set; }
        public decimal guardarComoAnticipoProv { get; set; }
    }
}