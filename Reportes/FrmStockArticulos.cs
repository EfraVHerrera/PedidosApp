﻿using System;
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
    public partial class FrmStockArticulos : Form
    {
        public FrmStockArticulos()
        {
            InitializeComponent();
        }

        private void FrmStockArticulos_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spstock_articulos' Puede moverla o quitarla según sea necesario.
            this.spstock_articulosTableAdapter.Fill(this.dsPrincipal.spstock_articulos);
            // TODO: esta línea de código carga datos en la tabla 'dsPrincipal.spstock_articulos' Puede moverla o quitarla según sea necesario.
            this.spstock_articulosTableAdapter.Fill(this.dsPrincipal.spstock_articulos);

            this.reportViewer1.RefreshReport();
        }
    }
}