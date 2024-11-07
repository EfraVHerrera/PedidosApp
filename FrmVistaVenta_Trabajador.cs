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
    public partial class FrmVistaVenta_Trabajador : Form
    {
        private FrmVenta frmVenta;  // Cambiado para que se refiera a FrmVenta
        public FrmVistaVenta_Trabajador(FrmVenta ventaForm)
        {
            InitializeComponent();
            this.frmVenta = ventaForm;  // Guardamos la instancia de FrmVenta
        }
        private void Mostrar()
        {
            DataTable dt = NTrabajador.Mostrar();

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
            dataListado.Columns["idtrabajador"].Visible = true;
            dataListado.Columns["idtrabajador"].HeaderText = "ID Trabajador";

            dataListado.Columns["nombre"].Visible = true;
            dataListado.Columns["nombre"].HeaderText = "Nombre";

            dataListado.Columns["apellidos"].Visible = true;
            dataListado.Columns["apellidos"].HeaderText = "Apellido";

            dataListado.Columns["nombre_equipo"].Visible = true;
            dataListado.Columns["nombre_equipo"].HeaderText = "Equipo";

            // Mostrar el total de registros
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }


        private void FrmVistaVenta_Trabajador_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void BuscarNombre()
        {
            //dataListado.DataSource = NTrabajador.BuscarNombre(txtBuscar.Text);  // Buscar trabajadores por nombre
            //lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataListado_DoubleClick_1(object sender, EventArgs e)
        {
            // Obtener los valores seleccionados del DataGridView
            string idtrabajador = Convert.ToString(this.dataListado.CurrentRow.Cells["idtrabajador"].Value);
            string nombre = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre"].Value);
            string apellido = Convert.ToString(this.dataListado.CurrentRow.Cells["apellidos"].Value);

            // Llamar al método de FrmVenta para mostrar los datos seleccionados
            frmVenta.MostrarTrabajadorSeleccionado(idtrabajador, nombre, apellido);

            // Cerrar este formulario después de pasar los datos
            this.Close();
        }
    }
}
