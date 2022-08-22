using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Reportes.Filtros
{
    
    public class HlpFiltrar: IFiltrar
    {

        private bool _filtrarIsOk;
        private bool _salidaIsOk;
        private bool _activaEstatus;
        private bool _activaSucursal;
        private bool _activaMesAnoRelacion;
        private bool _activaFechaDesde;
        private bool _activaFechaHasta;
        private bool _activaProveedor;
        private DateTime _desde;
        private DateTime _hasta;
        private HlpGestion.HndCombo.IOpcion _gSucursal;
        private HlpGestion.HndCombo.IOpcion _gEstatus;
        private ModCompra.Filtros.Proveedor.IFiltro _gProv;


        public HlpFiltrar()
        {
            _activaEstatus = false;
            _activaSucursal = false;
            _activaFechaDesde = false;
            _activaFechaHasta = false;
            _activaMesAnoRelacion = false;
            _activaProveedor = false;
            _filtrarIsOk = false;
            _salidaIsOk = false;
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _gSucursal = new HlpGestion.HndCombo.Opcion();
            _gEstatus= new HlpGestion.HndCombo.Opcion();
            _gProv = new ModCompra.Filtros.Proveedor.Filtro();
        }


        public void Inicializa()
        {
            _filtrarIsOk = false;
            _salidaIsOk = false;
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _gSucursal.Inicializa();
            _gEstatus.Inicializa();
            _gProv.Inicializa();

        }
        FiltrosFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null) 
                {
                    frm = new FiltrosFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }


        public BindingSource GetSucursalData { get { return _gSucursal.Source; } }
        public BindingSource GetEstatusData { get { return _gEstatus.Source; } }


        private bool CargarData()
        {
            var xr1 = Sistema.MyData.Sucursal_GetLista();
            if (xr1.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(xr1.Mensaje);
                return false;
            }
            var _lst_1 = xr1.Lista.Select(s =>
            {
                return new HlpGestion.ficha(s.auto, "", s.nombre);
            }).ToList();
            _gSucursal.setData(_lst_1.OrderBy(o => o.desc).ToList());

            var _lst_2 = new List<HlpGestion.ficha>();
            _lst_2.Add(new HlpGestion.ficha("01", "", "ACTIVO"));
            _lst_2.Add(new HlpGestion.ficha("02", "", "ANULADO"));
            _gEstatus.setData(_lst_2);

            return true;
        }


        public bool FiltrarIsOk { get { return _filtrarIsOk; } }
        public void Filtrar()
        {
            if (_desde > _hasta) 
            {
                Helpers.Msg.Alerta("FECHAS INCORRECTAS, VERIFIQUE POR FAVOR");
                return;
            } 
            _filtrarIsOk = true;
        }

        public bool SalidaIsOk { get { return _salidaIsOk; } }
        public void Salir()
        {
            _salidaIsOk = true;
        }

        public bool GetEstatusActivo { get { return _activaEstatus; } }
        public bool GetSucursalActivo { get { return _activaSucursal; } }
        public bool GetMesAnoRelacionActivo { get { return _activaMesAnoRelacion; } }
        public bool GetFechaDesdeActivo { get { return _activaFechaDesde; } }
        public bool GetFechaHastaActivo { get { return _activaFechaHasta; } }
        public bool GetProveedorActivo { get { return _activaProveedor; } }
        public void setEstatusFiltros(IFiltros filtros)
        {
            _activaSucursal = filtros.ActivarSucursal;
            _activaEstatus = filtros.ActivarEstatus;
            _activaFechaDesde = filtros.ActivarDesde;
            _activaFechaHasta= filtros.ActivarHasta;
            _activaMesAnoRelacion = filtros.ActivarMesAnoRelacion;
            _activaProveedor = filtros.ActivarProveedor;
        }


        public string GetSurucrsalId { get { return _gSucursal.GetId; } }
        public string GetEstatusId { get { return _gEstatus.GetId; } }
        public string GetEstatusDesc { get { return _gEstatus.GetId != "" ? _gEstatus.Item.desc : ""; } }
        public string GetSucursalDesc { get { return _gSucursal.GetId != "" ? _gSucursal.Item.desc : ""; } }
        public DateTime GetFechaDesde { get { return _desde; } }
        public DateTime GetFechaHasta { get { return _hasta; } }
        public decimal GetMesRelacion { get { return DateTime.Now.Date.Month; } }
        public decimal GetAnoRelacion { get { return DateTime.Now.Date.Year; } }
        public string GetProveedorDesc { get { return _gProv.GetProveedorDesc; } }


        public void setFechaDesde(DateTime fecha)
        {
            _desde = fecha.Date;
        }
        public void setFechaHasta(DateTime fecha)
        {
            _hasta = fecha.Date;
        }
        public void setSucursal(string id)
        {
            _gSucursal.setFicha(id);
        }
        public void setEstatus(string id)
        {
            _gEstatus.setFicha(id);
        }


        public bool BuscarProvIsOk { get { return _gProv.ItemSeleccionadoIsOk; } }
        public void setProvBuscar(string desc)
        {
            _gProv.setCadenaBusq(desc);
        }
        public void BuscarProv()
        {
            _gProv.BuscarProv();
        }
        public bool GetProveedorSeleccionadoIsOk { get { return _gProv.ItemSeleccionadoIsOk; } }
        public string GetProveedorSeleccionadoId { get { return _gProv.GetProveedorSeleccionadoId; } }
        public string GetProveedorSeleccionadoDesc { get { return _gProv.GetProveedorSeleccionadoDesc; } }


        public void LimpiarProveedor()
        {
            _gProv.LimpiarSeleccion();
        }

    }

}