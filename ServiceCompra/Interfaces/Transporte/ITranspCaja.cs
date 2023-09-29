﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ServiceCompra.Interfaces.Transporte
{
    public interface ITranspCaja
    {
        DtoLib.ResultadoLista<DtoLibTransporte.Caja.Lista.Ficha>
            Transporte_Caja_GetLista();
        DtoLib.ResultadoEntidad<DtoLibTransporte.Caja.Crud.Entidad.Ficha>
            Transporte_Caja_GetById(int idCja);
        DtoLib.ResultadoId
            Transporte_Caja_Agregar(DtoLibTransporte.Caja.Crud.Agregar.Ficha ficha);
        DtoLib.Resultado
            Transporte_Caja_Editar(DtoLibTransporte.Caja.Crud.Editar.Ficha ficha);
    }
}