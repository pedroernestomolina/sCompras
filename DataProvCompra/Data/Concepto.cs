using DataProvCompra.InfraEstructura;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{

    public partial class DataProv: IData
    {

        public OOB.ResultadoEntidad<OOB.LibCompra.Concepto.Ficha> Concepto_PorMovCompra()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Concepto.Ficha>();

            var r01 = MyData.Concepto_PorMovCompra();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Concepto.Ficha ()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

        public OOB.ResultadoEntidad<OOB.LibCompra.Concepto.Ficha> Concepto_PorMovDevCompra()
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Concepto.Ficha>();

            var r01 = MyData.Concepto_PorMovDevCompra();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                rt.Mensaje = r01.Mensaje;
                rt.Result = OOB.Enumerados.EnumResult.isError;
                return rt;
            }

            var s = r01.Entidad;
            var nr = new OOB.LibCompra.Concepto.Ficha()
            {
                auto = s.auto,
                codigo = s.codigo,
                nombre = s.nombre,
            };
            rt.Entidad = nr;

            return rt;
        }

    }

}