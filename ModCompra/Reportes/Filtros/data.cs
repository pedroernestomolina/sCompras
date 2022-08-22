using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Reportes.Filtros
{
    
    public class data
    {

        private string _idSucursal;
        private string _sucursal;
        private string _idEstatus;
        private string _estatus;
        private DateTime _desde;
        private DateTime _hasta;
        private string _mesRelacion;
        private string _anoRelacion;
        private string _idProveedor;
        private string _proveedor;


        public data()
        {
            Limpiar();
        }


        public void Limpiar()
        {
            _idSucursal = "";
            _idEstatus = "";
            _estatus = "";
            _sucursal = "";
            _desde = DateTime.Now.Date;
            _hasta = DateTime.Now.Date;
            _mesRelacion = "";
            _anoRelacion = "";
            _idProveedor = "";
            _proveedor = "";
        }

        public void setSucursal(string id, string desc) 
        {
            _idSucursal = id;
            _sucursal = desc;
        }
        public void setEstatus(string id, string desc)
        {
            _idEstatus = id;
            _estatus= desc;
        }
        public void setFechaDesde(DateTime fecha) 
        {
            _desde = fecha;
        }
        public void setFechaHasta(DateTime fecha)
        {
            _hasta= fecha;
        }
        public void setProveedor(string id, string desc)
        {
            _idProveedor = id;
            _proveedor = desc;
        }

        public DateTime GetDesde { get { return _desde; } }
        public DateTime GetHasta { get { return _hasta; } }
        public string GetSucursalId { get { return _idSucursal; } }
        public string GetEstatusId { get { return _idEstatus; } }
        public string GetProveedorId { get { return _idProveedor; } }
        public string GetProveedorDesc { get { return _proveedor; } }

    }

}