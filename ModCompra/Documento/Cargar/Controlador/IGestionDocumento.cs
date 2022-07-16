using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public interface IGestionDocumento
    {

        string CadenaBuscar { get; set; }
        string DocumentoNro { get; set; }
        string ControlNro { get; set; }
        string OrdenCompraNro { get; set; }
        int DiasCredito { get; set; }
        decimal FactorDivisa { get; set; }
        DateTime FechaEmision { get; set; }
        string Notas { get; set; }
        string IdSucursal { get; }
        string IdDeposito { get; }
        string MesRelacion { get; }
        string AnoRelacion { get; }
        DateTime FechaVencimiento { get; }
        string IdProveedor { get; }
        string RifProveedor { get; }
        string RazonSocialProveedor { get; }
        string DireccionProveedor { get; }
        System.Windows.Forms.BindingSource SucursalSource { get; }
        System.Windows.Forms.BindingSource DepositoSource { get; }
        Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda PreferenciaBusquedaProveedor { get; }
        bool IsAceptarOk { get; }
        bool ProveedorIsOk { get; set; }
        bool LimpiarDatosIsOk { get; set; }
        string DepositoNombre { get; }
        string SucursalNombre { get; }
        string CondicionPago { get; }
        OOB.LibCompra.Sucursal.Data.Ficha Sucursal { get; }
        OOB.LibCompra.Deposito.Data.Ficha Deposito { get; }
        OOB.LibCompra.Proveedor.Data.Ficha Proveedor { get; }
        //
        string RemisionEstatus { get; }
        string Remision_TipoDocumento { get; }
        string Remision_Fecha { get; }
        string Remision_Control { get; }
        string Remision_Documento { get; }
        OOB.LibCompra.Documento.GetData.Ficha RemisionFicha { get; }
        //

        bool CargarData();
        void Aceptar();
        void setMetodoBusqueda(Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda metodo);
        void BuscarProveedor();
        void LimpiarDatos();
        void Limpiar();
        void setNotas(string p);
        void setFormulario(Formulario.DatosDocumentoFrm frm);
        void setFactorCambio(decimal p);
        void setProveedor(OOB.LibCompra.Proveedor.Data.Ficha prv);
        void setDocumentoNro(string p);
        void setControlNro(string p);
        void setFechaEmision(DateTime dateTime);
        void setDiasCredito(int p);
        void setSucursal(string p);
        void setDeposito(string p);
        void setOrdenCompra(string p);
        void AceptarData();
        void Inicializa();

    }

}