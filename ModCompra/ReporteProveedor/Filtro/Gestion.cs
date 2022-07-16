using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.ReporteProveedor.Filtro
{
    
    public class Gestion
    {

        private IFiltro _filtro;
        private data _data;
        private bool _isOk;
        private bool _procesarIsOk;
        //
        private List<general> _lGrupo;
        private List<general> _lEstado;
        private List<general> _lEstatus;
        //
        private BindingSource _bsGrupo;
        private BindingSource _bsEstado;
        private BindingSource _bsEstatus;


        //source
        public BindingSource SourceGrupo { get { return _bsGrupo; } }
        public BindingSource SourceEstado { get { return _bsEstado; } }
        public BindingSource SourceEstatus { get { return _bsEstatus; } }

        //
        public bool ActivarGrupo { get { return _filtro.ActivarGrupo; } }
        public bool ActivarEstado { get { return _filtro.ActivarEstado; } }
        public bool ActivarEstatus { get { return _filtro.ActivarEstatus; } }
        //
        public bool IsOk { get { return _isOk; } }
        public data Data { get { return _data; } }
        public bool ProcesarIsOk { get { return _procesarIsOk; } }


        public Gestion()
        {
            _data = new data();
            _lGrupo = new List<general>();
            _lEstado = new List<general>();
            _lEstatus = new List<general>();
            //
            _bsGrupo = new BindingSource();
            _bsEstado = new BindingSource();
            _bsEstatus = new BindingSource();
            //
            _bsGrupo.DataSource = _lGrupo;
            _bsEstado.DataSource = _lEstado;
            _bsEstatus.DataSource = _lEstatus;
        }


        public void Inicializa()
        {
            _isOk = false;
            _procesarIsOk = false;
            _data.Inicializa();
        }

        public bool CargarData()
        {
            var rt = true;

            var rt1 = Sistema.MyData.Grupo_GetLista();
            if (rt1.Result ==  OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(rt1.Mensaje);
                return false;
            }
            _lGrupo.Clear();
            foreach (var it in rt1.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lGrupo.Add(new general(it.auto, it.nombre));
            }
            _bsGrupo.CurrencyManager.Refresh();

            var rt3 = Sistema.MyData.Estado_GetLista();
            if (rt3.Result ==  OOB.Enumerados.EnumResult.isError )
            {
                Helpers.Msg.Error(rt3.Mensaje);
                return false;
            }
            _lEstado.Clear();
            foreach (var it in rt3.Lista.OrderBy(o => o.nombre).ToList())
            {
                _lEstado.Add(new general(it.auto, it.nombre));
            }
            _bsEstado.CurrencyManager.Refresh();

            _lEstatus.Clear();
            _lEstatus.Add(new general("01", "Activo"));
            _lEstatus.Add(new general("02", "Inactivo"));
            _bsEstatus.CurrencyManager.Refresh();

            return rt;
        }

        FiltroFrm frm;
        public void Inicia()
        {
            if (frm == null) 
            {
                frm = new FiltroFrm();
                frm.setControlador(this);
            }
            frm.ShowDialog();
        }

        public void setFiltros(IFiltro filtro)
        {
            _filtro = filtro;
        }

        public void Filtrar()
        {
            _isOk = false;
            _procesarIsOk = false;
            if (_data.IsOk())
            {
                _isOk = true;
                _procesarIsOk = true;
            }
        }

        public void Salir()
        {
            _isOk = true;
        }

        public void setGrupo(string p)
        {
            _data.setGrupo(_lGrupo.FirstOrDefault(f=>f.Id==p));
        }

        public void setEstado(string p)
        {
            _data.setEstado(_lEstado.FirstOrDefault(f => f.Id == p));
        }

        public void setEstatus(string p)
        {
            _data.setEstatus(_lEstatus.FirstOrDefault(f => f.Id == p));
        }

    }

}