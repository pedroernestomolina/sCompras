using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Producto.Precio.Actualizar
{
    
    public class Editar: IEditar 
    {


        private bool _isProcesarIsOk;
        private bool _isAbandonarIsOk;
        private string _idProducto;
        private string _descPrecio1;
        private string _descPrecio2;
        private string _descPrecio3;
        private string _descPrecio4;
        private string _descPrecio5;
        private HlpGestion.HndCombo.IOpcion _gEmp1;
        private HlpGestion.HndCombo.IOpcion _gEmp2;
        private HlpGestion.HndCombo.IOpcion _gEmp3;
        private HlpGestion.HndCombo.IOpcion _gEmp4;
        private HlpGestion.HndCombo.IOpcion _gEmp5;
        private HlpGestion.HndCombo.IOpcion _gEmpM1;
        private HlpGestion.HndCombo.IOpcion _gEmpM2;
        private HlpGestion.HndCombo.IOpcion _gEmpM3;
        private HlpGestion.HndCombo.IOpcion _gEmpM4;
        private HlpGestion.HndCombo.IOpcion _gEmpD1;
        private HlpGestion.HndCombo.IOpcion _gEmpD2;
        private HlpGestion.HndCombo.IOpcion _gEmpD3;
        private HlpGestion.HndCombo.IOpcion _gEmpD4;
        //
        private HlpGestion.HndCombo.IOpcion _gEmpTipo_1;
        private int _contEmpTipo_1;
        private HlpGestion.HndCombo.IOpcion _gEmpTipo_2;
        private int _contEmpTipo_2;
        private HlpGestion.HndCombo.IOpcion _gEmpTipo_3;
        private int _contEmpTipo_3;
        //
        private dataPrecio _precio1;
        private dataPrecio _precio2;
        private dataPrecio _precio3;
        private dataPrecio _precio4;
        private dataPrecio _precio5;
        private dataPrecio _precioM1;
        private dataPrecio _precioM2;
        private dataPrecio _precioM3;
        private dataPrecio _precioM4;
        private dataPrecio _precioD1;
        private dataPrecio _precioD2;
        private dataPrecio _precioD3;
        private dataPrecio _precioD4;
        private dataProducto _dataPrd;
        //
        private decimal _tasaIvaPrd;
        private bool _esAdmDivisaPrd;
        private int _contEmpCompraPrd;
        private string _codigoPrd;
        private string _autoPrd;
        private string _descripcionPrd;
        private string _empCompraDescPrd;
        private decimal _costoMonedaLocalPrd;
        private decimal _costoMonedaDivisaPrd;


        public bool IsProcesarIsOk { get { return _isProcesarIsOk; } }
        public bool IsAbandonarIsOk { get { return _isAbandonarIsOk; } }
        public bool IsEditarPrecioIsOk { get { return _isProcesarIsOk; } }


        public Editar() 
        {
            _tasaIvaPrd=0m;
            _esAdmDivisaPrd=false;
            _contEmpCompraPrd=0;
            _codigoPrd="";
            _autoPrd="";
            _descripcionPrd="";
            _empCompraDescPrd="";
            _costoMonedaLocalPrd=0m;
            _costoMonedaDivisaPrd=0m;

            _gEmp1 = new HlpGestion.HndCombo.Opcion();
            _gEmp2 = new HlpGestion.HndCombo.Opcion();
            _gEmp3 = new HlpGestion.HndCombo.Opcion();
            _gEmp4 = new HlpGestion.HndCombo.Opcion();
            _gEmp5 = new HlpGestion.HndCombo.Opcion();
            _gEmpM1 = new HlpGestion.HndCombo.Opcion();
            _gEmpM2 = new HlpGestion.HndCombo.Opcion();
            _gEmpM3 = new HlpGestion.HndCombo.Opcion();
            _gEmpM4 = new HlpGestion.HndCombo.Opcion();
            _gEmpD1 = new HlpGestion.HndCombo.Opcion();
            _gEmpD2 = new HlpGestion.HndCombo.Opcion();
            _gEmpD3 = new HlpGestion.HndCombo.Opcion();
            _gEmpD4 = new HlpGestion.HndCombo.Opcion();
            //
            _gEmpTipo_1 = new HlpGestion.HndCombo.Opcion();
            _contEmpTipo_1=1;
            _gEmpTipo_2 = new HlpGestion.HndCombo.Opcion();
            _contEmpTipo_2 = 1;
            _gEmpTipo_3 = new HlpGestion.HndCombo.Opcion();
            _contEmpTipo_3 = 1;
            //
            _isAbandonarIsOk = false;
            _isProcesarIsOk = false;
            _idProducto = "";
            //
            _descPrecio1 = "";
            _descPrecio2 = "";
            _descPrecio3 = "";
            _descPrecio4 = "";
            _descPrecio5 = "";
            //
            _precio1 = new dataPrecio();
            _precio2 = new dataPrecio();
            _precio3 = new dataPrecio();
            _precio4 = new dataPrecio();
            _precio5 = new dataPrecio();
            //
            _precioM1 = new dataPrecio();
            _precioM2 = new dataPrecio();
            _precioM3 = new dataPrecio();
            _precioM4 = new dataPrecio();
            //
            _precioD1 = new dataPrecio();
            _precioD2 = new dataPrecio();
            _precioD3 = new dataPrecio();
            _precioD4 = new dataPrecio();
            //
            _dataPrd = new dataProducto();
        }


        public void Inicializa()
        {
            _isAbandonarIsOk = false;
            _isProcesarIsOk = false;
            _idProducto="";
            _descPrecio1 = "";
            _descPrecio2 = "";
            _descPrecio3 = "";
            _descPrecio4 = "";
            _descPrecio5 = "";
            //
            _gEmp1.Inicializa();
            _gEmp2.Inicializa();
            _gEmp3.Inicializa();
            _gEmp4.Inicializa();
            _gEmp5.Inicializa();
            //
            _gEmpM1.Inicializa();
            _gEmpM2.Inicializa();
            _gEmpM3.Inicializa();
            _gEmpM4.Inicializa();
            //
            _gEmpD1.Inicializa();
            _gEmpD2.Inicializa();
            _gEmpD3.Inicializa();
            _gEmpD4.Inicializa();
            //
            _precio1.Inicializa();
            _precio2.Inicializa();
            _precio3.Inicializa();
            _precio4.Inicializa();
            _precio5.Inicializa();
            //
            _precioM1.Inicializa();
            _precioM2.Inicializa();
            _precioM3.Inicializa();
            _precioM4.Inicializa();
            //
            _precioD1.Inicializa();
            _precioD2.Inicializa();
            _precioD3.Inicializa();
            _precioD4.Inicializa();
            //
            _gEmpTipo_1.Inicializa();
            _contEmpTipo_1 = 1;
            _gEmpTipo_2.Inicializa();
            _contEmpTipo_2 = 1;
            _gEmpTipo_3.Inicializa();
            _contEmpTipo_3 = 1;
            //
            _dataPrd.Inicializa();
        }
        PrecioEditarFrm frm;
        public void Inicia()
        {
            if (CargarData())
            {
                if (frm == null)
                {
                    frm = new PrecioEditarFrm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void setIdItemEditar(string idAuto)
        {
            _idProducto = idAuto;
        }


        private bool CargarData()
        {
            var rt = true;
            var _tasaCambio = 0m;
            var _metodoCalculoDesc = "";
            var _metodoCalculo = dataPrecio.enumMetCalUtilidad.SinDefinir;

            var r01 = Sistema.MyData.Producto_Precio_GetCapturar_ById(_idProducto);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            var r03 = Sistema.MyData.Configuracion_TasaCambioActual();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }
            _tasaCambio = r03.Entidad;
            var r04 = Sistema.MyData.Configuracion_MetodoCalculoUtilidad();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }
            if (r04.Entidad== OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Lineal)
            {
                _metodoCalculoDesc="LINEAL";
                _metodoCalculo = dataPrecio.enumMetCalUtilidad.Lineal;
            }
            else if (r04.Entidad== OOB.LibCompra.Configuracion.Enumerados.EnumMetodoCalculoUtilidad.Financiero )
            {
                _metodoCalculoDesc="FINANCIERO";
                _metodoCalculo = dataPrecio.enumMetCalUtilidad.Financiero;
            }

            var prd = r01.Entidad;
            var costo = _costoMonedaLocalPrd;
            var admDivisa = "NO";
            //
            var pneto_1 = prd.pnEmp1_1;
            var pneto_2 = prd.pnEmp1_2;
            var pneto_3 = prd.pnEmp1_3;
            var pneto_4 = prd.pnEmp1_4;
            var pneto_5 = prd.pnEmp1_5;
            //
            var pneto_M1 = prd.pnEmp2_1;
            var pneto_M2 = prd.pnEmp2_2;
            var pneto_M3 = prd.pnEmp2_3;
            var pneto_M4 = prd.pnEmp2_4;
            //
            var pneto_D1 = prd.pnEmp3_1;
            var pneto_D2 = prd.pnEmp3_2;
            var pneto_D3 = prd.pnEmp3_3;
            var pneto_D4 = prd.pnEmp3_4;
            if (_esAdmDivisaPrd) 
            {
                admDivisa = "SI";
                costo = _costoMonedaDivisaPrd;
                pneto_1 = CalculaNeto(prd.pfdEmp1_1, _tasaIvaPrd);
                pneto_2 = CalculaNeto(prd.pfdEmp1_2, _tasaIvaPrd);
                pneto_3 = CalculaNeto(prd.pfdEmp1_3, _tasaIvaPrd);
                pneto_4 = CalculaNeto(prd.pfdEmp1_4, _tasaIvaPrd);
                pneto_5 = CalculaNeto(prd.pfdEmp1_5, _tasaIvaPrd);
                //
                pneto_M1 = CalculaNeto(prd.pfdEmp2_1, _tasaIvaPrd);
                pneto_M2 = CalculaNeto(prd.pfdEmp2_2, _tasaIvaPrd);
                pneto_M3 = CalculaNeto(prd.pfdEmp2_3, _tasaIvaPrd);
                pneto_M4 = CalculaNeto(prd.pfdEmp2_4, _tasaIvaPrd);
                //
                pneto_D1 = CalculaNeto(prd.pfdEmp3_1, _tasaIvaPrd);
                pneto_D2 = CalculaNeto(prd.pfdEmp3_2, _tasaIvaPrd);
                pneto_D3 = CalculaNeto(prd.pfdEmp3_3, _tasaIvaPrd);
                pneto_D4 = CalculaNeto(prd.pfdEmp3_4, _tasaIvaPrd);
            }

            _dataPrd.setCodigo(_codigoPrd);
            _dataPrd.setDescripcion(_descripcionPrd);
            _dataPrd.setAuto(_autoPrd);
            _dataPrd.setEmpaqueCompraDesc(_empCompraDescPrd);
            _dataPrd.setContEmpaqueCompraDesc(_contEmpCompraPrd);
            _dataPrd.setCostoEmpCompra(costo);
            _dataPrd.setMetodoCalculoUt(_metodoCalculoDesc);
            _dataPrd.setTasaCambioPrd(_tasaCambio);
            _dataPrd.setAdmDivisaDesc(admDivisa);
            _dataPrd.setTasaIvaPrd(_tasaIvaPrd);
            _dataPrd.setFechaUltActPrd(new DateTime(2022, 05, 03).ToShortDateString());
            _dataPrd.setEsAdmDivisa(_esAdmDivisaPrd);

            _descPrecio1 = "PRECIO 1";
            _descPrecio2 = "PRECIO 2";
            _descPrecio3 = "PRECIO 3";
            _descPrecio4 = "PRECIO 4";
            _descPrecio5 = "PRECIO 5";

            var r02 = Sistema.MyData.Producto_EmpaqueMedida_GetLista();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }
            var lst = new List<HlpGestion.ficha>();
            foreach (var rg in r02.Lista.OrderBy(o => o.nombre).ToList()) 
            {
                var nr = new HlpGestion.ficha(rg.auto, "", rg.nombre);
                lst.Add(nr);
            }
            _gEmp1.setData(lst);
            _gEmp2.setData(lst);
            _gEmp3.setData(lst);
            _gEmp4.setData(lst);
            _gEmp5.setData(lst);
            _gEmpM1.setData(lst);
            _gEmpM2.setData(lst);
            _gEmpM3.setData(lst);
            _gEmpM4.setData(lst);
            _gEmpD1.setData(lst);
            _gEmpD2.setData(lst);
            _gEmpD3.setData(lst);
            _gEmpD4.setData(lst);
            //
            _gEmpTipo_1.setData(lst);
            _gEmpTipo_2.setData(lst);
            _gEmpTipo_3.setData(lst);
            //
            _precio1.setContenido(prd.contEmp1_1);
            _precio1.setUtilidadActual(prd.utEmp1_1);
            _precio1.setCostoEmpCompra(costo);
            _precio1.setContEmpCompra(_contEmpCompraPrd);
            _precio1.setAdmDivisa(_esAdmDivisaPrd);
            _precio1.setTasaCambio(_tasaCambio);
            _precio1.setTasaIva(_tasaIvaPrd);
            _precio1.setMetodoCalculoUtilidad(_metodoCalculo);
            _precio1.setNeto(pneto_1);
            _gEmp1.setFicha(prd.idEmp1_1);

            _precio2.setContenido(prd.contEmp1_2);
            _precio2.setUtilidadActual(prd.utEmp1_2);
            _precio2.setCostoEmpCompra(costo);
            _precio2.setContEmpCompra(_contEmpCompraPrd);
            _precio2.setAdmDivisa(_esAdmDivisaPrd);
            _precio2.setTasaCambio(_tasaCambio);
            _precio2.setTasaIva(_tasaIvaPrd);
            _precio2.setMetodoCalculoUtilidad(_metodoCalculo);
            _precio2.setNeto(pneto_2);
            _gEmp2.setFicha(prd.idEmp1_2);

            _precio3.setContenido(prd.contEmp1_3);
            _precio3.setUtilidadActual(prd.utEmp1_3);
            _precio3.setCostoEmpCompra(costo);
            _precio3.setContEmpCompra(_contEmpCompraPrd);
            _precio3.setAdmDivisa(_esAdmDivisaPrd);
            _precio3.setTasaCambio(_tasaCambio);
            _precio3.setTasaIva(_tasaIvaPrd);
            _precio3.setMetodoCalculoUtilidad(_metodoCalculo);
            _precio3.setNeto(pneto_3);
            _gEmp3.setFicha(prd.idEmp1_3);

            _precio4.setContenido(prd.contEmp1_4);
            _precio4.setUtilidadActual(prd.utEmp1_4);
            _precio4.setCostoEmpCompra(costo);
            _precio4.setContEmpCompra(_contEmpCompraPrd);
            _precio4.setAdmDivisa(_esAdmDivisaPrd);
            _precio4.setTasaCambio(_tasaCambio);
            _precio4.setTasaIva(_tasaIvaPrd);
            _precio4.setMetodoCalculoUtilidad(_metodoCalculo);
            _precio4.setNeto(pneto_4);
            _gEmp4.setFicha(prd.idEmp1_4);

            _precio5.setContenido(prd.contEmp1_5);
            _precio5.setUtilidadActual(prd.utEmp1_5);
            _precio5.setCostoEmpCompra(costo);
            _precio5.setContEmpCompra(_contEmpCompraPrd);
            _precio5.setAdmDivisa(_esAdmDivisaPrd);
            _precio5.setTasaCambio(_tasaCambio);
            _precio5.setTasaIva(_tasaIvaPrd);
            _precio5.setMetodoCalculoUtilidad(_metodoCalculo);
            _precio5.setNeto(pneto_5);
            _gEmp5.setFicha(prd.idEmp1_5);


            _precioM1.setContenido(prd.contEmp2_1);
            _precioM1.setUtilidadActual(prd.utEmp2_1);
            _precioM1.setCostoEmpCompra(costo);
            _precioM1.setContEmpCompra(_contEmpCompraPrd);
            _precioM1.setAdmDivisa(_esAdmDivisaPrd);
            _precioM1.setTasaCambio(_tasaCambio);
            _precioM1.setTasaIva(_tasaIvaPrd);
            _precioM1.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioM1.setNeto(pneto_M1);
            _gEmpM1.setFicha(prd.idEmp2_1);

            _precioM2.setContenido(prd.contEmp2_2);
            _precioM2.setUtilidadActual(prd.utEmp2_2);
            _precioM2.setCostoEmpCompra(costo);
            _precioM2.setContEmpCompra(_contEmpCompraPrd);
            _precioM2.setAdmDivisa(_esAdmDivisaPrd);
            _precioM2.setTasaCambio(_tasaCambio);
            _precioM2.setTasaIva(_tasaIvaPrd);
            _precioM2.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioM2.setNeto(pneto_M2);
            _gEmpM2.setFicha(prd.idEmp2_2);

            _precioM3.setContenido(prd.contEmp2_3);
            _precioM3.setUtilidadActual(prd.utEmp2_3);
            _precioM3.setCostoEmpCompra(costo);
            _precioM3.setContEmpCompra(_contEmpCompraPrd);
            _precioM3.setAdmDivisa(_esAdmDivisaPrd);
            _precioM3.setTasaCambio(_tasaCambio);
            _precioM3.setTasaIva(_tasaIvaPrd);
            _precioM3.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioM3.setNeto(pneto_M3);
            _gEmpM3.setFicha(prd.idEmp2_3);

            _precioM4.setContenido(prd.contEmp2_4);
            _precioM4.setUtilidadActual(prd.utEmp2_4);
            _precioM4.setCostoEmpCompra(costo);
            _precioM4.setContEmpCompra(_contEmpCompraPrd);
            _precioM4.setAdmDivisa(_esAdmDivisaPrd);
            _precioM4.setTasaCambio(_tasaCambio);
            _precioM4.setTasaIva(_tasaIvaPrd);
            _precioM4.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioM4.setNeto(pneto_M4);
            _gEmpM4.setFicha(prd.idEmp2_4);


            _precioD1.setContenido(prd.contEmp3_1);
            _precioD1.setUtilidadActual(prd.utEmp3_1);
            _precioD1.setCostoEmpCompra(costo);
            _precioD1.setContEmpCompra(_contEmpCompraPrd);
            _precioD1.setAdmDivisa(_esAdmDivisaPrd);
            _precioD1.setTasaCambio(_tasaCambio);
            _precioD1.setTasaIva(_tasaIvaPrd);
            _precioD1.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioD1.setNeto(pneto_D1);
            _gEmpD1.setFicha(prd.idEmp3_1);

            _precioD2.setContenido(prd.contEmp3_2);
            _precioD2.setUtilidadActual(prd.utEmp3_2);
            _precioD2.setCostoEmpCompra(costo);
            _precioD2.setContEmpCompra(_contEmpCompraPrd);
            _precioD2.setAdmDivisa(_esAdmDivisaPrd);
            _precioD2.setTasaCambio(_tasaCambio);
            _precioD2.setTasaIva(_tasaIvaPrd);
            _precioD2.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioD2.setNeto(pneto_D2);
            _gEmpD2.setFicha(prd.idEmp3_2);

            _precioD3.setContenido(prd.contEmp3_3);
            _precioD3.setUtilidadActual(prd.utEmp3_3);
            _precioD3.setCostoEmpCompra(costo);
            _precioD3.setContEmpCompra(_contEmpCompraPrd);
            _precioD3.setAdmDivisa(_esAdmDivisaPrd);
            _precioD3.setTasaCambio(_tasaCambio);
            _precioD3.setTasaIva(_tasaIvaPrd);
            _precioD3.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioD3.setNeto(pneto_D3);
            _gEmpD3.setFicha(prd.idEmp3_3);

            _precioD4.setContenido(prd.contEmp3_4);
            _precioD4.setUtilidadActual(prd.utEmp3_4);
            _precioD4.setCostoEmpCompra(costo);
            _precioD4.setContEmpCompra(_contEmpCompraPrd);
            _precioD4.setAdmDivisa(_esAdmDivisaPrd);
            _precioD4.setTasaCambio(_tasaCambio);
            _precioD4.setTasaIva(_tasaIvaPrd);
            _precioD4.setMetodoCalculoUtilidad(_metodoCalculo);
            _precioD4.setNeto(pneto_D4);
            _gEmpD4.setFicha(prd.idEmp3_4);


            var r05 = Sistema.MyData.Configuracion_ForzarRedondeoPrecioVenta();
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            var r06 = Sistema.MyData.Configuracion_PreferenciaRegistroPrecio();
            if (r06.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r06.Mensaje);
                return false;
            }
            return rt;
        }

        public void AbandonarFicha()
        {
            _isAbandonarIsOk = false;
            var xmsg = "Abandonar Cambios Realizados ?";
            var msg = MessageBox.Show(xmsg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                _isAbandonarIsOk = true;
            }
        }


        public BindingSource GetEmp1_Source { get { return _gEmp1.Source; } }
        public BindingSource GetEmp2_Source { get { return _gEmp2.Source; } }
        public BindingSource GetEmp3_Source { get { return _gEmp3.Source; } }
        public BindingSource GetEmp4_Source { get { return _gEmp4.Source; } }
        public BindingSource GetEmp5_Source { get { return _gEmp5.Source; } }
        //
        public BindingSource GetEmpM1_Source { get { return _gEmpM1.Source; } }
        public BindingSource GetEmpM2_Source { get { return _gEmpM2.Source; } }
        public BindingSource GetEmpM3_Source { get { return _gEmpM3.Source; } }
        public BindingSource GetEmpM4_Source { get { return _gEmpM4.Source; } }
        //
        public BindingSource GetEmpD1_Source { get { return _gEmpD1.Source; } }
        public BindingSource GetEmpD2_Source { get { return _gEmpD2.Source; } }
        public BindingSource GetEmpD3_Source { get { return _gEmpD3.Source; } }
        public BindingSource GetEmpD4_Source { get { return _gEmpD4.Source; } }


        public void setEmp1(string id)
        {
            _gEmp1.setFicha(id);
        }
        public void setEmp2(string id)
        {
            _gEmp2.setFicha(id);
        }
        public void setEmp3(string id)
        {
            _gEmp3.setFicha(id);
        }
        public void setEmp4(string id)
        {
            _gEmp4.setFicha(id);
        }
        public void setEmp5(string id)
        {
            _gEmp5.setFicha(id);
        }
        //
        public void setEmpM1(string id)
        {
            _gEmpM1.setFicha(id);
        }
        public void setEmpM2(string id)
        {
            _gEmpM2.setFicha(id);
        }
        public void setEmpM3(string id)
        {
            _gEmpM3.setFicha(id);
        }
        public void setEmpM4(string id)
        {
            _gEmpM4.setFicha(id);
        }
        //
        public void setEmpD1(string id)
        {
            _gEmpD1.setFicha(id);
        }
        public void setEmpD2(string id)
        {
            _gEmpD2.setFicha(id);
        }
        public void setEmpD3(string id)
        {
            _gEmpD3.setFicha(id);
        }
        public void setEmpD4(string id)
        {
            _gEmpD4.setFicha(id);
        }


        public string GetDescPrecio1 { get { return _descPrecio1; } }
        public string GetDescPrecio2 { get { return _descPrecio2; } }
        public string GetDescPrecio3 { get { return _descPrecio3; } }
        public string GetDescPrecio4 { get { return _descPrecio4; } }
        public string GetDescPrecio5 { get { return _descPrecio5; } }
        //
        public string GetDescPrecioM1 { get { return _descPrecio1; } }
        public string GetDescPrecioM2 { get { return _descPrecio2; } }
        public string GetDescPrecioM3 { get { return _descPrecio3; } }
        public string GetDescPrecioM4 { get { return _descPrecio4; } }


        public string GetEmp1_Id { get { return _gEmp1.GetId; } }
        public string GetEmp2_Id { get { return _gEmp2.GetId; } }
        public string GetEmp3_Id { get { return _gEmp3.GetId; } }
        public string GetEmp4_Id { get { return _gEmp4.GetId; } }
        public string GetEmp5_Id { get { return _gEmp5.GetId; } }
        //
        public string GetEmpM1_Id { get { return _gEmpM1.GetId; } }
        public string GetEmpM2_Id { get { return _gEmpM2.GetId; } }
        public string GetEmpM3_Id { get { return _gEmpM3.GetId; } }
        public string GetEmpM4_Id { get { return _gEmpM4.GetId; } }
        //
        public string GetEmpD1_Id { get { return _gEmpD1.GetId; } }
        public string GetEmpD2_Id { get { return _gEmpD2.GetId; } }
        public string GetEmpD3_Id { get { return _gEmpD3.GetId; } }
        public string GetEmpD4_Id { get { return _gEmpD4.GetId; } }


        public void setContEmp_1(int cont)
        {
            _precio1.setContenido(cont);
        }
        public void setUt_1(decimal ut)
        {
            _precio1.setUtilidadNueva(ut);
        }
        public void setPN_1(decimal monto)
        {
            _precio1.setNeto(monto);
        }
        public void setPF_1(decimal monto)
        {
            _precio1.setFull(monto);
        }
        public int GetCont1 { get { return _precio1.Contenido; } }
        public decimal GetUt1 { get { return _precio1.Utilidad; } }
        public decimal GetPN1 { get { return _precio1.Neto; } }
        public decimal GetPF1 { get { return _precio1.Full; } }
        public decimal GetUtActual1 { get { return _precio1.UtilidadActual; } }
        public bool ERR_1 { get { return _precio1.IsError; } }


        public void setContEmp_2(int cont)
        {
            _precio2.setContenido(cont);
        }
        public void setUt_2(decimal ut)
        {
            _precio2.setUtilidadNueva(ut);
        }
        public void setPN_2(decimal monto)
        {
            _precio2.setNeto(monto);
        }
        public void setPF_2(decimal monto)
        {
            _precio2.setFull(monto);
        }
        public int GetCont2 { get { return _precio2.Contenido; } }
        public decimal GetUt2 { get { return _precio2.Utilidad; } }
        public decimal GetPN2 { get { return _precio2.Neto; } }
        public decimal GetPF2 { get { return _precio2.Full; } }
        public decimal GetUtActual2 { get { return _precio2.UtilidadActual; } }
        public bool ERR_2 { get { return _precio2.IsError; } }


        public void setContEmp_3(int cont)
        {
            _precio3.setContenido(cont);
        }
        public void setUt_3(decimal ut)
        {
            _precio3.setUtilidadNueva(ut);
        }
        public void setPN_3(decimal monto)
        {
            _precio3.setNeto(monto);
        }
        public void setPF_3(decimal monto)
        {
            _precio3.setFull(monto);
        }
        public int GetCont3 { get { return _precio3.Contenido; } }
        public decimal GetUt3 { get { return _precio3.Utilidad; } }
        public decimal GetPN3 { get { return _precio3.Neto; } }
        public decimal GetPF3 { get { return _precio3.Full; } }
        public decimal GetUtActual3 { get { return _precio3.UtilidadActual; } }
        public bool ERR_3 { get { return _precio3.IsError; } }


        public void setContEmp_4(int cont)
        {
            _precio4.setContenido(cont);
        }
        public void setUt_4(decimal ut)
        {
            _precio4.setUtilidadNueva(ut);
        }
        public void setPN_4(decimal monto)
        {
            _precio4.setNeto(monto);
        }
        public void setPF_4(decimal monto)
        {
            _precio4.setFull(monto);
        }
        public int GetCont4 { get { return _precio4.Contenido; } }
        public decimal GetUt4 { get { return _precio4.Utilidad; } }
        public decimal GetPN4 { get { return _precio4.Neto; } }
        public decimal GetPF4 { get { return _precio4.Full; } }
        public decimal GetUtActual4 { get { return _precio4.UtilidadActual; } }
        public bool ERR_4 { get { return _precio4.IsError; } }


        public void setContEmp_5(int cont)
        {
            _precio5.setContenido(cont);
        }
        public void setUt_5(decimal ut)
        {
            _precio5.setUtilidadNueva(ut);
        }
        public void setPN_5(decimal monto)
        {
            _precio5.setNeto(monto);
        }
        public void setPF_5(decimal monto)
        {
            _precio5.setFull(monto);
        }
        public int GetCont5 { get { return _precio5.Contenido; } }
        public decimal GetUt5 { get { return _precio5.Utilidad; } }
        public decimal GetPN5 { get { return _precio5.Neto; } }
        public decimal GetPF5 { get { return _precio5.Full; } }
        public decimal GetUtActual5 { get { return _precio5.UtilidadActual; } }
        public bool ERR_5 { get { return _precio5.IsError; } }


        public void setContEmp_M1(int cont)
        {
            _precioM1.setContenido(cont);
        }
        public void setUt_M1(decimal ut)
        {
            _precioM1.setUtilidadNueva(ut);
        }
        public void setPN_M1(decimal monto)
        {
            _precioM1.setNeto(monto);
        }
        public void setPF_M1(decimal monto)
        {
            _precioM1.setFull(monto);
        }
        public int GetContM1 { get { return _precioM1.Contenido; } }
        public decimal GetUtM1 { get { return _precioM1.Utilidad; } }
        public decimal GetPNM1 { get { return _precioM1.Neto; } }
        public decimal GetPFM1 { get { return _precioM1.Full; } }
        public decimal GetUtActualM1 { get { return _precioM1.UtilidadActual; } }
        public bool ERR_M1 { get { return _precioM1.IsError; } }


        public void setContEmp_M2(int cont)
        {
            _precioM2.setContenido(cont);
        }
        public void setUt_M2(decimal ut)
        {
            _precioM2.setUtilidadNueva(ut);
        }
        public void setPN_M2(decimal monto)
        {
            _precioM2.setNeto(monto);
        }
        public void setPF_M2(decimal monto)
        {
            _precioM2.setFull(monto);
        }
        public int GetContM2 { get { return _precioM2.Contenido; } }
        public decimal GetUtM2 { get { return _precioM2.Utilidad; } }
        public decimal GetPNM2 { get { return _precioM2.Neto; } }
        public decimal GetPFM2 { get { return _precioM2.Full; } }
        public decimal GetUtActualM2 { get { return _precioM2.UtilidadActual; } }
        public bool ERR_M2 { get { return _precioM2.IsError; } }


        public void setContEmp_M3(int cont)
        {
            _precioM3.setContenido(cont);
        }
        public void setUt_M3(decimal ut)
        {
            _precioM3.setUtilidadNueva(ut);
        }
        public void setPN_M3(decimal monto)
        {
            _precioM3.setNeto(monto);
        }
        public void setPF_M3(decimal monto)
        {
            _precioM3.setFull(monto);
        }
        public int GetContM3 { get { return _precioM3.Contenido; } }
        public decimal GetUtM3 { get { return _precioM3.Utilidad; } }
        public decimal GetPNM3 { get { return _precioM3.Neto; } }
        public decimal GetPFM3 { get { return _precioM3.Full; } }
        public decimal GetUtActualM3 { get { return _precioM3.UtilidadActual; } }
        public bool ERR_M3 { get { return _precioM3.IsError; } }


        public void setContEmp_M4(int cont)
        {
            _precioM4.setContenido(cont);
        }
        public void setUt_M4(decimal ut)
        {
            _precioM4.setUtilidadNueva(ut);
        }
        public void setPN_M4(decimal monto)
        {
            _precioM4.setNeto(monto);
        }
        public void setPF_M4(decimal monto)
        {
            _precioM4.setFull(monto);
        }
        public int GetContM4 { get { return _precioM4.Contenido; } }
        public decimal GetUtM4 { get { return _precioM4.Utilidad; } }
        public decimal GetPNM4 { get { return _precioM4.Neto; } }
        public decimal GetPFM4 { get { return _precioM4.Full; } }
        public decimal GetUtActualM4 { get { return _precioM4.UtilidadActual; } }
        public bool ERR_M4 { get { return _precioM4.IsError; } }


        public string GetInfProducto { get { return _dataPrd.InfPrd; } }
        public string GetInfEmpCompraPrd { get { return _dataPrd.InfEmpCompra; } }
        public decimal GetInfCostoEmpCompraPrd { get { return _dataPrd.InfCostoEmpCompra; } }
        public string GetInfMetodoCalculoUt { get { return _dataPrd.InfMetodoCalculoUt; } }
        public decimal GetInfTasaCambioPrd { get { return _dataPrd.InfTasaCambio ; } }
        public string GetInfAdmDivisaPrd { get { return _dataPrd.InfAdmDivisaDesc; } }
        public decimal GetInfTasaIvaPrd { get { return _dataPrd.InfTasaIva; } }
        public decimal GetInfCostoUndPrd { get { return _dataPrd.InfCostoUnd; } }
        public string GetInfFechaUltActPrd { get { return _dataPrd.InfFechaUltAct; } }
        public bool GetEsAdmDivisaPrd { get { return _dataPrd.InfEsAdmDivisa; } }


        public void Procesar()
        {
            _isProcesarIsOk = false;
            var msg = "Procesar Cambios Efectuados ?";
            var rt = MessageBox.Show(msg, "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (rt == DialogResult.Yes)
            {
                Guardar();
            }
        }

        private dataGuardar _dataG;
        public dataGuardar DataPrecios { get { return _dataG; } }
        private void Guardar()
        {
            if (_gEmp1.GetId == "") 
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(1) PARA PRECIO (1) INCORRECTO");
                return;
            }
            if (_gEmp2.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(1) PARA PRECIO (2) INCORRECTO");
                return;
            }
            if (_gEmp3.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(1) PARA PRECIO (3) INCORRECTO");
                return;
            }
            if (_gEmp4.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(1) PARA PRECIO (4) INCORRECTO");
                return;
            }
            if (_gEmp5.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO (5) INCORRECTO");
                return;
            }

            if (_gEmpM1.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(2) PARA PRECIO (1) INCORRECTO");
                return;
            }
            if (_gEmpM2.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(2) PARA PRECIO (2) INCORRECTO");
                return;
            }
            if (_gEmpM3.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(2) PARA PRECIO (3) INCORRECTO");
                return;
            }
            if (_gEmpM4.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(2) PARA PRECIO (4) INCORRECTO");
                return;
            }

            if (_gEmpD1.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(3) PARA PRECIO (1) INCORRECTO");
                return;
            }
            if (_gEmpD2.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(3) PARA PRECIO (2) INCORRECTO");
                return;
            }
            if (_gEmpD3.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(3) PARA PRECIO (3) INCORRECTO");
                return;
            }
            if (_gEmpD4.GetId == "")
            {
                Helpers.Msg.Error("[ EMPAQUE PRECIO TIPO(3) PARA PRECIO (4) INCORRECTO");
                return;
            }


            if (!_precio1.IsOk())
            {
                Helpers.Msg.Error("PRECIO (1)," + _precio1.msgError);
                return;
            }
            if (!_precio2.IsOk())
            {
                Helpers.Msg.Error("PRECIO (2)," + _precio2.msgError);
                return;
            }
            if (!_precio3.IsOk())
            {
                Helpers.Msg.Error("PRECIO (3)," + _precio3.msgError);
                return;
            }
            if (!_precio4.IsOk())
            {
                Helpers.Msg.Error("PRECIO (4)," + _precio4.msgError);
                return;
            }
            if (!_precio5.IsOk())
            {
                Helpers.Msg.Error("PRECIO (5)," + _precio5.msgError);
                return;
            }

            if (!_precioM1.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(2) PARA PRECIO (1)," + _precioM1.msgError);
                return;
            }
            if (!_precioM2.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(2) PARA PRECIO (2)," + _precioM2.msgError);
                return;
            }
            if (!_precioM3.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(2) PARA PRECIO (3)," + _precioM3.msgError);
                return;
            }
            if (!_precioM4.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(2) PARA PRECIO (4)," + _precioM4.msgError);
                return;
            }

            if (!_precioD1.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(3) PARA PRECIO (1)," + _precioM1.msgError);
                return;
            }
            if (!_precioD2.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(3) PARA PRECIO (2)," + _precioM2.msgError);
                return;
            }
            if (!_precioD3.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(3) PARA PRECIO (3)," + _precioM3.msgError);
                return;
            }
            if (!_precioD4.IsOk())
            {
                Helpers.Msg.Error("PRECIO EMPAQUE TIPO(3) PARA PRECIO (4)," + _precioM4.msgError);
                return;
            }

            _dataG = new dataGuardar();
            _dataG.setFactorDivisa(_dataPrd.InfTasaCambio);
            _dataG.precio_1_Emp_1.setData(_gEmp1.GetId,
                                        _precio1.Contenido,
                                        _precio1.Utilidad,
                                        Math.Round(_precio1.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precio1.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmp1.Item.desc);
            _dataG.precio_1_Emp_2.setData(_gEmpM1.GetId,
                                        _precioM1.Contenido,
                                        _precioM1.Utilidad,
                                        Math.Round(_precioM1.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precioM1.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmpM1.Item.desc);
            _dataG.precio_1_Emp_3.setData(_gEmpD1.GetId,
                                        _precioD1.Contenido,
                                        _precioD1.Utilidad,
                                        Math.Round(_precioD1.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precioD1.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmpD1.Item.desc);
            //
            _dataG.precio_2_Emp_1.setData(_gEmp2.GetId,
                                        _precio2.Contenido,
                                        _precio2.Utilidad,
                                        Math.Round(_precio2.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precio2.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmp2.Item.desc);
            _dataG.precio_2_Emp_2.setData(_gEmpM2.GetId,
                                        _precioM2.Contenido,
                                        _precioM2.Utilidad,
                                        Math.Round(_precioM2.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precioM2.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmpM2.Item.desc);
            _dataG.precio_2_Emp_3.setData(_gEmpD2.GetId,
                                        _precioD2.Contenido,
                                        _precioD2.Utilidad,
                                        Math.Round(_precioD2.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precioD2.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmpD2.Item.desc);
            //
            _dataG.precio_3_Emp_1.setData(_gEmp3.GetId,
                                        _precio3.Contenido,
                                        _precio3.Utilidad,
                                        Math.Round(_precio3.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precio3.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmp3.Item.desc);
            _dataG.precio_3_Emp_2.setData(_gEmpM3.GetId,
                                        _precioM3.Contenido,
                                        _precioM3.Utilidad,
                                        Math.Round(_precioM3.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precioM3.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmpM3.Item.desc);
            _dataG.precio_3_Emp_3.setData(_gEmpD3.GetId,
                                        _precioD3.Contenido,
                                        _precioD3.Utilidad,
                                        Math.Round(_precioD3.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precioD3.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmpD3.Item.desc);
            //
            _dataG.precio_4_Emp_1.setData(_gEmp4.GetId,
                                        _precio4.Contenido,
                                        _precio4.Utilidad,
                                        Math.Round(_precio4.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precio4.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmp4.Item.desc);
            _dataG.precio_4_Emp_2.setData(_gEmpM4.GetId,
                                        _precioM4.Contenido,
                                        _precioM4.Utilidad,
                                        Math.Round(_precioM4.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precioM4.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmpM4.Item.desc);
            _dataG.precio_4_Emp_3.setData(_gEmpD4.GetId,
                                        _precioD4.Contenido,
                                        _precioD4.Utilidad,
                                        Math.Round(_precioD4.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precioD4.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmpD4.Item.desc);
            //
            _dataG.precio_5_Emp_1.setData(_gEmp5.GetId,
                                        _precio5.Contenido,
                                        _precio5.Utilidad,
                                        Math.Round(_precio5.Neto_MonedaLocal, 2, MidpointRounding.AwayFromZero),
                                        Math.Round(_precio5.Full_Divisa, 2, MidpointRounding.AwayFromZero),
                                        _gEmp5.Item.desc);

            //var ficha = new OOB.LibInventario.Precio.Editar.Ficha()
            //{
            //    autoProducto = _idProducto,
            //    autoUsuario = Sistema.UsuarioP.autoUsu,
            //    codigoUsuario = Sistema.UsuarioP.codigoUsu,
            //    estacion = Environment.MachineName,
            //    nombreUsuario = Sistema.UsuarioP.nombreUsu,
            //};
            //var p1 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmp1.GetId,
            //    contenido = _precio1.Contenido ,
            //    precio_divisa_Neto = _precio1.Full_Divisa,
            //    precioNeto = _precio1.Neto_MonedaLocal,
            //    utilidad = _precio1.Utilidad,
            //};
            //ficha.precio_1= p1;
            //var h1 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precio1.Neto_MonedaLocal,
            //    precio_id = "1",
            //    empaque = "UNIDAD",
            //    contenido = _precio1.Contenido,
            //};

            //var p2 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmp2.GetId,
            //    contenido = _precio2.Contenido,
            //    precio_divisa_Neto = _precio2.Full_Divisa,
            //    precioNeto = _precio2.Neto_MonedaLocal,
            //    utilidad = _precio2.Utilidad,
            //};
            //ficha.precio_2 = p2;
            //var h2 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precio2.Neto_MonedaLocal,
            //    precio_id = "2",
            //    empaque = "UNIDAD",
            //    contenido = _precio2.Contenido,
            //};

            //var p3 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmp3.GetId,
            //    contenido = _precio3.Contenido,
            //    precio_divisa_Neto = _precio3.Full_Divisa,
            //    precioNeto = _precio3.Neto_MonedaLocal,
            //    utilidad = _precio3.Utilidad ,
            //};
            //ficha.precio_3 = p3;
            //var h3 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precio3.Neto_MonedaLocal,
            //    precio_id = "3",
            //    empaque = "UNIDAD",
            //    contenido = _precio3.Contenido,
            //};

            //var p4 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmp4.GetId,
            //    contenido = _precio4.Contenido,
            //    precio_divisa_Neto = _precio4.Full_Divisa,
            //    precioNeto = _precio4.Neto_MonedaLocal,
            //    utilidad = _precio4.Utilidad,
            //};
            //ficha.precio_4 = p4;
            //var h4 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precio4.Neto_MonedaLocal,
            //    precio_id = "4",
            //    empaque = "UNIDAD",
            //    contenido = _precio4.Contenido,
            //};

            //var p5 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmp5.GetId,
            //    contenido = _precio5.Contenido,
            //    precio_divisa_Neto = _precio5.Full_Divisa,
            //    precioNeto = _precio5.Neto_MonedaLocal,
            //    utilidad = _precio5.Utilidad,
            //};
            //ficha.precio_5 = p5;
            //var h5 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precio5.Neto_MonedaLocal,
            //    precio_id = "PTO",
            //    empaque = "UNIDAD",
            //    contenido = _precio5.Contenido,
            //};

            ////
            //var m1 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmpM1.GetId,
            //    contenido = _precioM1.Contenido,
            //    precio_divisa_Neto = _precioM1.Full_Divisa,
            //    precioNeto = _precioM1.Neto_MonedaLocal,
            //    utilidad = _precioM1.Utilidad,
            //};
            //ficha.may_1 = m1;
            //var hM1 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precioM1.Neto_MonedaLocal,
            //    precio_id = "MY1",
            //    empaque = _gEmpM1.Item.desc,
            //    contenido = _precioM1.Contenido,
            //};

            //var m2 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmpM2.GetId,
            //    contenido = _precioM2.Contenido,
            //    precio_divisa_Neto = _precioM2.Full_Divisa,
            //    precioNeto = _precioM2.Neto_MonedaLocal,
            //    utilidad = _precioM2.Utilidad,
            //};
            //ficha.may_2 = m2;
            //var hM2 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precioM2.Neto_MonedaLocal,
            //    precio_id = "MY2",
            //    empaque = _gEmpM2.Item.desc,
            //    contenido = _precioM2.Contenido,
            //};

            //var m3 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmpM3.GetId,
            //    contenido = _precioM3.Contenido,
            //    precio_divisa_Neto = _precioM3.Full_Divisa,
            //    precioNeto = _precioM3.Neto_MonedaLocal,
            //    utilidad = _precioM3.Utilidad,
            //};
            //ficha.may_3 = m3;
            //var hM3 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precioM3.Neto_MonedaLocal,
            //    precio_id = "MY3",
            //    empaque = _gEmpM3.Item.desc,
            //    contenido = _precioM3.Contenido,
            //};

            //var m4 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmpM4.GetId,
            //    contenido = _precioM4.Contenido,
            //    precio_divisa_Neto = _precioM4.Full_Divisa,
            //    precioNeto = _precioM4.Neto_MonedaLocal,
            //    utilidad = _precioM4.Utilidad,
            //};
            //ficha.may_4 = m4;
            //var hM4 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precioM4.Neto_MonedaLocal,
            //    precio_id = "MY4",
            //    empaque = _gEmpM4.Item.desc,
            //    contenido = _precioM4.Contenido,
            //};


            ////
            //var d1 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmpD1.GetId,
            //    contenido = _precioD1.Contenido,
            //    precio_divisa_Neto = _precioD1.Full_Divisa,
            //    precioNeto = _precioD1.Neto_MonedaLocal,
            //    utilidad = _precioD1.Utilidad,
            //};
            //ficha.dsp_1  = d1;
            //var hD1 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precioD1.Neto_MonedaLocal,
            //    precio_id = "DS1",
            //    empaque = _gEmpD1.Item.desc,
            //    contenido = _precioD1.Contenido,
            //};

            //var d2 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmpD2.GetId,
            //    contenido = _precioD2.Contenido,
            //    precio_divisa_Neto = _precioD2.Full_Divisa,
            //    precioNeto = _precioD2.Neto_MonedaLocal,
            //    utilidad = _precioD2.Utilidad,
            //};
            //ficha.dsp_2 = d2;
            //var hD2 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precioD2.Neto_MonedaLocal,
            //    precio_id = "DS2",
            //    empaque = _gEmpD2.Item.desc,
            //    contenido = _precioD2.Contenido,
            //};

            //var d3 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmpD3.GetId,
            //    contenido = _precioD3.Contenido,
            //    precio_divisa_Neto = _precioD3.Full_Divisa,
            //    precioNeto = _precioD3.Neto_MonedaLocal,
            //    utilidad = _precioD3.Utilidad,
            //};
            //ficha.dsp_3 = d3;
            //var hD3 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precioD3.Neto_MonedaLocal,
            //    precio_id = "DS3",
            //    empaque = _gEmpD3.Item.desc,
            //    contenido = _precioD3.Contenido,
            //};

            //var d4 = new OOB.LibInventario.Precio.Editar.FichaPrecio()
            //{
            //    autoEmp = _gEmpD4.GetId,
            //    contenido = _precioD4.Contenido,
            //    precio_divisa_Neto = _precioD4.Full_Divisa,
            //    precioNeto = _precioD4.Neto_MonedaLocal,
            //    utilidad = _precioD4.Utilidad,
            //};
            //ficha.dsp_4 = d4;
            //var hD4 = new OOB.LibInventario.Precio.Editar.FichaHistorica()
            //{
            //    nota = "",
            //    precio = _precioD4.Neto_MonedaLocal,
            //    precio_id = "DS4",
            //    empaque = _gEmpD4.Item.desc,
            //    contenido = _precioD4.Contenido,
            //};


            //var historia = new List<OOB.LibInventario.Precio.Editar.FichaHistorica>();
            //historia.Add(h1);
            //historia.Add(h2);
            //historia.Add(h3);
            //historia.Add(h4);
            //historia.Add(h5);
            ////
            //historia.Add(hM1);
            //historia.Add(hM2);
            //historia.Add(hM3);
            //historia.Add(hM4);
            ////
            //historia.Add(hD1);
            //historia.Add(hD2);
            //historia.Add(hD3);
            //historia.Add(hD4); 


            //ficha.historia = historia;
            //var r01 = Sistema.MyData.PrecioProducto_Actualizar(ficha);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return ;
            //}
            _isProcesarIsOk = true;
        }


        private decimal CalculaNeto(decimal monto, decimal tasa)
        {
            var rt = 0m;
            rt = monto / ((tasa / 100) + 1);
            return rt;
        }


        public void setContEmp_D1(int cont)
        {
            _precioD1.setContenido(cont);
        }
        public void setUt_D1(decimal ut)
        {
            _precioD1.setUtilidadNueva(ut);
        }
        public void setPN_D1(decimal monto)
        {
            _precioD1.setNeto(monto);
        }
        public void setPF_D1(decimal monto)
        {
            _precioD1.setFull(monto);
        }
        public int GetContD1 { get { return _precioD1.Contenido; } }
        public decimal GetUtD1 { get { return _precioD1.Utilidad; } }
        public decimal GetPND1 { get { return _precioD1.Neto; } }
        public decimal GetPFD1 { get { return _precioD1.Full; } }
        public decimal GetUtActualD1 { get { return _precioD1.UtilidadActual; } }
        public bool ERR_D1 { get { return _precioD1.IsError; } }


        public void setContEmp_D2(int cont)
        {
            _precioD2.setContenido(cont);
        }
        public void setUt_D2(decimal ut)
        {
            _precioD2.setUtilidadNueva(ut);
        }
        public void setPN_D2(decimal monto)
        {
            _precioD2.setNeto(monto);
        }
        public void setPF_D2(decimal monto)
        {
            _precioD2.setFull(monto);
        }
        public int GetContD2 { get { return _precioD2.Contenido; } }
        public decimal GetUtD2 { get { return _precioD2.Utilidad; } }
        public decimal GetPND2 { get { return _precioD2.Neto; } }
        public decimal GetPFD2 { get { return _precioD2.Full; } }
        public decimal GetUtActualD2 { get { return _precioD2.UtilidadActual; } }
        public bool ERR_D2 { get { return _precioD2.IsError; } }


        public void setContEmp_D3(int cont)
        {
            _precioD3.setContenido(cont);
        }
        public void setUt_D3(decimal ut)
        {
            _precioD3.setUtilidadNueva(ut);
        }
        public void setPN_D3(decimal monto)
        {
            _precioD3.setNeto(monto);
        }
        public void setPF_D3(decimal monto)
        {
            _precioD3.setFull(monto);
        }
        public int GetContD3 { get { return _precioD3.Contenido; } }
        public decimal GetUtD3 { get { return _precioD3.Utilidad; } }
        public decimal GetPND3 { get { return _precioD3.Neto; } }
        public decimal GetPFD3 { get { return _precioD3.Full; } }
        public decimal GetUtActualD3 { get { return _precioD3.UtilidadActual; } }
        public bool ERR_D3 { get { return _precioD3.IsError; } }


        public void setContEmp_D4(int cont)
        {
            _precioD4.setContenido(cont);
        }
        public void setUt_D4(decimal ut)
        {
            _precioD4.setUtilidadNueva(ut);
        }
        public void setPN_D4(decimal monto)
        {
            _precioD4.setNeto(monto);
        }
        public void setPF_D4(decimal monto)
        {
            _precioD4.setFull(monto);
        }
        public int GetContD4 { get { return _precioD4.Contenido; } }
        public decimal GetUtD4 { get { return _precioD4.Utilidad; } }
        public decimal GetPND4 { get { return _precioD4.Neto; } }
        public decimal GetPFD4 { get { return _precioD4.Full; } }
        public decimal GetUtActualD4 { get { return _precioD4.UtilidadActual; } }
        public bool ERR_D4 { get { return _precioD4.IsError; } }


        public BindingSource GetEmpTipo_1_Source { get { return _gEmpTipo_1.Source; } }
        public int GetContEmpTipo_1 { get { return _contEmpTipo_1; } }
        public BindingSource GetEmpTipo_2_Source { get { return _gEmpTipo_2.Source; } }
        public int GetContEmpTipo_2 { get { return _contEmpTipo_2; } }
        public BindingSource GetEmpTipo_3_Source { get { return _gEmpTipo_3.Source; } }
        public int GetContEmpTipo_3 { get { return _contEmpTipo_3; } }


        public void setPrdEditar(dataPrdEditar fichaPrd)
        {
            _idProducto = fichaPrd.AutoPrd;
            _tasaIvaPrd= fichaPrd.TasaIva;
            _esAdmDivisaPrd = fichaPrd.AdmDivisa;
            _contEmpCompraPrd=fichaPrd.ContEmpCompra;
            _codigoPrd=fichaPrd.CodigoPrd;
            _autoPrd=fichaPrd.AutoPrd;
            _descripcionPrd=fichaPrd.DescripcionPrd;
            _empCompraDescPrd=fichaPrd.EmpCompraDescripcion;
            _costoMonedaLocalPrd= fichaPrd.CostoMonedaLocal;
            _costoMonedaDivisaPrd = fichaPrd.CostoMonedaDivisa;
        }

    }

}