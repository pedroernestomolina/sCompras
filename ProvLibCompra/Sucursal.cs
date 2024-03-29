﻿using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCompra
{

    public partial class Provider: ILibCompras.IProvider
    {
        public DtoLib.ResultadoLista<DtoLibCompra.Sucursal.Lista.Resumen> Sucursal_GetLista()
        {
            var result = new DtoLib.ResultadoLista<DtoLibCompra.Sucursal.Lista.Resumen>();
            //
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var sql = @"select 
                                    auto as auto,
                                    codigo as codigo,
                                    nombre as nombre,
                                    sucExt.es_activo as estatusActivo
                                from empresa_sucursal as suc 
                                join empresa_sucursal_ext as sucExt on sucExt.auto_sucursal=suc.auto";
                    result.Lista = cnn.Database.SqlQuery<DtoLibCompra.Sucursal.Lista.Resumen>(sql).ToList();
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            //
            return result;
        }

        public DtoLib.ResultadoEntidad<DtoLibCompra.Sucursal.Data.Ficha> Sucursal_GetFicha(string autoSucursal)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCompra.Sucursal.Data.Ficha>();

            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var ent = cnn.empresa_sucursal.Find(autoSucursal);

                    if (ent == null)
                    {
                        result.Mensaje = "[ ID ] SUCURSAL NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }

                    var depCodigo = "";
                    var depNombre = "";
                    var depAuto = "";
                    if (ent.autoDepositoPrincipal.Trim() != "")
                    {
                        var entDeposito = cnn.empresa_depositos.Find(ent.autoDepositoPrincipal);
                        depAuto = entDeposito.auto;
                        depCodigo = entDeposito.codigo;
                        depNombre = entDeposito.nombre;
                    };

                    var grupoAuto = "";
                    var grupoNombre = "";
                    if (ent.autoEmpresaGrupo.Trim() != "")
                    {
                        var entGrupoEmpresa = cnn.empresa_grupo.Find(ent.autoEmpresaGrupo);
                        grupoAuto = entGrupoEmpresa.auto;
                        grupoNombre = entGrupoEmpresa.nombre;
                    }

                    var nr = new DtoLibCompra.Sucursal.Data.Ficha()
                    {
                        auto = ent.auto,
                        codigo = ent.codigo,
                        nombre = ent.nombre,
                        autoDepositoPrincipal = depAuto,
                        autoEmpresaGrupo = grupoAuto,
                        codigoDepositoPrincipal = depCodigo,
                        nombreDepositoPrincipal = depNombre,
                        nombreEmpresaGrupo = grupoNombre,
                    };
                    result.Entidad = nr;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }

            return result;
        }

    }

}