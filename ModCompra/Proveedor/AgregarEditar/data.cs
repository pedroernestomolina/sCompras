using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Proveedor.AgregarEditar
{
    public class data
    {
        private string _ciRif;
        private string _codigo;
        private string _razonSocial;
        private string _dirFiscal;
        private string _pais;
        private string _codigoPostal;
        private string _persona;
        private string _telefono;
        private string _email;
        private string _website;
        private OOB.LibCompra.Maestros.Grupo.Ficha _grupo;
        private OOB.LibCompra.Maestros.Estado.Ficha _estado;
        private OOB.LibCompra.Maestros.DenFiscal.Ficha _denFiscal;
        private decimal _tasaRetIva;
        private string _codXmlIslr;
        private string _descXmlIslr;


        public string CiRif { get { return _ciRif.Trim().ToUpper(); } }
        public string Codigo { get { return _codigo.Trim().ToUpper(); } }
        public string RazonSocial { get { return _razonSocial.Trim().ToUpper(); } }
        public string DirFiscal { get { return _dirFiscal.Trim().ToUpper(); } }
        public string Pais { get { return _pais.Trim().ToUpper(); } }
        public string CodigoPostal { get { return _codigoPostal.Trim().ToUpper(); } }
        public string Persona { get { return _persona.Trim().ToUpper(); } }
        public string Telefono { get { return _telefono.Trim(); } }
        public string Email { get { return _email.Trim(); } }
        public string WebSite { get { return _website.Trim(); } }
        public decimal TasaRetIva { get { return _tasaRetIva; } }
        public string CodigoXmlIslr { get { return _codXmlIslr; } }
        public string DescXmlIslr { get { return _descXmlIslr; } }


        public string Grupo 
        { 
            get 
            {
                var rt = "";
                if (_grupo != null) rt = _grupo.auto;
                return rt;
            } 
        }
        public string DenFiscal
        {
            get
            {
                var rt = "";
                if (_denFiscal != null) rt = _denFiscal.auto;
                return rt;
            }
        }
        public string Estado
        {
            get
            {
                var rt = "";
                if (_estado != null) rt = _estado.auto;
                return rt;
            }
        }
        public string DenFiscalDescripcion
        {
            get
            {
                var rt = "";
                if (_denFiscal != null) rt = _denFiscal.nombre.Trim();
                return rt;
            }
        }


        public data()
        {
            limpiarFicha();
        }


        private void limpiarFicha()
        {
            _ciRif = "";
            _codigo = "";
            _razonSocial = "";
            _dirFiscal = "";
            _pais = "";
            _codigoPostal = "";
            _persona = "";
            _telefono = "";
            _email = "";
            _website = "";
            _denFiscal = null;
            _estado = null;
            _grupo = null;
            _tasaRetIva = 0.0m;
            _codXmlIslr = "";
            _descXmlIslr = "";
        }

        public void setCirRif(string dat) 
        {
            _ciRif = dat;
        }
        public void setCodigo(string dat)
        {
            _codigo = dat;
        }
        public void setRazonSocial(string dat) 
        {
            _razonSocial = dat;
        }
        public void setDirFiscal(string dat)
        {
            _dirFiscal= dat;
        }
        public void setPais (string dat)
        {
            _pais = dat;
        }
        public void setCodigoPostal (string dat)
        {
            _codigoPostal = dat;
        }
        public void setPersona (string dat)
        {
            _persona = dat;
        }
        public void setTelefono (string dat)
        {
            _telefono = dat;
        }
        public void setEmail (string dat)
        {
            _email = dat;
        }
        public void setWebSite (string dat)
        {
            _website = dat;
        }
        public void setGrupo(OOB.LibCompra.Maestros.Grupo.Ficha ficha)
        {
            _grupo = ficha;
        }
        public void setEstado(OOB.LibCompra.Maestros.Estado.Ficha ficha)
        {
            _estado = ficha;
        }
        public void setDenFiscal(OOB.LibCompra.Maestros.DenFiscal.Ficha ficha)
        {
            _denFiscal = ficha;
        }
        public void setTasaRetIva(decimal p)
        {
            _tasaRetIva = p;
        }
        public void setCodXmlIslr(string p)
        {
            _codXmlIslr = p;
        }
        public void setDescXmlIslr(string p)
        {
            _descXmlIslr = p;
        }

        public bool IsOk()
        {
            var rt = true;
            //
            if (_ciRif.Trim() == "")
            {
                Helpers.Msg.Error("DATO INCOMPLETO [ CIRIF ]");
                return false;
            }
            if (_razonSocial.Trim() == "") 
            {
                Helpers.Msg.Error("DATO INCOMPLETO [ NOMBRE / RAZON SOCIAL ]");
                return false;
            }
            if (_dirFiscal.Trim() == "")
            {
                Helpers.Msg.Error("DATO INCOMPLETO [ DIRECCION FISCAL ]");
                return false;
            }
            if (_estado== null)
            {
                Helpers.Msg.Error("DATO INCOMPLETO [ ESTADO ]");
                return false;
            }
            if (_grupo == null)
            {
                Helpers.Msg.Error("DATO INCOMPLETO [ GRUPO ]");
                return false;
            }
            if (_denFiscal == null)
            {
                Helpers.Msg.Error("DATO INCOMPLETO [ DENOMINACION FISCAL ]");
                return false;
            }
            //
            return rt;
        }

        public void Limpiar()
        {
            limpiarFicha();
        }
        public void cargarFicha(OOB.LibCompra.Proveedor.Data.Ficha ficha)
        {
            _ciRif=ficha.ciRif;
            _codigo=ficha.codigo;
            _razonSocial=ficha.nombreRazonSocial;
            _dirFiscal = ficha.direccionFiscal;
            _pais = ficha.identidad.pais;
            _codigoPostal = ficha.identidad.codigoPostal;
            _persona=ficha.identidad.nombreContacto;
            _telefono = ficha.identidad.telefono;
            _email = ficha.identidad.email;
            _website = ficha.identidad.website;
            _tasaRetIva = ficha.identidad.retIva;
            _codXmlIslr = ficha.identidad.codXmlIslr;
            _descXmlIslr = ficha.identidad.descXmlIslr;
        }
    }
}