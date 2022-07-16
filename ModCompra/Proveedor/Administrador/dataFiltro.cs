using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Proveedor.Administrador
{
    
    public class dataFiltro
    {

        public Enumerados.enumMetodoBusqueda MetodoBusqueda;
        public string cadena { get; set; }


        public dataFiltro()
        {
            MetodoBusqueda = Enumerados.enumMetodoBusqueda.SinDefinir;
            Limpiar();
        }


        public void Limpiar()
        {
            cadena = "";
        }

    }

}