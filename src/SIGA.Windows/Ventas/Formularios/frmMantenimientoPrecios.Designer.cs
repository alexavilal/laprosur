namespace SIGA.Windows.Ventas.Formularios
{
    partial class frmMantenimientoPrecios
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
            this.dgvPrecio = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.cboPolitica = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cboZona = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.CodGeneral = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Familia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Item = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Unidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Flete = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPrecio
            // 
            this.dgvPrecio.AllowUserToAddRows = false;
            this.dgvPrecio.AllowUserToDeleteRows = false;
            this.dgvPrecio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrecio.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CodGeneral,
            this.Codigo,
            this.Familia,
            this.Item,
            this.Unidad,
            this.Precio,
            this.Flete});
            this.dgvPrecio.Location = new System.Drawing.Point(23, 105);
            this.dgvPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.dgvPrecio.Name = "dgvPrecio";
            this.dgvPrecio.RowHeadersWidth = 51;
            this.dgvPrecio.Size = new System.Drawing.Size(1156, 450);
            this.dgvPrecio.TabIndex = 53;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(586, 574);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(125, 49);
            this.btnModificar.TabIndex = 55;
            this.btnModificar.Text = "Salir";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(439, 574);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(125, 49);
            this.btnNuevo.TabIndex = 54;
            this.btnNuevo.Text = "Guardar";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // cboPolitica
            // 
            this.cboPolitica.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboPolitica.FormattingEnabled = true;
            this.cboPolitica.Location = new System.Drawing.Point(151, 20);
            this.cboPolitica.Margin = new System.Windows.Forms.Padding(4);
            this.cboPolitica.Name = "cboPolitica";
            this.cboPolitica.Size = new System.Drawing.Size(336, 24);
            this.cboPolitica.TabIndex = 78;
            this.cboPolitica.SelectedIndexChanged += new System.EventHandler(this.cboPolitica_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(24, 20);
            this.label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(119, 16);
            this.label32.TabIndex = 79;
            this.label32.Text = "Politica de Precios";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 16);
            this.label1.TabIndex = 80;
            this.label1.Text = "Zona";
            // 
            // cboZona
            // 
            this.cboZona.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboZona.FormattingEnabled = true;
            this.cboZona.Location = new System.Drawing.Point(151, 59);
            this.cboZona.Margin = new System.Windows.Forms.Padding(4);
            this.cboZona.Name = "cboZona";
            this.cboZona.Size = new System.Drawing.Size(336, 24);
            this.cboZona.TabIndex = 81;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(553, 46);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 49);
            this.button1.TabIndex = 82;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // CodGeneral
            // 
            this.CodGeneral.HeaderText = "CodGeneral";
            this.CodGeneral.MinimumWidth = 6;
            this.CodGeneral.Name = "CodGeneral";
            this.CodGeneral.Width = 6;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.MinimumWidth = 6;
            this.Codigo.Name = "Codigo";
            this.Codigo.ReadOnly = true;
            this.Codigo.Width = 90;
            // 
            // Familia
            // 
            this.Familia.HeaderText = "Familia";
            this.Familia.MinimumWidth = 6;
            this.Familia.Name = "Familia";
            this.Familia.ReadOnly = true;
            this.Familia.Width = 150;
            // 
            // Item
            // 
            this.Item.HeaderText = "Item";
            this.Item.MinimumWidth = 6;
            this.Item.Name = "Item";
            this.Item.ReadOnly = true;
            this.Item.Width = 350;
            // 
            // Unidad
            // 
            this.Unidad.HeaderText = "Unidad";
            this.Unidad.MinimumWidth = 6;
            this.Unidad.Name = "Unidad";
            this.Unidad.ReadOnly = true;
            this.Unidad.Width = 120;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.Width = 95;
            // 
            // Flete
            // 
            this.Flete.HeaderText = "Flete";
            this.Flete.MinimumWidth = 6;
            this.Flete.Name = "Flete";
            this.Flete.Width = 95;
            // 
            // frmMantenimientoPrecios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1206, 626);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cboZona);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPolitica);
            this.Controls.Add(this.label32);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.dgvPrecio);
            this.Name = "frmMantenimientoPrecios";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGA-Mantenimiento de Precios";
            this.Load += new System.EventHandler(this.frmMantenimientoPrecios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrecio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrecio;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.ComboBox cboPolitica;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboZona;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CodGeneral;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Familia;
        private System.Windows.Forms.DataGridViewTextBoxColumn Item;
        private System.Windows.Forms.DataGridViewTextBoxColumn Unidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewTextBoxColumn Flete;
    }
}