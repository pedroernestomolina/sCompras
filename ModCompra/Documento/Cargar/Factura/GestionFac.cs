using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Documento.Cargar.Factura
{
    
    public class GestionFac : Controlador.IGestion
    {

        public event EventHandler ActualizarItemHnd;


        private Controlador.IGestionDocumento gestionDoc;
        private Controlador.IGestionItem gestionItem;
        private Controlador.IGestionProductoBuscar gestionPrdBuscar;
        private Controlador.IGestionTotalizar gestionTotalizar;
        private Administrador.Gestion _gestionAdmDoc;
        private Pendiente.Gestion _gestionPend;
        private OOB.LibCompra.Empresa.Fiscal.Ficha tasasFiscal;
        private OOB.LibCompra.Concepto.Ficha conceptoCompra;
        private bool _dejarPendienteIsOk;
        private int _cntPend;


        public Controlador.GestionProductoBuscar.metodoBusqueda MetodoBusquedaProducto { get { return gestionPrdBuscar.MetodoBusquedaProducto; } }
        public Controlador.IGestionDocumento GestionDoc { get { return gestionDoc; } }
        public Controlador.IGestionItem GestionItem {get { return gestionItem; }}
        public Controlador.IGestionTotalizar GestionTotalizar {get { return gestionTotalizar; }}
        public bool VisualizarColDevolucion { get { return false; } }


        public string CadenaPrdBuscar { get { return gestionPrdBuscar.CadenaPrdBuscar; } set { gestionPrdBuscar.CadenaPrdBuscar = value; } }
        public bool SalidaOk { get; set; }


        public string TituloDocumento { get { return "Entrada Documento: ( FACTURA )"; } }
        public System.Drawing.Color ColorFondoDocumento { get { return System.Drawing.Color.Green; } }
        public bool DejarPendienteIsOk { get { return _dejarPendienteIsOk; } }
        public string CntPend { get { return "(" + _cntPend.ToString("n0") + ")"; } }
        public bool AbrirPendienteIsOk { get { return _gestionPend.IsItemSeleccionadoOk; } }
        

        public GestionFac()
        {
            _cntPend = 0;
            _dejarPendienteIsOk = false;
            SalidaOk = false;
            gestionDoc= new GestionDocumentoFac();
            gestionItem = new GestionItemFac();
            gestionPrdBuscar = new GestionProductoBuscarFac();
            gestionTotalizar = new GestionTotalizarFac();
            gestionItem.ActualizarItemHnd +=gestionItem_ActualizarItemHnd;
            _gestionAdmDoc = new Administrador.Gestion();
            _gestionPend = new Pendiente.Gestion();
            _gOpcBusqueda = new HlpGestion.HndCombo.Opcion();
        }

        private void gestionItem_ActualizarItemHnd(object sender, EventArgs e)
        {
            EventHandler hnd = ActualizarItemHnd;
            if (hnd != null)
            {
                hnd(this, e);
            }
        }

        public void Inicializar() 
        {
            _cntPend = 0;
            _dejarPendienteIsOk = false;
            SalidaOk = false;
            _gOpcBusqueda.Inicializa();
        }

        public bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Configuracion_PreferenciaBusquedaProducto();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData.Empresa_GetTasas();
            if (r02.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            var r03 = Sistema.MyData.Concepto_PorMovCompra();
            if (r03.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r03.Mensaje);
                return false;
            }

            var r04 = Sistema.MyData.Configuracion_TasaCambioActual ();
            if (r04.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r04.Mensaje);
                return false;
            }

            var filtro = new OOB.LibCompra.Documento.Pendiente.Filtro.Ficha()
            {
                docTipo = "01",
                idUsuario = Sistema.UsuarioP.autoUsu,
            };
            var r05 = Sistema.MyData.Compra_Documento_Pendiente_Cnt(filtro);
            if (r05.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r05.Mensaje);
                return false;
            }
            _cntPend = r05.Entidad;


            var _lst = new List<HlpGestion.ficha>();
            _lst.Add(new HlpGestion.ficha() { id = "01", codigo = "", desc = "Por Codigo" });
            _lst.Add(new HlpGestion.ficha() { id = "02", codigo = "", desc = "Por Descripción" });
            _lst.Add(new HlpGestion.ficha() { id = "03", codigo = "", desc = "Por Referencia" });
            _lst.Add(new HlpGestion.ficha() { id = "04", codigo = "", desc = "Por Cod/Barra" });
            _gOpcBusqueda.setData(_lst);
            var _opcBusq = "";

            var mt = Controlador.GestionProductoBuscar.metodoBusqueda.SinDefinir;
            switch (r01.Entidad)
            {
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto.PorCodigo:
                    mt = Controlador.GestionProductoBuscar.metodoBusqueda.Codigo;
                    _opcBusq = "01";
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto.PorNombre:
                    mt= Controlador.GestionProductoBuscar.metodoBusqueda.Nombre;
                    _opcBusq = "02";
                    break;
                case OOB.LibCompra.Configuracion.Enumerados.EnumPreferenciaBusquedaProducto.Referencia:
                    mt= Controlador.GestionProductoBuscar.metodoBusqueda.Referencia;
                    _opcBusq = "03";
                    break;
            }
            _gOpcBusqueda.setFicha(_opcBusq);

            gestionPrdBuscar.setMetodoBusqueda(mt);
            tasasFiscal = r02.Entidad;
            conceptoCompra = r03.Entidad;
            gestionDoc.setFactorCambio(r04.Entidad);

            return rt;
        }

        public void Salir()
        {
            SalidaOk = false;
            var ms = MessageBox.Show("Estas Seguro de Abandonar/Perder Datos del Documento ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ms == DialogResult.Yes)
            {
                SalidaOk = true;
            }
        }

        public void LimpiarDocumento()
        {
            var ms = MessageBox.Show("Estas Seguro Limpiar/Perder Los Datos ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (ms == DialogResult.Yes)
            {
                gestionItem.Limpiar();
                gestionDoc.Limpiar();
            }
        }

        public void BuscarProducto()
        {
            if (!gestionDoc.IsAceptarOk)
            {
                Helpers.Msg.Alerta("Debe Primero Hacer Click En Nuevo Documento");
                return;
            }
            gestionPrdBuscar.setFiltroDeposito(gestionDoc.IdDeposito);
            gestionPrdBuscar.BuscarProducto();
            if (gestionPrdBuscar.IsProductoSeleccionadoOk)
            {
                var autoPrd = gestionPrdBuscar.AutoProductoSeleccionado;
                if (verificarDepositoAsignado(autoPrd))
                    gestionItem.AgregarItem(autoPrd, gestionDoc.Proveedor.autoId, gestionDoc.FactorDivisa);
            }
        }

        private bool verificarDepositoAsignado(string prdAuto)
        {
            var rt = true;
            var ficha = new OOB.LibCompra.Producto.VerificarDepositoAsignado.Ficha() { autoPrd = prdAuto, autoDeposito = gestionDoc.IdDeposito };
            var rt1 = Sistema.MyData.Producto_VerificaDepositoAsignado(ficha);
            if (rt1.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            return rt;
        }

        public void ActivarBusquedaProductoPorCodigo()
        {
            gestionPrdBuscar.setMetodoBusqueda(Controlador.GestionProductoBuscar.metodoBusqueda.Codigo);
        }

        public void ActivarBusquedaProductoPorNombre()
        {
            gestionPrdBuscar.setMetodoBusqueda(Controlador.GestionProductoBuscar.metodoBusqueda.Nombre);
        }

        public void ActivarBusquedaProductoPorReferencia()
        {
            gestionPrdBuscar.setMetodoBusqueda(Controlador.GestionProductoBuscar.metodoBusqueda.Referencia);
        }

        public void Guardar()
        {
            SalidaOk = false;

            if (!gestionDoc.IsAceptarOk)
            {
                Helpers.Msg.Error("Datos Del Documento Incorrectos !!!");
                return;
            }

            if (gestionItem.TItems == 0)
            {
                Helpers.Msg.Error("No Hay Items Que Procesar !!!");
                return;
            }

            if (gestionItem.TotalMonto == 0.0m)
            {
                Helpers.Msg.Error("Monto del Documento Incorrecto !!!");
                return;
            }

            var r00 = Sistema.MyData.Configuracion_GetPermitirCambiarPrecioAlRegistrarDocCompra();
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }
            if (r00.Entidad)
            {
                var _it = ((List<dataItem>)gestionItem.Lista).FirstOrDefault(s=> !s.GetActualizarPrecio);
                if (_it!=null)
                {
                    Helpers.Msg.Error(" [ " +_it.Producto.descripcion + " ], PRECIO DE VENTA NO ASIGNADO");
                    return;
                }
            }

            var r01 = Sistema.MyData.Permiso_RegistrarFactura_ProcesarDocumento(Sistema.UsuarioP.autoGru);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            if (Seguridad.Gestion.SolicitarClave(r01.Entidad))
            {
                SalidaOk = GuardarDoc();
            }
        }

        private bool GuardarDoc()
        {
            var rt = true;

            var preciosMod =new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecios>();
            var historicoPrecio = new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico>();
            foreach (dataItem it in ((List<dataItem>)gestionItem.Lista).Where(w=>w.GetActualizarPrecio).ToList())
            {
                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p1_1 = null;
                if (it.GetDataPrecios.precio_1_Emp_1.pNeto>0)
                {
                    p1_1 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_1_Emp_1.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_1_Emp_1.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_1_Emp_1.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_1_Emp_1.pFull,
                        utilidad = it.GetDataPrecios.precio_1_Emp_1.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_1_Emp_1.pNeto,
                        precioId = "1",
                        empaque = it.GetDataPrecios.precio_1_Emp_1.descEmpaque,
                        contenido = it.GetDataPrecios.precio_1_Emp_1.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }
                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p1_2 = null;
                if (it.GetDataPrecios.precio_1_Emp_2.pNeto > 0)
                {
                    p1_2 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_1_Emp_2.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_1_Emp_2.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_1_Emp_2.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_1_Emp_2.pFull,
                        utilidad = it.GetDataPrecios.precio_1_Emp_2.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_1_Emp_2.pNeto,
                        precioId = "MY1",
                        empaque = it.GetDataPrecios.precio_1_Emp_2.descEmpaque,
                        contenido = it.GetDataPrecios.precio_1_Emp_2.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }
                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p1_3 = null;
                if (it.GetDataPrecios.precio_1_Emp_3.pNeto > 0)
                {
                    p1_3 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_1_Emp_3.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_1_Emp_3.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_1_Emp_3.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_1_Emp_3.pFull,
                        utilidad = it.GetDataPrecios.precio_1_Emp_3.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_1_Emp_3.pNeto,
                        precioId = "DS1",
                        empaque = it.GetDataPrecios.precio_1_Emp_3.descEmpaque,
                        contenido = it.GetDataPrecios.precio_1_Emp_3.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }

                //

                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p2_1 = null;
                if (it.GetDataPrecios.precio_2_Emp_1.pNeto > 0)
                {
                    p2_1 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_2_Emp_1.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_2_Emp_1.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_2_Emp_1.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_2_Emp_1.pFull,
                        utilidad = it.GetDataPrecios.precio_2_Emp_1.utilidad,
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_2_Emp_1.pNeto,
                        precioId = "2",
                        empaque = it.GetDataPrecios.precio_2_Emp_1.descEmpaque,
                        contenido = it.GetDataPrecios.precio_2_Emp_1.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }
                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p2_2 = null;
                if (it.GetDataPrecios.precio_2_Emp_2.pNeto > 0)
                {
                    p2_2 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_2_Emp_2.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_2_Emp_2.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_2_Emp_2.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_2_Emp_2.pFull,
                        utilidad = it.GetDataPrecios.precio_2_Emp_2.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_2_Emp_2.pNeto,
                        precioId = "MY2",
                        empaque = it.GetDataPrecios.precio_2_Emp_2.descEmpaque,
                        contenido = it.GetDataPrecios.precio_2_Emp_2.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }
                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p2_3 = null;
                if (it.GetDataPrecios.precio_2_Emp_3.pNeto > 0)
                {
                    p2_3 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_2_Emp_3.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_2_Emp_3.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_2_Emp_3.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_2_Emp_3.pFull,
                        utilidad = it.GetDataPrecios.precio_2_Emp_3.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_2_Emp_3.pNeto,
                        precioId = "DS2",
                        empaque = it.GetDataPrecios.precio_2_Emp_3.descEmpaque,
                        contenido = it.GetDataPrecios.precio_2_Emp_3.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }

                //

                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p3_1 = null;
                if (it.GetDataPrecios.precio_3_Emp_1.pNeto > 0)
                {
                    p3_1 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_3_Emp_1.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_3_Emp_1.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_3_Emp_1.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_3_Emp_1.pFull,
                        utilidad = it.GetDataPrecios.precio_3_Emp_1.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_3_Emp_1.pNeto,
                        precioId = "3",
                        empaque = it.GetDataPrecios.precio_3_Emp_1.descEmpaque,
                        contenido = it.GetDataPrecios.precio_3_Emp_1.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }
                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p3_2 = null;
                if (it.GetDataPrecios.precio_3_Emp_2.pNeto > 0)
                {
                    p3_2 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_3_Emp_2.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_3_Emp_2.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_3_Emp_2.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_3_Emp_2.pFull,
                        utilidad = it.GetDataPrecios.precio_3_Emp_2.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_3_Emp_2.pNeto,
                        precioId = "MY3",
                        empaque = it.GetDataPrecios.precio_3_Emp_2.descEmpaque,
                        contenido = it.GetDataPrecios.precio_3_Emp_2.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }
                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p3_3 = null;
                if (it.GetDataPrecios.precio_3_Emp_3.pNeto > 0)
                {
                    p3_3 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_3_Emp_3.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_3_Emp_3.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_3_Emp_3.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_3_Emp_3.pFull,
                        utilidad = it.GetDataPrecios.precio_3_Emp_3.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_3_Emp_3.pNeto,
                        precioId = "DS3",
                        empaque = it.GetDataPrecios.precio_3_Emp_3.descEmpaque,
                        contenido = it.GetDataPrecios.precio_3_Emp_3.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }

                //

                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p4_1 = null;
                if (it.GetDataPrecios.precio_4_Emp_1.pNeto > 0)
                {
                    p4_1 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_4_Emp_1.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_4_Emp_1.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_4_Emp_1.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_4_Emp_1.pFull,
                        utilidad = it.GetDataPrecios.precio_4_Emp_1.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_4_Emp_1.pNeto,
                        precioId = "4",
                        empaque = it.GetDataPrecios.precio_4_Emp_1.descEmpaque,
                        contenido = it.GetDataPrecios.precio_4_Emp_1.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }
                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p4_2 = null;
                if (it.GetDataPrecios.precio_4_Emp_2.pNeto > 0)
                {
                    p4_2 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_4_Emp_2.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_4_Emp_2.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_4_Emp_2.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_4_Emp_2.pFull,
                        utilidad = it.GetDataPrecios.precio_4_Emp_2.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_4_Emp_2.pNeto,
                        precioId = "MY4",
                        empaque = it.GetDataPrecios.precio_4_Emp_2.descEmpaque,
                        contenido = it.GetDataPrecios.precio_4_Emp_2.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }
                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p4_3 = null;
                if (it.GetDataPrecios.precio_4_Emp_3.pNeto > 0)
                {
                    p4_3 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_4_Emp_3.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_4_Emp_3.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_4_Emp_3.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_4_Emp_3.pFull,
                        utilidad = it.GetDataPrecios.precio_4_Emp_3.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_4_Emp_3.pNeto,
                        precioId = "DS4",
                        empaque = it.GetDataPrecios.precio_4_Emp_3.descEmpaque,
                        contenido = it.GetDataPrecios.precio_4_Emp_3.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }

                //

                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p5_1 = null;
                if (it.GetDataPrecios.precio_5_Emp_1.pNeto > 0)
                {
                    p5_1 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_5_Emp_1.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_5_Emp_1.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_5_Emp_1.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_5_Emp_1.pFull,
                        utilidad = it.GetDataPrecios.precio_5_Emp_1.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_5_Emp_1.pNeto,
                        precioId = "PTO",
                        empaque = it.GetDataPrecios.precio_5_Emp_1.descEmpaque,
                        contenido = it.GetDataPrecios.precio_5_Emp_1.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }
                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p5_2 = null;
                if (it.GetDataPrecios.precio_5_Emp_2.pNeto > 0)
                {
                    p5_2 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_5_Emp_2.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_5_Emp_2.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_5_Emp_2.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_5_Emp_2.pFull,
                        utilidad = it.GetDataPrecios.precio_5_Emp_2.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_5_Emp_2.pNeto,
                        precioId = "MY5",
                        empaque = it.GetDataPrecios.precio_5_Emp_2.descEmpaque,
                        contenido = it.GetDataPrecios.precio_5_Emp_2.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }
                OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio p5_3 = null;
                if (it.GetDataPrecios.precio_5_Emp_3.pNeto > 0)
                {
                    p5_3 = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrecio()
                    {
                        autoEmp = it.GetDataPrecios.precio_5_Emp_3.autoEmpaque,
                        contenido = it.GetDataPrecios.precio_5_Emp_3.contEmpaque,
                        precioNeto = it.GetDataPrecios.precio_5_Emp_3.pNeto,
                        precioFullDivisa = it.GetDataPrecios.precio_5_Emp_3.pFull,
                        utilidad = it.GetDataPrecios.precio_5_Emp_3.utilidad
                    };
                    var ph = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecioHistorico()
                    {
                        autoPrd = it.Producto.auto,
                        nota = "FACTURA COMPRA",
                        precio = it.GetDataPrecios.precio_5_Emp_3.pNeto,
                        precioId = "DS5",
                        empaque = it.GetDataPrecios.precio_5_Emp_3.descEmpaque,
                        contenido = it.GetDataPrecios.precio_5_Emp_3.contEmpaque,
                        tasaFactorCambio = it.GetDataPrecios.GetFactorDivisa,
                    };
                    historicoPrecio.Add(ph);
                }

                var fp = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdPrecios()
                {
                    autoPrd = it.Producto.auto,
                    //
                    precio1_Emp1 = p1_1,
                    precio1_Emp2 = p1_2,
                    precio1_Emp3 = p1_3,
                    //
                    precio2_Emp1 = p2_1,
                    precio2_Emp2 = p2_2,
                    precio2_Emp3 = p2_3,
                    //
                    precio3_Emp1 = p3_1,
                    precio3_Emp2 = p3_2,
                    precio3_Emp3 = p3_3,
                    //
                    precio4_Emp1 = p4_1,
                    precio4_Emp2 = p4_2,
                    precio4_Emp3 = p4_3,
                    //
                    precio5_Emp1 = p5_1,
                    precio5_Emp2 = p5_2,
                    precio5_Emp3 = p5_3,
                };
                preciosMod.Add(fp);
            }

            var saldoPend = 0.0m;
            if (gestionDoc.DiasCredito>0)
                saldoPend=gestionItem.TotalMonto_Final;

            var fichaDoc = new OOB.LibCompra.Documento.Cargar.Factura.FichaDocumento()
            {
                anoRelacion = gestionDoc.AnoRelacion,
                anticipoIva = 0.0m,
                aplicaDocumentoNro = "",
                autoConcepto = "0000000001",
                autoProveedor = gestionDoc.Proveedor.autoId,
                autoRemision = "",
                cierreFtp = "",
                ciRifProveedor = gestionDoc.Proveedor.ciRif,
                cntRenglones = gestionItem.TItems,
                codicionPago = gestionDoc.CondicionPago,
                codigoProveedor = gestionDoc.Proveedor.codigo,
                columna = "1",
                comprobanteRetencionISLR = "",
                comprobanteRetencionNro = "",
                controlNro = gestionDoc.ControlNro,
                denominacionFiscal = "No Contribuyente",
                diasCredito = gestionDoc.DiasCredito,
                diasValidez = 0,
                direccionFiscalProveedor = gestionDoc.Proveedor.direccionFiscal,
                documentoNombre = "COMPRAS",
                documentoNro = gestionDoc.DocumentoNro,
                documentoRemision = "",
                documentoTipo = "Compras",
                esAnulado = "0",
                estacionEquipo = Sistema.EquipoEstacion,
                estatusCierreContable = "0",
                expediente = "",
                factorCambio = gestionDoc.FactorDivisa,
                fechaDocumento = gestionDoc.FechaEmision,
                fechaRetencion = new DateTime(2000, 01, 01).Date,
                fechaVencimiento = gestionDoc.FechaVencimiento,
                mesRelacion = gestionDoc.MesRelacion,
                montoBase = gestionItem.MontoBase_Final,
                montoBase1 = gestionItem.MontoBase1_Final,
                montoBase2 = gestionItem.MontoBase2_Final,
                montoBase3 = gestionItem.MontoBase3_Final,
                montoCargo = gestionItem.MontoCargo_Final,
                montoCosto = 0.0m,
                montoDescuento1 = gestionItem.MontoDescuento_Final,
                montoDescuento2 = 0.0m,
                montoDivisa = gestionItem.MontoDivisa_Final,
                montoExento = gestionItem.MontoExento_Final,
                montoImpuesto = gestionItem.MontoImpuesto_Final,
                montoImpuesto1 = gestionItem.MontoImpuesto1_Final,
                montoImpuesto2 = gestionItem.MontoImpuesto2_Final,
                montoImpuesto3 = gestionItem.MontoImpuesto3_Final,
                montoNeto = gestionItem.TotalMonto_Final - gestionItem.MontoImpuesto_Final,
                montoRetencionISLR = 0.0m,
                montoRetencionIva = 0.0m,
                montoSaldoPendeiente = saldoPend,
                montoTotal = gestionItem.TotalMonto_Final,
                montoUtilidad = 0.0m,
                nombreRazonSocialProveedor = gestionDoc.Proveedor.nombreRazonSocial,
                notaDocumento = gestionDoc.Notas,
                ordenCompraNro = gestionDoc.OrdenCompraNro,
                planilla = "",
                serieDocumento = "FAC",
                signoDocumento = 1,
                situacionDocumento = "Procesado",
                subTotalNeto = gestionItem.TotalMonto_Final - gestionItem.MontoImpuesto_Final,
                subTotal = gestionItem.TotalMonto_Final,
                subTotalImpuesto = gestionItem.MontoImpuesto_Final,
                sucursalCodigo = gestionDoc.Sucursal.codigo,
                tarifa = "0",
                telefonoPropveedor = gestionDoc.Proveedor.identidad.telefono,
                tercerosIva = 0.0m,
                tipoDocumento = "01",
                tipoProveedor = "",
                tipoRemision = "",
                usuarioAuto = Sistema.UsuarioP.autoUsu,
                usuarioCodigo = Sistema.UsuarioP.codigoUsu,
                usuarioNombre = Sistema.UsuarioP.nombreUsu,
                valorPorccargo = gestionTotalizar.Cargo,
                valorPorcDescuento1 = gestionTotalizar.Dscto,
                valorPorcDescuento2 = 0.0m,
                valorPorctUtilidad = 0.0m,
                valorTasaIva1 = tasasFiscal.Tasa1,
                valorTasaIva2 = tasasFiscal.Tasa2,
                valorTasaIva3 = tasasFiscal.Tasa3,
                valorTasaRetencionISLR = 0.0m,
                valorTasaRetencionIva = 0.0m,
            };
            var fichaCxP = new OOB.LibCompra.Documento.Cargar.Factura.FichaCxP()
            {
                acumulado = 0.0m,
                Anexo = "",
                autoAgencia = "0000000001",
                autoProveedor = gestionDoc.Proveedor.autoId,
                ciRifProveedor = gestionDoc.Proveedor.ciRif,
                codigoProveedor = gestionDoc.Proveedor.codigo,
                diasCredito = gestionDoc.DiasCredito,
                documentoNro = gestionDoc.DocumentoNro,
                esAnulado = "0",
                esCancelado = "0",
                estatusCierreContable = "0",
                fechaVencimiento = gestionDoc.FechaVencimiento,
                importe = gestionItem.TotalMonto_Final,
                importeDivisa = gestionItem.MontoDivisa_Final,
                nombreAgencia = "",
                nombreRazonSocialProveedor = gestionDoc.Proveedor.nombreRazonSocial,
                nota = "",
                numero = "",
                resta = gestionItem.TotalMonto_Final,
                signoDocumento = 1,
                tipoDocumento = "FAC",
            };
            var fichaDetalle= new List<OOB.LibCompra.Documento.Cargar.Factura.FichaDetalle>();
            var fichaPrdDeposito = new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdDeposito>();
            var fichaPrdKardex = new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdKardex>();
            var fichaPrdCosto= new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdCosto>();
            var fichaPrdCostoHistorico = new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdCostoHistorico>();
            var fichaPrdProveedor  = new List<OOB.LibCompra.Documento.Cargar.Factura.FichaPrdProveedor>();
            foreach (dataItem it in gestionItem.Lista)
            {
                var detalle = new OOB.LibCompra.Documento.Cargar.Factura.FichaDetalle()
                {
                    autoDepartamento = it.Producto.autoDepartamento,
                    autoDeposito = gestionDoc.IdDeposito,
                    autoGrupo = it.Producto.autoGrupo,
                    autoProducto = it.Producto.auto,
                    autoProveedor = gestionDoc.Proveedor.autoId,
                    autoSubGrupo = it.Producto.autoSubGrupo,
                    autoTasaIva = it.Producto.autoTasa,
                    cantidadBonoFac = 0.0m,
                    cantidadFac = it.cantidad,
                    cantidadUnd = it.CantidadUnd,
                    categoriaPrd = it.Producto.categoria,
                    cierreFtp = "",
                    codigoProducto = it.Producto.codigo,
                    codigoProveedor = it.CodRefPrv,
                    contenidoEmpaque = it.Producto.contenidoCompra,
                    costoBruto = it.costoMoneda,
                    costoCompra = it.CostoFinal,
                    costoPromedioUnd = 0.0m,
                    costoUnd = it.CostoFinal_Und,
                    decimalesPrd = it.Producto.decimales,
                    depositoCodigo = gestionDoc.Deposito.codigo,
                    depositoNombre = gestionDoc.Deposito.nombre,
                    detalle = "",
                    empaquePrd = it.ProductoEmpaqueDesc,
                    esAnulado = "0",
                    estatusUnidad = "0",
                    fechaLote = new DateTime(200, 01, 01).Date,
                    montoDescto1 = it.dsct_1_m,
                    montoDescto2 = it.dsct_2_m,
                    montoDescto3 = it.dsct_3_m,
                    montoImpuesto = it.impuesto,
                    montoTotal = it.total,
                    nombreProducto = it.Producto.descripcion,
                    signo = 1,
                    tipoDocumento = "01",
                    totalNeto = it.subTotal_2,
                    valorPorcDescto1 = it.dsct_1_p,
                    valorPorcDescto2 = it.dsct_2_p,
                    valorPorcDescto3 = it.dsct_3_p,
                    valorTasaIva = it.Producto.tasaIva,
                    estatusHabilitarCambioPrecioVenta = it.GetActualizarPrecio ? "1" : "0",
                };
                fichaDetalle.Add(detalle);
                var prdDep = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdDeposito()
                {
                    autoDep = gestionDoc.IdDeposito,
                    autoPrd = it.Producto.auto,
                    cantidadUnd = it.CantidadUnd,
                    nombrePrd = it.Producto.descripcion,
                };
                fichaPrdDeposito.Add(prdDep);
                var prdKardex = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdKardex()
                {
                    autoConcepto = conceptoCompra.auto,
                    autoDeposito = gestionDoc.Deposito.auto,
                    autoPrd = it.Producto.auto,
                    cantidadBonoFac = 0.0m,
                    cantidadFac = it.cantidad,
                    cantidadUnd = it.CantidadUnd,
                    cierreFtp = "",
                    codigoConcepto = conceptoCompra.codigo,
                    codigoDeposito = gestionDoc.Deposito.codigo,
                    codigoMovDoc = "01",
                    codigoSucursal = gestionDoc.Sucursal.codigo,
                    costoUnd = it.CostoFinal_Und,
                    documentoNro = gestionDoc.DocumentoNro,
                    entidad = gestionDoc.Proveedor.nombreRazonSocial,
                    esAnulado = "0",
                    modulo = "Compras",
                    montoTotal = it.TotalFinal,
                    nombreConcepto = conceptoCompra.nombre,
                    nombreDeposito = gestionDoc.Deposito.nombre,
                    nota = "",
                    precioUnd = 0.0m,
                    siglasMovDoc = "FAC",
                    signoDocumento = 1,
                    nombrePrd = it.Producto.descripcion,
                    factorCambio = gestionDoc.FactorDivisa,
                };
                fichaPrdKardex.Add(prdKardex);
                var prdCosto = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdCosto()
                {
                    autoPrd = it.Producto.auto,
                    cntUnd = it.CantidadUnd,
                    contenido = it.Producto.contenidoCompra,
                    costo = it.CostoFinal,
                    costoDivisa = it.CostoDivisaFinal,
                    costoUnd = it.CostoFinal_Und,
                    nombrePrd = it.Producto.descripcion,
                };
                fichaPrdCosto.Add(prdCosto);
                var prdCostoHistorico = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdCostoHistorico()
                {
                    autoPrd = it.Producto.auto,
                    costo = it.CostoFinal,
                    costoDivisa = it.CostoDivisaFinal,
                    documento = gestionDoc.DocumentoNro,
                    nota = "",
                    serie = "FAC",
                    tasaDivisa = gestionDoc.FactorDivisa,
                };
                fichaPrdCostoHistorico.Add(prdCostoHistorico);
                if (it.CodRefPrvActual=="")
                {
                    if (it.CodRefPrv != "") 
                    {
                        var prdProveedor = new OOB.LibCompra.Documento.Cargar.Factura.FichaPrdProveedor()
                        {
                            autoPrd = it.Producto.auto,
                            autoProveedor = gestionDoc.Proveedor.autoId,
                            codigoRefProveedor = it.CodRefPrv,
                        };
                        fichaPrdProveedor.Add(prdProveedor);
                    }
                }
            }

            var ficha = new OOB.LibCompra.Documento.Cargar.Factura.Ficha()
            {
                documento = fichaDoc,
                cxp = fichaCxP,
                detalles = fichaDetalle,
                prdDeposito = fichaPrdDeposito,
                prdKardex = fichaPrdKardex,
                prdCosto = fichaPrdCosto,
                prdCostosHistorico = fichaPrdCostoHistorico,
                prdProveedor = fichaPrdProveedor,
                prdPreciosMod = preciosMod,
                prdPreciosHistorico = historicoPrecio,
            };
            var r01 = Sistema.MyData.Compra_DocumentoAgregarFactura(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            Helpers.Msg.AgregarOk();
            Helpers.VisualizarDocumento.Visualizar(r01.Auto);

            return rt;
        }

        public void CargarItems()
        {
        }

        public void Totalizar()
        {
            if (!gestionDoc.IsAceptarOk)
            {
                Helpers.Msg.Error("Datos Del Documento Incorrectos !!!");
                return;
            }

            if (gestionItem.TItems == 0)
            {
                Helpers.Msg.Error("No Hay Items Que Procesar !!!");
                return;
            }

            if (gestionItem.TotalMonto == 0.0m)
            {
                Helpers.Msg.Error("Monto del Documento Incorrecto !!!");
                return;
            }

            gestionTotalizar.SetMonto(gestionItem.TotalMonto);
            gestionTotalizar.SetNotas(gestionDoc.Notas);
            gestionTotalizar.Inicia();
            if (gestionTotalizar.IsOk)
            {
                gestionItem.setDescuentoFinal(gestionTotalizar.Dscto);
                gestionItem.setCargoFinal(gestionTotalizar.Cargo);
                gestionDoc.setNotas(gestionTotalizar.Notas);
                Guardar();
            }
        }

        public void AdmDocumentos()
        {
            if (!gestionDoc.IsAceptarOk)
            {
                Helpers.Msg.Alerta("Debe Primero Hacer Click En Nuevo Documento");
                return;
            }

            var r00 = Sistema.MyData.Permiso_AdmDoc(Sistema.UsuarioP.autoGru);
            if (r00.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r00.Mensaje);
                return;
            }

            if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
            {
                _gestionAdmDoc.setGestion(new Administrador.Documentos.Gestion());
                _gestionAdmDoc.setActivarSeleccionItem(true);
                _gestionAdmDoc.Inicializa();
                _gestionAdmDoc.Inicia();

                if (_gestionAdmDoc.ItemSeleccionadoIsOk)
                {
                    if (_gestionAdmDoc.ItemSeleccionado != null)
                    {
                        if (gestionItem.TotalMonto != 0.0m || gestionItem.TItems != 0)
                        {
                            Helpers.Msg.Error("Para Importar Data de un Documento, no deben haber Items Cargados");
                            return;
                        }

                        if (_gestionAdmDoc.ItemSeleccionado.CodigoDoc!="01")
                        {
                            Helpers.Msg.Error("Tipo Documento Incorrecto Para Importar");
                            return;
                        }

                        var doc = _gestionAdmDoc.ItemSeleccionado.AutoDoc;
                        var rt = Sistema.MyData.Compra_Documento_ItemImportar_GetLista(doc);
                        if (rt.Result == OOB.Enumerados.EnumResult.isError)
                        {
                            Helpers.Msg.Error(rt.Mensaje);
                            return;
                        }

                        gestionItem.AgregarListaItem(rt.Lista, gestionDoc.IdProveedor, gestionDoc.FactorDivisa);
                    }
                }
            }
        }

        public void DejarPendiente()
        {
            if (!gestionDoc.IsAceptarOk)
            {
                Helpers.Msg.Error("Datos Del Documento Incorrectos !!!");
                return;
            }
            if (gestionItem.TItems == 0)
            {
                Helpers.Msg.Error("No Hay Items Que Procesar !!!");
                return;
            }
            if (gestionItem.TotalMonto == 0.0m)
            {
                Helpers.Msg.Error("Monto del Documento Incorrecto !!!");
                return;
            }

            var msg = MessageBox.Show("Dejar Documento En Pendiente ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes) 
            {
                if (CrearPendiente())
                {
                    _dejarPendienteIsOk = true;
                    gestionItem.Limpiar();
                    gestionDoc.Limpiar();

                    var filtro = new OOB.LibCompra.Documento.Pendiente.Filtro.Ficha()
                    {
                        docTipo = "01",
                        idUsuario = Sistema.UsuarioP.autoUsu,
                    };
                    var r01 = Sistema.MyData.Compra_Documento_Pendiente_Cnt(filtro);
                    if (r01.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r01.Mensaje);
                        return;
                    }
                    _cntPend = r01.Entidad;
                }
            }
        }

        private bool CrearPendiente()
        {
            var ficha = new OOB.LibCompra.Documento.Pendiente.Agregar.Ficha()
            {
                docFactorCambio = gestionDoc.FactorDivisa,
                docItemsNro = gestionItem.TItems,
                docMonto = gestionItem.TotalMonto,
                docMontoDivisa = gestionItem.MontoDivisa,
                docNombre = "COMPRAS",
                docTipo = "01",
                docControl = gestionDoc.ControlNro,
                docNumero = gestionDoc.DocumentoNro,
                entidadCiRif = gestionDoc.Proveedor.ciRif,
                entidadNombre = gestionDoc.Proveedor.nombreRazonSocial,
                usuarioId = Sistema.UsuarioP.autoUsu,
                usuarioNombre = Sistema.UsuarioP.nombreUsu,
                autoDeposito = gestionDoc.IdDeposito,
                autoSucursal = gestionDoc.IdSucursal,
                docDiasCredito = gestionDoc.DiasCredito,
                docFechaEmision = gestionDoc.FechaEmision,
                docNotas = gestionDoc.Notas,
                docOrdenCompra = gestionDoc.OrdenCompraNro,
                entidadAuto = gestionDoc.IdProveedor,
                entidadCodigo = gestionDoc.Proveedor.codigo,
                entidadDirFiscal = gestionDoc.DireccionProveedor,
            };
            var items = new List<OOB.LibCompra.Documento.Pendiente.Agregar.FichaDetalle>();
            foreach (dataItem it in gestionItem.Lista)
            {
                var item = new OOB.LibCompra.Documento.Pendiente.Agregar.FichaDetalle()
                {
                    categoria = it.Producto.categoria,
                    cntFactura = it.cantidad,
                    codRefProv = it.CodRefPrv,
                    contenidoEmp = it.Producto.contenidoCompra,
                    decimales = it.Producto.decimales,
                    dscto1p = it.dsct_1_p,
                    dscto2p = it.dsct_2_p,
                    dscto3p = it.dsct_3_p,
                    empaqueCompra = it.ProductoEmpaqueDesc,
                    prdAuto = it.Producto.auto,
                    prdAutoDepartamento = it.Producto.autoDepartamento,
                    prdAutoGrupo = it.Producto.autoGrupo,
                    prdAutoSubGrupo = it.Producto.autoSubGrupo,
                    prdAutoTasaIva = it.Producto.autoTasa,
                    prdCodigo = it.Producto.codigo,
                    prdNombre = it.Producto.descripcion,
                    precioFactura = it.costoMoneda,
                    tasaIva = it.Producto.tasaIva,
                    //
                    precioFacturaDivisa= it.costoDivisa,
                    prdCostoActualLocal= it.Producto.costo,
                    prdCostoActualDivisa = it.Producto.costoDivisa,
                    esAdmDivisa= it.Producto.AdmPorDivisa== OOB.LibCompra.Producto.Enumerados.EnumAdministradorPorDivisa.Si,
                };
                items.Add(item);
            }
            ficha.items = items;

            var r01 = Sistema.MyData.Compra_Documento_Pendiente_Agregar(ficha);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            return true;
        }

        public void AbrirPendiente()
        {
            if (gestionDoc.IsAceptarOk)
            {
                Helpers.Msg.Error("El Documento Debe Estar Totalmente Limpio");
                return;
            }
            if (gestionItem.TotalMonto != 0.0m || gestionItem.TItems != 0)
            {
                Helpers.Msg.Error("Para Abrir Un Documento Pendiente, no deben haber Items Cargados");
                return;
            }

            var filtro = new OOB.LibCompra.Documento.Pendiente.Filtro.Ficha()
            {
                docTipo = "01",
                idUsuario = Sistema.UsuarioP.autoUsu,
            };
            var r01 = Sistema.MyData.Compra_Documento_Pendiente_GetLista(filtro);
            if (r01.Result ==  OOB.Enumerados.EnumResult.isError )
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            if (r01.Lista.Count > 0) 
            {
                _gestionPend.Inicializa();
                _gestionPend.setLista(r01.Lista);
                _gestionPend.Inicia();
                if (_gestionPend.IsItemSeleccionadoOk) 
                {
                    var msg = MessageBox.Show("Abrir Este Documento Pendiente ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                    if (msg != DialogResult.Yes)
                    {
                        return;
                    }

                    var itemPend = _gestionPend.ItemSeleccionado;
                    var r02 = Sistema.MyData.Compra_Documento_Pendiente_Abrir_GetById(itemPend.id);
                    if (r02.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r02.Mensaje);
                        return;
                    }
                    var r03 = Sistema.MyData.Compra_Documento_Pendiente_Eliminar(itemPend.id);
                    if (r03.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r03.Mensaje);
                        return;
                    }
                    var r04 = Sistema.MyData.Compra_Documento_Pendiente_Cnt(filtro);
                    if (r04.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r04.Mensaje);
                        return;
                    }
                    _cntPend -= 1;

                    var doc = r02.Entidad;
                    var prv = new OOB.LibCompra.Proveedor.Data.Ficha(doc.entidadAuto, doc.entidadCiRif, doc.entidadNombre, doc.entidadDirFiscal , doc.entidadCodigo );
                    gestionDoc.Inicializa();
                    if (gestionDoc.CargarData())
                    {
                        gestionDoc.setProveedor(prv);
                        gestionDoc.setDocumentoNro(doc.docNumero);
                        gestionDoc.setControlNro(doc.docControl);
                        gestionDoc.setFechaEmision(doc.docFechaEmision);
                        gestionDoc.setDiasCredito(doc.docDiasCredito);
                        gestionDoc.setSucursal(doc.autoSucursal );
                        gestionDoc.setDeposito(doc.autoDeposito );
                        gestionDoc.setOrdenCompra(doc.docOrdenCompra);
                        gestionDoc.setNotas(doc.docNotas);
                        gestionDoc.setFactorCambio(doc.docFactorCambio);
                        gestionDoc.AceptarData();
                        gestionItem.AgregarListaItem(doc.items, gestionDoc.IdProveedor, gestionDoc.FactorDivisa);
                    }
                }
            }
        }


        private HlpGestion.HndCombo.IOpcion _gOpcBusqueda;
        public BindingSource GetOpcionBusquedaSource { get { return _gOpcBusqueda.Source; } }
        public string GetOpcionBusquedaId { get { return _gOpcBusqueda.GetId; } }
        public void setOpcBusqueda(string id)
        {
            _gOpcBusqueda.setFicha(id);
            switch (id) 
            {
                case "01":
                    gestionPrdBuscar.setMetodoBusqueda(Controlador.GestionProductoBuscar.metodoBusqueda.Codigo);
                    break;
                case "02":
                    gestionPrdBuscar.setMetodoBusqueda(Controlador.GestionProductoBuscar.metodoBusqueda.Nombre);
                    break;
                case "03":
                    gestionPrdBuscar.setMetodoBusqueda(Controlador.GestionProductoBuscar.metodoBusqueda.Referencia);
                    break;
                case "04":
                    gestionPrdBuscar.setMetodoBusqueda(Controlador.GestionProductoBuscar.metodoBusqueda.CodBarra);
                    break;
            }
        }

    }

}