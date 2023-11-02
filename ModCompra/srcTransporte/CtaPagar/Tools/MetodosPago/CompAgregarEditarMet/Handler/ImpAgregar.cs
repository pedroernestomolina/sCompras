using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.Tools.MetodosPago.CompAgregarEditarMet.Handler
{
    public class ImpAgregar: baseAgregarEditar, Vista.IAgregar
    {
        public override string Get_TituloFicha { get { return "AGREGAR METODO/PAGO"; } }


        public ImpAgregar()
            :base()
        {
        }
        protected override bool cargarData()
        {
            try
            {
                HndData.Cargardata();
                var r01 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r01.Mensaje);
                    return false;
                }
                HndData.setFactor(r01.Entidad);
                //
                var r02 = Sistema.MyData.FechaServidor();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    return false;
                }
                _fechaServidor = r02.Entidad;
                HndData.setFechaOperacion(r02.Entidad);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}