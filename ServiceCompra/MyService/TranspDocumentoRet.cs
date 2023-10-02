﻿using ServiceCompra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.MyService
{
    public partial class Service: IService
    {
        public DtoLib.ResultadoLista<DtoLibTransporte.DocumentoRet.ListaAdm.Ficha> 
            Transporte_DocumentoRet_GetLista(DtoLibTransporte.DocumentoRet.ListaAdm.Filtro filtro)
        {
            return ServiceProv.Transporte_DocumentoRet_GetLista(filtro);
        }
    }
}