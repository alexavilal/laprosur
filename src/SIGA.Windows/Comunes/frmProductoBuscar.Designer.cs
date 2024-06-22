namespace SIGA.Windows.Comunes
{
    partial class frmProductoBuscar
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
            this.XT = new System.Windows.Forms.GroupBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cboCapacidad = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodigoGeneral = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboUnidad = new System.Windows.Forms.ComboBox();
            this.dgvProducto = new System.Windows.Forms.DataGridView();
            this.XT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).BeginInit();
            this.SuspendLayout();
            // 
            // XT
            // 
            this.XT.Controls.Add(this.label21);
            this.XT.Controls.Add(this.cboCapacidad);
            this.XT.Controls.Add(this.label10);
            this.XT.Controls.Add(this.button1);
            this.XT.Controls.Add(this.label9);
            this.XT.Controls.Add(this.txtCodigoGeneral);
            this.XT.Controls.Add(this.txtDescripcion);
            this.XT.Controls.Add(this.label8);
            this.XT.Controls.Add(this.cboUnidad);
            this.XT.Location = new System.Drawing.Point(13, 13);
            this.XT.Margin = new System.Windows.Forms.Padding(4);
            this.XT.Name = "XT";
            this.XT.Padding = new System.Windows.Forms.Padding(4);
            this.XT.Size = new System.Drawing.Size(852, 104);
            this.XT.TabIndex = 15;
            this.XT.TabStop = false;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(1055, 102);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(97, 16);
            this.label21.TabIndex = 84;
            this.label21.Text = "Tipo Empaque";
            // 
            // cboCapacidad
            // 
            this.cboCapacidad.FormattingEnabled = true;
            this.cboCapacidad.Location = new System.Drawing.Point(135, -28);
            this.cboCapacidad.Margin = new System.Windows.Forms.Padding(4);
            this.cboCapacidad.Name = "cboCapacidad";
            this.cboCapacidad.Size = new System.Drawing.Size(244, 24);
            this.cboCapacidad.TabIndex = 80;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(21, -18);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 16);
            this.label10.TabIndex = 79;
            this.label10.Text = "Capacidad";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(675, 38);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 38);
            this.button1.TabIndex = 78;
            this.button1.Text = "Buscar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 19);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 77;
            this.label9.Text = "Codigo";
            // 
            // txtCodigoGeneral
            // 
            this.txtCodigoGeneral.Location = new System.Drawing.Point(95, 16);
            this.txtCodigoGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoGeneral.Name = "txtCodigoGeneral";
            this.txtCodigoGeneral.Size = new System.Drawing.Size(244, 22);
            this.txtCodigoGeneral.TabIndex = 76;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(95, 46);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(561, 22);
            this.txtDescripcion.TabIndex = 75;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 49);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 74;
            this.label8.Text = "Descripcion";
            // 
            // cboUnidad
            // 
            this.cboUnidad.FormattingEnabled = true;
            this.cboUnidad.Location = new System.Drawing.Point(427, 545);
            this.cboUnidad.Margin = new System.Windows.Forms.Padding(4);
            this.cboUnidad.Name = "cboUnidad";
            this.cboUnidad.Size = new System.Drawing.Size(244, 24);
            this.cboUnidad.TabIndex = 41;
            // 
            // dgvProducto
            // 
            this.dgvProducto.AllowUserToAddRows = false;
            this.dgvProducto.AllowUserToDeleteRows = false;
            this.dgvProducto.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvProducto.Location = new System.Drawing.Point(13, 125);
            this.dgvProducto.Margin = new System.Windows.Forms.Padding(4);
            this.dgvProducto.Name = "dgvProducto";
            this.dgvProducto.RowHeadersWidth = 51;
            this.dgvProducto.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProducto.Size = new System.Drawing.Size(852, 412);
            this.dgvProducto.TabIndex = 16;
            this.dgvProducto.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducto_CellContentClick);
            this.dgvProducto.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvProducto_CellDoubleClick);
            // 
            // frmProductoBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 549);
            this.Controls.Add(this.dgvProducto);
            this.Controls.Add(this.XT);
            this.Name = "frmProductoBuscar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGA-Buscar Productos";
            this.Load += new System.EventHandler(this.frmProductoBuscar_Load);
            this.XT.ResumeLayout(false);
            this.XT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProducto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox XT;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.ComboBox cboCapacidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodigoGeneral;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboUnidad;
        private System.Windows.Forms.DataGridView dgvProducto;
    }
}