﻿namespace SIGA.Windows.Ventas.Formularios
{
    partial class frmMantenimientoGuia
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboVendedor = new System.Windows.Forms.ComboBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.rbF = new System.Windows.Forms.RadioButton();
            this.rbM = new System.Windows.Forms.RadioButton();
            this.label20 = new System.Windows.Forms.Label();
            this.txtCodigoCliente = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtRazonSocial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dtFin = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtInicio = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dgvGuia = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnAnula = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuia)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboVendedor);
            this.groupBox1.Controls.Add(this.label33);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.rbF);
            this.groupBox1.Controls.Add(this.rbM);
            this.groupBox1.Controls.Add(this.label20);
            this.groupBox1.Controls.Add(this.txtCodigoCliente);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.txtRazonSocial);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Location = new System.Drawing.Point(14, 43);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(809, 134);
            this.groupBox1.TabIndex = 104;
            this.groupBox1.TabStop = false;
            // 
            // cboVendedor
            // 
            this.cboVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboVendedor.FormattingEnabled = true;
            this.cboVendedor.Location = new System.Drawing.Point(67, 70);
            this.cboVendedor.Margin = new System.Windows.Forms.Padding(4);
            this.cboVendedor.Name = "cboVendedor";
            this.cboVendedor.Size = new System.Drawing.Size(638, 24);
            this.cboVendedor.TabIndex = 99;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(0, 73);
            this.label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(70, 17);
            this.label33.TabIndex = 98;
            this.label33.Text = "Vendedor";
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(9, 190);
            this.label36.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(0, 17);
            this.label36.TabIndex = 83;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(713, 26);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 24);
            this.button2.TabIndex = 4;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // rbF
            // 
            this.rbF.AutoSize = true;
            this.rbF.Location = new System.Drawing.Point(1116, 130);
            this.rbF.Margin = new System.Windows.Forms.Padding(4);
            this.rbF.Name = "rbF";
            this.rbF.Size = new System.Drawing.Size(91, 21);
            this.rbF.TabIndex = 62;
            this.rbF.TabStop = true;
            this.rbF.Text = "Femenino";
            this.rbF.UseVisualStyleBackColor = true;
            this.rbF.Visible = false;
            // 
            // rbM
            // 
            this.rbM.AutoSize = true;
            this.rbM.Location = new System.Drawing.Point(1011, 132);
            this.rbM.Margin = new System.Windows.Forms.Padding(4);
            this.rbM.Name = "rbM";
            this.rbM.Size = new System.Drawing.Size(92, 21);
            this.rbM.TabIndex = 61;
            this.rbM.TabStop = true;
            this.rbM.Text = "Masculino";
            this.rbM.UseVisualStyleBackColor = true;
            this.rbM.Visible = false;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(961, 135);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(39, 17);
            this.label20.TabIndex = 60;
            this.label20.Text = "Sexo";
            this.label20.Visible = false;
            // 
            // txtCodigoCliente
            // 
            this.txtCodigoCliente.Enabled = false;
            this.txtCodigoCliente.Location = new System.Drawing.Point(67, 27);
            this.txtCodigoCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtCodigoCliente.Name = "txtCodigoCliente";
            this.txtCodigoCliente.Size = new System.Drawing.Size(122, 22);
            this.txtCodigoCliente.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 27);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(52, 17);
            this.label15.TabIndex = 49;
            this.label15.Text = "Codigo";
            // 
            // txtRazonSocial
            // 
            this.txtRazonSocial.Enabled = false;
            this.txtRazonSocial.Location = new System.Drawing.Point(282, 27);
            this.txtRazonSocial.Margin = new System.Windows.Forms.Padding(4);
            this.txtRazonSocial.MaxLength = 35;
            this.txtRazonSocial.Name = "txtRazonSocial";
            this.txtRazonSocial.Size = new System.Drawing.Size(423, 22);
            this.txtRazonSocial.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(197, 30);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 17);
            this.label8.TabIndex = 12;
            this.label8.Text = "Razon Social";
            // 
            // dtFin
            // 
            this.dtFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFin.Location = new System.Drawing.Point(259, 14);
            this.dtFin.Name = "dtFin";
            this.dtFin.Size = new System.Drawing.Size(103, 22);
            this.dtFin.TabIndex = 103;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(211, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(20, 17);
            this.label1.TabIndex = 102;
            this.label1.Text = "Al";
            // 
            // dtInicio
            // 
            this.dtInicio.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtInicio.Location = new System.Drawing.Point(81, 12);
            this.dtInicio.Name = "dtInicio";
            this.dtInicio.Size = new System.Drawing.Size(103, 22);
            this.dtInicio.TabIndex = 101;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 18);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 17);
            this.label4.TabIndex = 100;
            this.label4.Text = "Del";
            // 
            // dgvGuia
            // 
            this.dgvGuia.AllowUserToAddRows = false;
            this.dgvGuia.AllowUserToDeleteRows = false;
            this.dgvGuia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGuia.Location = new System.Drawing.Point(14, 203);
            this.dgvGuia.Margin = new System.Windows.Forms.Padding(4);
            this.dgvGuia.Name = "dgvGuia";
            this.dgvGuia.RowHeadersWidth = 51;
            this.dgvGuia.Size = new System.Drawing.Size(1156, 374);
            this.dgvGuia.TabIndex = 96;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(869, 128);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(125, 49);
            this.button1.TabIndex = 99;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(670, 585);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(125, 49);
            this.btnModificar.TabIndex = 98;
            this.btnModificar.Text = "Salir";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.Location = new System.Drawing.Point(267, 583);
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(4);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(125, 49);
            this.btnNuevo.TabIndex = 97;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(535, 585);
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(4);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(127, 47);
            this.btnImprimir.TabIndex = 119;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnAnula
            // 
            this.btnAnula.Location = new System.Drawing.Point(400, 585);
            this.btnAnula.Margin = new System.Windows.Forms.Padding(4);
            this.btnAnula.Name = "btnAnula";
            this.btnAnula.Size = new System.Drawing.Size(127, 47);
            this.btnAnula.TabIndex = 120;
            this.btnAnula.Text = "Anular";
            this.btnAnula.UseVisualStyleBackColor = true;
            this.btnAnula.Click += new System.EventHandler(this.btnAnula_Click);
            // 
            // frmMantenimientoGuia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 647);
            this.Controls.Add(this.btnAnula);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtFin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtInicio);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dgvGuia);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnModificar);
            this.Controls.Add(this.btnNuevo);
            this.Name = "frmMantenimientoGuia";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGA - Guias de Control";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGuia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cboVendedor;
        private System.Windows.Forms.Label label33;
        private System.Windows.Forms.Label label36;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.RadioButton rbF;
        private System.Windows.Forms.RadioButton rbM;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.TextBox txtCodigoCliente;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtRazonSocial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtFin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtInicio;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgvGuia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnAnula;
    }
}