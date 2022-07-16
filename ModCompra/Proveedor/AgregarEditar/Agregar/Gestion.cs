using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Proveedor.AgregarEditar.Agregar
{
    
    public class Gestion: IGestion
    {

        private data _data;
        private BindingSource _bsEstado;
        private BindingSource _bsGrupo;
        private BindingSource _bsDenFiscal;
        private List<OOB.LibCompra.Maestros.Grupo.Ficha> _lstGrupo;
        private List<OOB.LibCompra.Maestros.Estado.Ficha> _lstEstado;
        private List<OOB.LibCompra.Maestros.DenFiscal.Ficha> _lstDenFiscal;
        private bool _salidaIsOk;
        private bool _procesarIsOk;
        private string _autoProved; 


        public string TituloFicha { get { return "Agregar Ficha"; } }
        public string GetRif { get { return _data.CiRif; } }
        public string GetCodigo { get { return _data.Codigo; } }
        public string GetRazonSocial { get { return _data.RazonSocial; } }
        public string GetDirFiscal { get { return _data.DirFiscal; } }
        public string GetPais { get { return _data.Pais; } }
        public string GetCodigoPostal { get { return _data.CodigoPostal; } }
        public string GetTelefono { get { return _data.Telefono; } }
        public string GetEmail { get { return _data.Email; } }
        public string GetWebSite { get { return _data.WebSite; } }
        public string GetPersona { get { return _data.Persona; } }
        public string GetGrupo { get { return _data.Grupo; } }
        public string GetEstado{ get { return _data.Estado; } }
        public string GetDenFiscal { get { return _data.DenFiscal; } }
        public decimal GetTasaRetIva { get { return _data.TasaRetIva; } }
        public bool salidaIsOk { get { return _salidaIsOk; } }
        public bool procesarIsOk { get { return _procesarIsOk; } }
        public string autoProvRegistrado { get { return _autoProved; } }

        
        public System.Windows.Forms.BindingSource SourceGrupo { get { return _bsGrupo; } }
        public System.Windows.Forms.BindingSource SourEstado { get { return _bsEstado; } }
        public System.Windows.Forms.BindingSource SourceDenFiscal { get { return _bsDenFiscal; } }


        public Gestion()
        {
            _autoProved = "";
            _salidaIsOk = false;
            _procesarIsOk = false;
            _data = new data();
            _lstGrupo = new List<OOB.LibCompra.Maestros.Grupo.Ficha>();
            _lstEstado = new List<OOB.LibCompra.Maestros.Estado.Ficha>();
            _lstDenFiscal = new List<OOB.LibCompra.Maestros.DenFiscal.Ficha>();
            _bsGrupo = new BindingSource();
            _bsEstado = new BindingSource();
            _bsDenFiscal = new BindingSource();
            _bsGrupo.DataSource = _lstGrupo;
            _bsEstado.DataSource = _lstEstado;
            _bsDenFiscal.DataSource = _lstDenFiscal;
        }


        public bool CargarData()
        {
            var rt = true;

            var r01 = Sistema.MyData.Grupo_GetLista();
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }

            var r02 = Sistema.MyData.Estado_GetLista ();
            if (r02.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r02.Mensaje);
                return false;
            }

            _lstGrupo.Clear();
            _lstGrupo.AddRange(r01.Lista);
            _bsGrupo.CurrencyManager.Refresh();

            _lstEstado.Clear();
            _lstEstado.AddRange(r02.Lista);
            _bsEstado.CurrencyManager.Refresh();

            _lstDenFiscal.Clear();
            _lstDenFiscal.Add(new OOB.LibCompra.Maestros.DenFiscal.Ficha() { auto = "0000000001", nombre = "Contribuyente" });
            _lstDenFiscal.Add(new OOB.LibCompra.Maestros.DenFiscal.Ficha() { auto = "0000000002", nombre = "No Contribuyente" });
            _bsDenFiscal.CurrencyManager.Refresh();

            return rt;
        }

        public void setCiRif(string p)
        {
            _data.setCirRif(p);
        }

        public void setCodigo(string p)
        {
            _data.setCodigo(p);
        }

        public void setRazonSocial(string p)
        {
            _data.setRazonSocial(p);
        }

        public void setDirFiscal(string p)
        {
            _data.setDirFiscal(p);
        }

        public void setCodigoPostal(string p)
        {
            _data.setCodigoPostal(p);
        }

        public void setPersona(string p)
        {
            _data.setPersona(p);
        }

        public void setTelefono(string p)
        {
            _data.setTelefono(p);
        }

        public void setEmail(string p)
        {
            _data.setEmail(p);
        }

        public void setWebSite(string p)
        {
            _data.setWebSite(p);
        }

        public void setPais(string p)
        {
            _data.setPais(p);
        }

        public void setGrupo(string p)
        {
            _data.setGrupo(_lstGrupo.FirstOrDefault(f => f.auto == p));
        }

        public void setEstado(string p)
        {
            _data.setEstado(_lstEstado.FirstOrDefault(f => f.auto == p));
        }

        public void setDenFiscal(string p)
        {
            _data.setDenFiscal(_lstDenFiscal.FirstOrDefault(f => f.auto == p));
        }

        public void setTasaRetIva(decimal p)
        {
            _data.setTasaRetIva(p);
        }

        public void Procesar()
        {
            _procesarIsOk = false;
            _salidaIsOk = false;
            if (_data.IsOk()) 
            {
                var msg = MessageBox.Show("Guardar Ficha ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    if (GuardarFicha()) 
                    {
                        _procesarIsOk = true;
                        _salidaIsOk = true;
                    }
                }
            }
        }

        private bool GuardarFicha()
        {
            var rt = true;

            var dataOOB = new OOB.LibCompra.Proveedor.Agregar.Ficha()
            {
                ciRif = _data.CiRif,
                codigo = _data.Codigo,
                codPostal = _data.CodigoPostal,
                contacto = _data.Persona,
                denFiscal = _data.DenFiscalDescripcion,
                dirFiscal = _data.DirFiscal,
                email = _data.Email,
                estatus = "Activo",
                idEstado = _data.Estado,
                idGrupo = _data.Grupo,
                pais = _data.Pais,
                razonSocial = _data.RazonSocial,
                retIva = _data.TasaRetIva,
                telefono = _data.Telefono,
                webSite = _data.WebSite,
            };
            var r01 = Sistema.MyData.Proveedor_AgregarFicha(dataOOB);
            if (r01.Result == OOB.Enumerados.EnumResult.isError) 
            {
                Helpers.Msg.Error(r01.Mensaje);
                return false;
            }
            _autoProved = r01.Auto;

            return rt;
        }

        public void Salir()
        {
            _salidaIsOk = false;
            var msg = MessageBox.Show("Abandonar Ficha Registro ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
            if (msg == DialogResult.Yes)
            {
                _salidaIsOk = true;
            }
        }

        public void Inicializar()
        {
            _data.Limpiar();
            _salidaIsOk = false;
            _procesarIsOk = false;
            _autoProved = "";
        }

        public void setFichaEditar(string id)
        {
        }

    }

}