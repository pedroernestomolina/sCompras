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
        public OOB.ResultadoEntidad<OOB.LibCompra.Auditoria.Entidad.Ficha> 
            AuditoriaDocumento_Get(OOB.LibCompra.Auditoria.Entidad.Busqueda ficha)
        {
            var rt = new OOB.ResultadoEntidad<OOB.LibCompra.Auditoria.Entidad.Ficha>();
            var fichaDTO = new DtoLibCompra.Auditoria.Entidad.Busqueda()
            {
                autoDoc = ficha.autoDoc,
                autoTipoDoc = ficha.autoTipoDoc,
            };
            var r01 = MyData.AuditoriaDocumento_Get(fichaDTO);
            if (r01.Result == DtoLib.Enumerados.EnumResult.isError)
            {
                throw new Exception(r01.Mensaje);
            }
            var s = r01.Entidad;
            rt.Entidad = new OOB.LibCompra.Auditoria.Entidad.Ficha()
            {
                estacionEquipo = s.estacionEquipo,
                fecha = s.fecha,
                hora = s.hora,
                motivo = s.motivo,
                usuAuto = s.usuAuto,
                usuCodigo = s.usuCodigo,
                usuNombre = s.usuNombre,
            };
            return rt;
        }
    }
}