using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Concepto.AgregarEditar.Handlers.Editar
{
    public class Imp: impBase, Vistas.IEditar
    {
        private int _idConceptoEditar;


        public Imp()
            :base()
        {
            _idConceptoEditar = -1;
        }
        public override void Inicializa()
        {
            base.Inicializa();
            _idConceptoEditar = -1;
        }
        protected override bool CargarData()
        {
            var r = base.CargarData();
            if (r) 
            {
                try
                {
                    var r01 = Sistema.MyData.Transporte_Documento_Concepto_GetById(_idConceptoEditar);
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
                    var fichaOOB = new OOB.LibCompra.Transporte.Documento.Concepto.Editar.Ficha()
                    {
                        id = _idConceptoEditar,
                        codigo = data.Get_Codigo,
                        descripcion = data.Get_Descripcion,
                    };
                    try
                    {
                        var r01 = Sistema.MyData.Transporte_Documento_Concepto_Editar(fichaOOB);
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
        public void setConceptoEditar(int id)
        {
            _idConceptoEditar = id;
        }
    }
}