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
            //Sistema.Fabrica = new Fabrica.Transporte.Imp();
            Sistema.Fabrica = new Fabrica.Pita.Imp();
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

                var _loginId= new Identificacion.Gestion();
                _loginId.Inicia();
                if (_loginId.IsUsuarioOk)
                {
                    var _gestionCompra = new Gestion();
                    _gestionCompra.Inicia();
                }
            }
            else
            {
                Helpers.Msg.Error(r01.Mensaje);
            }
            Application.Exit();
        }
    }
}