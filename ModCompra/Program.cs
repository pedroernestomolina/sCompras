using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ModCompra
{

    static class Program
    {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Sistema.CnfGenerarDoc = new Documento.CnfGenerarDocumento();
            var r01 = Helpers.Utilitis.CargarXml();
            if (r01.Result != OOB.Enumerados.EnumResult.isError)
            {
                if (Sistema._Usuario == "") 
                {
                    Sistema.MyData = new DataProvCompra.Data.DataProv(Sistema._Instancia, Sistema._BaseDatos);
                }
                else 
                {
                    Sistema.MyData = new DataProvCompra.Data.DataProv(Sistema._Instancia, Sistema._BaseDatos, Sistema._Usuario);
                }
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                var r02 = Sistema.MyData.Empresa_Datos();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r02.Mensaje);
                    Application.Exit();
                }
                else
                {
                    Sistema.Negocio = r02.Entidad;
                    Sistema.EquipoEstacion = Environment.MachineName;

                    var _gestionId = new Identificacion.Gestion();
                    _gestionId.Inicia();
                    if (_gestionId.IsUsuarioOk)
                    {
                        var _gestionCompra = new Gestion();
                        _gestionCompra.Inicia();
                    }
                }
                //Application.EnableVisualStyles();
                //Application.SetCompatibleTextRenderingDefault(false);
                //Application.Run(new Form1());
            }
            else
            {
                Helpers.Msg.Error(r01.Mensaje);
                Application.Exit();
            }
        }

    }

}