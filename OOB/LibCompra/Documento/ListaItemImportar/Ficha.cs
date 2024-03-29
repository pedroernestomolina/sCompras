﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OOB.LibCompra.Documento.ListaItemImportar
{
    
    public class Ficha
    {

        public string prdAuto { get; set; }
        public string prdCodigo { get; set; }
        public string prdNombre { get; set; }
        public string prdAutoDepartamento { get; set; }
        public string prdAutoGrupo { get; set; }
        public string prdAutoSubGrupo { get; set; }
        public string prdAutoTasaIva { get; set; }
        public decimal cntFactura { get; set; }
        public string estatusUnidad { get; set; }
        public string empaqueCompra { get; set; }
        public int contenidoEmp { get; set; }
        public decimal precioFactura { get; set; }
        public decimal dscto1p { get; set; }
        public decimal dscto2p { get; set; }
        public decimal dscto3p { get; set; }
        public decimal tasaIva { get; set; }
        public string decimales { get; set; }
        public string categoria { get; set; }
        public string codRefProv { get; set; }
        //
        public string autoEmpCompPreDeterminado { get; set; }
        public int contEmpCompPreDeterminado { get; set; }
        public string autoEmpInv { get; set; }
        public int contEmpInv { get; set; }
        public bool isEmpPorUnidad { get { return estatusUnidad.Trim().ToUpper() == "1"; } }


        public Ficha()
        {
            prdAuto = "";
            prdAutoDepartamento = "";
            prdAutoGrupo = "";
            prdAutoSubGrupo = "";
            prdAutoTasaIva = "";
            prdCodigo = "";
            prdNombre = "";
            cntFactura = 0.0m;
            estatusUnidad = "";
            empaqueCompra = "";
            contenidoEmp = 0;
            precioFactura = 0.0m;
            dscto1p = 0.0m;
            dscto2p = 0.0m;
            dscto3p = 0.0m;
            tasaIva = 0.0m;
            decimales = "";
            categoria = "";
            codRefProv = "";
            //
            autoEmpCompPreDeterminado = "";
            contEmpCompPreDeterminado = 0;
            autoEmpInv = "";
            contEmpInv = 0;
        }

    }

}