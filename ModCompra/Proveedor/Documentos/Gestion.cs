using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.Documentos
{
    
    public class Gestion
    {


        private string _autoProv;
        private OOB.LibCompra.Proveedor.Data.Ficha _proveedor;
        private BindingSource _bs;
        private BindingSource _bsTipoDoc ;
        private Filtro _filtro;
        private List<data> _ldata;
        private List<dataGeneral> _ltipoDoc;


        public string Proveedor { get { return _proveedor.RifNombrePrv; } }
        public BindingSource Source { get { return _bs; } }
        public DateTime Desde { get { return _filtro.desde; } }
        public DateTime Hasta { get { return _filtro.hasta; } }
        public string IdTipoDocumento 
        { 
            get 
            {
                var id = "";
                if (_filtro.TipoDocumento != null) 
                {
                    id = _filtro.TipoDocumento.id;
                }
                return id;
            } 
        }
        public BindingSource SourceTipoDocumento { get { return _bsTipoDoc; } }


        public Gestion()
        {
            _autoProv = "";
            _filtro = new Filtro();
            _ltipoDoc = new List<dataGeneral>();
            _ldata= new List<data>();
            _bs = new BindingSource();
            _bs.DataSource = _ldata;
            _bsTipoDoc = new BindingSource();
            _bsTipoDoc.DataSource = _ltipoDoc;
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

        DocumentosFrm frm;
        public void Inicia()
        {
            if (CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new DocumentosFrm();
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

            _ltipoDoc.Clear();
            _ltipoDoc.Add(new dataGeneral("01", "FACTURA"));
            _ltipoDoc.Add(new dataGeneral("02", "NOTA DEBITO"));
            _ltipoDoc.Add(new dataGeneral("03", "NOTA CREDITO"));
            _ltipoDoc.Add(new dataGeneral("04", "ORDEN COMPRA"));
            _bsTipoDoc.CurrencyManager.Refresh();

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

        public void setTipoDocumento(string id)
        {
            _filtro.setTipoDocumento(_ltipoDoc.FirstOrDefault(f=>f.id==id));
        }

        public void Buscar()
        {
            if (_filtro.IsOk()) 
            {
                var filtroOOB = new OOB.LibCompra.Proveedor.Documentos.Filtro()
                {
                    desde = _filtro.desde,
                    hasta = _filtro.hasta,
                    autoProv = _filtro.autoProveedor,
                };
                if (_filtro.TipoDocumento != null) 
                {
                    switch (_filtro.TipoDocumento.id) 
                    {
                        case "01":
                            filtroOOB.tipoDoc = OOB.LibCompra.Proveedor.Documentos.Enumerados.enumTipoDoc.Factura;
                            break;
                        case "02":
                            filtroOOB.tipoDoc = OOB.LibCompra.Proveedor.Documentos.Enumerados.enumTipoDoc.NotaDebito;
                            break;
                        case "03":
                            filtroOOB.tipoDoc = OOB.LibCompra.Proveedor.Documentos.Enumerados.enumTipoDoc.NotaCRedito;
                            break;
                        case "04":
                            filtroOOB.tipoDoc = OOB.LibCompra.Proveedor.Documentos.Enumerados.enumTipoDoc.OrdenCompra;
                            break;
                    }
                }

                var r01 = Sistema.MyData.Proveedor_Documentos_GetLista(filtroOOB);
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
            var pt = AppDomain.CurrentDomain.BaseDirectory + @"ReporteProveedor\Documento.rdlc";
            var ds = new ReporteProveedor.DS_PROV();

            foreach (var it in _ldata.ToList())
            {
                DataRow rt = ds.Tables["Documento"].NewRow();
                rt["fecha"] = it.Fecha.Date;
                rt["tipo"] = it.Tipo;
                rt["serie"] = it.Serie;
                rt["docNro"] = it.Documento;
                rt["controlNro"] = it.ControlNro;
                rt["monto"] = it.Importe ;
                rt["montoDivisa"] = it.ImporteDivisa;
                rt["estatus"] = it.Estatus ;
                ds.Tables["Documento"].Rows.Add(rt);
            }

            var Rds = new List<ReportDataSource>();
            var pmt = new List<ReportParameter>();
            //pmt.Add(new ReportParameter("EMPRESA_RIF", Sistema.Negocio.CiRif));
            //pmt.Add(new ReportParameter("EMPRESA_NOMBRE", Sistema.Negocio.Nombre));
            //pmt.Add(new ReportParameter("EMPRESA_DIRECCION", Sistema.Negocio.DireccionFiscal));
            //pmt.Add(new ReportParameter("DOCUMENTO", ficha.documentoModo));
            Rds.Add(new ReportDataSource("Documento", ds.Tables["Documento"]));

            var frp = new Reportes.ReporteFrm();
            frp.rds = Rds;
            frp.prmts = pmt;
            frp.Path = pt;
            frp.ShowDialog();
        }

    }

}