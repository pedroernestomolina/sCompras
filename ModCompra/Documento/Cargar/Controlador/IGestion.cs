using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public interface IGestion
    {

        event EventHandler ActualizarItemHnd;


        string TituloDocumento { get; }
        System.Drawing.Color ColorFondoDocumento { get; }
        bool SalidaOk { get; }
        Controlador.GestionProductoBuscar.metodoBusqueda MetodoBusquedaProducto { get; }
        bool VisualizarColDevolucion { get; }
        bool DejarPendienteIsOk { get; }
        string CadenaPrdBuscar { get; set; }
        string CntPend { get; }
        bool AbrirPendienteIsOk { get; }


        IGestionDocumento GestionDoc { get; }
        IGestionItem GestionItem { get; }
        IGestionTotalizar GestionTotalizar { get; }
        

        void Inicializar();
        bool CargarData();
        void Salir();
        void LimpiarDocumento();
        void BuscarProducto();
        void ActivarBusquedaProductoPorCodigo();
        void ActivarBusquedaProductoPorNombre();
        void ActivarBusquedaProductoPorReferencia();
        void Guardar();
        void CargarItems();
        void Totalizar();
        void AdmDocumentos();
        void DejarPendiente();
        void AbrirPendiente();


        BindingSource GetOpcionBusquedaSource { get; }
        string GetOpcionBusquedaId { get; }
        void setOpcBusqueda(string id);


        bool GetEsDocNotaEntrega{ get; }
        void CambiarTipoDocNotaEntrega();
    }
}