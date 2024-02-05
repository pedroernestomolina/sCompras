using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using ModCompra.srcTransporte.Reportes.ListaAdm;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.CXP.Aliado.EdoCta
{
    public class Imp : IRepPlanilla
    {
        private int _idAliado;


        public Imp()
        {
        }
        public void setIdDoc(object idAliado)
        {
            _idAliado = (int)idAliado;
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(_idAliado);
                var r02 = Sistema.MyData.Transporte_Aliado_GetFichaById(_idAliado);
                imprimir(r01.Lista, r02.Entidad);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }
        private void imprimir(List<OOB.LibCompra.Transporte.Aliado.PagoServ.ServPrestado.Ficha> list, 
            OOB.LibCompra.Transporte.Aliado.Entidad.Ficha ficha)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\CxP\RepCxp_AliadoEdoCta.rdlc";
            var ds = new DS_ADM();
            //
            DataRow rt0 = ds.Tables["AliadoEdoCta_Enc"].NewRow();
            rt0["aliado"] = ficha.ciRif +Environment.NewLine+ficha.nombreRazonSocial;
            rt0["montoAnticipo"] = ficha.MontoTotalPorAnticipo;
            ds.Tables["AliadoEdoCta_Enc"].Rows.Add(rt0);
            foreach (var rg in list)
            {
                DataRow rt = ds.Tables["AliadoEdoCta_Det"].NewRow();
                rt["cliente"] = rg.fechaDoc.ToShortDateString()+Environment.NewLine+
                                rg.numDoc + ", " + rg.nombreDoc+ Environment.NewLine+
                                rg.clienteCiRif + Environment.NewLine + rg.clienteNombre;
                rt["importe"] = rg.importeServDiv ;
                rt["acumulado"] = rg.servMontoAcumuladoDiv;
                rt["saldo"] = rg.importeServDiv - rg.servMontoAcumuladoDiv;
                rt["tipoServ"] = rg.servDesc;
                rt["detalleServ"] = rg.servDetalle;
                ds.Tables["AliadoEdoCta_Det"].Rows.Add(rt);
            }
            //
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("AliadoEdoCta_Det", ds.Tables["AliadoEdoCta_Det"]));
            Rds.Add(new ReportDataSource("AliadoEdoCta_Enc", ds.Tables["AliadoEdoCta_Enc"]));
            //
            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}