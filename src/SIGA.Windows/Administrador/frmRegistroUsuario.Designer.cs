namespace SIGA.Windows.Administrador
{
    partial class frmRegistroUsuario
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
            this.label2 = new System.Windows.Forms.Label();
            this.TxtClave = new System.Windows.Forms.TextBox();
            this.TxtUsuario = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.TxtCorreo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtNombre = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtAm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtAp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.BtnSalir = new System.Windows.Forms.Button();
            this.BtnGuardar = new System.Windows.Forms.Button();
            this.CboEstado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCodigo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SubTabPerfiles = new System.Windows.Forms.TabControl();
            this.SubTabUsuario = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.DgvPerfiles = new System.Windows.Forms.DataGridView();
            this.lblClave = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboCargo = new System.Windows.Forms.ComboBox();
            this.SubTabPerfiles.SuspendLayout();
            this.SubTabUsuario.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvPerfiles)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 230);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 16);
            this.label2.TabIndex = 54;
            this.label2.Text = "Clave";
            // 
            // TxtClave
            // 
            this.TxtClave.Location = new System.Drawing.Point(447, 230);
            this.TxtClave.Margin = new System.Windows.Forms.Padding(4);
            this.TxtClave.Name = "TxtClave";
            this.TxtClave.PasswordChar = '*';
            this.TxtClave.Size = new System.Drawing.Size(153, 22);
            this.TxtClave.TabIndex = 8;
            // 
            // TxtUsuario
            // 
            this.TxtUsuario.Location = new System.Drawing.Point(173, 230);
            this.TxtUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.TxtUsuario.Name = "TxtUsuario";
            this.TxtUsuario.Size = new System.Drawing.Size(216, 22);
            this.TxtUsuario.TabIndex = 7;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(33, 233);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(54, 16);
            this.label9.TabIndex = 51;
            this.label9.Text = "Usuario";
            // 
            // TxtCorreo
            // 
            this.TxtCorreo.Location = new System.Drawing.Point(173, 260);
            this.TxtCorreo.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCorreo.Name = "TxtCorreo";
            this.TxtCorreo.Size = new System.Drawing.Size(432, 22);
            this.TxtCorreo.TabIndex = 9;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 263);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 49;
            this.label7.Text = "Correo";
            // 
            // TxtNombre
            // 
            this.TxtNombre.Location = new System.Drawing.Point(173, 116);
            this.TxtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.TxtNombre.Name = "TxtNombre";
            this.TxtNombre.Size = new System.Drawing.Size(432, 22);
            this.TxtNombre.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(35, 124);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 16);
            this.label6.TabIndex = 47;
            this.label6.Text = "Nombres";
            // 
            // TxtAm
            // 
            this.TxtAm.Location = new System.Drawing.Point(173, 84);
            this.TxtAm.Margin = new System.Windows.Forms.Padding(4);
            this.TxtAm.Name = "TxtAm";
            this.TxtAm.Size = new System.Drawing.Size(432, 22);
            this.TxtAm.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(35, 91);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 16);
            this.label5.TabIndex = 45;
            this.label5.Text = "Apellido Materno";
            // 
            // TxtAp
            // 
            this.TxtAp.Location = new System.Drawing.Point(173, 52);
            this.TxtAp.Margin = new System.Windows.Forms.Padding(4);
            this.TxtAp.Name = "TxtAp";
            this.TxtAp.Size = new System.Drawing.Size(432, 22);
            this.TxtAp.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 59);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 16);
            this.label4.TabIndex = 43;
            this.label4.Text = "Apellido Paterno";
            // 
            // BtnSalir
            // 
            this.BtnSalir.Location = new System.Drawing.Point(345, 414);
            this.BtnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.BtnSalir.Name = "BtnSalir";
            this.BtnSalir.Size = new System.Drawing.Size(125, 49);
            this.BtnSalir.TabIndex = 13;
            this.BtnSalir.Text = "Salir";
            this.BtnSalir.UseVisualStyleBackColor = true;
            this.BtnSalir.Click += new System.EventHandler(this.BtnSalir_Click);
            // 
            // BtnGuardar
            // 
            this.BtnGuardar.Location = new System.Drawing.Point(193, 414);
            this.BtnGuardar.Margin = new System.Windows.Forms.Padding(4);
            this.BtnGuardar.Name = "BtnGuardar";
            this.BtnGuardar.Size = new System.Drawing.Size(125, 49);
            this.BtnGuardar.TabIndex = 12;
            this.BtnGuardar.Text = "Guardar";
            this.BtnGuardar.UseVisualStyleBackColor = true;
            this.BtnGuardar.Click += new System.EventHandler(this.BtnGuardar_Click);
            // 
            // CboEstado
            // 
            this.CboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboEstado.FormattingEnabled = true;
            this.CboEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.CboEstado.Location = new System.Drawing.Point(173, 308);
            this.CboEstado.Margin = new System.Windows.Forms.Padding(4);
            this.CboEstado.Name = "CboEstado";
            this.CboEstado.Size = new System.Drawing.Size(160, 24);
            this.CboEstado.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 308);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 16);
            this.label3.TabIndex = 39;
            this.label3.Text = "Estado";
            // 
            // TxtCodigo
            // 
            this.TxtCodigo.Enabled = false;
            this.TxtCodigo.Location = new System.Drawing.Point(173, 20);
            this.TxtCodigo.Margin = new System.Windows.Forms.Padding(4);
            this.TxtCodigo.Name = "TxtCodigo";
            this.TxtCodigo.ReadOnly = true;
            this.TxtCodigo.Size = new System.Drawing.Size(100, 22);
            this.TxtCodigo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 16);
            this.label1.TabIndex = 37;
            this.label1.Text = "Código";
            // 
            // SubTabPerfiles
            // 
            this.SubTabPerfiles.Controls.Add(this.SubTabUsuario);
            this.SubTabPerfiles.Controls.Add(this.tabPage2);
            this.SubTabPerfiles.Location = new System.Drawing.Point(16, 15);
            this.SubTabPerfiles.Margin = new System.Windows.Forms.Padding(4);
            this.SubTabPerfiles.Name = "SubTabPerfiles";
            this.SubTabPerfiles.SelectedIndex = 0;
            this.SubTabPerfiles.Size = new System.Drawing.Size(676, 391);
            this.SubTabPerfiles.TabIndex = 55;
            // 
            // SubTabUsuario
            // 
            this.SubTabUsuario.Controls.Add(this.cboCargo);
            this.SubTabUsuario.Controls.Add(this.label11);
            this.SubTabUsuario.Controls.Add(this.label10);
            this.SubTabUsuario.Controls.Add(this.txtNumero);
            this.SubTabUsuario.Controls.Add(this.label8);
            this.SubTabUsuario.Controls.Add(this.cboTipoDocumento);
            this.SubTabUsuario.Controls.Add(this.label7);
            this.SubTabUsuario.Controls.Add(this.label2);
            this.SubTabUsuario.Controls.Add(this.label1);
            this.SubTabUsuario.Controls.Add(this.TxtClave);
            this.SubTabUsuario.Controls.Add(this.TxtCodigo);
            this.SubTabUsuario.Controls.Add(this.TxtUsuario);
            this.SubTabUsuario.Controls.Add(this.label3);
            this.SubTabUsuario.Controls.Add(this.label9);
            this.SubTabUsuario.Controls.Add(this.CboEstado);
            this.SubTabUsuario.Controls.Add(this.TxtCorreo);
            this.SubTabUsuario.Controls.Add(this.label4);
            this.SubTabUsuario.Controls.Add(this.TxtAp);
            this.SubTabUsuario.Controls.Add(this.TxtNombre);
            this.SubTabUsuario.Controls.Add(this.label5);
            this.SubTabUsuario.Controls.Add(this.label6);
            this.SubTabUsuario.Controls.Add(this.TxtAm);
            this.SubTabUsuario.Location = new System.Drawing.Point(4, 25);
            this.SubTabUsuario.Margin = new System.Windows.Forms.Padding(4);
            this.SubTabUsuario.Name = "SubTabUsuario";
            this.SubTabUsuario.Padding = new System.Windows.Forms.Padding(4);
            this.SubTabUsuario.Size = new System.Drawing.Size(668, 362);
            this.SubTabUsuario.TabIndex = 0;
            this.SubTabUsuario.Text = "Datos del Usuario";
            this.SubTabUsuario.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DgvPerfiles);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(668, 362);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Perfiles";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // DgvPerfiles
            // 
            this.DgvPerfiles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvPerfiles.Location = new System.Drawing.Point(29, 20);
            this.DgvPerfiles.Margin = new System.Windows.Forms.Padding(4);
            this.DgvPerfiles.Name = "DgvPerfiles";
            this.DgvPerfiles.RowHeadersWidth = 51;
            this.DgvPerfiles.Size = new System.Drawing.Size(592, 225);
            this.DgvPerfiles.TabIndex = 1;
            this.DgvPerfiles.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DgvPerfiles_DataBindingComplete);
            // 
            // lblClave
            // 
            this.lblClave.AutoSize = true;
            this.lblClave.Location = new System.Drawing.Point(573, 326);
            this.lblClave.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblClave.Name = "lblClave";
            this.lblClave.Size = new System.Drawing.Size(0, 16);
            this.lblClave.TabIndex = 56;
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cboTipoDocumento.Location = new System.Drawing.Point(173, 155);
            this.cboTipoDocumento.Margin = new System.Windows.Forms.Padding(4);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(169, 24);
            this.cboTipoDocumento.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(35, 163);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 16);
            this.label8.TabIndex = 56;
            this.label8.Text = "Tipo Documento";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(350, 160);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 16);
            this.label10.TabIndex = 58;
            this.label10.Text = "Numero";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(413, 155);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(192, 22);
            this.txtNumero.TabIndex = 5;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(39, 200);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 16);
            this.label11.TabIndex = 59;
            this.label11.Text = "Cargo";
            // 
            // cboCargo
            // 
            this.cboCargo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCargo.FormattingEnabled = true;
            this.cboCargo.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cboCargo.Location = new System.Drawing.Point(173, 198);
            this.cboCargo.Margin = new System.Windows.Forms.Padding(4);
            this.cboCargo.Name = "cboCargo";
            this.cboCargo.Size = new System.Drawing.Size(216, 24);
            this.cboCargo.TabIndex = 6;
            // 
            // frmRegistroUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 476);
            this.Controls.Add(this.lblClave);
            this.Controls.Add(this.SubTabPerfiles);
            this.Controls.Add(this.BtnSalir);
            this.Controls.Add(this.BtnGuardar);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmRegistroUsuario";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGA - Registro de Usuario";
            this.Load += new System.EventHandler(this.frmRegistroUsuario_Load);
            this.SubTabPerfiles.ResumeLayout(false);
            this.SubTabUsuario.ResumeLayout(false);
            this.SubTabUsuario.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvPerfiles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtClave;
        private System.Windows.Forms.TextBox TxtUsuario;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TxtCorreo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtNombre;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtAm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtAp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button BtnSalir;
        private System.Windows.Forms.Button BtnGuardar;
        private System.Windows.Forms.ComboBox CboEstado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCodigo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl SubTabPerfiles;
        private System.Windows.Forms.TabPage SubTabUsuario;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.DataGridView DgvPerfiles;
        private System.Windows.Forms.Label lblClave;
        private System.Windows.Forms.ComboBox cboCargo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
    }
}