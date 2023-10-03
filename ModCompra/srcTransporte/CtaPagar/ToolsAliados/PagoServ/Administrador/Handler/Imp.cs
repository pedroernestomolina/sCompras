﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Administrador.Handler
{
    public class Imp: Vistas.IAdmPagoServ
    {
        private bool _abandonarIsOK;
        private Vistas.IListaPagoServ _lista;
        private Vistas.IBusqDocPagoServ _busqDoc;
        private Vistas.IFiltroPagoServ _filtro;


        public Utils.Componente.Administrador.Vistas.ILista data { get { return _lista; } }
        public Vistas.IBusqDocPagoServ BusqDoc { get { return _busqDoc; } }
        public Utils.Componente.Administrador.Vistas.IFiltro filtros { get { return _filtro; } }
        public string Get_TituloAdm { get { return "Administrador Documentos: PAGOS/SERV"; } }
        public int Get_CntItem { get { return _lista.Get_CntItem; } }
        

        public Imp()
        {
            _abandonarIsOK = false;
            _lista = new HndLista();
            _busqDoc = new HndBusqDoc();
            _filtro = new HndFiltro();
        }
        public void Inicializa()
        {
            _abandonarIsOK = false;
            _lista.Inicializa();
            _busqDoc.Inicializa();
            _filtro.Inicializa();
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
            if (_filtro.VerificarFiltros())
            {
                _busqDoc.setFiltros(_filtro.Get_Filtros);
                var r01 = _busqDoc.Buscar();
                if (r01 != null)
                {
                    var lst = new List<Vistas.IdataItem>();
                    foreach (var rg in r01)
                    {
                        var nr = new dataItem((OOB.LibCompra.Transporte.Aliado.PagoServ.Lista.Ficha)rg);
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
                    Helpers.Msg.Alerta("ITEM YA SE ENCUENTRA ANULADO");
                    return;
                }
                anulaItem(it);
                _lista.Refresca();
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
                _filtro.setDesde(new DateTime(_ano, _mes, 01));
                _filtro.setHasta(new DateTime(_ano, _mes, _dia));
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
        private void anulaItem(dataItem it)
        {
            var seg= Helpers.Msg.Procesar("Anular Movimiento de Pago ?");
            if (seg)
            {
                try
                {
                    var r01 = Sistema.MyData.Transporte_Aliado_PagoServ_AnularPago(it.idMov);
                    it.setEstatusAnulado();
                    Helpers.Msg.EliminarOk();
                }
                catch (Exception e)
                {
                    Helpers.Msg.Error(e.Message);
                }
            }
        }
        private void visualizarItem(dataItem it)
        {
            srcTransporte.Reportes.IRepPlanilla _rep = new srcTransporte.Reportes.CXP.Planillas.PagoServ.Imp();
            _rep.setIdDoc(it.idMov.ToString().Trim());
            _rep.Generar();
        }
        private void imprimirItems()
        {
            srcTransporte.Reportes.IRepListAdm _rep = new srcTransporte.Reportes.ListaAdm.PagoServ.Imp();
            _rep.setFiltrosBusq("");
            _rep.setDataCargar(_lista.Get_Items);
            _rep.Generar();
        }


        public void LimpiarFiltros()
        {
            throw new NotImplementedException();
        }
    }
}