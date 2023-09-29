using LibEntityCompra;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ProvLibCompra
{
    public partial class Provider: ILibCompras.IProvider
    {
        public DtoLib.ResultadoEntidad<DtoLibCompra.Auditoria.Entidad.Ficha> 
            AuditoriaDocumento_Get(DtoLibCompra.Auditoria.Entidad.Busqueda ficha)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCompra.Auditoria.Entidad.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("autoDoc", ficha.autoDoc);
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter("autoTipoDoc", ficha.autoTipoDoc);
                    var sql = @"SELECT 
                                    auto_usuario as usuAuto, 
                                    codigo as usuCodigo, 
                                    usuario as usuNombre, 
                                    fecha, 
                                    hora, 
                                    estacion as estacionEquipo, 
                                    memo as motivo
                                FROM auditoria_documentos 
                                WHERE auto_documento=@autoDoc and auto_sistema_documentos=@autoTipoDoc";
                    var ent = cnn.Database.SqlQuery<DtoLibCompra.Auditoria.Entidad.Ficha>(sql, p1, p2).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "[ ID DOCUMENTO / ID TIPO DOCUMENTO ] NO ENCONTRADO";
                        result.Result = DtoLib.Enumerados.EnumResult.isError;
                        return result;
                    }
                    result.Entidad = ent;
                }
            }
            catch (Exception e)
            {
                result.Mensaje = e.Message;
                result.Result = DtoLib.Enumerados.EnumResult.isError;
            }
            return result;
        }
    }
}