using Microsoft.Reporting.WinForms;
using ModCompra.ReporteProveedor;
using ModCompra.Reportes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Maestros.Proveedor
{
    public class Imp: IRep
    {
        public Imp()
        {
        }
        public void Generar()
        {
            var filtro = new OOB.LibCompra.ReporteProv.Maestro.Filtro();
            var r01 = Sistema.MyData.ReportesProv_Maestro(filtro);
            if (r01.Result ==  OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Imprimir(r01.Lista);
        }
        private void Imprimir(List<OOB.LibCompra.ReporteProv.Maestro.Ficha> list)
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"ReporteProveedor\Maestro.rdlc";
            var ds = new DS_PROV();

            foreach (var it in list.ToList())
            {
                DataRow rt = ds.Tables["Maestro"].NewRow();
                rt["codigo"] = it.codigo;
                rt["nombre"] = it.ciRif + Environment.NewLine + it.nombre;
                rt["dirFiscal"] = it.dirFiscal;
                rt["telefono"] = it.telefono;
                rt["estatus"] = it.estatus.Trim().ToUpper() == "ACTIVO" ? "" : "INACTIVO";
                ds.Tables["Maestro"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("Maestro", ds.Tables["Maestro"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }
    }
}