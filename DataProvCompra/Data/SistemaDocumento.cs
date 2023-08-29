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

        public OOB.ResultadoEntidad<OOB.LibCompra.SistemaDocumento.Entidad.Ficha> 
            SistemaDocumento_Get(OOB.LibCompra.SistemaDocumento.Entidad.Busqueda ficha)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.SistemaDocumento.Entidad.Ficha>();
            var fichaDTO = new DtoLibCompra.SistemaDocumento.Entidad.Busqueda()
            {
                codigoDoc = ficha.codigoDoc,
                tipoDoc = ficha.TipoDoc,
            };
            var r01 = MyData.SistemaDocumento_Get(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            rt.Entidad = new OOB.LibCompra.SistemaDocumento.Entidad.Ficha()
            {
                autoId = s.autoId,
                codigo = s.codigo,
                nombre = s.nombre,
                siglas = s.siglas,
                signo = s.signo,
                tipo = s.tipo,
            };
            return rt;
        }

    }

}