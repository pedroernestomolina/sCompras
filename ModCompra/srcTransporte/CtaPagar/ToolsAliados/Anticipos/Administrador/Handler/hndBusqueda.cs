﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.Anticipos.Administrador.Handler
{
    public class hndBusqueda: Utils.Componente.Busqueda.Vistas.IBusqueda
    {
        private OOB.LibCompra.Transporte.Aliado.Anticipo.Lista.Filtro _filtro;


        public hndBusqueda()
        {
            _filtro= new OOB.LibCompra.Transporte.Aliado.Anticipo.Lista.Filtro();
        }
        public void Inicializa()
        {
        }
        public void setFiltros(object filtros)
        {
            var filt = (Filtro.Vistas.IdataFiltrar)filtros;
            var _estatus = "";
            if (filt.EstatusDoc != Filtro.Vistas.Enumerados.EstatusDoc.SinDefinir)
            {
                _estatus = "A";
                if (filt.EstatusDoc == Filtro.Vistas.Enumerados.EstatusDoc.Anulado)
                {
                    _estatus = "I";
                }
            }
            _filtro = new OOB.LibCompra.Transporte.Aliado.Anticipo.Lista.Filtro()
            {
                desde = filt.Desde,
                hasta = filt.Hasta,
                Estatus=_estatus,
                IdAliado=filt.IdAliado,
            };
        }
        public IEnumerable<object>Buscar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Aliado_Anticipo_GetLista(_filtro);
                return (IEnumerable<object>)r01.Lista.OrderByDescending(o=>o.idMov);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return null;
            }
        }
    }
}