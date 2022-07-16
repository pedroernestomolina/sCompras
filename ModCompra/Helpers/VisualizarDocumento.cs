using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Helpers
{

    public static  class VisualizarDocumento
    {

        public static void Visualizar(string auto) 
        {
            var r01 = Sistema.MyData.Compra_DocumentoVisualizar(auto);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return ;
            }

            Generar(r01.Entidad);
        }

        private static void Generar(OOB.LibCompra.Documento.Visualizar.Ficha ficha)
        {
            var rp1 = new Reportes.Documento.Gestion(ficha);
            rp1.Generar();
        }

    }

}