using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.zufu.ActualizarPrecio.Handler
{
    public class ImpMatPrecio: Vista.IMatPrecio
    {
        private CtrlPrecio.IPrecio[] _precio;
        private string _descripcion;
        private int _contenido;
        //
        public string Empaque { get { return _descripcion; } }
        public int Contenido { get { return _contenido; } }
        public CtrlPrecio.IPrecio[] Precio { get { return _precio; } }
        public string DescTipoEmpaque { get { return "Empaque Venta Tipo: (" + _descripcion.Trim() + "/" + _contenido.ToString().Trim() + ")"; } }
        public bool HayError
        {
            get 
            { 
                var rt=false;
                if (_precio != null) 
                {
                    var ct = _precio.Count(f => f.Data.UtilidadIsError);
                    return ct > 0;
                }
                return rt;
            }
        }
        //
        public ImpMatPrecio()
        {
            _descripcion = "";
            _contenido = 0;
            _precio = new CtrlPrecio.IPrecio[4];
        }
        //cuando se necesite cargar precios
        public ImpMatPrecio(Vista.IMatPrecio precioEmp)
        {
            _precio = new CtrlPrecio.ImpPrecio[4];
            _descripcion = precioEmp.Empaque;
            _contenido = precioEmp.Contenido;
            _precio[0] = new CtrlPrecio.ImpPrecio(precioEmp.Precio[0]);
            _precio[1] = new CtrlPrecio.ImpPrecio(precioEmp.Precio[1]);
            _precio[2] = new CtrlPrecio.ImpPrecio(precioEmp.Precio[2]);
            _precio[3] = new CtrlPrecio.ImpPrecio(precioEmp.Precio[3]);
        }
        //cuando se necesite cargar precios y actualizar costo
        public ImpMatPrecio(Vista.IMatPrecio precioEmp, decimal costoUnd)
        {
            _precio = new CtrlPrecio.ImpPrecio[4];
            _descripcion = precioEmp.Empaque;
            _contenido = precioEmp.Contenido;
            _precio[0] = new CtrlPrecio.ImpPrecio(precioEmp.Precio[0], costoUnd);
            _precio[1] = new CtrlPrecio.ImpPrecio(precioEmp.Precio[1], costoUnd);
            _precio[2] = new CtrlPrecio.ImpPrecio(precioEmp.Precio[2], costoUnd);
            _precio[3] = new CtrlPrecio.ImpPrecio(precioEmp.Precio[3], costoUnd);
        }
        public void Inicializa()
        {
            foreach (var el in _precio)
            {
                if (el != null) { el.Inicializa(); }
            }
        }
        public void setDescripcion(string desc)
        {
            _descripcion = desc;
        }
        public void setContenido(int cont)
        {
            _contenido = cont;
        }
        //CUANDO LOS PRECIOS SON IMPORTADOS PARA SER EDITADOS 
        //SE VERIFICA EL NUEVO COSTO 
        //SE ACTIVAN ERRORES DE PRECIO POR DEBAJO DEL COSTO
        public void ActualizarImportacion()
        {
            foreach (var it in _precio) 
            {
                it.ActualizarImportacion();
            }
        }
        //CUANDO LOS PRECIOS SON RECONSTRUIDOS POR UN PENDIENTE 
        public void RecuperarPrecios(string empaque, int cont, 
            CtrlPrecio.IPrecio p1,
            CtrlPrecio.IPrecio p2,
            CtrlPrecio.IPrecio p3,
            CtrlPrecio.IPrecio p4)
        {
            setDescripcion(empaque);
            setContenido(cont);
            _precio[0] = p1;
            _precio[1] = p2;
            _precio[2] = p3;
            _precio[3] = p4;
        }
    }
}