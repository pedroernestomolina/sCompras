using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Caja.Maestro.AgregarEditar.Handlers.Agregar
{
    public class Imp: impBase, Vistas.IAgregar 
    {
        private int _idItemAgregado;


        public int IdItemAgregado { get { return _idItemAgregado; } }


        public Imp()
            :base()
        {
            _idItemAgregado = -1;
        }
        public override void Inicializa()
        {
            base.Inicializa();
            _idItemAgregado = -1;
        }
        public override void Procesar()
        {
            _procesarIsOK = false;
            _idItemAgregado = -1;
            if (data.DatosAgregarIsOk())
            {
                var r = Helpers.Msg.Procesar();
                if (r)
                {
                    var fichaOOB = new OOB.LibCompra.Transporte.Caja.Crud.Agregar.Ficha()
                    {
                        esDivisa = data.Get_IsDivisa,
                        saldoInicial = data.Get_Saldo,
                        codigo = data.Get_Codigo,
                        descripcion = data.Get_Descripcion,
                    };
                    try
                    {
                        var r01 = Sistema.MyData.Transporte_Caja_Agregar(fichaOOB);
                        _idItemAgregado = r01.Id;
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