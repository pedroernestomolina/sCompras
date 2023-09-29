using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Maestro.AgregarEditar.Handlers.Editar
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
                    var r01 = Sistema.MyData.Transporte_Caja_GetById(_idItemEditar);
                    data.setIsDivisa(r01.Entidad.esDivisa=="1");
                    data.setSaldoInicial(r01.Entidad.saldoInicial);
                    data.SetCodigo(r01.Entidad.codigo);
                    data.SetDescripcion(r01.Entidad.descripcion);
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
                    var fichaOOB = new OOB.LibCompra.Transporte.Caja.Crud.Editar.Ficha()
                    {
                        id = _idItemEditar,
                        codigo = data.Get_Codigo,
                        descripcion = data.Get_Descripcion,
                        esDivisa = data.Get_IsDivisa,
                        saldoInicial = data.Get_Saldo,
                    };
                    try
                    {
                        var r01 = Sistema.MyData.Transporte_Caja_Editar(fichaOOB);
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