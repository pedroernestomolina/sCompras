using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.AgregarEditar
{
    
    public class Gestion
    {


        private IGestion _gestion;


        public string TituloFicha { get { return _gestion.TituloFicha; } }
        public string GetRif { get { return _gestion.GetRif; } }
        public string GetCodigo { get { return _gestion.GetCodigo; } }
        public string GetRazonSocial { get { return _gestion.GetRazonSocial; } }
        public string GetDirFiscal { get { return _gestion.GetDirFiscal; } }
        public string GetPais { get { return _gestion.GetPais; } }
        public string GetCodigoPostal { get { return _gestion.GetCodigoPostal; } }
        public string GetTelefono { get { return _gestion.GetTelefono; } }
        public string GetEmail { get { return _gestion.GetEmail; } }
        public string GetWebSite { get { return _gestion.GetWebSite; } }
        public string GetPersona { get { return _gestion.GetPersona; } }
        public string GetGrupo { get { return _gestion.GetGrupo; } }
        public string GetEstado { get { return _gestion.GetEstado; } }
        public string GetDenFiscal { get { return _gestion.GetDenFiscal; } }
        public decimal GetTasaRetIva { get { return _gestion.GetTasaRetIva; } }
        public bool salirIsOk { get { return _gestion.salidaIsOk; } }
        public bool AgregarIsOk { get { return _gestion.procesarIsOk; } }
        public string autoProvRegistrado { get {return  _gestion.autoProvRegistrado; } }
        public bool EditarIsOk { get { return _gestion.procesarIsOk; } }


        public BindingSource SourceGrupo { get { return _gestion.SourceGrupo; } }
        public BindingSource SourceEstado { get { return _gestion.SourEstado; } }
        public BindingSource SourceDenFiscal { get { return _gestion.SourceDenFiscal; } }


        public Gestion()
        {
        }


        private AgregarEditarFrm frm;
        public void Inicia() 
        {
            if (_gestion.CargarData()) 
            {
                if (frm == null) 
                {
                    frm = new AgregarEditarFrm();
                    frm.setContolador(this);
                }
                frm.ShowDialog();
            }
        }


        public void setGestion(IGestion gestion)
        {
            _gestion = gestion;
        }

        public void Inicializar()
        {
            _gestion.Inicializar();
        }


        public void setCiRif(string p)
        {
            _gestion.setCiRif(p);
        }

        public void setCodigo(string p)
        {
            _gestion.setCodigo(p);
        }

        public void setRazonSocial(string p)
        {
            _gestion.setRazonSocial(p);
        }

        public void setDirFiscal(string p)
        {
            _gestion.setDirFiscal(p);
        }

        public void setPais (string p)
        {
            _gestion.setPais(p);
        }

        public void setCodigoPostal(string p)
        {
            _gestion.setCodigoPostal(p);
        }

        public void setPersona(string p)
        {
            _gestion.setPersona(p);
        }

        public void setTelefono (string p)
        {
            _gestion.setTelefono(p);
        }

        public void setEmail(string p)
        {
            _gestion.setEmail(p);
        }

        public void setWebSite(string p)
        {
            _gestion.setWebSite(p);
        }

        public void setGrupo(string p)
        {
            _gestion.setGrupo(p);
        }

        public void setEstado(string p)
        {
            _gestion.setEstado(p);
        }

        public void setDenFiscal(string p)
        {
            _gestion.setDenFiscal(p);
        }

        public void setTasaRetIva(decimal p)
        {
            _gestion.setTasaRetIva(p);
        }

        public void Procesar()
        {
            _gestion.Procesar();
            if (_gestion.procesarIsOk) 
            {
                frm.Cerrar();
            }
        }

        public void Salir()
        {
            _gestion.Salir();
            if (_gestion.salidaIsOk)
                frm.Cerrar();
        }

        public void setFichaEditar(string id)
        {
            _gestion.setFichaEditar(id);
        }

    }

}