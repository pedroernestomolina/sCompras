using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Filtros
{
    
    public class Gestion
    {

        private data aFiltrar;
        private List<OOB.LibCompra.Sucursal.Data.Ficha> lSucursal;
        private BindingSource bsSucursal;
        private List<tipoDoc> lTipoDoc;
        private BindingSource bsTipoDoc;


        public data DataFiltrar { get { return aFiltrar; } }
        public BindingSource SucursalSource { get { return bsSucursal; } }
        public BindingSource TipoDocSource { get { return bsTipoDoc; } }
        public string Proveedor { get { return aFiltrar.Proveedor; } }
        public DateTime FechaDesde { get { return aFiltrar.FechaDesde; } }
        public DateTime FechaHasta { get { return aFiltrar.FechaHasta; } }


        public Gestion()
        {
            aFiltrar = new data();

            lSucursal = new List<OOB.LibCompra.Sucursal.Data.Ficha>();
            bsSucursal = new BindingSource();
            bsSucursal.DataSource = lSucursal;

            lTipoDoc = new List<tipoDoc>();
            bsTipoDoc = new BindingSource();
            bsTipoDoc.DataSource = lTipoDoc;
        }


        public void Inicia() 
        {
            InicializarFiltros();
        }

        public void InicializarFiltros()
        {
            aFiltrar.InicializarFiltros();
        }

        public void setFechaDesde(DateTime fecha) 
        {
            aFiltrar.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            aFiltrar.setFechaHasta(fecha);
        }

        public bool CargarData()
        {
            var rt = true;

            var rt1 = Sistema.MyData.Sucursal_GetLista();
            if (rt1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            lSucursal.Clear();
            lSucursal.AddRange(rt1.Lista.OrderBy(o=>o.nombre).ToList());
            bsSucursal.CurrencyManager.Refresh();

            lTipoDoc.Clear();
            lTipoDoc.Add(new tipoDoc("01", "Factura"));
            lTipoDoc.Add(new tipoDoc("02", "Nota Debito"));
            lTipoDoc.Add(new tipoDoc("03", "Nota Credito"));
            lTipoDoc.Add(new tipoDoc("04", "Orden Compra"));
            bsTipoDoc.CurrencyManager.Refresh();

            return rt;
        }

        public void setSucursal(string autoId)
        {
            aFiltrar.setSucursal(lSucursal.FirstOrDefault(f => f.auto == autoId));
        }

        public void setTipoDoc(string id)
        {
            aFiltrar.setTipoDoc(lTipoDoc.FirstOrDefault(f => f.id == id));
        }

        public void setProveedor(OOB.LibCompra.Proveedor.Data.Ficha prv)
        {
            aFiltrar.setProveedor(prv);
        }

    }

}