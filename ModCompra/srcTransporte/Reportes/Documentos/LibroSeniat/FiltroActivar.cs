using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.srcTransporte.Reportes.Documentos.LibroSeniat
{
    public class FiltroActivar: Reportes.RepFiltro.Vista.IFiltroActivar
    {
        private bool _estatus;
        private bool _aliado;


        public bool Estatus { get { return _estatus; } }
        public bool Aliado { get { return _aliado; } }


        public FiltroActivar()
        {
            _estatus = false;
            _aliado = false;
        }
    }
}