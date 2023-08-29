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

        public DtoLib.ResultadoEntidad<DtoLibCompra.SistemaDocumento.Entidad.Ficha> 
            SistemaDocumento_Get(DtoLibCompra.SistemaDocumento.Entidad.Busqueda ficha)
        {
            var result = new DtoLib.ResultadoEntidad<DtoLibCompra.SistemaDocumento.Entidad.Ficha>();
            try
            {
                using (var cnn = new compraEntities(_cnCompra.ConnectionString))
                {
                    var p1 = new MySql.Data.MySqlClient.MySqlParameter("@cod", ficha.codigoDoc);
                    var p2 = new MySql.Data.MySqlClient.MySqlParameter("@tipoDoc", ficha.tipoDoc);
                    var sql = @"SELECT 
                                    auto as autoId, 
                                    tipo, 
                                    codigo, 
                                    nombre,     
                                    signo, 
                                    siglas
                                FROM sistema_documentos 
                                WHERE codigo=@cod and upper(trim(tipo))=@tipoDoc";
                    var ent = cnn.Database.SqlQuery<DtoLibCompra.SistemaDocumento.Entidad.Ficha>(sql, p1,p2).FirstOrDefault();
                    if (ent == null)
                    {
                        result.Mensaje = "TIPO DOCUMENTO NO ENCONTRADO";
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