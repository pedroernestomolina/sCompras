using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.AdministradorCompra
{

    public class RepAdmDoc: IRepAdmDoc
    {

        private List<data> _lst;


        public RepAdmDoc()
        {
            _lst = new List<data>();
        }

        public void setData(IEnumerable<object> lst)
        {
            _lst.Clear();
            _lst = (List<data>)lst;
        }
        public void Generar()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"Reportes\AdministradorCompra\Listado.rdlc";
            var ds = new DS();
            foreach (var it in _lst)
            {
                DataRow rt = ds.Tables["AdmDoc"].NewRow();
                rt["fechaEmision"] = it.FechaEmision;
                rt["fechaRegistro"] = it.FechaReg;
                rt["proveedor"] = it.ProvCiRif+Environment.NewLine+it.ProvNombre;
                rt["sucursal"] = it.Sucursal;
                rt["importe"] = it.IsAnulado ? 0 : it.Importe * it.Signo;
                rt["importeDivisa"] = it.IsAnulado ? 0 : it.ImporteDivisa * it.Signo;
                rt["estatusDoc"] = it.IsAnulado ? "ANULADO" : "";
                rt["aplica"] = it.Aplica;
                rt["numDoc"] = "Doc #: " + it.NumDocumento + Environment.NewLine + "Control #: " + it.NumControl;
                rt["numControlDoc"] = it.NumControl;
                rt["situacionDoc"] = it.Situacion;
                rt["signoDoc"] = it.SignoDesc;
                rt["tipoDoc"] = it.NombreDoc;
                ds.Tables["AdmDoc"].Rows.Add(rt);
            }
            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("Filtros", xfiltro));
            Rds.Add(new ReportDataSource("AdmDoc", ds.Tables["AdmDoc"]));

            var frp = new ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}