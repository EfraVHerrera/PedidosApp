using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace PedidosApp
{
    public partial class 
        FrmArticulo : Form
    {
        private bool IsNuevo = false;
        private bool IsEditar = false;
        private static FrmArticulo _Instancia;

        public static FrmArticulo GetInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new FrmArticulo();
            }
            return _Instancia;
        }
        public void setCategoria(string idcategoria, string nombre)
        {
            this.txtIdcategoria.Text = idcategoria;
            this.txtCategoria.Text = nombre;
        }
        public FrmArticulo()
        {
            InitializeComponent();
            this.ttMensaje.SetToolTip(this.txtNombre, "Ingrese el nombre del Articulo");
            this.ttMensaje.SetToolTip(this.txtCategoria, "Seleccione la categoria del Articulo");

            this.txtIdcategoria.Visible = false;
            this.txtCategoria.ReadOnly = true;
            //this.txtIdarticulo.Visible = false;
        }
        //Mostrar Mensaje de confirmacion
        private void MensajeOK(string mensaje)
        {
            MessageBox.Show(mensaje, "Pedidos App", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        //Mostrar Mensaje de error
        private void MensajeError(string mensaje)
        {
            MessageBox.Show(mensaje, "Pedidos App", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        //Limpiar todos los controles del formulario
        private void Limpiar()
        {
            this.txtCodigo.Text = string.Empty;
            this.txtNombre.Text = string.Empty;
            this.txtDescripcion.Text = string.Empty;
            this.txtIdcategoria.Text = string.Empty;
            this.txtCategoria.Text = string.Empty;
            this.txtIdarticulo.Text = string.Empty;
        }
        //Habilitar los controles del formulario
        private void Habilitar(bool valor)
        {
            this.txtCodigo.ReadOnly = !valor;
            this.txtNombre.ReadOnly = !valor;
            this.txtDescripcion.ReadOnly = !valor;
            this.btnBuscarCategoria.Enabled = valor;
            this.txtIdcategoria.ReadOnly = !valor;
        }
        //Habilitar los botones
        private void Botones()
        {
            if (this.IsNuevo || this.IsEditar)
            {
                this.Habilitar(true);
                this.btnNuevo.Enabled = false;
                this.btnGuardar.Enabled = true;
                this.btnEditar.Enabled = false;
                this.btnCancelar.Enabled = true;
            }
            else
            {
                this.Habilitar(false);
                this.btnNuevo.Enabled = true;
                this.btnGuardar.Enabled = false;
                this.btnEditar.Enabled = true;
                this.btnCancelar.Enabled = false;
            }
        }
        //Metodo para ocultar columnas
        private void OcultarColumnas()
        {
            if (this.dataListado.RowCount > 0)
            {
                this.dataListado.Columns[0].Visible = false;
                this.dataListado.Columns[1].Visible = true;
                this.dataListado.Columns[2].Visible = true;
                this.dataListado.Columns[3].Visible = true;
                this.dataListado.Columns[4].Visible = true;
                this.dataListado.Columns[5].Visible = true;
                this.dataListado.Columns[6].Visible = true;
            }
        }
        //Metodo mostrar
        private void Mostrar()
        {
            this.dataListado.DataSource = NArticulo.Mostrar();
            this.OcultarColumnas();
            this.lblTotal.Text = "Registros encontrados : " + Convert.ToString(dataListado.Rows.Count);
            this.tabControl1.SelectedIndex = 0;
        }
        //Metodo BuscarNombre
        private void BuscarNombre()
        {
            this.dataListado.DataSource = NArticulo.BuscarNombre(this.txtBuscar.Text);
            this.OcultarColumnas();
            this.lblTotal.Text = "Registros encontrados : " + Convert.ToString(dataListado.Rows.Count);
        }
        private void FrmArticulo_Load(object sender, EventArgs e)
        {
            this.Mostrar();
            this.Habilitar(false);
            this.Botones();
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }
        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            this.BuscarNombre();
        }
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            this.IsNuevo = true;
            this.IsEditar = false;
            this.Botones();
            this.Limpiar();
            this.Habilitar(true);
            this.txtCodigo.Focus();
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                string rpta = "";
                if (this.txtCodigo.Text == string.Empty || this.txtNombre.Text == string.Empty)
                {
                    MensajeError("Falta ingresar algunos datos, seran remarcados");
                    errorIcono.SetError(txtCodigo, "Ingrese un valor");
                    errorIcono.SetError(txtNombre, "Ingrese el nombre del articulo");
                    errorIcono.SetError(txtCategoria, "Seleccione una categoria");
                }
                else
                {
                    System.IO.MemoryStream ms = new System.IO.MemoryStream();
                    //this.pxImagen.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Png);
                    //byte[] imagen = ms.GetBuffer();
                    if (this.IsNuevo)
                    {
                        rpta = NArticulo.Insertar(txtCodigo.Text, txtNombre.Text.Trim().ToUpper(),
                            txtDescripcion.Text.Trim(), Convert.ToInt32(txtIdcategoria.Text));
                        
                    }
                    else
                    {
                        rpta = NArticulo.Editar(Convert.ToInt32(txtIdarticulo.Text), txtCodigo.Text,
                            txtNombre.Text.Trim().ToUpper(), txtDescripcion.Text.Trim(),
                        Convert.ToInt32(txtIdcategoria.Text));
                    }
                    if (rpta.Equals("OK"))
                    {
                        if (this.IsNuevo) { MensajeOK("Se guardó el registro"); }
                        else { MensajeOK("Se actualizó el registro"); }
                    }
                    else 
                    {
                        MensajeError(rpta);
                    }
                    IsNuevo = false;
                    IsEditar = false;
                    Botones();
                    Limpiar();
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (!txtIdarticulo.Text.Equals(""))
            {
                IsEditar = true;
                Botones();
                Habilitar(true);
            }
            else
            {
                MensajeError("Debe seleccionar primero el registro para modificar");
            }
        }
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            IsNuevo = false;
            IsEditar = false;
            Botones();
            Limpiar();
            Habilitar(false);
        }
        private void chkEliminar_CheckedChanged(object sender, EventArgs e)
        {
            if (chkEliminar.Checked)
            {
                dataListado.Columns[0].Visible = true;
            }
            else
            {
                dataListado.Columns[0].Visible = false;
            }
        }
        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            {
                DataGridViewCheckBoxCell ChkEliminar = (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
                ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            }
        }
        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            txtIdarticulo.Text = Convert.ToString(dataListado.CurrentRow.Cells["idarticulo"].Value);
            txtCodigo.Text = Convert.ToString(dataListado.CurrentRow.Cells["codigo"].Value);
            txtNombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["nombre"].Value);
            txtDescripcion.Text = Convert.ToString(dataListado.CurrentRow.Cells["descripcion"].Value);
            txtIdcategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["idcategoria"].Value);
            txtCategoria.Text = Convert.ToString(dataListado.CurrentRow.Cells["categoria"].Value);
            tabControl1.SelectedIndex = 1;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult Opcion;
                Opcion = MessageBox.Show("Esta seguro de borrar los registros?", "Pedidos App",
                    MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (Opcion == DialogResult.OK)
                {
                    string Codigo;
                    string rpta = "";
                    foreach (DataGridViewRow row in dataListado.Rows)
                    {
                        if (Convert.ToBoolean(row.Cells[0].Value))
                        {
                            Codigo = Convert.ToString(row.Cells[1].Value);
                            rpta = NArticulo.Eliminar(Convert.ToInt32(Codigo));
                            if (rpta.Equals("OK"))
                            {
                                MensajeOK("Se borraron los registros");
                            }
                            else { MensajeError(rpta); }
                        }
                    }
                    Mostrar();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace);
            }
        }
        private void btnBuscarCategoria_Click(object sender, EventArgs e)
        {
            FrmVistaCategoria_Articulo form = new FrmVistaCategoria_Articulo();
            form.ShowDialog();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            Reportes.FrmStockArticulos frm = new Reportes.FrmStockArticulos();
            //frm.Texto = txtBuscar.Text;
            frm.ShowDialog();
        }
        private void FrmArticulo_FormClosing(object sender, FormClosingEventArgs e)
        {
            _Instancia = null;
        }

        private void txtCategoria_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void txtIdcategoria_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
