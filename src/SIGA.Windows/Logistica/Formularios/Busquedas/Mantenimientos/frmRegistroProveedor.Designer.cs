namespace SIGA.Windows.Logistica.Formularios.Mantenimientos
{
    partial class frmRegProveedor
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabProveedor = new System.Windows.Forms.TabControl();
            this.tabPrincipal = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtDirecion = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.dgvMarcas = new System.Windows.Forms.DataGridView();
            this.TxtCodigoGenerado = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnQuitar = new System.Windows.Forms.Button();
            this.btnAñadir = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.optSinMarca = new System.Windows.Forms.RadioButton();
            this.optMarca = new System.Windows.Forms.RadioButton();
            this.txtCorreoElectronico = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtNombreComercial = new System.Windows.Forms.TextBox();
            this.txtPaginaWeb = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNumero = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cboTipoDocumento = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabContacto = new System.Windows.Forms.TabPage();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.btnAgregarContacto = new System.Windows.Forms.Button();
            this.btnQuitarContacto = new System.Windows.Forms.Button();
            this.dgvContactos = new System.Windows.Forms.DataGridView();
            this.TxtNumeroTel = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.cboOperador = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.TxtArea = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.TxtCargo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.TxtContacto = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnRegistrar = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.tabProveedor.SuspendLayout();
            this.tabPrincipal.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).BeginInit();
            this.tabContacto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).BeginInit();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, -39);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(504, 22);
            this.textBox1.TabIndex = 18;
            // 
            // tabProveedor
            // 
            this.tabProveedor.Controls.Add(this.tabPrincipal);
            this.tabProveedor.Controls.Add(this.tabContacto);
            this.tabProveedor.Location = new System.Drawing.Point(16, 15);
            this.tabProveedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabProveedor.Name = "tabProveedor";
            this.tabProveedor.SelectedIndex = 0;
            this.tabProveedor.Size = new System.Drawing.Size(1316, 355);
            this.tabProveedor.TabIndex = 19;
            // 
            // tabPrincipal
            // 
            this.tabPrincipal.Controls.Add(this.groupBox1);
            this.tabPrincipal.Location = new System.Drawing.Point(4, 25);
            this.tabPrincipal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPrincipal.Name = "tabPrincipal";
            this.tabPrincipal.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPrincipal.Size = new System.Drawing.Size(1308, 326);
            this.tabPrincipal.TabIndex = 0;
            this.tabPrincipal.Text = "Datos Principales del Proveedor";
            this.tabPrincipal.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.txtDirecion);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.dgvMarcas);
            this.groupBox1.Controls.Add(this.TxtCodigoGenerado);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cboEstado);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnQuitar);
            this.groupBox1.Controls.Add(this.btnAñadir);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboMarca);
            this.groupBox1.Controls.Add(this.optSinMarca);
            this.groupBox1.Controls.Add(this.optMarca);
            this.groupBox1.Controls.Add(this.txtCorreoElectronico);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txtNombreComercial);
            this.groupBox1.Controls.Add(this.txtPaginaWeb);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtNumero);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cboTipoDocumento);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtRazonSocial);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(5, 18);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(1280, 257);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // txtDirecion
            // 
            this.txtDirecion.Location = new System.Drawing.Point(747, 82);
            this.txtDirecion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtDirecion.MaxLength = 70;
            this.txtDirecion.Multiline = true;
            this.txtDirecion.Name = "txtDirecion";
            this.txtDirecion.Size = new System.Drawing.Size(499, 54);
            this.txtDirecion.TabIndex = 53;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(683, 86);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 16);
            this.label16.TabIndex = 52;
            this.label16.Text = "Dirección";
            // 
            // dgvMarcas
            // 
            this.dgvMarcas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMarcas.Location = new System.Drawing.Point(28, 309);
            this.dgvMarcas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvMarcas.Name = "dgvMarcas";
            this.dgvMarcas.RowHeadersWidth = 51;
            this.dgvMarcas.Size = new System.Drawing.Size(475, 155);
            this.dgvMarcas.TabIndex = 51;
            // 
            // TxtCodigoGenerado
            // 
            this.TxtCodigoGenerado.Enabled = false;
            this.TxtCodigoGenerado.Location = new System.Drawing.Point(169, 20);
            this.TxtCodigoGenerado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtCodigoGenerado.Name = "TxtCodigoGenerado";
            this.TxtCodigoGenerado.Size = new System.Drawing.Size(145, 22);
            this.TxtCodigoGenerado.TabIndex = 50;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(27, 20);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 16);
            this.label15.TabIndex = 49;
            this.label15.Text = "Codigo";
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(765, 215);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(180, 24);
            this.cboEstado.TabIndex = 48;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(697, 215);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 16);
            this.label4.TabIndex = 47;
            this.label4.Text = "Estado";
            // 
            // btnQuitar
            // 
            this.btnQuitar.Location = new System.Drawing.Point(529, 362);
            this.btnQuitar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuitar.Name = "btnQuitar";
            this.btnQuitar.Size = new System.Drawing.Size(53, 32);
            this.btnQuitar.TabIndex = 12;
            this.btnQuitar.Text = ">>";
            this.btnQuitar.UseVisualStyleBackColor = true;
            this.btnQuitar.Click += new System.EventHandler(this.btnQuitar_Click);
            // 
            // btnAñadir
            // 
            this.btnAñadir.Location = new System.Drawing.Point(529, 309);
            this.btnAñadir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAñadir.Name = "btnAñadir";
            this.btnAñadir.Size = new System.Drawing.Size(53, 32);
            this.btnAñadir.TabIndex = 11;
            this.btnAñadir.Text = "<<";
            this.btnAñadir.UseVisualStyleBackColor = true;
            this.btnAñadir.Click += new System.EventHandler(this.btnAñadir_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 279);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 16);
            this.label3.TabIndex = 44;
            this.label3.Text = "Marca";
            // 
            // cboMarca
            // 
            this.cboMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(111, 276);
            this.cboMarca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(219, 24);
            this.cboMarca.TabIndex = 10;
            // 
            // optSinMarca
            // 
            this.optSinMarca.AutoSize = true;
            this.optSinMarca.Location = new System.Drawing.Point(169, 279);
            this.optSinMarca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optSinMarca.Name = "optSinMarca";
            this.optSinMarca.Size = new System.Drawing.Size(88, 20);
            this.optSinMarca.TabIndex = 9;
            this.optSinMarca.Text = "Sin Marca";
            this.optSinMarca.UseVisualStyleBackColor = true;
            this.optSinMarca.CheckedChanged += new System.EventHandler(this.optSinMarca_CheckedChanged);
            // 
            // optMarca
            // 
            this.optMarca.AutoSize = true;
            this.optMarca.Checked = true;
            this.optMarca.Location = new System.Drawing.Point(30, 295);
            this.optMarca.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.optMarca.Name = "optMarca";
            this.optMarca.Size = new System.Drawing.Size(93, 20);
            this.optMarca.TabIndex = 8;
            this.optMarca.TabStop = true;
            this.optMarca.Text = "Con Marca";
            this.optMarca.UseVisualStyleBackColor = true;
            this.optMarca.CheckedChanged += new System.EventHandler(this.optMarca_CheckedChanged);
            // 
            // txtCorreoElectronico
            // 
            this.txtCorreoElectronico.Location = new System.Drawing.Point(169, 154);
            this.txtCorreoElectronico.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCorreoElectronico.MaxLength = 50;
            this.txtCorreoElectronico.Name = "txtCorreoElectronico";
            this.txtCorreoElectronico.Size = new System.Drawing.Size(504, 22);
            this.txtCorreoElectronico.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 162);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(118, 16);
            this.label9.TabIndex = 36;
            this.label9.Text = "Correo Electronico";
            // 
            // txtNombreComercial
            // 
            this.txtNombreComercial.Location = new System.Drawing.Point(169, 86);
            this.txtNombreComercial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreComercial.MaxLength = 50;
            this.txtNombreComercial.Name = "txtNombreComercial";
            this.txtNombreComercial.Size = new System.Drawing.Size(504, 22);
            this.txtNombreComercial.TabIndex = 4;
            // 
            // txtPaginaWeb
            // 
            this.txtPaginaWeb.Location = new System.Drawing.Point(169, 118);
            this.txtPaginaWeb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtPaginaWeb.MaxLength = 50;
            this.txtPaginaWeb.Name = "txtPaginaWeb";
            this.txtPaginaWeb.Size = new System.Drawing.Size(504, 22);
            this.txtPaginaWeb.TabIndex = 5;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 122);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 16);
            this.label8.TabIndex = 33;
            this.label8.Text = "Pagina Web";
            // 
            // dtpFecha
            // 
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFecha.Location = new System.Drawing.Point(169, 196);
            this.dtpFecha.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(160, 22);
            this.dtpFecha.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 196);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 16);
            this.label7.TabIndex = 31;
            this.label7.Text = "Fecha Aniversario";
            // 
            // txtNumero
            // 
            this.txtNumero.Location = new System.Drawing.Point(765, 15);
            this.txtNumero.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumero.MaxLength = 50;
            this.txtNumero.Name = "txtNumero";
            this.txtNumero.Size = new System.Drawing.Size(127, 22);
            this.txtNumero.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(677, 23);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Numero";
            // 
            // cboTipoDocumento
            // 
            this.cboTipoDocumento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTipoDocumento.FormattingEnabled = true;
            this.cboTipoDocumento.Location = new System.Drawing.Point(489, 16);
            this.cboTipoDocumento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboTipoDocumento.Name = "cboTipoDocumento";
            this.cboTipoDocumento.Size = new System.Drawing.Size(160, 24);
            this.cboTipoDocumento.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 86);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "Nombre Comercial";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(345, 23);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 16);
            this.label6.TabIndex = 15;
            this.label6.Text = "Tipo Documento";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Location = new System.Drawing.Point(169, 54);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRazonSocial.MaxLength = 50;
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(504, 22);
            this.txtRazonSocial.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 54);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 16);
            this.label5.TabIndex = 12;
            this.label5.Text = "Razon Social";
            // 
            // tabContacto
            // 
            this.tabContacto.Controls.Add(this.label17);
            this.tabContacto.Controls.Add(this.txtCorreo);
            this.tabContacto.Controls.Add(this.btnAgregarContacto);
            this.tabContacto.Controls.Add(this.btnQuitarContacto);
            this.tabContacto.Controls.Add(this.dgvContactos);
            this.tabContacto.Controls.Add(this.TxtNumeroTel);
            this.tabContacto.Controls.Add(this.label14);
            this.tabContacto.Controls.Add(this.cboOperador);
            this.tabContacto.Controls.Add(this.label13);
            this.tabContacto.Controls.Add(this.TxtArea);
            this.tabContacto.Controls.Add(this.label12);
            this.tabContacto.Controls.Add(this.TxtCargo);
            this.tabContacto.Controls.Add(this.label11);
            this.tabContacto.Controls.Add(this.TxtContacto);
            this.tabContacto.Controls.Add(this.label10);
            this.tabContacto.Location = new System.Drawing.Point(4, 25);
            this.tabContacto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabContacto.Name = "tabContacto";
            this.tabContacto.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabContacto.Size = new System.Drawing.Size(1308, 510);
            this.tabContacto.TabIndex = 1;
            this.tabContacto.Text = "Contactos";
            this.tabContacto.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(655, 100);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(111, 16);
            this.label17.TabIndex = 51;
            this.label17.Text = "Correo Eletronico";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Location = new System.Drawing.Point(659, 121);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(299, 22);
            this.txtCorreo.TabIndex = 50;
            // 
            // btnAgregarContacto
            // 
            this.btnAgregarContacto.Location = new System.Drawing.Point(1244, 183);
            this.btnAgregarContacto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAgregarContacto.Name = "btnAgregarContacto";
            this.btnAgregarContacto.Size = new System.Drawing.Size(53, 32);
            this.btnAgregarContacto.TabIndex = 49;
            this.btnAgregarContacto.Text = "<<";
            this.btnAgregarContacto.UseVisualStyleBackColor = true;
            this.btnAgregarContacto.Click += new System.EventHandler(this.btnAgregarContacto_Click);
            // 
            // btnQuitarContacto
            // 
            this.btnQuitarContacto.Location = new System.Drawing.Point(1244, 235);
            this.btnQuitarContacto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnQuitarContacto.Name = "btnQuitarContacto";
            this.btnQuitarContacto.Size = new System.Drawing.Size(53, 32);
            this.btnQuitarContacto.TabIndex = 48;
            this.btnQuitarContacto.Text = ">>";
            this.btnQuitarContacto.UseVisualStyleBackColor = true;
            this.btnQuitarContacto.Click += new System.EventHandler(this.btnQuitarContacto_Click);
            // 
            // dgvContactos
            // 
            this.dgvContactos.AllowUserToAddRows = false;
            this.dgvContactos.AllowUserToDeleteRows = false;
            this.dgvContactos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvContactos.Location = new System.Drawing.Point(27, 183);
            this.dgvContactos.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvContactos.Name = "dgvContactos";
            this.dgvContactos.RowHeadersWidth = 51;
            this.dgvContactos.Size = new System.Drawing.Size(1193, 289);
            this.dgvContactos.TabIndex = 47;
            // 
            // TxtNumeroTel
            // 
            this.TxtNumeroTel.Location = new System.Drawing.Point(351, 119);
            this.TxtNumeroTel.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtNumeroTel.Name = "TxtNumeroTel";
            this.TxtNumeroTel.Size = new System.Drawing.Size(299, 22);
            this.TxtNumeroTel.TabIndex = 46;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(347, 100);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(55, 16);
            this.label14.TabIndex = 45;
            this.label14.Text = "Numero";
            // 
            // cboOperador
            // 
            this.cboOperador.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboOperador.FormattingEnabled = true;
            this.cboOperador.Location = new System.Drawing.Point(27, 119);
            this.cboOperador.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cboOperador.Name = "cboOperador";
            this.cboOperador.Size = new System.Drawing.Size(300, 24);
            this.cboOperador.TabIndex = 44;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(23, 100);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 16);
            this.label13.TabIndex = 20;
            this.label13.Text = "Operador";
            // 
            // TxtArea
            // 
            this.TxtArea.Location = new System.Drawing.Point(659, 58);
            this.TxtArea.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtArea.Name = "TxtArea";
            this.TxtArea.Size = new System.Drawing.Size(299, 22);
            this.TxtArea.TabIndex = 19;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(672, 38);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(36, 16);
            this.label12.TabIndex = 18;
            this.label12.Text = "Area";
            // 
            // TxtCargo
            // 
            this.TxtCargo.Location = new System.Drawing.Point(351, 58);
            this.TxtCargo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtCargo.Name = "TxtCargo";
            this.TxtCargo.Size = new System.Drawing.Size(299, 22);
            this.TxtCargo.TabIndex = 17;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(347, 38);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(44, 16);
            this.label11.TabIndex = 16;
            this.label11.Text = "Cargo";
            // 
            // TxtContacto
            // 
            this.TxtContacto.Location = new System.Drawing.Point(27, 63);
            this.TxtContacto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.TxtContacto.Name = "TxtContacto";
            this.TxtContacto.Size = new System.Drawing.Size(299, 22);
            this.TxtContacto.TabIndex = 15;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 38);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(60, 16);
            this.label10.TabIndex = 14;
            this.label10.Text = "Contacto";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(593, 389);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(139, 50);
            this.btnSalir.TabIndex = 39;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnRegistrar
            // 
            this.btnRegistrar.Location = new System.Drawing.Point(446, 389);
            this.btnRegistrar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegistrar.Name = "btnRegistrar";
            this.btnRegistrar.Size = new System.Drawing.Size(139, 50);
            this.btnRegistrar.TabIndex = 38;
            this.btnRegistrar.Text = "Registrar";
            this.btnRegistrar.UseVisualStyleBackColor = true;
            this.btnRegistrar.Click += new System.EventHandler(this.btnRegistrar_Click_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(918, 15);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 24);
            this.button1.TabIndex = 54;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmRegProveedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1365, 454);
            this.Controls.Add(this.tabProveedor);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRegistrar);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "frmRegProveedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGA - Registro / Actualizacion de Proveedor";
            this.Load += new System.EventHandler(this.frmRegProveedor_Load);
            this.tabProveedor.ResumeLayout(false);
            this.tabPrincipal.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMarcas)).EndInit();
            this.tabContacto.ResumeLayout(false);
            this.tabContacto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvContactos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TabControl tabProveedor;
        private System.Windows.Forms.TabPage tabPrincipal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.RadioButton optSinMarca;
        private System.Windows.Forms.RadioButton optMarca;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnRegistrar;
        private System.Windows.Forms.TextBox txtCorreoElectronico;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtNombreComercial;
        private System.Windows.Forms.TextBox txtPaginaWeb;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNumero;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboTipoDocumento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TabPage tabContacto;
        private System.Windows.Forms.Button btnQuitar;
        private System.Windows.Forms.Button btnAñadir;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregarContacto;
        private System.Windows.Forms.Button btnQuitarContacto;
        private System.Windows.Forms.DataGridView dgvContactos;
        private System.Windows.Forms.TextBox TxtNumeroTel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboOperador;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox TxtArea;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox TxtCargo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox TxtContacto;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TxtCodigoGenerado;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgvMarcas;
        private System.Windows.Forms.TextBox txtDirecion;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Button button1;
    }
}