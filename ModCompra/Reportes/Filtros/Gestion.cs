using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Reportes.Filtros
{
    
    public class Gestion
    {

        private Reportes.Filtros.IReporte miGestion;
        private IFiltros filtros;
        private List<OOB.LibCompra.Sucursal.Data.Ficha> lSucursal;
        private List<Estatus> lEstatus;
        private BindingSource bsSucursal;
        private BindingSource bsEstatus;
        private data dataFiltro;


        public bool ActivarSucursal { get { return filtros.ActivarSucursal; } }
        public bool ActivarDesde { get { return filtros.ActivarDesde; } }
        public bool ActivarHasta { get { return filtros.ActivarHasta; } }
        public bool ActivarProveedor { get { return filtros.ActivarProveedor; } }
        public bool ActivarEstatus { get { return filtros.ActivarEstatus; } }
        public bool ActivarMesAnoRElacion { get { return filtros.ActivarMesAnoRelacion; } }
        public BindingSource SourceSucursal{ get { return bsSucursal; } }
        public BindingSource SourceEstatus { get { return bsEstatus; } }
        public data DataFiltrar { get { return dataFiltro; } }


        public bool FiltrosIsOk { get; set; }


        public Gestion()
        {
            dataFiltro = new data();
            lSucursal= new List<OOB.LibCompra.Sucursal.Data.Ficha >();
            lEstatus = new List<Estatus>();
            bsSucursal= new BindingSource();
            bsEstatus = new BindingSource();
            bsSucursal.DataSource = lSucursal;
            bsEstatus.DataSource = lEstatus;
            FiltrosIsOk = false;
        }


        public void Inicia()
        {
            Limpiar();
            if (CargarData())
            {
                var frm = new FiltrosFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var rt = true;

            var xr1 = Sistema.MyData.Sucursal_GetLista();
            if (xr1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr1.Mensaje);
                return false;
            }

            lSucursal.Clear();
            lEstatus.Clear();
            foreach (var it in xr1.Lista.OrderBy(o => o.nombre).ToList())
            {
                lSucursal.Add(new OOB.LibCompra.Sucursal.Data.Ficha(it));
            }
            lEstatus.Add(new Estatus("01", "ACTIVO"));
            lEstatus.Add(new Estatus("02", "ANULADO"));

            return rt;
        }

        private void Limpiar()
        {
            FiltrosIsOk = false;
            dataFiltro.Limpiar();
        }

        public void setGestion(Reportes.Filtros.IReporte gestion)
        {
            miGestion = gestion;
            filtros = miGestion.Filtros;
        }

        public void setEstatus(string autoId)
        {
            dataFiltro.estatus = lEstatus.FirstOrDefault(f => f.Id == autoId);
        }

        public void setSucursal(string autoId)
        {
            dataFiltro.sucursal = lSucursal.FirstOrDefault(f => f.auto == autoId);
        }

        public void setFechaDesde(DateTime fecha)
        {
            dataFiltro.desde = fecha.Date;
        }

        public void setFechaHasta(DateTime fecha)
        {
            dataFiltro.hasta = fecha.Date;
        }

        public void Filtrar()
        {
            miGestion.setDataFiltros(dataFiltro);
            miGestion.Generar();
        }

        public void LimpiarFiltros()
        {
            Limpiar();
        }

        public void LimpiarMesAnoRelacion()
        {
            dataFiltro.LimpiarMesAnoRelacion();
        }

        public void setMesAnoRelacion(decimal mes, decimal ano)
        {
            dataFiltro.mesRelacion = ((int)mes).ToString().Trim().PadLeft(2, '0');
            dataFiltro.anoRelacion = ((int)ano).ToString().Trim().PadLeft(4, '0');
        }

    }

}