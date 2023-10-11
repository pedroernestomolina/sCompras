using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Beneficiario.Maestro.AgregarEditar.Handlers
{
    public class data: AgregarEditar.Vistas.Idata
    {
        private string _codigo;
        private string _desc;
        private string _direccion;
        private string _telefono;


        public string Get_Codigo { get { return _codigo; } }
        public string Get_Descripcion { get { return _desc; } }
        public string Get_Direccion { get { return _direccion; } }
        public string Get_Telefono { get { return _telefono; } }


        public data()
        {
            _codigo = "";
            _desc = "";
            _direccion = "";
            _telefono = "";
        }


        public void SetCodigo(string desc)
        {
            _codigo = desc;
        }
        public void SetDescripcion(string desc)
        {
            _desc = desc;
        }
        public void SetDireccion(string desc)
        {
            _direccion = desc;
        }
        public void SetTelefono(string desc)
        {
            _telefono = desc;
        }


        public void Inicializa()
        {
            _codigo = "";
            _desc = "";
            _direccion = "";
            _telefono = "";
        }
        public bool DatosAgregarIsOk()
        {
            return verificar();
        }
        public bool DatosEditarIsOk()
        {
            return verificar();
        }


        private bool verificar()
        {
            var rt = true;
            if (_codigo.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ CI/RIF ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_desc.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ NOMBRE/RAZON SOCIAL ] NO PUEDE ESTAR VACIO");
                return false;
            }
            return rt;
        }
    }
}