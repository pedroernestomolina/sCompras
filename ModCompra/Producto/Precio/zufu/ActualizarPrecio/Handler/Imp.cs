using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Producto.Precio.zufu.ActualizarPrecio.Handler
{
    public class Imp: Vista.IVista
    {
        private Vista.IdataProducto _fichaPrd;
        private Vista.IMatPrecio _precioEmp1;
        private Vista.IMatPrecio _precioEmp2;
        private Vista.IMatPrecio _precioEmp3;
        private Utils.Control.Boton.Procesar.IProcesar _btProcesar;
        private Utils.Control.Boton.Abandonar.IAbandonar _btAbandonar;
        private Vista.IMatPrecio[] _preciosImportar;
        //
        public Vista.IdataProducto Data { get { return _fichaPrd; } }
        public Vista.IMatPrecio PrecioEmp1 { get { return _precioEmp1; } }
        public Vista.IMatPrecio PrecioEmp2 { get { return _precioEmp2; } }
        public Vista.IMatPrecio PrecioEmp3 { get { return _precioEmp3; } }
        public Utils.Control.Boton.Procesar.IProcesar BtProcesar { get { return _btProcesar; } }
        public Utils.Control.Boton.Abandonar.IAbandonar BtAbandonar { get { return _btAbandonar; } }
        //
        public Vista.IMatPrecio[] DataExportar
        {
            get
            {
                Vista.IMatPrecio[] rt = new ImpMatPrecio[3];
                rt[0] = new ImpMatPrecio(_precioEmp1);
                rt[1] = new ImpMatPrecio(_precioEmp2);
                rt[2] = new ImpMatPrecio(_precioEmp3); 
                return rt;
            }
        }

        public Imp()
        {
            _precioEmp1 = new ImpMatPrecio();
            _precioEmp2 = new ImpMatPrecio();
            _precioEmp3 = new ImpMatPrecio();
            _btProcesar = new Utils.Control.Boton.Procesar.Imp();
            _btAbandonar = new Utils.Control.Boton.Abandonar.Imp();
            _preciosImportar = null;
        }
        public void Inicializa()
        {
            _precioEmp1.Inicializa();
            _precioEmp2.Inicializa();
            _precioEmp3.Inicializa();
            _btAbandonar.Inicializa();
            _btProcesar.Inicializa();
            _preciosImportar = null;
        }
        Vista.Frm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Vista.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void Procesar()
        {
            if (_precioEmp1.HayError) 
            {
                Helpers.Msg.Error("HAY PRECIOS INCORRECTOS" + Environment.NewLine + _precioEmp1.DescTipoEmpaque);
                return;
            }
            if (_precioEmp2.HayError)
            {
                Helpers.Msg.Error("HAY PRECIOS INCORRECTOS" + Environment.NewLine + _precioEmp2.DescTipoEmpaque);
                return;
            }
            if (_precioEmp3.HayError)
            {
                Helpers.Msg.Error("HAY PRECIOS INCORRECTOS" + Environment.NewLine + _precioEmp3.DescTipoEmpaque);
                return;
            }
            _btProcesar.Opcion();
        }
        public void setProductoCargar(Vista.IdataProducto fichaPrd)
        {
            _fichaPrd = fichaPrd;
        }
        public void setImportarPrecios(Vista.IMatPrecio[] matPrecios)
        {
            _preciosImportar = matPrecios;
        }

        //
        private bool cargarData()
        {
            var rt = true;
            try
            {
                if (_fichaPrd == null) { throw new Exception("FICHA PRODUCTO A CARGAR NO REGISTRADA"); }
                var r01 = Sistema.MyData.Producto_ActualizarPreciosVenta_ObtenerData_GetById (_fichaPrd.idPrd);
                if (r01.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r01.Mensaje);
                }
                var r02 = Sistema.MyData.Configuracion_TasaCambioActual();
                if (r02.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r02.Mensaje);
                }
                var r03 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
                if (r03.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r03.Mensaje);
                }
                var r04 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta();
                if (r04.Result == OOB.Enumerados.EnumResult.isError)
                {
                    throw new Exception(r04.Mensaje);
                }
                //
                _fichaPrd.metCalculoUtilidadIsLineal =true;
                var _metCalculoUt = CtrlPrecio.enumerados.enumMetCalculoUtilidad.Lineal;
                if (r03.Entidad != OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Lineal)
                {
                    _metCalculoUt = CtrlPrecio.enumerados.enumMetCalculoUtilidad.Financiero;
                    _fichaPrd.metCalculoUtilidadIsLineal = false;
                }
                _fichaPrd.tasaCambio=r02.Entidad;
                //
                var _costoUnd = _fichaPrd.CostoxUnidad;
                var _prdTasaIva = _fichaPrd.tasaIva;
                //

                if (_preciosImportar != null)
                {
                    _precioEmp1 = new ImpMatPrecio(_preciosImportar[0], _costoUnd);
                    //
                    _precioEmp1.Precio[0].setUtilidadVieja(r01.Entidad.utEmpVta_1_Precio_1);
                    _precioEmp1.Precio[0].setPrecioViejo(r01.Entidad.pfdEmpVta_1_Precio_1, false);
                    _precioEmp1.Precio[0].setDescripcion("PRECIO 1");
                    _precioEmp1.Precio[1].setUtilidadVieja(r01.Entidad.utEmpVta_1_Precio_2);
                    _precioEmp1.Precio[1].setPrecioViejo(r01.Entidad.pfdEmpVta_1_Precio_2, false);
                    _precioEmp1.Precio[1].setDescripcion("PRECIO 2");
                    _precioEmp1.Precio[2].setUtilidadVieja(r01.Entidad.utEmpVta_1_Precio_3);
                    _precioEmp1.Precio[2].setPrecioViejo(r01.Entidad.pfdEmpVta_1_Precio_3, false);
                    _precioEmp1.Precio[2].setDescripcion("PRECIO 3");
                    _precioEmp1.Precio[3].setUtilidadVieja(r01.Entidad.utEmpVta_1_Precio_4);
                    _precioEmp1.Precio[3].setPrecioViejo(r01.Entidad.pfdEmpVta_1_Precio_4, false);
                    _precioEmp1.Precio[3].setDescripcion("PRECIO 4");
                    //
                    _precioEmp2 = new ImpMatPrecio(_preciosImportar[1], _costoUnd);
                    //
                    _precioEmp2.Precio[0].setUtilidadVieja(r01.Entidad.utEmpVta_2_Precio_1);
                    _precioEmp2.Precio[0].setPrecioViejo(r01.Entidad.pfdEmpVta_2_Precio_1, false);
                    _precioEmp2.Precio[0].setDescripcion("PRECIO 1");
                    _precioEmp2.Precio[1].setUtilidadVieja(r01.Entidad.utEmpVta_2_Precio_2);
                    _precioEmp2.Precio[1].setPrecioViejo(r01.Entidad.pfdEmpVta_2_Precio_2, false);
                    _precioEmp2.Precio[1].setDescripcion("PRECIO 2");
                    _precioEmp2.Precio[2].setUtilidadVieja(r01.Entidad.utEmpVta_2_Precio_3);
                    _precioEmp2.Precio[2].setPrecioViejo(r01.Entidad.pfdEmpVta_2_Precio_3, false);
                    _precioEmp2.Precio[2].setDescripcion("PRECIO 3");
                    _precioEmp2.Precio[3].setUtilidadVieja(r01.Entidad.utEmpVta_2_Precio_4);
                    _precioEmp2.Precio[3].setPrecioViejo(r01.Entidad.pfdEmpVta_2_Precio_4, false);
                    _precioEmp2.Precio[3].setDescripcion("PRECIO 4");
                    //
                    _precioEmp3 = new ImpMatPrecio(_preciosImportar[2], _costoUnd);
                    //
                    _precioEmp3.Precio[0].setUtilidadVieja(r01.Entidad.utEmpVta_3_Precio_1);
                    _precioEmp3.Precio[0].setPrecioViejo(r01.Entidad.pfdEmpVta_3_Precio_1, false);
                    _precioEmp3.Precio[0].setDescripcion("PRECIO 1");
                    _precioEmp3.Precio[1].setUtilidadVieja(r01.Entidad.utEmpVta_3_Precio_2);
                    _precioEmp3.Precio[1].setPrecioViejo(r01.Entidad.pfdEmpVta_3_Precio_2, false);
                    _precioEmp3.Precio[1].setDescripcion("PRECIO 2");
                    _precioEmp3.Precio[2].setUtilidadVieja(r01.Entidad.utEmpVta_3_Precio_3);
                    _precioEmp3.Precio[2].setPrecioViejo(r01.Entidad.pfdEmpVta_3_Precio_3, false);
                    _precioEmp3.Precio[2].setDescripcion("PRECIO 3");
                    _precioEmp3.Precio[3].setUtilidadVieja(r01.Entidad.utEmpVta_3_Precio_4);
                    _precioEmp3.Precio[3].setPrecioViejo(r01.Entidad.pfdEmpVta_3_Precio_4, false);
                    _precioEmp3.Precio[3].setDescripcion("PRECIO 4");
                    //
                    _precioEmp1.ActualizarImportacion();
                    _precioEmp2.ActualizarImportacion();
                    _precioEmp3.ActualizarImportacion();
                }
                else
                {
                    var _descEmpVta_1 = r01.Entidad.descEmpVta1;
                    var _contEmpVta_1 = r01.Entidad.contEmpVta1;
                    _precioEmp1.setDescripcion(_descEmpVta_1);
                    _precioEmp1.setContenido(_contEmpVta_1);
                    //
                    _precioEmp1.Precio[0] = new CtrlPrecio.ImpPrecio(_costoUnd, _contEmpVta_1, _prdTasaIva, _metCalculoUt);
                    _precioEmp1.Precio[0].setFull(r01.Entidad.pfdEmpVta_1_Precio_1);
                    _precioEmp1.Precio[0].setUtilidadVieja(r01.Entidad.utEmpVta_1_Precio_1);
                    _precioEmp1.Precio[0].setPrecioViejo(r01.Entidad.pfdEmpVta_1_Precio_1, false);
                    _precioEmp1.Precio[0].setDescripcion("PRECIO 1");
                    //
                    _precioEmp1.Precio[1] = new CtrlPrecio.ImpPrecio(_costoUnd, _contEmpVta_1, _prdTasaIva, _metCalculoUt);
                    _precioEmp1.Precio[1].setFull(r01.Entidad.pfdEmpVta_1_Precio_2);
                    _precioEmp1.Precio[1].setUtilidadVieja(r01.Entidad.utEmpVta_1_Precio_2);
                    _precioEmp1.Precio[1].setPrecioViejo(r01.Entidad.pfdEmpVta_1_Precio_2, false);
                    _precioEmp1.Precio[1].setDescripcion("PRECIO 2");
                    //
                    _precioEmp1.Precio[2] = new CtrlPrecio.ImpPrecio(_costoUnd, _contEmpVta_1, _prdTasaIva, _metCalculoUt);
                    _precioEmp1.Precio[2].setFull(r01.Entidad.pfdEmpVta_1_Precio_3);
                    _precioEmp1.Precio[2].setUtilidadVieja(r01.Entidad.utEmpVta_1_Precio_3);
                    _precioEmp1.Precio[2].setPrecioViejo(r01.Entidad.pfdEmpVta_1_Precio_3, false);
                    _precioEmp1.Precio[2].setDescripcion("PRECIO 3");
                    //
                    _precioEmp1.Precio[3] = new CtrlPrecio.ImpPrecio(_costoUnd, _contEmpVta_1, _prdTasaIva, _metCalculoUt);
                    _precioEmp1.Precio[3].setFull(r01.Entidad.pfdEmpVta_1_Precio_4);
                    _precioEmp1.Precio[3].setUtilidadVieja(r01.Entidad.utEmpVta_1_Precio_4);
                    _precioEmp1.Precio[3].setPrecioViejo(r01.Entidad.pfdEmpVta_1_Precio_4, false);
                    _precioEmp1.Precio[3].setDescripcion("PRECIO 4");

                    //
                    var _descEmpVta_2 = r01.Entidad.descEmpVta2;
                    var _contEmpVta_2 = r01.Entidad.contEmpVta2;
                    _precioEmp2.setDescripcion(_descEmpVta_2);
                    _precioEmp2.setContenido(_contEmpVta_2);
                    //
                    _precioEmp2.Precio[0] = new CtrlPrecio.ImpPrecio(_costoUnd, _contEmpVta_2, _prdTasaIva, _metCalculoUt);
                    _precioEmp2.Precio[0].setFull(r01.Entidad.pfdEmpVta_2_Precio_1);
                    _precioEmp2.Precio[0].setUtilidadVieja(r01.Entidad.utEmpVta_2_Precio_1);
                    _precioEmp2.Precio[0].setPrecioViejo(r01.Entidad.pfdEmpVta_2_Precio_1, false);
                    _precioEmp2.Precio[0].setDescripcion("PRECIO 1");
                    //
                    _precioEmp2.Precio[1] = new CtrlPrecio.ImpPrecio(_costoUnd, _contEmpVta_2, _prdTasaIva, _metCalculoUt);
                    _precioEmp2.Precio[1].setFull(r01.Entidad.pfdEmpVta_2_Precio_2);
                    _precioEmp2.Precio[1].setUtilidadVieja(r01.Entidad.utEmpVta_2_Precio_2);
                    _precioEmp2.Precio[1].setPrecioViejo(r01.Entidad.pfdEmpVta_2_Precio_2, false);
                    _precioEmp2.Precio[1].setDescripcion("PRECIO 2");
                    //
                    _precioEmp2.Precio[2] = new CtrlPrecio.ImpPrecio(_costoUnd, _contEmpVta_2, _prdTasaIva, _metCalculoUt);
                    _precioEmp2.Precio[2].setFull(r01.Entidad.pfdEmpVta_2_Precio_3);
                    _precioEmp2.Precio[2].setUtilidadVieja(r01.Entidad.utEmpVta_2_Precio_3);
                    _precioEmp2.Precio[2].setPrecioViejo(r01.Entidad.pfdEmpVta_2_Precio_3, false);
                    _precioEmp2.Precio[2].setDescripcion("PRECIO 3");
                    //
                    _precioEmp2.Precio[3] = new CtrlPrecio.ImpPrecio(_costoUnd, _contEmpVta_2, _prdTasaIva, _metCalculoUt);
                    _precioEmp2.Precio[3].setFull(r01.Entidad.pfdEmpVta_2_Precio_4);
                    _precioEmp2.Precio[3].setUtilidadVieja(r01.Entidad.utEmpVta_2_Precio_4);
                    _precioEmp2.Precio[3].setPrecioViejo(r01.Entidad.pfdEmpVta_2_Precio_4, false);
                    _precioEmp2.Precio[3].setDescripcion("PRECIO 4");

                    //
                    var _descEmpVta_3 = r01.Entidad.descEmpVta3;
                    var _contEmpVta_3 = r01.Entidad.contEmpVta3;
                    _precioEmp3.setDescripcion(_descEmpVta_3);
                    _precioEmp3.setContenido(_contEmpVta_3);
                    //
                    _precioEmp3.Precio[0] = new CtrlPrecio.ImpPrecio(_costoUnd, _contEmpVta_3, _prdTasaIva, _metCalculoUt);
                    _precioEmp3.Precio[0].setFull(r01.Entidad.pfdEmpVta_3_Precio_1);
                    _precioEmp3.Precio[0].setUtilidadVieja(r01.Entidad.utEmpVta_3_Precio_1);
                    _precioEmp3.Precio[0].setPrecioViejo(r01.Entidad.pfdEmpVta_3_Precio_1, false);
                    _precioEmp3.Precio[0].setDescripcion("PRECIO 1");
                    //
                    _precioEmp3.Precio[1] = new CtrlPrecio.ImpPrecio(_costoUnd, _contEmpVta_3, _prdTasaIva, _metCalculoUt);
                    _precioEmp3.Precio[1].setFull(r01.Entidad.pfdEmpVta_3_Precio_2);
                    _precioEmp3.Precio[1].setUtilidadVieja(r01.Entidad.utEmpVta_3_Precio_2);
                    _precioEmp3.Precio[1].setPrecioViejo(r01.Entidad.pfdEmpVta_3_Precio_2, false);
                    _precioEmp3.Precio[1].setDescripcion("PRECIO 2");
                    //
                    _precioEmp3.Precio[2] = new CtrlPrecio.ImpPrecio(_costoUnd, _contEmpVta_3, _prdTasaIva, _metCalculoUt);
                    _precioEmp3.Precio[2].setFull(r01.Entidad.pfdEmpVta_3_Precio_3);
                    _precioEmp3.Precio[2].setUtilidadVieja(r01.Entidad.utEmpVta_3_Precio_3);
                    _precioEmp3.Precio[2].setPrecioViejo(r01.Entidad.pfdEmpVta_3_Precio_3, false);
                    _precioEmp3.Precio[2].setDescripcion("PRECIO 3");
                    //
                    _precioEmp3.Precio[3] = new CtrlPrecio.ImpPrecio(_costoUnd, _contEmpVta_3, _prdTasaIva, _metCalculoUt);
                    _precioEmp3.Precio[3].setFull(r01.Entidad.pfdEmpVta_3_Precio_4);
                    _precioEmp3.Precio[3].setUtilidadVieja(r01.Entidad.utEmpVta_3_Precio_4);
                    _precioEmp3.Precio[3].setPrecioViejo(r01.Entidad.pfdEmpVta_3_Precio_4, false);
                    _precioEmp3.Precio[3].setDescripcion("PRECIO 4");
                }
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
            return rt;
        }
    }
}