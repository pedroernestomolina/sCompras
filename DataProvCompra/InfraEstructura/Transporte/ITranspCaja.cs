﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.InfraEstructura.Transporte
{
    public interface ITranspCaja
    {
        OOB.ResultadoLista<OOB.LibCompra.Transporte.Caja.Lista.Ficha>
            Transporte_Caja_GetLista();
        OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Caja.Crud.Entidad.Ficha>
            Transporte_Caja_GetById(int idCja);
    }
}