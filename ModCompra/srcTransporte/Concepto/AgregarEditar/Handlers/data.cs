using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Concepto.AgregarEditar.Handlers
{
    public class data: AgregarEditar.Vistas.Idata
    {
        private string _codigo;
        private string _desc;


        public string Get_Codigo { get { return _codigo; } }
        public string Get_Descripcion { get { return _desc; } }


        public data()
        {
            _codigo = "";
            _desc = "";
        }


        public void SetCodigo(string desc)
        {
            _codigo = desc;
        }
        public void SetDescripcion(string desc)
        {
            _desc = desc;
        }


        public void Inicializa()
        {
            _codigo = "";
            _desc = "";
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
                Helpers.Msg.Alerta("CAMPO [ CODIGO ] NO PUEDE ESTAR VACIO");
                return false;
            }
            if (_desc.Trim() == "")
            {
                Helpers.Msg.Alerta("CAMPO [ DESCRIPCION ] NO PUEDE ESTAR VACIO");
                return false;
            }
            return rt;
        }
    }
}