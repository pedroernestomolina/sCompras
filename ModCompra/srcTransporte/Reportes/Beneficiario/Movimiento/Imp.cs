using Microsoft.Reporting.WinForms;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Beneficiario.Movimiento
{
    public class Imp : IRepFiltro
    {
        private OOB.LibCompra.Transporte.Reportes.Beneficiario.Movimiento.Fitro _filtro;


        public Imp()
        {
            _filtro = new OOB.LibCompra.Transporte.Reportes.Beneficiario.Movimiento.Fitro();
        }
        public void setFiltros(object data)
        {
        }
        public void Generar()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Reportes_Beneficiario_Movimiento_GetLista(_filtro);
                var filtro2 = new OOB.LibCompra.Transporte.Reportes.Caja.Saldo.Filtro()
                {
                    fecha = new DateTime(2023, 10, 01),
                    idCaja = 2,
                };
                imprimir(r01.Lista);
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
            }
        }


        private void imprimir(List<OOB.LibCompra.Transporte.Reportes.Beneficiario.Movimiento.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"srcTransporte\Reportes\Beneficiario\RepBeneficiarioMov.rdlc";
            var ds = new DS_BENEFICIARIO();

            foreach (var rg in list.ToList())
            {
                DataRow rt = ds.Tables["Movimiento"].NewRow();
                rt["fecha"] = rg.fechaReg;
                rt["monto"] = rg.montoDiv;
                if (rg.estatusAnulado.Trim().ToUpper() == "1") 
                {
                    rt["monto"] = 0m;
                }
                rt["concepto"] = rg.codConcepto.Trim()+Environment.NewLine+rg.descConcepto.Trim();
                rt["beneficiario"] = rg.cirifBene.Trim() + Environment.NewLine + rg.nombreBene.Trim();
                rt["estatus"] = rg.estatusAnulado.Trim().ToUpper() == "1" ? "ANULADO" : "";
                ds.Tables["Movimiento"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("Movimiento", ds.Tables["Movimiento"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}