using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.zufu.ActualizarPrecio.Vista
{
    public interface IMatPrecio
    {
        CtrlPrecio.IPrecio[] Precio { get; }
        string Empaque { get; }
        int Contenido { get; }
        string DescTipoEmpaque { get; }
        bool HayError { get; }
        //
        void Inicializa();
        void setDescripcion(string desc);
        void setContenido(int cont);
        //
        void ActualizarImportacion();
        void RecuperarPrecios(string empaque, int cont, 
            CtrlPrecio.IPrecio p1, CtrlPrecio.IPrecio p2, 
            CtrlPrecio.IPrecio p3, CtrlPrecio.IPrecio p4);
        //
        bool VerificarPrecio(decimal costoUnd);
    }
}