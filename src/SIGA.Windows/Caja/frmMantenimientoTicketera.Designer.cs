namespace SIGA.Windows.Caja
{
    partial class frmMantenimientoTicketera
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
            this.dgvMaquina = new System.Windows.Forms.DataGridView();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.btnNumeroSerie = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.btnConsultarSeries = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaquina)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMaquina
            // 
            this.dgvMaquina.AllowUserToAddRows = false;
            this.dgvMaquina.AllowUserToDeleteRows = false;
            this.dgvMaquina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaquina.Location = new System.Drawing.Point(12, 117);
            this.dgvMaquina.Name = "dgvMaquina";
            this.dgvMaquina.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.dgvMaquina.Size = new System.Drawing.Size(854, 255);
            this.dgvMaquina.TabIndex = 0;
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(563, 389);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(94, 40);
            this.BtnSalir.TabIndex = 60;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(85, 389);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(94, 40);
            this.BtnGuardar.TabIndex = 59;
            this.BtnGuardar.Text = "Nuevo";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // btnNumeroSerie
            // 
            this.btnNumeroSerie.Location = new System.Drawing.Point(307, 389);
            this.btnNumeroSerie.Name = "btnNumeroSerie";
            this.btnNumeroSerie.Size = new System.Drawing.Size(122, 40);
            this.btnNumeroSerie.TabIndex = 61;
            this.btnNumeroSerie.Text = "Registrar Numero de Series";
            this.btnNumeroSerie.UseVisualStyleBackColor = true;
            this.btnNumeroSerie.Click += new System.EventHandler(this.btnNumeroSerie_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(510, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 40);
            this.button1.TabIndex = 3;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 66;
            this.label2.Text = "Descripcion";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(99, 42);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(383, 20);
            this.txtDescripcion.TabIndex = 67;
            // 
            // btnConsultarSeries
            // 
            this.btnConsultarSeries.Location = new System.Drawing.Point(435, 389);
            this.btnConsultarSeries.Name = "btnConsultarSeries";
            this.btnConsultarSeries.Size = new System.Drawing.Size(122, 40);
            this.btnConsultarSeries.TabIndex = 68;
            this.btnConsultarSeries.Text = "Consultar Numero de Series";
            this.btnConsultarSeries.UseVisualStyleBackColor = true;
            this.btnConsultarSeries.Click += new System.EventHandler(this.btnConsultarSeries_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(25, 15);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(54, 13);
            this.label19.TabIndex = 74;
            this.label19.Text = "Empresa :";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(99, 12);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(383, 21);
            this.cboEmpresa.TabIndex = 73;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 389);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 40);
            this.button2.TabIndex = 75;
            this.button2.Text = "Modificar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // frmMantenimientoTicketera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 454);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.btnConsultarSeries);
            this.Controls.Add(this.txtDescripcion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNumeroSerie);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnGuardar);
            this.Controls.Add(this.dgvMaquina);
            this.Name = "frmMantenimientoTicketera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGA-Mantenimiento de Maquinas Ticketeras";
            this.Load += new System.EventHandler(this.frmMantenimientoTicketera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaquina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMaquina;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.Button btnNumeroSerie;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnConsultarSeries;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Button button2;
    }
}