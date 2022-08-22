using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Controlador
{
    
    public class GestionDocumento
    {

        private IGestionDocumento _gestion;
        private bool _hayItemsCargados;


        public string DocumentoNro { get { return _gestion.DocumentoNro; } set { _gestion.DocumentoNro = value; } }
        public DateTime FechaEmision { get { return _gestion.FechaEmision; } set { _gestion.FechaEmision = value; } }
        public string ControlNro { get { return _gestion.ControlNro; } set { _gestion.ControlNro = value; } }
        public int DiasCredito { get { return _gestion.DiasCredito; } set { _gestion.DiasCredito = value; } }
        public string OrdenCompraNro { get { return _gestion.OrdenCompraNro; } set { _gestion.OrdenCompraNro = value; } }
        public decimal FactorDivisa { get { return _gestion.FactorDivisa; } set { _gestion.FactorDivisa = value; } }
        public string Notas { get { return _gestion.Notas; } set { _gestion.Notas = value; } }
        public string IdSucursal { get { return _gestion.IdSucursal; } }
        public string IdDeposito { get { return _gestion.IdDeposito; } } 
        public string MesRelacion { get { return _gestion.MesRelacion; } }
        public string AnoRelacion { get { return _gestion.AnoRelacion; } }
        public string IdProveedor { get { return _gestion.IdProveedor; } }
        public string RifProveedor { get { return _gestion.RifProveedor; } }
        public string RazonSocialProveedor { get { return _gestion.RazonSocialProveedor; } }
        public string DireccionProveedor { get { return _gestion.DireccionProveedor; } } 
        public DateTime FechaVencimiento { get { return _gestion.FechaVencimiento; } }
        public BindingSource SucursalSource { get { return _gestion.SucursalSource; } }
        public BindingSource DepositoSource { get { return _gestion.DepositoSource; } }
        public Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda PreferenciaBusquedaProveedor { get { return _gestion.PreferenciaBusquedaProveedor; } }
        public bool IsAceptarOk { get { return _gestion.IsAceptarOk; } }
        public string CadenaBuscar { get { return _gestion.CadenaBuscar; } set { _gestion.CadenaBuscar = value; } }
        public bool ProveedorIsOk { get { return _gestion.ProveedorIsOk; } }
        public bool LimpiarDatosIsOk { get { return _gestion.LimpiarDatosIsOk; } }
        public string DepositoNombre { get { return _gestion.DepositoNombre; } }
        public string SucursalNombre { get { return _gestion.SucursalNombre; } }

        public string Remision { get { return _gestion.RemisionEstatus; } }
        public string Remision_TipoDocumento { get { return _gestion.Remision_TipoDocumento; } }
        public string Remision_Fecha { get { return _gestion.Remision_Fecha; } }
        public string Remision_Control { get { return _gestion.Remision_Control; } }
        public string Remision_Documento { get { return _gestion.Remision_Documento; } }
        public OOB.LibCompra.Documento.GetData.Ficha RemisionFicha { get { return _gestion.RemisionFicha ; } }
        public bool HayItemsCargados { get { return _hayItemsCargados; } }


        public string Proveedor 
        {
            get 
            {
                var rt = "";
                rt = RifProveedor + Environment.NewLine + RazonSocialProveedor + Environment.NewLine + DireccionProveedor;
                return rt;
            }

        }

        Formulario.DatosDocumentoFrm frm;
        public void Inicia()
        {
            if (_gestion.CargarData())
            {
                if (frm == null)
                {
                    frm = new Formulario.DatosDocumentoFrm();
                    frm.setControlador(this);
                }
                _gestion.setFormulario(frm);
                frm.ShowDialog();
            }
        }

        public void setGestion(IGestionDocumento gestion) 
        {
            _gestion = gestion;
        }

        public void Aceptar()
        {
            _gestion.Aceptar();
        }

        public void BuscarProveedor()
        {
            _gestion.BuscarProveedor();
        }

        public void setMetodoBusqueda(Proveedor.Busqueda.Enumerados.EnumMetodoBusqueda metodo)
        {
            _gestion.setMetodoBusqueda(metodo);
        }

        public void LimpiarDatos()
        {
            _gestion.LimpiarDatos();
        }

        public void setNotas(string p)
        {
            _gestion.setNotas(p);
        }

        public void setDeposito(string id)
        {
            _gestion.setDeposito(id);
        }

        public void setSucursal(string id)
        {
            _gestion.setSucursal(id);
        }

        public void IniciaEditar()
        {
            if (frm == null)
            {
                frm = new Formulario.DatosDocumentoFrm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }

        public void setHayItemsCargados(bool p)
        {
            _hayItemsCargados = p;
        }

    }

}