using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Maestro.AgregarEditar.Handlers
{
    public class data: AgregarEditar.Vistas.Idata
    {
        private bool _isDivisa;
        private decimal _saldo;
        private string _codigo;
        private string _desc;


        public bool Get_IsDivisa { get { return _isDivisa; } }
        public decimal Get_Saldo { get { return _saldo; } }
        public string Get_Codigo { get { return _codigo; } }
        public string Get_Descripcion { get { return _desc; } }


        public data()
        {
            _isDivisa = false;
            _saldo = 0m;
            _codigo = "";
            _desc = "";
        }


        public void setSaldoInicial(decimal monto)
        {
            _saldo = monto;
        }
        public void setIsDivisa(bool modo)
        {
            _isDivisa = modo;
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
            _isDivisa = false;
            _saldo = 0m;
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