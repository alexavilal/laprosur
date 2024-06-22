namespace SIGA.Windows.Logistica.Formularios
{
    partial class frmMantenimientoProducto
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
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnModificar = new System.Windows.Forms.Button();
            this.XT = new System.Windows.Forms.GroupBox();
            this.cboEstado = new System.Windows.Forms.ComboBox();
            this.cboUnidadMedida = new System.Windows.Forms.ComboBox();
            this.label28 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cboCapacidad = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtCodigoGeneral = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cboFamilia = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboUnidad = new System.Windows.Forms.ComboBox();
            this.cboClasificacion = new System.Windows.Forms.ComboBox();
            this.lblCodigoGeneral = new System.Windows.Forms.Label();
            this.Capacidad = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cboEmpaque = new System.Windows.Forms.ComboBox();
            this.txtCodigoBarra = new System.Windows.Forms.TextBox();
            this.cboSubFamilia = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.cboSeccion = new System.Windows.Forms.ComboBox();
            this.cboForma = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cboColor = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboEmpresa = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cboMaterial = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.cboVentas = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.XT.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(552, 624);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(129, 38);
            this.btnSalir.TabIndex = 12;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(283, 624);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(129, 38);
            this.btnNuevo.TabIndex = 11;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(10, 268);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1042, 348);
            this.dataGridView1.TabIndex = 9;
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(420, 624);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(129, 38);
            this.btnModificar.TabIndex = 13;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // XT
            // 
            this.XT.Controls.Add(this.cboVentas);
            this.XT.Controls.Add(this.cboEstado);
            this.XT.Controls.Add(this.label13);
            this.XT.Controls.Add(this.cboUnidadMedida);
            this.XT.Controls.Add(this.label28);
            this.XT.Controls.Add(this.label21);
            this.XT.Controls.Add(this.label14);
            this.XT.Controls.Add(this.cboCapacidad);
            this.XT.Controls.Add(this.label10);
            this.XT.Controls.Add(this.button1);
            this.XT.Controls.Add(this.label9);
            this.XT.Controls.Add(this.txtCodigoGeneral);
            this.XT.Controls.Add(this.txtDescripcion);
            this.XT.Controls.Add(this.label8);
            this.XT.Controls.Add(this.cboFamilia);
            this.XT.Controls.Add(this.label4);
            this.XT.Controls.Add(this.cboUnidad);
            this.XT.Location = new System.Drawing.Point(10, 79);
            this.XT.Margin = new System.Windows.Forms.Padding(4);
            this.XT.Name = "XT";
            this.XT.Padding = new System.Windows.Forms.Padding(4);
            this.XT.Size = new System.Drawing.Size(1039, 181);
            this.XT.TabIndex = 14;
            this.XT.TabStop = false;
            // 
            // cboEstado
            // 
            this.cboEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboEstado.FormattingEnabled = true;
            this.cboEstado.Location = new System.Drawing.Point(562, 134);
            this.cboEstado.Margin = new System.Windows.Forms.Padding(4);
            this.cboEstado.Name = "cboEstado";
            this.cboEstado.Size = new System.Drawing.Size(180, 24);
            this.cboEstado.TabIndex = 89;
            // 
            // cboUnidadMedida
            // 
            this.cboUnidadMedida.FormattingEnabled = true;
            this.cboUnidadMedida.Location = new System.Drawing.Point(553, 22);
            this.cboUnidadMedida.Margin = new System.Windows.Forms.Padding(4);
            this.cboUnidadMedida.Name = "cboUnidadMedida";
            this.cboUnidadMedida.Size = new System.Drawing.Size(244, 24);
            this.cboUnidadMedida.TabIndex = 81;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(425, 140);
            this.label28.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(50, 16);
            this.label28.TabIndex = 85;
            this.label28.Text = "Estado";
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
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(425, 25);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(100, 16);
            this.label14.TabIndex = 83;
            this.label14.Text = "Unidad Medida";
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
            this.button1.Location = new System.Drawing.Point(882, 118);
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
            this.label9.Location = new System.Drawing.Point(29, 67);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(51, 16);
            this.label9.TabIndex = 77;
            this.label9.Text = "Codigo";
            // 
            // txtCodigoGeneral
            // 
            this.txtCodigoGeneral.Location = new System.Drawing.Point(143, 64);
            this.txtCodigoGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoGeneral.Name = "txtCodigoGeneral";
            this.txtCodigoGeneral.Size = new System.Drawing.Size(244, 22);
            this.txtCodigoGeneral.TabIndex = 76;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(143, 102);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(708, 22);
            this.txtDescripcion.TabIndex = 75;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(29, 105);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 74;
            this.label8.Text = "Descripcion";
            // 
            // cboFamilia
            // 
            this.cboFamilia.FormattingEnabled = true;
            this.cboFamilia.Location = new System.Drawing.Point(143, 22);
            this.cboFamilia.Margin = new System.Windows.Forms.Padding(4);
            this.cboFamilia.Name = "cboFamilia";
            this.cboFamilia.Size = new System.Drawing.Size(244, 24);
            this.cboFamilia.TabIndex = 9;
            this.cboFamilia.SelectedIndexChanged += new System.EventHandler(this.cboFamilia_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 25);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "Familia";
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
            // cboClasificacion
            // 
            this.cboClasificacion.FormattingEnabled = true;
            this.cboClasificacion.Location = new System.Drawing.Point(1219, 142);
            this.cboClasificacion.Margin = new System.Windows.Forms.Padding(4);
            this.cboClasificacion.Name = "cboClasificacion";
            this.cboClasificacion.Size = new System.Drawing.Size(244, 24);
            this.cboClasificacion.TabIndex = 93;
            // 
            // lblCodigoGeneral
            // 
            this.lblCodigoGeneral.AutoSize = true;
            this.lblCodigoGeneral.Location = new System.Drawing.Point(1294, 170);
            this.lblCodigoGeneral.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCodigoGeneral.Name = "lblCodigoGeneral";
            this.lblCodigoGeneral.Size = new System.Drawing.Size(83, 16);
            this.lblCodigoGeneral.TabIndex = 92;
            this.lblCodigoGeneral.Text = "Clasificacion";
            // 
            // Capacidad
            // 
            this.Capacidad.FormattingEnabled = true;
            this.Capacidad.Location = new System.Drawing.Point(1190, 195);
            this.Capacidad.Margin = new System.Windows.Forms.Padding(4);
            this.Capacidad.Name = "Capacidad";
            this.Capacidad.Size = new System.Drawing.Size(244, 24);
            this.Capacidad.TabIndex = 87;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(1303, 145);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(74, 16);
            this.label11.TabIndex = 88;
            this.label11.Text = "Capacidad";
            // 
            // cboEmpaque
            // 
            this.cboEmpaque.FormattingEnabled = true;
            this.cboEmpaque.Location = new System.Drawing.Point(1281, 186);
            this.cboEmpaque.Margin = new System.Windows.Forms.Padding(4);
            this.cboEmpaque.Name = "cboEmpaque";
            this.cboEmpaque.Size = new System.Drawing.Size(244, 24);
            this.cboEmpaque.TabIndex = 82;
            // 
            // txtCodigoBarra
            // 
            this.txtCodigoBarra.Location = new System.Drawing.Point(1207, 188);
            this.txtCodigoBarra.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoBarra.Name = "txtCodigoBarra";
            this.txtCodigoBarra.Size = new System.Drawing.Size(244, 22);
            this.txtCodigoBarra.TabIndex = 73;
            // 
            // cboSubFamilia
            // 
            this.cboSubFamilia.FormattingEnabled = true;
            this.cboSubFamilia.Location = new System.Drawing.Point(1207, 69);
            this.cboSubFamilia.Margin = new System.Windows.Forms.Padding(4);
            this.cboSubFamilia.Name = "cboSubFamilia";
            this.cboSubFamilia.Size = new System.Drawing.Size(244, 24);
            this.cboSubFamilia.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1294, 80);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Sub Familia";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(1321, 170);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 16);
            this.label15.TabIndex = 96;
            this.label15.Text = "Seccion";
            // 
            // cboSeccion
            // 
            this.cboSeccion.FormattingEnabled = true;
            this.cboSeccion.Location = new System.Drawing.Point(1257, 158);
            this.cboSeccion.Margin = new System.Windows.Forms.Padding(4);
            this.cboSeccion.Name = "cboSeccion";
            this.cboSeccion.Size = new System.Drawing.Size(244, 24);
            this.cboSeccion.TabIndex = 8;
            // 
            // cboForma
            // 
            this.cboForma.FormattingEnabled = true;
            this.cboForma.Location = new System.Drawing.Point(1297, 250);
            this.cboForma.Margin = new System.Windows.Forms.Padding(4);
            this.cboForma.Name = "cboForma";
            this.cboForma.Size = new System.Drawing.Size(244, 24);
            this.cboForma.TabIndex = 90;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(1304, 221);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 16);
            this.label12.TabIndex = 91;
            this.label12.Text = "Forma";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1347, 97);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 16);
            this.label7.TabIndex = 72;
            this.label7.Text = "Codigo Barra";
            // 
            // cboColor
            // 
            this.cboColor.FormattingEnabled = true;
            this.cboColor.Location = new System.Drawing.Point(1335, 218);
            this.cboColor.Margin = new System.Windows.Forms.Padding(4);
            this.cboColor.Name = "cboColor";
            this.cboColor.Size = new System.Drawing.Size(244, 24);
            this.cboColor.TabIndex = 71;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1294, 231);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(39, 16);
            this.label6.TabIndex = 70;
            this.label6.Text = "Color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1315, 27);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 16);
            this.label5.TabIndex = 69;
            this.label5.Text = "Empresa";
            // 
            // cboEmpresa
            // 
            this.cboEmpresa.FormattingEnabled = true;
            this.cboEmpresa.Location = new System.Drawing.Point(1307, 52);
            this.cboEmpresa.Margin = new System.Windows.Forms.Padding(4);
            this.cboEmpresa.Name = "cboEmpresa";
            this.cboEmpresa.Size = new System.Drawing.Size(244, 24);
            this.cboEmpresa.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1294, 198);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Material";
            // 
            // cboMaterial
            // 
            this.cboMaterial.FormattingEnabled = true;
            this.cboMaterial.Location = new System.Drawing.Point(1219, 190);
            this.cboMaterial.Margin = new System.Windows.Forms.Padding(4);
            this.cboMaterial.Name = "cboMaterial";
            this.cboMaterial.Size = new System.Drawing.Size(244, 24);
            this.cboMaterial.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1332, 97);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Marca";
            // 
            // cboMarca
            // 
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(1307, 135);
            this.cboMarca.Margin = new System.Windows.Forms.Padding(4);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(244, 24);
            this.cboMarca.TabIndex = 7;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(29, 140);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(49, 16);
            this.label13.TabIndex = 97;
            this.label13.Text = "Ventas";
            // 
            // cboVentas
            // 
            this.cboVentas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVentas.FormattingEnabled = true;
            this.cboVentas.Location = new System.Drawing.Point(143, 137);
            this.cboVentas.Margin = new System.Windows.Forms.Padding(4);
            this.cboVentas.Name = "cboVentas";
            this.cboVentas.Size = new System.Drawing.Size(180, 24);
            this.cboVentas.TabIndex = 98;
            // 
            // frmMantenimientoProducto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 671);
            this.Controls.Add(this.cboClasificacion);
            this.Controls.Add(this.Capacidad);
            this.Controls.Add(this.cboSeccion);
            this.Controls.Add(this.cboEmpaque);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lblCodigoGeneral);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.XT);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.cboForma);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboEmpresa);
            this.Controls.Add(this.txtCodigoBarra);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cboMaterial);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cboColor);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboSubFamilia);
            this.Controls.Add(this.label2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMantenimientoProducto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGA - Mantenimiento de Productos";
            this.Load += new System.EventHandler(this.frmMantenimientoProducto_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.XT.ResumeLayout(false);
            this.XT.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.GroupBox XT;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtCodigoGeneral;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCodigoBarra;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboColor;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboEmpresa;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboMaterial;
        private System.Windows.Forms.ComboBox cboSubFamilia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboFamilia;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.ComboBox cboUnidad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox Capacidad;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cboUnidadMedida;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.ComboBox cboEmpaque;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cboCapacidad;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboEstado;
        private System.Windows.Forms.ComboBox cboForma;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cboClasificacion;
        private System.Windows.Forms.Label lblCodigoGeneral;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ComboBox cboSeccion;
        private System.Windows.Forms.ComboBox cboVentas;
        private System.Windows.Forms.Label label13;
    }
}