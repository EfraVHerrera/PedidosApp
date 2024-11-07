using CapaNegocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosApp
{
    public partial class FrmVenta : Form
    {
        public FrmVenta()
        {
            InitializeComponent();
            this.txtIdtrabajador.Visible = false;
            this.nombre.ReadOnly = true;
            this.apellido.ReadOnly = true;
            this.txtnombre.Visible = false;
        }
        private void Mostrar()
        {
            this.dataListado.DataSource = NVenta.Mostrar();
            this.lblTotal.Text = "Registros encontrados : " + Convert.ToString(dataListado.Rows.Count);
            this.tabControl1.SelectedIndex = 0;

        }
        private void InsertarVenta()
        {
            try
            {
                // Validar campos
                if (string.IsNullOrEmpty(txtIdtrabajador.Text) ||
                    string.IsNullOrEmpty(txtnombre.Text) ||
                    string.IsNullOrEmpty(txtCantidad.Text) ||
                    string.IsNullOrEmpty(txtPrecio.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                int idtrabajador = Convert.ToInt32(txtIdtrabajador.Text);
                int idarticulo = Convert.ToInt32(txtnombre.Text);
                int cantidad = Convert.ToInt32(txtCantidad.Text);
                decimal precio = Convert.ToDecimal(txtPrecio.Text);
                DateTime fecha = dtFecha.Value; // Tomar la fecha del DateTimePicker

                string resultado = NVenta.Insertar(idarticulo, idtrabajador, cantidad, precio, fecha);

                if (resultado.Equals("OK"))
                {
                    MessageBox.Show("Venta registrada con éxito.");
                    // Aquí puedes limpiar los campos o realizar otras acciones
                    // Actualiza el listado
                    Mostrar();
                    // Cambia de pestaña al listado
                    tabControl1.SelectedIndex = 0; // Suponiendo que el índice 0 es el del DataGridView
                                                   // Aquí puedes limpiar los campos si deseas
                    LimpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error: " + resultado);
                }
            }
            catch (FormatException ex)
            {
                MessageBox.Show("Por favor, ingrese valores numéricos válidos para IdTrabajador, IdProducto, Cantidad y Precio.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LimpiarCampos()
        {
            txtIdtrabajador.Clear();
            txtnombre.Clear();
            txtCantidad.Clear();
            txtPrecio.Clear();
            dtFecha.Value = DateTime.Now; // O la fecha que desees por defecto
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void FrmVenta_Load(object sender, EventArgs e)
        {
            this.Mostrar();
        }
        public void MostrarTrabajadorSeleccionado(string idtrabajador, string nombre, string apellido)
        {
            // Asignar los valores seleccionados al formulario FrmVenta
            this.txtIdtrabajador.Text = idtrabajador;  // Suponiendo que tienes un TextBox llamado txtIdTrabajador
            this.nombre.Text = nombre;    // Suponiendo que tienes un TextBox llamado txtNombreTrabajador
            this.apellido.Text = apellido;    // Suponiendo que tienes un TextBox llamado txtNombreTrabajador
 
        }
        public void MostrarTrabajadorSeleccionado1(string nombre,string idarticulo, string descripcion)
        {
            // Asignar los valores seleccionados al formulario FrmVenta
            this.txtIdproducto.Text = idarticulo;
            this.txtnombre.Text = nombre;
            this.descripcion.Text = descripcion;

        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            // Crear una nueva instancia de FrmVistaVenta_Trabajador y pasar la referencia de este formulario
            FrmVistaVenta_Trabajador vistaTrabajadorForm = new FrmVistaVenta_Trabajador(this);
            vistaTrabajadorForm.ShowDialog();  // Mostrar el formulario de selección

        }

        private void btnBuscarProducto_Click(object sender, EventArgs e)
        {
            FrmVistaVenta_Producto vistaTrabajadorForm = new FrmVistaVenta_Producto(this);
            vistaTrabajadorForm.ShowDialog();  // Mostrar el formulario de selección
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show($"ID Trabajador: {txtIdtrabajador.Text}, ID Producto: {txtIdproducto.Text}, Precio: {txtPrecio.Text}, Cantidad: {txtCantidad.Text}");

            InsertarVenta();
        }

        private void dataListadoVenta_DoubleClick(object sender, EventArgs e)
        {
            //txtIdarticulo.Text = Convert.ToString(dataListado.CurrentRow.Cells["idventa"].Value);
            txtIdtrabajador.Text = Convert.ToString(dataListado.CurrentRow.Cells["idtrabajador"].Value);
            txtCantidad.Text = Convert.ToString(dataListado.CurrentRow.Cells["cantidad"].Value);
            txtnombre.Text = Convert.ToString(dataListado.CurrentRow.Cells["idarticulo"].Value);
            txtPrecio.Text = Convert.ToString(dataListado.CurrentRow.Cells["precio"].Value);
            dtFecha.Text = Convert.ToString(dataListado.CurrentRow.Cells["fecha"].Value);
            tabControl1.SelectedIndex = 1;
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (e.ColumnIndex == dataListado.Columns["Eliminar"].Index)
            //{
            //    DataGridViewCheckBoxCell ChkEliminar =
            //        (DataGridViewCheckBoxCell)dataListado.Rows[e.RowIndex].Cells["Eliminar"];
            //    ChkEliminar.Value = !Convert.ToBoolean(ChkEliminar.Value);
            //    this.OcultarColumnas();
            //}
        }
        private void OcultarColumnas()
        {
            if (this.dataListado.RowCount > 0)
            {
                // Ajusta la visibilidad de las columnas restantes según sea necesario
                this.dataListado.Columns[0].Visible = true; // Mantener visible según necesidad
                this.dataListado.Columns[1].Visible = true; // Mantener visible según necesidad
                this.dataListado.Columns[2].Visible = true;
                this.dataListado.Columns[3].Visible = true;
                this.dataListado.Columns[4].Visible = true;
                this.dataListado.Columns[5].Visible = true;
                // No incluyas la columna "Eliminar"
            }
        }
    }
}
