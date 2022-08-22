using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            ILibCompras.IProvider _test = new ProvLibCompra.Provider("localhost","pita");
            //var r01 = _test.Producto_Precio_GetCapturar_ById("0000000432");
        }
    }
}
