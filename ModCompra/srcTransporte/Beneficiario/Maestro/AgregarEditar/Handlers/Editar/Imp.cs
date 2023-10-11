using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Beneficiario.Maestro.AgregarEditar.Handlers.Editar
{
    public class Imp: impBase, Vistas.IEditar
    {
        private int _idItemEditar;


        public Imp()
            :base()
        {
            _idItemEditar = -1;
        }
        public override void Inicializa()
        {
            base.Inicializa();
            _idItemEditar = -1;
        }
        protected override bool CargarData()
        {
            var r = base.CargarData();
            if (r) 
            {
                try
                {
                    var r01 = Sistema.MyData.Transporte_Beneficiario_GetById(_idItemEditar);
                    data.SetCodigo(r01.Entidad.ciRif);
                    data.SetDescripcion(r01.Entidad.nombreRazonSocial);
                    data.SetDireccion(r01.Entidad.direccion);
                    data.SetTelefono(r01.Entidad.telefono);
                    return true;
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                    return false;
                }
            }
            return r;
        }
        public override void Procesar()
        {
            _procesarIsOK = false;
            if (data.DatosEditarIsOk())
            {
                var r = Helpers.Msg.Procesar();
                if (r)
                {
                    var fichaOOB = new OOB.LibCompra.Transporte.Beneficiario.Crud.Editar.Ficha()
                    {
                        id = _idItemEditar,
                        ciRif = data.Get_Codigo,
                        nombreRazonSocial = data.Get_Descripcion,
                        direccion = data.Get_Direccion,
                        telefono = data.Get_Telefono,
                    };
                    try
                    {
                        var r01 = Sistema.MyData.Transporte_Beneficiario_Editar(fichaOOB);
                        _procesarIsOK = true;
                        Helpers.Msg.EditarOk();
                    }
                    catch (Exception e)
                    {
                        Helpers.Msg.Error(e.Message);
                    }
                }
            }
        }
        public void setItemEditar(int id)
        {
            _idItemEditar = id;
        }
    }
}