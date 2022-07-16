using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Proveedor.Visualizar
{
    
    public class Gestion
    {

        private string _idProveedor;
        private data _ficha;


        public string CiRif { get { return _ficha.CiRif; } }
        public string Codigo { get { return _ficha.Codigo; } }
        public string NombreRazonSocial { get { return _ficha.NombreRazonSocial; } }
        public string DirFiscal { get { return _ficha.DirFiscal; } }
        public string CodPostal { get { return _ficha.CodPostal; } }
        public string Estado { get { return _ficha.Estado; } }
        public string Pais { get { return _ficha.Pais; } }
        public string Grupo { get { return _ficha.Grupo; } }
        public string Email { get { return _ficha.Email; } }
        public string Persona { get { return _ficha.Persona; } }
        public string WebSite { get { return _ficha.WebSite; } }
        public string Telefono { get { return _ficha.Telefono; } }
        public string DenominacionFiscal { get { return _ficha.DenominacionFiscal; } }
        public string RetencionIva { get { return _ficha.RetencionIva; } }


        public Gestion() 
        {
            _idProveedor = "";
            _ficha = new data();
        }

        public void setIdProveedor(string id)
        {
            _idProveedor = id;
        }


        public void Inicializa() 
        {
            _idProveedor = "";
            _ficha.Inicializar();
        }

        private VisualizarFrm _frm;
        public void Inicia() 
        {
            if (CargarData()) 
            {
                if (_frm == null) 
                {
                    _frm = new VisualizarFrm();
                    _frm.setControlador(this);
                }
                _frm.ShowDialog();
            }
        }

        private bool CargarData()
        {
            var r01 = Sistema.MyData.Proveedor_GetFicha(_idProveedor);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _ficha.setData(r01.Entidad);

            return true;
        }

    }

}