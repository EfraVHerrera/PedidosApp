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
    public partial class FrmVistaEquipo_Trabajador : Form
    {
        private FrmTrabajador frmTrabajador;

        // Constructor para recibir la instancia de FrmTrabajador
        public FrmVistaEquipo_Trabajador(FrmTrabajador trabajadorForm)
        {
            InitializeComponent();
            this.frmTrabajador = trabajadorForm;  // Guardamos la instancia de FrmTrabajador
        }
        private void Mostrar()
        {
            dataListado.DataSource = NEquipo.Mostrar();
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }
        private void dataListado_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FrmVistaEquipo_Trabajador_Load(object sender, EventArgs e)
        {
            Mostrar();
        }

        private void dataListado_DoubleClick(object sender, EventArgs e)
        {
            // Obtener los valores seleccionados del DataGridView
            string id_equipo = Convert.ToString(this.dataListado.CurrentRow.Cells["id_equipo"].Value);
            string nombre_equipo = Convert.ToString(this.dataListado.CurrentRow.Cells["nombre_equipo"].Value);

            // Llamar al método de FrmTrabajador para mostrar los datos seleccionados
            frmTrabajador.MostrarEquipoSeleccionado(id_equipo, nombre_equipo);

            // Cerrar este formulario después de pasar los datos
            this.Close();
        }
        private void BuscarNombre()
        {
            dataListado.DataSource = NEquipo.BuscarNombre(txtBuscar.Text);
            lblTotal.Text = "Total de Registros: " + Convert.ToString(dataListado.Rows.Count);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            BuscarNombre();
        }

    }
}
