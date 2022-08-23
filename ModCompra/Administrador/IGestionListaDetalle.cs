using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Administrador
{
    
    public interface IGestionListaDetalle
    {

        BindingSource ItemsSource { get; }
        string ItemsEncontrados { get; }
        int GetCntItems { get; }
        Documentos.data ItemActual { get; }
        List<Documentos.data> GetItems { get; }


        void AnularItem();
        void LimpiarData();
        void setGestionAnular(Anular.Gestion _gestionAnular);
        void VisualizarDocumento();
        void setLista(List<OOB.LibCompra.Documento.Lista.Ficha> list);
        void CorrectorDocumento();
        void Inicializa();

    }

}