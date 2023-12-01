using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModCompra.Proveedor.AgregarEditar
{
    
    public interface IGestion
    {

        string TituloFicha { get; }
        string GetRif { get; }
        string GetCodigo { get; }
        string GetRazonSocial { get; }
        string GetDirFiscal { get; }
        string GetPais { get; }
        string GetCodigoPostal { get; }
        string GetTelefono { get; }
        string GetEmail { get; }
        string GetWebSite { get; }
        string GetPersona { get; }
        string GetGrupo { get; }
        string GetDenFiscal { get; }
        string GetEstado { get; }
        string GetCodigoXmlIslr { get; }
        string GetDescXmlIslr { get; }
        System.Windows.Forms.BindingSource SourceGrupo { get; }
        System.Windows.Forms.BindingSource SourEstado { get; }
        System.Windows.Forms.BindingSource SourceDenFiscal { get; }
        decimal GetTasaRetIva { get; }
        bool salidaIsOk { get; }
        bool procesarIsOk { get; }
        string autoProvRegistrado { get; }


        bool CargarData();
        void setCiRif(string p);
        void setCodigo(string p);
        void setRazonSocial(string p);
        void setDirFiscal(string p);
        void setPais(string p);
        void setCodigoPostal(string p);
        void setPersona(string p);
        void setTelefono(string p);
        void setEmail(string p);
        void setWebSite(string p);
        void setGrupo(string p);
        void setEstado(string p);
        void setDenFiscal(string p);
        void setTasaRetIva(decimal p);
        void setCodXmlIslr(string p);
        void setDescXmlIslr(string p);

        void Procesar();
        void Salir();
        void Inicializar();
        void setFichaEditar(string id);
    }
}