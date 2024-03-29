﻿using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    public partial class DataProv: IData
    {
        public OOB.ResultadoLista<OOB.LibCompra.Transporte.Caja.Lista.Ficha> 
            Transporte_Caja_GetLista()
        {
            var result = new OOB.ResultadoLista<OOB.LibCompra.Transporte.Caja.Lista.Ficha>();
            var r01 = MyData.Transporte_Caja_GetLista();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var lst = new List<OOB.LibCompra.Transporte.Caja.Lista.Ficha>();
            if (r01.Lista != null)
            {
                if (r01.Lista.Count > 0)
                {
                    lst = r01.Lista.Select(s =>
                    {
                        var nr = new OOB.LibCompra.Transporte.Caja.Lista.Ficha()
                        {
                            id = s.id,
                            codigo = s.codigo,
                            descripcion = s.descripcion,
                            estatusAnulado = s.estatusAnulado,
                            montoPorAnulaciones = s.montoPorAnulaciones,
                            montoPorEgresos = s.montoPorEgresos,
                            montoPorIngresos = s.montoPorIngresos,
                            saldoInicial = s.saldoInicial,
                            esDivisa = s.esDivisa,
                        };
                        return nr;
                    }).ToList();
                }
            }
            result.Lista = lst;
            return result;
        }
        public OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Caja.Crud.Entidad.Ficha>
            Transporte_Caja_GetById(int idCja)
        {
            var result = new OOB.ResultadoEntidad<OOB.LibCompra.Transporte.Caja.Crud.Entidad.Ficha>();
            var r01 = MyData.Transporte_Caja_GetById(idCja);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Transporte.Caja.Crud.Entidad.Ficha()
            {
                descripcion = s.descripcion,
                esDivisa = s.esDivisa,
                estatusAnulado = s.estatusAnulado,
                fechaRegistro = s.fechaRegistro,
                id = s.id,
                montoEgreso = s.montoEgreso,
                montoEgresoAnulado = s.montoEgresoAnulado,
                montoIngreso = s.montoIngreso,
                montoIngresoAnulado = s.montoIngresoAnulado,
                saldoInicial = s.saldoInicial,
                codigo = s.codigo,
            };
            result.Entidad = nr;
            return result;
        }
        public OOB.ResultadoId 
            Transporte_Caja_Agregar(OOB.LibCompra.Transporte.Caja.Crud.Agregar.Ficha ficha)
        {
            var result = new OOB.ResultadoId();
            var fichaDTO = new DtoLibTransporte.Caja.Crud.Agregar.Ficha()
            {
                esDivisa = ficha.esDivisa,
                saldoInicial = ficha.saldoInicial,
                codigo = ficha.codigo,
                descripcion = ficha.descripcion,
            };
            var r01 = MyData.Transporte_Caja_Agregar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            result.Id = r01.Id;
            return result;
        }
        public OOB.Resultado 
            Transporte_Caja_Editar(OOB.LibCompra.Transporte.Caja.Crud.Editar.Ficha ficha)
        {
            var result = new OOB.Resultado();
            var fichaDTO = new DtoLibTransporte.Caja.Crud.Editar.Ficha()
            {
                id = ficha.id,
                esDivisa = ficha.esDivisa,
                saldoInicial = ficha.saldoInicial,
                codigo = ficha.codigo,
                descripcion = ficha.descripcion,
            };
            var r01 = MyData.Transporte_Caja_Editar(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            return result;
        }
    }
}