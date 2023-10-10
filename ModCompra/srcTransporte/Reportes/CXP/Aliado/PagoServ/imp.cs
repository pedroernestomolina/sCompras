﻿using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using ModCompra.srcTransporte.Reportes.ListaAdm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.CXP.Aliado.PagoServ
{
    public class Imp : IRepFiltro
    {
        public Imp()
        {
        }
        public void setFiltros(object filtros)
        {
        }
        public void Generar()
        {
            try
            {
                var filtroOOB = new OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.General.Filtro();
                var r01 = Sistema.MyData.Transporte_Reportes_Aliado_PagoServ_GetLista(filtroOOB);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Aliado.PagoServ.General.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\CxP\RepCxp_PagoServ.rdlc";
            var ds = new DS_ADM();

            foreach (var rg in list)
            {
                DataRow rt = ds.Tables["PagoServ"].NewRow();
                rt["fecha"] = rg.fecha;
                rt["recibo"] = rg.numRecibo;
                rt["aliado"] = rg.cirifAliado+ Environment.NewLine + rg.nombreAliado;
                rt["monto"] = rg.montoPagoSelMonDiv;
                rt["aplicaRet"] = rg.aplicaRet.Trim().ToUpper() == "1" ? "SI" : "";
                rt["montoRet"] = rg.montoRetMonAct / rg.tasaFactor;
                rt["montoPag"] = rg.totalPagoMonDiv;
                if (rg.estatusAnulado.Trim().ToUpper() == "1")
                {
                    rt["monto"] = 0m;
                    rt["aplicaRet"] = "";
                    rt["montoRet"] = 0m;
                    rt["montoPag"] = 0m;
                }
                rt["estatus"] = rg.estatusAnulado.Trim().ToUpper() == "1" ? "ANULADO" : "";
                ds.Tables["PagoServ"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("PagoServ", ds.Tables["PagoServ"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}