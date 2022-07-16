using DataProvCompra.InfraEstructura;
using ServiceCompra.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataProvCompra.Data
{
    
    public partial class DataProv: IData
    {

        public static IService MyData;


        public DataProv(string instancia, string bd, string usu="root")
        {
            MyData = new ServiceCompra.MyService.Service(instancia, bd, usu);
        }


        public OOB.ResultadoEntidad<DateTime> FechaServidor()
        {
            var result = new OOB.ResultadoEntidad<DateTime>();

            var r01 = MyData.FechaServidor();
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                result.Mensaje = r01.Mensaje;
                result.Result = OOB.Enumerados.EnumResult.isError;
                return result;
            }

            result.Entidad = (DateTime)r01.Entidad;
            return result;
        }

    }

}