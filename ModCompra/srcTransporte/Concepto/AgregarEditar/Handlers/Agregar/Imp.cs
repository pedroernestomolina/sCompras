using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Concepto.AgregarEditar.Handlers.Agregar
{
    public class Imp: impBase, Vistas.IAgregar 
    {
        private int _idConceptoAgregado;


        public int IdConceptoAgregado { get { return _idConceptoAgregado; } }


        public Imp()
            :base()
        {
            _idConceptoAgregado = -1;
        }
        public override void Inicializa()
        {
            base.Inicializa();
            _idConceptoAgregado = -1;
        }
        public override void Procesar()
        {
            _procesarIsOK = false;
            _idConceptoAgregado = -1;
            if (data.DatosAgregarIsOk())
            {
                var r = Helpers.Msg.Procesar();
                if (r)
                {
                    var fichaOOB = new OOB.LibCompra.Transporte.Documento.Concepto.Agregar.Ficha()
                    {
                        codigo = data.Get_Codigo,
                        descripcion = data.Get_Descripcion,
                    };
                    try
                    {
                        var r01 = Sistema.MyData.Transporte_Documento_Concepto_Agregar(fichaOOB);
                        _idConceptoAgregado = r01.Id;
                        _procesarIsOK = true;
                        Helpers.Msg.AgregarOk();
                    }
                    catch (Exception e)
                    {
                        Helpers.Msg.Error(e.Message);
                    }
                }
            }
        }
    }
}