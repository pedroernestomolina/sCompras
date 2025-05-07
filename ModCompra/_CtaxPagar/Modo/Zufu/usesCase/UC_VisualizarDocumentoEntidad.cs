using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra._CtaxPagar.Modo.Zufu.usesCase
{
    public class UC_VisualizarDocumentoEntidad: IVisualizarDocumentoEntidad
    {
        private string _idDoc;
        //
        public void setIdDocVisualizar(string idDoc)
        {
            _idDoc = idDoc;
        }
        public void Execute()
        {
            try
            {
                var r00 = Sistema.MyData.Permiso_AdmDoc_Visualizar(Sistema.UsuarioP.autoGru);
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r00.Mensaje);
                }
                if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                {
                    Helpers.VisualizarDocumento.Visualizar(_idDoc);
                }
            }
            catch (Exception ex)
            {
                Helpers.Msg.Error(ex.Message);
            }
        }
    }
}
