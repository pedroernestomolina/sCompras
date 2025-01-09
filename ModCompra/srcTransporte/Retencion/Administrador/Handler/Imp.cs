using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Retencion.Administrador.Handler
{
    public class Imp: Vistas.IAdm
    {
        private bool _abandonarIsOK;
        private Vistas.IListaAdm _lista;
        private Vistas.IBusqDoc _busqDoc;
        private srcTransporte.Filtro.Vistas.IFiltro _ctrFiltro;
        private ModCompra.Anular.Gestion _anular;
        //
        public Utils.Componente.Administrador.Vistas.ILista data { get { return _lista; } }
        public Vistas.IBusqDoc BusqDoc { get { return _busqDoc; } }
        public string Get_TituloAdm { get { return "Administrador Documentos: RETENCIONES"; } }
        public int Get_CntItem { get { return _lista.Get_CntItem; } }
        //
        public Imp()
        {
            _abandonarIsOK = false;
            _lista = new HndLista();
            _busqDoc = new HndBusqDoc();
            _ctrFiltro = new Filtro.DocRetencion.Imp();
        }
        public void Inicializa()
        {
            _abandonarIsOK = false;
            _lista.Inicializa();
            _busqDoc.Inicializa();
            _ctrFiltro.Inicializa();
        }
        Vistas.Frm frm;
        public void Inicia()
        {
            if (cargarData()) 
            {
                if (frm == null) 
                {
                    frm = new Vistas.Frm();
                    frm.setControlador(this);
                }
                frm.ShowDialog();
            }
        }
        public void Buscar()
        {
            if (_ctrFiltro.HndFiltro.VerificarFiltros())
            {
                _busqDoc.setFiltros(_ctrFiltro.HndFiltro.Get_Filtros);
                var r01 = _busqDoc.Buscar();
                if (r01 != null)
                {
                    var lst = new List<Vistas.IdataItem>();
                    foreach (var rg in r01)
                    {
                        var nr = new dataItem((OOB.LibCompra.Transporte.DocumentoRet.ListaAdm.Ficha)rg);
                        lst.Add(nr);
                    }
                    _lista.setDataCargar(lst);
                }
            }
        }
        public void AnularItem()
        {
            if (_lista.ItemActual != null)
            {
                var it = (dataItem)_lista.ItemActual;
                if (it.isAnulado)
                {
                    return;
                }
                _anular = new ModCompra.Anular.Gestion();
                _anular.Inicia();
                if (!_anular.IsAnularOK)
                {
                    return;
                }
                try
                {
                    var rt = Sistema.MyData.Transporte_DocumentoRet_Crud_Anular_ObtenerData(it.Ficha.auto);
                    var _auditorias = new List<OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.Procesar.Auditoria>();
                    var audPorCompra = new OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.Procesar.Auditoria()
                    {
                        autoDoc = it.Ficha.auto,
                        autoSistemaDocumento = rt.Entidad.idSistemaDoc_CompraRet,
                        autoUsuario = Sistema.UsuarioP.autoUsu,
                        codigoUsuario = Sistema.UsuarioP.codigoUsu,
                        estacion = Sistema.EquipoEstacion,
                        ip = "",
                        motivo = _anular.Motivo,
                        nombreUsuario = Sistema.UsuarioP.nombreUsu,
                    };
                    _auditorias.Add(audPorCompra);
                    var ent = rt.Entidad;
                    var _isRetIva = ent.tipoRetencion.Trim().ToUpper() == "07";
                    var fichaOOB = new OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.Procesar.Ficha()
                    {
                        auditorias = _auditorias,
                        proveedor = new OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.Procesar.Proveedor()
                        {
                            idProv = ent.idProveedor,
                            montoRestaurarMonDiv = ent.montoRetMonDiv,
                        },
                        compraRet = new OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.Procesar.CompraRetencion()
                        {
                            idDocCompra = it.Ficha.autoDocRef,
                            idDocCompraRet = it.Ficha.auto,
                            isRetIva = _isRetIva,
                        },
                        cxpDocOrigen = new OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.Procesar.CxP_DocOrigen()
                        {
                            idDoc = ent.idCxP_Origen,
                            montoRestaurarMonAct = ent.montoRetMonAct,
                            montoRestaurarMonDiv = ent.montoRetMonDiv,
                        },
                        cxpIR = new OOB.LibCompra.Transporte.DocumentoRet.Crud.Anular.Procesar.CxP_IR()
                        {
                            idDocIR = ent.idCxp_IR,
                            idRecibo = ent.idCxp_IR_Recibo,
                        }
                    };
                    var rt_02 = Sistema.MyData.Transporte_DocumentoRet_Crud_Anular_Procesar(fichaOOB);
                    Helpers.Msg.EliminarOk();
                    it.setActualizarEstatusAnulado();
                    _lista.Refresca();
                }
                catch (Exception e) 
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        public void VisualizarDocumento()
        {
            if (_lista.ItemActual != null)
            {
                var it = (dataItem)_lista.ItemActual;
                visualizarItem(it);
                _lista.Refresca();
            }
        }
        public void Imprimir()
        {
            if (_lista.Get_CntItem > 0) 
            {
                imprimirItems();
            }
        }
        public void CorrectorDoucmento()
        {
            if (_lista.ItemActual != null)
            {
                var it = (dataItem)_lista.ItemActual;
                corregirItem(it);
                //_lista.Refresca();
            }
        }


        public bool AbandonarIsOK { get { return _abandonarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonarIsOK = Helpers.Msg.Abandonar();
        }


        private bool cargarData()
        {
            try
            {
                var r01 = Sistema.MyData.FechaServidor();
                var _ano = r01.Entidad.Year;
                var _mes = r01.Entidad.Month;
                var _dia = DateTime.DaysInMonth(_ano, _mes);
                _ctrFiltro.HndFiltro.setDesde(new DateTime(_ano, _mes, 01));
                _ctrFiltro.HndFiltro.setHasta(new DateTime(_ano, _mes, _dia));
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void visualizarItem(dataItem it)
        {
            if (it != null) 
            {
                if (it.Ficha.tipoRetCod == "07") 
                {
                    PlanillaRetIva(it.Ficha.autoDocRef);
                }
                else
                {
                    PlanillaRetIslr(it.Ficha.autoDocRef);
                }
            }
        }
        private void imprimirItems()
        {
            srcTransporte.Reportes.IRepListAdm _rep = new srcTransporte.Reportes.ListaAdm.DocumentoRet.Imp();
            _rep.setFiltrosBusq("");
            _rep.setDataCargar(_lista.Get_Items);
            _rep.Generar();
        }
        private Corrector.Vista.IVista _corrector;
        private void corregirItem(dataItem it)
        {
            if (it != null)
            {
                if (it.Ficha.tipoRetCod != "08") { return; }
                if (_corrector ==null)
                {
                    _corrector= new Corrector.Handler.ImpVista();
                }
                _corrector.Inicializa();
                _corrector.setIdDocumento(it.Ficha.autoDocRef);
                _corrector.Inicia();
            }
        }


        public void PlanillaRetIva(string autoDoc)
        {
            srcTransporte.Reportes.IRepPlanilla _rep = new srcTransporte.Reportes.Planillas.RetIva.Imp();
            _rep.setIdDoc(autoDoc);
            _rep.Generar();
        }
        public void PlanillaRetIslr(string autoDoc)
        {
            srcTransporte.Reportes.IRepPlanilla _rep = new srcTransporte.Reportes.Planillas.RetISLR.Imp();
            _rep.setIdDoc(autoDoc);
            _rep.Generar();
        }

        //
        //
        public DateTime Get_Desde { get { return _ctrFiltro.HndFiltro.Get_Desde; } }
        public DateTime Get_Hasta { get { return _ctrFiltro.HndFiltro.Get_Hasta; } }
        public bool Get_IsActivoDesde { get { return _ctrFiltro.HndFiltro.Get_IsActivoDesde; } }
        public bool Get_IsActivoHasta { get { return _ctrFiltro.HndFiltro.Get_IsActivoDesde; } }
        public void setDesde(DateTime fecha)
        {
            _ctrFiltro.HndFiltro.setDesde(fecha);
        }
        public void setHasta(DateTime fecha)
        {
            _ctrFiltro.HndFiltro.setHasta(fecha);
        }
        public void ActivarDesde(bool modo)
        {
            _ctrFiltro.HndFiltro.ActivarDesde(modo);
        }
        public void ActivarHasta(bool modo)
        {
            _ctrFiltro.HndFiltro.ActivarHasta(modo);
        }

        public void FitrosBusqueda()
        {
            _ctrFiltro.Inicia();
        }
        public void FiltrosLimpiar()
        {
            _ctrFiltro.Limpiar();
        }
    }
}