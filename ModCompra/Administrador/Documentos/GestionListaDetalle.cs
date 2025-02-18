using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ModCompra.Administrador.Documentos
{

    public class GestionListaDetalle : IGestionListaDetalle
    {

        private List<data> list;
        private BindingSource bs;
        private BindingList<data> bl;
        private Anular.Gestion _anular;
        private Corrector.Documento.Gestion _corrector;


        public BindingSource ItemsSource { get { return bs; } }
        public string ItemsEncontrados { get { return string.Format("Items Encontrados: {0}", bs.Count); } }
        public data Item { get; set; }
        public data ItemActual
        {
            get { return Item; }
        }


        public GestionListaDetalle()
        {
            list = new List<data>();
            bl = new BindingList<data>(list);
            bs = new BindingSource();
            bs.CurrentChanged += bs_CurrentChanged;
            bs.DataSource = bl;
            _corrector = new Corrector.Documento.Gestion();
        }

        private void bs_CurrentChanged(object sender, EventArgs e)
        {
            if (bs.Current != null)
                Item = (data)bs.Current;
        }

        public void LimpiarData()
        {
            if (bl.Count > 0)
            {
                var msg = MessageBox.Show("Desechar Vista Actual ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (msg == DialogResult.Yes)
                {
                    bl.Clear();
                    bs.CurrencyManager.Refresh();
                }
            }
        }

        public void AnularItem()
        {
            if (Item != null)
            {
                if (!Item.IsAnulado)
                {
                    var r00 = Sistema.MyData.Permiso_AdmDoc_Anular(Sistema.UsuarioP.autoGru);
                    if (r00.Result == OOB.Enumerados.EnumResult.isError)
                    {
                        Helpers.Msg.Error(r00.Mensaje);
                        return;
                    }
                    if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                    {
                        _anular.Inicia();
                        if (_anular.IsAnularOK)
                        {
                            var msg = MessageBox.Show("Anular Movimiento Actual ?", "*** ALERTA ***", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                            if (msg == DialogResult.Yes)
                            {
                                switch (Item.Ficha.tipoDoc)
                                {
                                    case OOB.LibCompra.Documento.Enumerados.enumTipoDocumento.Factura:
                                    case OOB.LibCompra.Documento.Enumerados.enumTipoDocumento.NotaEntrega:
                                        AnularFactura();
                                        break;
                                    case OOB.LibCompra.Documento.Enumerados.enumTipoDocumento.NotaDebito:
                                        AnularNotaDebito();
                                        break;
                                    case OOB.LibCompra.Documento.Enumerados.enumTipoDocumento.NotaCredito:
                                        AnularNotaCredito();
                                        break;
                                }
                            }
                        }
                    }
                }
                else
                    Helpers.Msg.Error("Documento Ya Está Anulado, Verifique Por Favor");
            }
        }

        private void AnularNotaCredito()
        {
            var r01 = Sistema.Fabrica.AnularDocCompra_NotaCredito(Item.AutoDoc, _anular.Motivo);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            //var ficha = new OOB.LibCompra.Documento.Anular.NotaCredito.Ficha()
            //{
            //    autoDocumento = Item.AutoDoc,
            //    codigoDocumento = Item.Ficha.codigoTipo,
            //    autoSistemaDocumento = "0000000019",
            //    autoUsuario = Sistema.UsuarioP.autoUsu,
            //    codigoUsuario = Sistema.UsuarioP.codigoUsu,
            //    estacion = Environment.MachineName,
            //    motivo = _anular.Motivo,
            //    nombreUsuario = Sistema.UsuarioP.nombreUsu,
            //};
            //var r01 = Sistema.MyData.Compra_DocumentoAnularNotaCredito(ficha);
            //if (r01.Result == OOB.Enumerados.EnumResult.isError)
            //{
            //    Helpers.Msg.Error(r01.Mensaje);
            //    return;
            //}
            Item.Ficha.esAnulado = true;
            bs.CurrencyManager.Refresh();
            Helpers.Msg.EliminarOk();
        }

        private void AnularFactura()
        {
            var r01 = Sistema.Fabrica.AnularDocCompra_Factura(Item.AutoDoc, _anular.Motivo);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Item.Ficha.esAnulado = true;
            bs.CurrencyManager.Refresh();
            Helpers.Msg.EliminarOk();
        }
        private void AnularNotaDebito()
        {
            var r01 = Sistema.Fabrica.AnularDocCompra_NotaDebito(Item.AutoDoc, _anular.Motivo);
            if (r01.Result == OOB.Enumerados.EnumResult.isError)
            {
                Helpers.Msg.Error(r01.Mensaje);
                return;
            }
            Item.Ficha.esAnulado = true;
            bs.CurrencyManager.Refresh();
            Helpers.Msg.EliminarOk();
        }



        public void setGestionAnular(Anular.Gestion _gestionAnular)
        {
            _anular = _gestionAnular;
        }

        public void VisualizarDocumento()
        {
            if (Item != null)
            {
                var r00 = Sistema.MyData.Permiso_AdmDoc_Visualizar(Sistema.UsuarioP.autoGru);
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }
                if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                {
                    Helpers.VisualizarDocumento.Visualizar(Item.AutoDoc);
                }
            }
        }

        public void setLista(List<OOB.LibCompra.Documento.Lista.Ficha> list)
        {
            bl.Clear();
            foreach (var rg in list.OrderByDescending(o => o.fechaEmision).ToList())
            {
                bl.Add(new data(rg));
            }
            bs.CurrencyManager.Refresh();
        }

        public void CorrectorDocumento()
        {
            if (Item != null)
            {
                if (Item.IsAnulado)
                    return;

                var r00 = Sistema.MyData.Permiso_AdmDoc_Corrector(Sistema.UsuarioP.autoGru);
                if (r00.Result == OOB.Enumerados.EnumResult.isError)
                {
                    Helpers.Msg.Error(r00.Mensaje);
                    return;
                }
                if (Seguridad.Gestion.SolicitarClave(r00.Entidad))
                {
                    _corrector.Inicializa();
                    _corrector.setIdDoc_Corregir(Item.AutoDoc);
                    _corrector.Inicia();
                }
            }
        }

        public void Inicializa()
        {
            bl.Clear();
            bs.CurrencyManager.Refresh();
        }

        public int GetCntItems { get { return bs.Count; } }
        public List<data> GetItems { get { return bl.ToList(); } }

    }

}