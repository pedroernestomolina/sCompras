using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.ArticulosCompra
{
    
    public class Gestion
    {


        private string _autoProv;
        private OOB.LibCompra.Proveedor.Data.Ficha _proveedor;
        private BindingSource _bs;
        private Filtro _filtro;
        private List<data> _ldata;


        public string Proveedor { get { return _proveedor.RifNombrePrv; } }
        public BindingSource Source { get { return _bs; } }
        public DateTime Desde { get { return _filtro.desde; } }
        public DateTime Hasta { get { return _filtro.hasta; } }


        public Gestion()
        {
            _autoProv = "";
            _filtro = new Filtro();
            _ldata= new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _ldata;
        }


        public void Inicializa()
        {
            _autoProv = "";
            _proveedor = null;
            _filtro.Limpiar();
        }

        public void setIdProveedor(string id)
        {
            _autoProv = id;
        }

        CompraArticulosFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new CompraArticulosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Proveedor_GetFicha(_autoProv);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _proveedor = r01.Entidad;
            _filtro.setProveedor(r01.Entidad.autoId);

            return rt;
        }

        public void setDesde(DateTime fecha)
        {
            _filtro.setDesde(fecha);
        }

        public void setHasta(DateTime fecha)
        {
            _filtro.setHasta(fecha);
        }

        public void Buscar()
        {
            if (_filtro.IsOk()) 
            {
                var filtroOOB = new OOB.LibCompra.Proveedor.Articulos.Filtro()
                {
                    desde = _filtro.desde,
                    hasta = _filtro.hasta,
                    autoProv = _filtro.autoProveedor,
                };
                var r01 = Sistema.MyData.Proveedor_ArticulosComprados_GetLista(filtroOOB);
                if (r01.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return;
                }
                _ldata.Clear();
                foreach(var it in r01.Lista)
                {
                    var nr = new data(it);
                    _ldata.Add(nr);
                }
                _bs.CurrencyManager.Refresh();
            }
        }

        public void Limpiar()
        {
            _filtro.Limpiar();
            _filtro.setProveedor(_proveedor.autoId);
            _ldata.Clear();
            _bs.CurrencyManager.Refresh();
        }

        public void Imprimir()
        {
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"ReporteProveedor\Articulo.rdlc";
            var ds = new ReporteProveedor.DS_PROV();

            foreach (var it in _ldata.ToList())
            {
                DataRow rt = ds.Tables["Articulo"].NewRow();
                rt["fecha"] = it.Fecha.Date;
                rt["tipo"] = it.Tipo;
                rt["serie"] = it.Serie;
                rt["documento"] = it.Documento;
                rt["producto"] = it.CodPrd + Environment.NewLine + it.DescripcionPrd;
                rt["cantidad"] = it.Cantidad;
                rt["empaque"] = it.EmpaqueCompra;
                rt["costoDivisa"] = it.CostoDivisa;
                rt["estatus"] = it.Estatus;
                ds.Tables["Articulo"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("Articulo", ds.Tables["Articulo"]));

            var frp = new Reportes.ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}