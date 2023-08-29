using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Administrador
{
    
    public interface IGestion
    {

        enumerados.EnumTipoAdministrador TipoAdministrador { get; }
        string Titulo { get; }
        BindingSource ItemsSource { get; }
        string ItemsEncontrados { get; }
        BindingSource SucursalSource { get; }
        BindingSource TipoDocSource { get; }
        string Proveedor { get; }
        bool ItemSeleccionadoIsOk { get; }
        Documentos.data ItemSeleccionado { get; }
        DateTime FechaDesde { get; }
        DateTime FechaHasta { get; }


        void Inicia();
        void Buscar();
        void AnularItem();
        void LimpiarFiltros();
        void LimpiarData();
        void VisualizarDocumento();
        void VisualizarAnulacion();
        void Imprimir();
        void Limpiar();
        bool CargarData();
        void setFechaDesde(DateTime fecha);
        void setFechaHasta(DateTime fecha);
        void setSucursal(string autoId);
        void setTipoDoc(string id);
        void setCadenaBusProv(string cad);
        void CorrectorDocumento();
        void BuscarProveedor();
        void LimpiarProveedor();
        void SeleccionarItem();
        void Inicializa();
        void setActivarSeleccionItem(bool p);

    }

}