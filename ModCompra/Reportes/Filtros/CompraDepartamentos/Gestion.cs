﻿using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.Filtros.CompraDepartamentos
{

    public class Gestion : IReporte
    {

        private IFiltros filtros;
        private Reportes.Filtros.data filtrarPor;


        public IFiltros Filtros
        {
            get { return filtros; }
        }


        public Gestion()
        {
            filtros = new Filtros();
        }


        public void setDataFiltros(data filtros)
        {
            filtrarPor = filtros;
        }

        public void Generar()
        {
            var xfiltro = "";
            var filtro = new OOB.LibCompra.Reportes.CompraporDepartamento.Filtro()
            {
                desde = filtrarPor.GetDesde,
                hasta = filtrarPor.GetHasta,
            };
            xfiltro += "Desde: " + filtrarPor.GetDesde.ToShortDateString() + ", Hasta: " + filtrarPor.GetHasta.ToShortDateString();
            if (filtrarPor.GetSucursalId != "")
            {
                var rt1 = Sistema.MyData.Sucursal_GetFicha(filtrarPor.GetSucursalId);
                if (rt1.Result == OOB.Enumerados.EnumResult.isError)
                {
                }
                filtro.codSucursal = rt1.Entidad.codigo;
                xfiltro += ", Cod/Suc: " + rt1.Entidad.nombre + "(" + rt1.Entidad.codigo + ")";
            }
            if (filtrarPor.GetProveedorId != "")
            {
                filtro.autoProveedor = filtrarPor.GetProveedorId;
                xfiltro += ", Proveedor: " + filtrarPor.GetProveedorDesc;
            }
            var xr1 = Sistema.MyData.Reportes_ComprasPorDepartamento(filtro);
            if (xr1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr1.Mensaje);
                return;
            }
            Reporte(xr1.Lista,xfiltro);
        }

        private void Reporte(List<OOB.LibCompra.Reportes.CompraporDepartamento.Ficha> list, string xfiltro)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\Filtros\CompraDepartamento.rdlc";
            var ds = new DS();
            foreach (var it in list.ToList().OrderBy(o => o.nombreDepartamento).ToList())
            {
                DataRow rt = ds.Tables["CompraDepart"].NewRow();
                rt["departamento"] = it.nombreDepartamento;
                rt["serieDoc"] = it.serieDoc;
                rt["nombreDoc"] = it.nombreDoc;
                rt["total"] = it.total * it.signoDoc;
                rt["totalDivisa"] = it.totalDivisa *it.signoDoc;
                ds.Tables["CompraDepart"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            pmt.Add(new ReportParameter("Filtros", xfiltro));
            Rds.Add(new ReportDataSource("CompraDepart", ds.Tables["CompraDepart"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}