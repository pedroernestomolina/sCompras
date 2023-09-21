using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.CtaPagar.ToolsAliados.PagoServ.Handlers
{
    public class Imp: Vistas.IPagServ
    {
        private bool _abandonarIsOK;
        private bool _procesarIsOK;
        private int _idAliado;
        private Vistas.IEnt _data;


        public Vistas.IEnt data { get { return _data; } }


        public Imp()
        {
            _idAliado = -1;
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _data = new hndEnt();
        }
        public void Inicializa()
        {
            _idAliado = -1;
            _abandonarIsOK = false;
            _procesarIsOK = false;
            _data.Inicializa();
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

            } frm.ShowDialog();
        }


        public void setServiciosAliado(int idAliado)
        {
            _idAliado = idAliado;
        }


        public bool AbandonarIsOK { get { return _abandonarIsOK; } }
        public void AbandonarFicha()
        {
            _abandonarIsOK = Helpers.Msg.Abandonar();
        }
        public bool ProcesarIsOK { get { return _procesarIsOK; } }
        public void Procesar()
        {
            _procesarIsOK = false;
            if (_data.GestPago.IsOk()) 
            {
                if (Helpers.Msg.Procesar())
                {
                }
            }
        }


        private bool cargarData()
        {
            try
            {
                var r01 = Sistema.MyData.Transporte_Aliado_GetFichaById(_idAliado);
                _data.setAliado(r01.Entidad);
                var r02 = Sistema.MyData.Transporte_Aliado_PagoServ_ServPrestado_GetListaBy(_idAliado);
                _data.setServicios(r02.Lista.OrderBy(o=>o.idAliadoServ).ToList());
                var r03 = Sistema.MyData.Configuracion_TasaCambioActual();
                _data.setTasaCambio(r03.Entidad);
                if (r03.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(r03.Mensaje);
                }
                var r04 = Sistema.MyData.FechaServidor();
                _data.setFechaServidor(r04.Entidad);
                if (r04.Result == OOB.Enumerados.EnumResult.isError) 
                {
                    throw new Exception(r04.Mensaje);
                }
                //
                _data.CargarData();
                var _lst = new List<Anticipos.Agregar.Vistas.IdataCaja>();
                if ((r01.Entidad.AnticiposDiv - r01.Entidad.AnticipoRetDiv) > 0m) 
                {
                    var _caja = new OOB.LibCompra.Transporte.Caja.Lista.Ficha()
                    {
                        descripcion = "ANTICIPOS ($)",
                        esDivisa = "1",
                        estatusAnulado = "",
                        id = -1,
                        montoPorAnulaciones = 0m,
                        montoPorEgresos = 0m,
                        montoPorIngresos = (r01.Entidad.AnticiposDiv - r01.Entidad.AnticipoRetDiv),
                        saldoInicial = 0m,
                    };
                    _lst.Add(new Anticipos.Agregar.Handler.dataCaja(_caja));
                }
                if (r01.Entidad.AnticipoRetDiv > 0m)
                {
                    var _caja = new OOB.LibCompra.Transporte.Caja.Lista.Ficha()
                    {
                        descripcion = "RET/ANTICIPOS ($)",
                        esDivisa = "1",
                        estatusAnulado = "",
                        id = -2,
                        montoPorAnulaciones = 0m,
                        montoPorEgresos = 0m,
                        montoPorIngresos = r01.Entidad.AnticipoRetDiv,
                        saldoInicial = 0m,
                    };
                    _lst.Add(new Anticipos.Agregar.Handler.dataCaja(_caja));
                }
                var r05 = Sistema.MyData.Transporte_Caja_GetLista();
                foreach (var rg in r05.Lista.OrderBy(o => o.descripcion).ToList())
                {
                    var nr = new Anticipos.Agregar.Handler.dataCaja(rg);
                    _lst.Add(nr);
                }
                _data.GestPago.hndCaja.setDataCargar(_lst);
                return true;
            }
            catch (Exception e)
            {
                Helpers.Msg.Error(e.Message);
                return false;
            }
        }
    }
}