using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Administrador
{
    
    public class Gestion
    {

        private IGestion _miGestion;


        public enumerados.EnumTipoAdministrador TipoAdministrador { get { return _miGestion.TipoAdministrador; } }
        public string Titulo { get { return _miGestion.Titulo; } }
        public string ItemsEncontrados { get { return _miGestion.ItemsEncontrados; } }
        public BindingSource ItemsSource { get { return _miGestion.ItemsSource; } }
        public BindingSource SucursalSource { get { return _miGestion.SucursalSource; } }
        public BindingSource TipoDocSource { get { return _miGestion.TipoDocSource; } }
        public string Proveedor { get { return _miGestion.Proveedor; } }
        public bool ItemSeleccionadoIsOk { get { return _miGestion.ItemSeleccionadoIsOk; } }
        public Documentos.data ItemSeleccionado { get { return _miGestion.ItemSeleccionado; } }
        public DateTime FechaDesde { get { return _miGestion.FechaDesde; } }
        public DateTime FechaHasta { get { return _miGestion.FechaHasta; } }

        
        AdministradorFrm frm;
        public void Inicia()
        {
            _miGestion.Limpiar();
            if (_miGestion.CargarData())
            {
                if (frm == null) 
                {
                    frm = new AdministradorFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }

        public void setGestion(IGestion gestion)
        {
            _miGestion = gestion;
        }


        public void setFechaDesde(DateTime fecha)
        {
            _miGestion.setFechaDesde(fecha);
        }

        public void setFechaHasta(DateTime fecha)
        {
            _miGestion.setFechaHasta(fecha);
        }

        public void Buscar()
        {
            _miGestion.Buscar();
        }

        public void LimpiarFiltros()
        {
            _miGestion.LimpiarFiltros();
        }

        public void LimpiarData()
        {
            _miGestion.LimpiarData();
        }

        public void VisualizarDocumento()
        {
            _miGestion.VisualizarDocumento();
        }

        public void setSucursal(string autoId)
        {
            _miGestion.setSucursal(autoId);
        }

        public void setTipoDoc(string id)
        {
            _miGestion.setTipoDoc(id);
        }

        public void AnularItem()
        {
            _miGestion.AnularItem();
        }

        public void Imprimir()
        {
            Helpers.Msg.Alerta("IR AL MODULO DE REPORTES");
        }

        public void CorrectorDocumentos()
        {
            _miGestion.CorrectorDocumento();
        }

        public void BuscarProveedor()
        {
            _miGestion.BuscarProveedor();
        }

        public void setCadenaBusProv(string cad)
        {
            _miGestion.setCadenaBusProv(cad);
        }

        public void LimpiarProveedor()
        {
            _miGestion.LimpiarProveedor();
        }

        public void SeleccionarItem()
        {
            _miGestion.SeleccionarItem();
            if (_miGestion.ItemSeleccionadoIsOk)
                CerrarFrm();
        }

        private void CerrarFrm()
        {
            frm.Close();
        }

        public void Inicializa()
        {
            _miGestion.Inicializa();
        }

        public void setActivarSeleccionItem(bool p)
        {
            _miGestion.setActivarSeleccionItem(p);
        }

    }

}