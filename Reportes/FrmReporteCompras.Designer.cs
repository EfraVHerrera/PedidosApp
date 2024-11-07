namespace PedidosApp.Reportes
{
    partial class FrmReporteCompras
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.dtFecha1 = new System.Windows.Forms.DateTimePicker();
            this.dtFecha2 = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.spmostraringresoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dsPrincipal = new PedidosApp.dsPrincipal();
            this.spmostrar_ingresoTableAdapter = new PedidosApp.dsPrincipalTableAdapters.spmostrar_ingresoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.spmostraringresoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.spmostraringresoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PedidosApp.Reportes.rptIngreso.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 63);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 387);
            this.reportViewer1.TabIndex = 0;
            // 
            // dtFecha1
            // 
            this.dtFecha1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha1.Location = new System.Drawing.Point(28, 23);
            this.dtFecha1.Margin = new System.Windows.Forms.Padding(2);
            this.dtFecha1.Name = "dtFecha1";
            this.dtFecha1.Size = new System.Drawing.Size(100, 20);
            this.dtFecha1.TabIndex = 9;
            // 
            // dtFecha2
            // 
            this.dtFecha2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha2.Location = new System.Drawing.Point(160, 23);
            this.dtFecha2.Margin = new System.Windows.Forms.Padding(2);
            this.dtFecha2.Name = "dtFecha2";
            this.dtFecha2.Size = new System.Drawing.Size(100, 20);
            this.dtFecha2.TabIndex = 10;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.Transparent;
            this.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBuscar.Location = new System.Drawing.Point(287, 15);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(2);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(100, 28);
            this.btnBuscar.TabIndex = 11;
            this.btnBuscar.Text = "&Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // spmostraringresoBindingSource
            // 
            this.spmostraringresoBindingSource.DataMember = "spmostrar_ingreso";
            this.spmostraringresoBindingSource.DataSource = this.dsPrincipal;
            // 
            // dsPrincipal
            // 
            this.dsPrincipal.DataSetName = "dsPrincipal";
            this.dsPrincipal.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // spmostrar_ingresoTableAdapter
            // 
            this.spmostrar_ingresoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmReporteCompras
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtFecha2);
            this.Controls.Add(this.dtFecha1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmReporteCompras";
            this.Text = "FrmReporteCompras";
            this.Load += new System.EventHandler(this.FrmReporteCompras_Load);
            ((System.ComponentModel.ISupportInitialize)(this.spmostraringresoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dsPrincipal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private dsPrincipal dsPrincipal;
        private System.Windows.Forms.BindingSource spmostraringresoBindingSource;
        private dsPrincipalTableAdapters.spmostrar_ingresoTableAdapter spmostrar_ingresoTableAdapter;
        private System.Windows.Forms.DateTimePicker dtFecha1;
        private System.Windows.Forms.DateTimePicker dtFecha2;
        private System.Windows.Forms.Button btnBuscar;
    }
}