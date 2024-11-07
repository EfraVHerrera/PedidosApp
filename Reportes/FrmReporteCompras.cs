using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PedidosApp.Reportes
{
    public partial class FrmReporteCompras : Form
    {
        public FrmReporteCompras()
        {
            InitializeComponent();
        }

        private void FrmReporteCompras_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spmostrar_ingreso' Puede moverla o quitarla según sea necesario.
            this.spmostrar_ingresoTableAdapter.Fill(this.dsPrincipal.spmostrar_ingreso);

            this.reportViewer1.RefreshReport();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            this.spmostrar_ingresoTableAdapter.Filterdate(this.dsPrincipal.spmostrar_ingreso,dtFecha1.Value.ToString(),dtFecha2.Value.ToString());

            this.reportViewer1.RefreshReport();
        }
    }
}
