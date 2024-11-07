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
    public partial class FrmVistaVenta_Producto : Form
    {
        private FrmVenta frmVenta1;  // Cambiado para que se refiera a FrmVenta
        public FrmVistaVenta_Producto(FrmVenta ventaForm1)
        {
            InitializeComponent();
            this.frmVenta1 = ventaForm1;  // Guardamos la instancia de FrmVenta
        }

        private void FrmVistaVenta_Producto_Load(object sender, EventArgs e)
        {
            Mostrar();
        }
        private void Mostrar()
        {
            DataTable dt = NArticulo.Mostrar();

            if (dt == null)
            {
                MessageBox.Show("Error al obtener los datos.");
                return;
            }

            // Configurar las columnas a mostrar
            dataListado.DataSource = dt;

            // Ocultar todas las columnas primero
            foreach (DataGridViewColumn column in dataListado.Columns)
            {
                column.Visible = false;
            }

            // Mostrar solo las columnas necesarias
            dataListado.Columns["Idarticulo"].Visible = true;
            dataListado.Columns["Idarticulo"].HeaderText = "ID Articulo";

            dataListado.Columns["nombre"].Visible = true;
            dataListado.Columns["nombre"].HeaderText = "Nombre";

            dataListado.Columns["descripcion"].Visible = true;
            dataListado.Columns["descripcion"].HeaderText = "Descripcion";

            // Mostrar el total de registros
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            // Obtener los valores seleccionados del DataGridView
            string Idarticulo = Convert.ToString(this.dataListado.CurrentRow.Cells["Idarticulo"].Value);
            string nombre = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            string descripcion = Convert.ToString(this.dataListado.CurrentRow.Cells["descripcion"].Value);
            

            // Llamar al método de FrmVenta para mostrar los datos seleccionados
            frmVenta1.MostrarTrabajadorSeleccionado1(Idarticulo, nombre, descripcion);

            // Cerrar este formulario después de pasar los datos
            this.Close();
        }
    }
}
