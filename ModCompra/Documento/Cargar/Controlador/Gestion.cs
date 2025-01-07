using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public class Gestion
    {

        private IGestion _gestion;
        private GestionDocumento _gestionDoc;
        private GestionItem _gestionItem;
        private GestionTotalizar _gestionTotalizar;

        //
        public System.Drawing.Color ColorFondoDocumento { get { return _gestion.ColorFondoDocumento; } }
        public string TituloDocumento { get { return _gestion.TituloDocumento; } }
        public bool SalidaOk { get { return _gestion.SalidaOk; } }
        //
        public string Proveedor { get { return _gestionDoc.Proveedor; } }
        public DateTime FechaEmision { get { return _gestionDoc.FechaEmision; } }
        public string DocumentoNro { get { return _gestionDoc.DocumentoNro; } }
        public string ControlNro { get { return _gestionDoc.ControlNro; } }
        public DateTime FechaVencimiento { get { return _gestionDoc.FechaVencimiento; } }
        public decimal FactorDivisa { get { return _gestionDoc.FactorDivisa; } }
        public string Deposito { get { return _gestionDoc.DepositoNombre; } }
        public string Sucursal { get { return _gestionDoc.SucursalNombre; } }
        public bool DatosDocumentoIsOk { get { return _gestionDoc.IsAceptarOk; } }
        //
        public BindingSource ItemSource { get { return _gestionItem.ItemSource; } }
        public decimal Total { get { return _gestionItem.TotalMonto; } }
        public decimal MontoIva { get { return _gestionItem.MontoIva; } }
        public decimal MontoDivisa { get { return _gestionItem.MontoDivisa; } }
        public int Items { get { return _gestionItem.TItems; } }
        public bool VisualizarColDevolucion { get { return _gestion.VisualizarColDevolucion; } }
        //
        public GestionProductoBuscar.metodoBusqueda MetodoBusquedaProducto { get { return _gestion.MetodoBusquedaProducto; } }
        public string CadenaPrdBuscar { get { return _gestion.CadenaPrdBuscar; } set { _gestion.CadenaPrdBuscar = value; } }
        //
        public string Item_Producto { get { return _gestionItem.Item_Producto; } }
        public decimal Item_Importe { get { return _gestionItem.Item_Importe; } }
        public decimal Item_Impuesto { get { return _gestionItem.Item_Impuesto; } }
        public decimal Item_Total { get { return _gestionItem.Item_Total; } }
        public decimal Item_Cantidad { get { return _gestionItem.Item_Cantidad; } }
        public decimal Item_CantidadUnd { get { return _gestionItem.Item_CantidadUnd; } }
        public decimal Item_CostoMoneda { get { return _gestionItem.Item_CostoMoneda; } }
        public decimal Item_CostoMonedaUnd { get { return _gestionItem.Item_CostoMonedaUnd; } }
        public decimal Item_CostoDivisa { get { return _gestionItem.Item_CostoDivisa; } }
        public decimal Item_CostoDivisaUnd { get { return _gestionItem.Item_CostoDivisaUnd; } }
        public string Item_EmpaqueCont { get { return _gestionItem.Item_EmpaqueCont; } }
        public string Item_CodRefPrv { get { return _gestionItem.Item_CodRefPrv; } }
        public decimal Item_Dscto { get { return _gestionItem.Item_Dscto; } }
        //
        public bool DejarPendienteIsOk { get { return _gestion.DejarPendienteIsOk; } }
        public string CntPend { get { return _gestion.CntPend; } }
        public bool AbrirPendienteIsOk { get { return _gestion.AbrirPendienteIsOk; } }


        public Gestion()
        {
            _gestionDoc = new GestionDocumento();
            _gestionItem = new GestionItem();
            _gestionItem.ActualizarItemHnd +=_gestionItem_ActualizarItemHnd;
            _gestionTotalizar= new GestionTotalizar();
        }


        private void _gestionItem_ActualizarItemHnd(object sender, EventArgs e)
        {
            frm.ActualizarDatosItem();
        }

        public void setGestion(IGestion gestion) 
        {
            _gestion = gestion;
            _gestion.ActualizarItemHnd +=_gestion_ActualizarItemHnd;
            _gestionDoc.setGestion(_gestion.GestionDoc);
            _gestionItem.setGestion(_gestion.GestionItem);
            _gestionTotalizar.setGestion(_gestion.GestionTotalizar);
        }

        private void _gestion_ActualizarItemHnd(object sender, EventArgs e)
        {
            frm.ActualizarDatosItem();
        }

        Formulario.DocumentoFrm frm;
        public void Inicia() 
        {
            _gestion.Inicializar();
            if (CargarData())
            {
                frm = new Formulario.DocumentoFrm();
                frm.setControlador(this);
                frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            return _gestion.CargarData();
        }

        public void NuevoDocumento()
        {
            if (_gestion.GestionItem.Lista.Count() == 0)
            {
                _gestionDoc.Inicia();
                _gestion.CargarItems();
            }
        }

        public void LimpiarItems()
        {
            _gestionItem.LimpiarItems();
        }

        public void EliminarItem()
        {
            _gestionItem.EliminarItem();
        }

        public void EditarItem()
        {
            _gestionItem.EditarItem();
        }

        public void BuscarProducto()
        {
            _gestion.BuscarProducto();
        }

        public void ActivarBusquedaProductoPorCodigo()
        {
            _gestion.ActivarBusquedaProductoPorCodigo();
        }

        public void ActivarBusquedaProductoPorNombre()
        {
            _gestion.ActivarBusquedaProductoPorNombre();
        }

        public void ActivarBusquedaProductoPorReferencia()
        {
            _gestion.ActivarBusquedaProductoPorReferencia();
        }

        public void Salir()
        {
            _gestion.Salir();
        }

        public void LimpiarDocumento()
        {
            _gestion.LimpiarDocumento();
        }

        public void Totalizar()
        {
            _gestion.Totalizar();
        }

        public void ImportarDoc()
        {
            AdmDocumentos();
        }

        private void AdmDocumentos()
        {
            _gestion.AdmDocumentos();
        }

        public void DejarPendiente()
        {
            _gestion.DejarPendiente();
        }

        public void AbrirPendiente()
        {
            _gestion.AbrirPendiente();
        }

        public void EditarDoc()
        {
            if (_gestionDoc.IsAceptarOk)
            {
                _gestionDoc.setHayItemsCargados(Items > 0);
                _gestionDoc.IniciaEditar();
            }
        }


        public BindingSource GetOpcionBusquedaSource { get { return _gestion.GetOpcionBusquedaSource; } }
        public string GetOpcionBusquedaId { get { return _gestion.GetOpcionBusquedaId; } }
        public void setOpcBusqueda(string id)
        {
            _gestion.setOpcBusqueda(id);
        }


        public bool GetEsDocNotaEntrega { get { return _gestion.GetEsDocNotaEntrega; } }
        public void CambiarTipoDocNotaEntrega()
        {
            _gestion.CambiarTipoDocNotaEntrega();
        }
    }
}