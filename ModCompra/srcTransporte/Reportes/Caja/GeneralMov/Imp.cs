﻿using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Caja.GeneralMov
{
    public class Imp : IRepFiltro
    {
        private OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Filtro _filtro;
        //
        public Imp()
        {
            _filtro = new OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Filtro();
        }
        public void setFiltros(object filtros)
        {
            var ft = (Reportes.RepFiltro.Vista.IFiltros)filtros;
            var _estatusDoc = OOB.LibCompra.Transporte.Reportes.Caja.enumerados.EstatusDoc.SinDefinir;
            if (ft.EstatusDocumento != RepFiltro.Vista.enumerados.EstatusDoc.SinDefinir)
            {
                _estatusDoc =  OOB.LibCompra.Transporte.Reportes.Caja.enumerados.EstatusDoc.Activo;
                if (ft.EstatusDocumento == RepFiltro.Vista.enumerados.EstatusDoc.Inactivo)
                {
                    _estatusDoc = OOB.LibCompra.Transporte.Reportes.Caja.enumerados.EstatusDoc.Anulado;
                }
            }
            var _tipoMov = OOB.LibCompra.Transporte.Reportes.Caja.enumerados.TipoMovCaja.SinDefinir;
            if (ft.TipoMovCaja  != RepFiltro.Vista.enumerados.TipoMovCaja.SinDefinir )
            {
                _tipoMov = OOB.LibCompra.Transporte.Reportes.Caja.enumerados.TipoMovCaja.Ingreso;
                if (ft.TipoMovCaja ==  RepFiltro.Vista.enumerados.TipoMovCaja.Egreso)
                {
                    _tipoMov = OOB.LibCompra.Transporte.Reportes.Caja.enumerados.TipoMovCaja.Egreso;
                }
            }
            _filtro = new OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Filtro()
            {
                Desde = ft.Desde,
                Hasta = ft.Hasta,
                IdCaja = ft.IdCaja,
                EstatusDoc = _estatusDoc,
                TipoMov = _tipoMov,
            };
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Caja_Movimientos_GetLista(_filtro);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        //
        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Caja.Movimiento.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Caja\RepCajaMov.rdlc";
            var ds = new ListaAdm.DS_ADM();
            //
            var lst = list.OrderBy(o => o.fechaMov).ToList();
            foreach (var rg in lst)
            {
                var _monto = (rg.cjEsDivisa.Trim().ToUpper() == "1" ? rg.montoMonDiv : rg.montoMonAct) * rg.signoMov;
                if (rg.estatusAnulado.Trim().ToUpper() == "1") 
                {
                    _monto = 0m;
                }
                DataRow rt = ds.Tables["CajaMov"].NewRow();
                rt["fecha"] = rg.fechaMov;
                rt["monto"] = _monto;
                rt["motivo"] = rg.motivoMov;
                rt["estatus"] = rg.estatusAnulado.Trim().ToUpper() == "1" ? "ANULADO" : "";
                rt["tipoMov"] = rg.tipoMov.Trim().ToUpper() == "I" ? "INGRESO" : "EGRESO";
                rt["cajaDesc"] = rg.cjDesc;
                rt["esDivisa"] = rg.cjEsDivisa.Trim().ToUpper() == "1" ? "$" : "";
                ds.Tables["CajaMov"].Rows.Add(rt);
            }
            //
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("CajaMov", ds.Tables["CajaMov"]));
            //
            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}