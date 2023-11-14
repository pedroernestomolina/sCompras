using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using ModCompra.srcTransporte.Reportes.ListaAdm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.CXP.Aliado.MovCaja
{
    public class Imp : IRepFiltro
    {
        private OOB.LibCompra.Transporte.Reportes.Aliado.MovCaja.Filtro _filtro;


        public Imp()
        {
        }
        public void setFiltros(object filtros)
        {
            var ft = (Reportes.RepFiltro.Vista.IFiltros)filtros;
            _filtro = new OOB.LibCompra.Transporte.Reportes.Aliado.MovCaja.Filtro()
            {
                Desde = ft.Desde,
                Hasta = ft.Hasta,
                IdAliado = ft.IdAliado,
            };
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Aliado_MovCaja_GetLista(_filtro);
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Aliado.MovCaja.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\CxP\RepCxp_AliadoMovCaja.rdlc";
            var ds = new DS_ADM();

            foreach (var rg in list)
            {
                DataRow rt = ds.Tables["AliadoMovCaja"].NewRow();
                rt["caja"] = rg.cajaDescripcion;
                rt["fecha"] = rg.fechaMov;
                rt["concepto"] = rg.conceptoMov;
                rt["aliado"] = rg.ciRifAliado + Environment.NewLine + rg.nombreAliado;
                rt["tipoMov"] = rg.tipoMov;
                rt["montoMonAct"] = rg.montoMonAct;
                rt["montoMonDiv"] = rg.montoMonDiv;
                rt["tasaFactor"] = rg.tasaFactor;
                rt["reciboNro"] = rg.reciboNro;
                ds.Tables["AliadoMovCaja"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("AliadoMovCaja", ds.Tables["AliadoMovCaja"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}