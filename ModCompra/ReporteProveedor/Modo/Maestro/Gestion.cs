using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.ReporteProveedor.Modo.Maestro
{
    
    public class Gestion: IGestion
    {

        private ReporteProveedor.Filtro.IFiltro _filtro;


        public ReporteProveedor.Filtro.IFiltro Filtros { get { return _filtro; } }


        public Gestion()
        {
            _filtro = new Filtro();
        }


        public void Generar(ReporteProveedor.Filtro.data data)
        {
            var filtro = new OOB.LibCompra.ReporteProv.Maestro.Filtro();
            if (data.Grupo != null)
            {
                filtro.idGrupo = data.Grupo.Id;
            }
            if (data.Estado != null)
            {
                filtro.idEstado = data.Estado.Id;
            }
            if (data.Estatus != null)
            {
                var desc = data.Estatus.Descripcion;
                filtro.estatus = desc;
            }
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

            var frp = new Reportes.ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}