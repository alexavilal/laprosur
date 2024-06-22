namespace SIGA.Windows.Caja
{
    partial class frmCierreCaja
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvBillete = new System.Windows.Forms.DataGridView();
            this.Codigo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Valor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label2 = new System.Windows.Forms.Label();
            this.dgvTarjetas = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtSaldoEfectivo = new System.Windows.Forms.TextBox();
            this.txtSaldoTarjeta = new System.Windows.Forms.TextBox();
            this.txtSaldoCheques = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTotalRecaudado = new System.Windows.Forms.TextBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFecha = new System.Windows.Forms.TextBox();
            this.cboBillete = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCantidadBillete = new System.Windows.Forms.TextBox();
            this.txtCantidadMoneda = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cboMoneda = new System.Windows.Forms.ComboBox();
            this.btnAgregarBillte = new System.Windows.Forms.Button();
            this.btnQuitarBillete = new System.Windows.Forms.Button();
            this.dgvMoneda = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cantid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnQuitarMoneda = new System.Windows.Forms.Button();
            this.btnAgregarMoneda = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.txtTotalBilletes = new System.Windows.Forms.TextBox();
            this.txtTotalMoneda = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillete)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarjetas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoneda)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Saldo en Efectivo";
            // 
            // dgvBillete
            // 
            this.dgvBillete.AllowUserToAddRows = false;
            this.dgvBillete.AllowUserToDeleteRows = false;
            this.dgvBillete.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillete.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Codigo,
            this.Valor,
            this.Cantidad,
            this.Total});
            this.dgvBillete.Location = new System.Drawing.Point(14, 108);
            this.dgvBillete.Name = "dgvBillete";
            this.dgvBillete.Size = new System.Drawing.Size(346, 103);
            this.dgvBillete.TabIndex = 1;
            // 
            // Codigo
            // 
            this.Codigo.HeaderText = "Codigo";
            this.Codigo.Name = "Codigo";
            this.Codigo.Visible = false;
            // 
            // Valor
            // 
            this.Valor.HeaderText = "Valor";
            this.Valor.Name = "Valor";
            // 
            // Cantidad
            // 
            this.Cantidad.HeaderText = "Cantidad";
            this.Cantidad.Name = "Cantidad";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(28, 380);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Pago Tarjetas";
            // 
            // dgvTarjetas
            // 
            this.dgvTarjetas.AllowUserToAddRows = false;
            this.dgvTarjetas.AllowUserToDeleteRows = false;
            this.dgvTarjetas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTarjetas.Location = new System.Drawing.Point(15, 292);
            this.dgvTarjetas.Name = "dgvTarjetas";
            this.dgvTarjetas.Size = new System.Drawing.Size(347, 85);
            this.dgvTarjetas.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(379, 383);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Pago Cheques";
            // 
            // txtSaldoEfectivo
            // 
            this.txtSaldoEfectivo.Location = new System.Drawing.Point(133, 38);
            this.txtSaldoEfectivo.Name = "txtSaldoEfectivo";
            this.txtSaldoEfectivo.ReadOnly = true;
            this.txtSaldoEfectivo.Size = new System.Drawing.Size(186, 20);
            this.txtSaldoEfectivo.TabIndex = 6;
            // 
            // txtSaldoTarjeta
            // 
            this.txtSaldoTarjeta.Location = new System.Drawing.Point(201, 383);
            this.txtSaldoTarjeta.Name = "txtSaldoTarjeta";
            this.txtSaldoTarjeta.ReadOnly = true;
            this.txtSaldoTarjeta.Size = new System.Drawing.Size(159, 20);
            this.txtSaldoTarjeta.TabIndex = 7;
            this.txtSaldoTarjeta.Text = "0";
            // 
            // txtSaldoCheques
            // 
            this.txtSaldoCheques.Location = new System.Drawing.Point(510, 380);
            this.txtSaldoCheques.Name = "txtSaldoCheques";
            this.txtSaldoCheques.ReadOnly = true;
            this.txtSaldoCheques.Size = new System.Drawing.Size(159, 20);
            this.txtSaldoCheques.TabIndex = 8;
            this.txtSaldoCheques.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(363, 426);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Total Recaudado";
            // 
            // txtTotalRecaudado
            // 
            this.txtTotalRecaudado.Location = new System.Drawing.Point(510, 423);
            this.txtTotalRecaudado.Name = "txtTotalRecaudado";
            this.txtTotalRecaudado.ReadOnly = true;
            this.txtTotalRecaudado.Size = new System.Drawing.Size(197, 20);
            this.txtTotalRecaudado.TabIndex = 10;
            this.txtTotalRecaudado.TextChanged += new System.EventHandler(this.txtTotalRecaudado_TextChanged);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(448, 449);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(97, 31);
            this.btnSalir.TabIndex = 19;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(222, 449);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 31);
            this.btnGuardar.TabIndex = 18;
            this.btnGuardar.Text = "Registrar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(133, 12);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.ReadOnly = true;
            this.txtUsuario.Size = new System.Drawing.Size(178, 20);
            this.txtUsuario.TabIndex = 20;
            this.txtUsuario.Text = "jinfantas";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Usuario";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(330, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Fecha";
            // 
            // txtFecha
            // 
            this.txtFecha.Location = new System.Drawing.Point(397, 12);
            this.txtFecha.Name = "txtFecha";
            this.txtFecha.ReadOnly = true;
            this.txtFecha.Size = new System.Drawing.Size(178, 20);
            this.txtFecha.TabIndex = 23;
            this.txtFecha.Text = "23/02/2015";
            // 
            // cboBillete
            // 
            this.cboBillete.FormattingEnabled = true;
            this.cboBillete.Location = new System.Drawing.Point(66, 81);
            this.cboBillete.Name = "cboBillete";
            this.cboBillete.Size = new System.Drawing.Size(129, 21);
            this.cboBillete.TabIndex = 24;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 84);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Billetes";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(201, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(50, 13);
            this.label8.TabIndex = 26;
            this.label8.Text = "Cantidad";
            // 
            // txtCantidadBillete
            // 
            this.txtCantidadBillete.Location = new System.Drawing.Point(265, 82);
            this.txtCantidadBillete.Name = "txtCantidadBillete";
            this.txtCantidadBillete.Size = new System.Drawing.Size(54, 20);
            this.txtCantidadBillete.TabIndex = 27;
            // 
            // txtCantidadMoneda
            // 
            this.txtCantidadMoneda.Location = new System.Drawing.Point(721, 85);
            this.txtCantidadMoneda.Name = "txtCantidadMoneda";
            this.txtCantidadMoneda.Size = new System.Drawing.Size(49, 20);
            this.txtCantidadMoneda.TabIndex = 31;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(619, 87);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(50, 13);
            this.label9.TabIndex = 30;
            this.label9.Text = "Cantidad";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(433, 85);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(45, 13);
            this.label10.TabIndex = 29;
            this.label10.Text = "Moneda";
            // 
            // cboMoneda
            // 
            this.cboMoneda.FormattingEnabled = true;
            this.cboMoneda.Location = new System.Drawing.Point(484, 84);
            this.cboMoneda.Name = "cboMoneda";
            this.cboMoneda.Size = new System.Drawing.Size(129, 21);
            this.cboMoneda.TabIndex = 28;
            // 
            // btnAgregarBillte
            // 
            this.btnAgregarBillte.Location = new System.Drawing.Point(366, 108);
            this.btnAgregarBillte.Name = "btnAgregarBillte";
            this.btnAgregarBillte.Size = new System.Drawing.Size(64, 31);
            this.btnAgregarBillte.TabIndex = 32;
            this.btnAgregarBillte.Text = "<<";
            this.btnAgregarBillte.UseVisualStyleBackColor = true;
            this.btnAgregarBillte.Click += new System.EventHandler(this.btnAgregarBillte_Click);
            // 
            // btnQuitarBillete
            // 
            this.btnQuitarBillete.Location = new System.Drawing.Point(366, 145);
            this.btnQuitarBillete.Name = "btnQuitarBillete";
            this.btnQuitarBillete.Size = new System.Drawing.Size(64, 31);
            this.btnQuitarBillete.TabIndex = 33;
            this.btnQuitarBillete.Text = ">>";
            this.btnQuitarBillete.UseVisualStyleBackColor = true;
            this.btnQuitarBillete.Click += new System.EventHandler(this.btnQuitarBillete_Click);
            // 
            // dgvMoneda
            // 
            this.dgvMoneda.AllowUserToAddRows = false;
            this.dgvMoneda.AllowUserToDeleteRows = false;
            this.dgvMoneda.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMoneda.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.Cantid,
            this.dataGridViewTextBoxColumn3});
            this.dgvMoneda.Location = new System.Drawing.Point(436, 111);
            this.dgvMoneda.Name = "dgvMoneda";
            this.dgvMoneda.Size = new System.Drawing.Size(355, 103);
            this.dgvMoneda.TabIndex = 34;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Codigo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Valor";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // Cantid
            // 
            this.Cantid.HeaderText = "Cantidad";
            this.Cantid.Name = "Cantid";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Total";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // btnQuitarMoneda
            // 
            this.btnQuitarMoneda.Location = new System.Drawing.Point(797, 145);
            this.btnQuitarMoneda.Name = "btnQuitarMoneda";
            this.btnQuitarMoneda.Size = new System.Drawing.Size(64, 31);
            this.btnQuitarMoneda.TabIndex = 36;
            this.btnQuitarMoneda.Text = ">>";
            this.btnQuitarMoneda.UseVisualStyleBackColor = true;
            this.btnQuitarMoneda.Click += new System.EventHandler(this.btnQuitarMoneda_Click);
            // 
            // btnAgregarMoneda
            // 
            this.btnAgregarMoneda.Location = new System.Drawing.Point(797, 111);
            this.btnAgregarMoneda.Name = "btnAgregarMoneda";
            this.btnAgregarMoneda.Size = new System.Drawing.Size(64, 31);
            this.btnAgregarMoneda.TabIndex = 35;
            this.btnAgregarMoneda.Text = "<<";
            this.btnAgregarMoneda.UseVisualStyleBackColor = true;
            this.btnAgregarMoneda.Click += new System.EventHandler(this.btnAgregarMoneda_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(65, 220);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 13);
            this.label11.TabIndex = 37;
            this.label11.Text = "Total Billetes";
            // 
            // txtTotalBilletes
            // 
            this.txtTotalBilletes.Location = new System.Drawing.Point(163, 217);
            this.txtTotalBilletes.Name = "txtTotalBilletes";
            this.txtTotalBilletes.ReadOnly = true;
            this.txtTotalBilletes.Size = new System.Drawing.Size(88, 20);
            this.txtTotalBilletes.TabIndex = 38;
            // 
            // txtTotalMoneda
            // 
            this.txtTotalMoneda.Location = new System.Drawing.Point(614, 220);
            this.txtTotalMoneda.Name = "txtTotalMoneda";
            this.txtTotalMoneda.ReadOnly = true;
            this.txtTotalMoneda.Size = new System.Drawing.Size(88, 20);
            this.txtTotalMoneda.TabIndex = 40;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(516, 223);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 39;
            this.label12.Text = "Total Moneda";
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(333, 449);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(97, 31);
            this.btnImprimir.TabIndex = 41;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Blue;
            this.label13.Location = new System.Drawing.Point(349, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(468, 13);
            this.label13.TabIndex = 42;
            this.label13.Text = "(Saldo Inicio + Pagos Tarjetas + Pagos Cheques + Total Billetes + Total Monedas)";
            // 
            // frmCierreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(873, 484);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.txtTotalMoneda);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.txtTotalBilletes);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnQuitarMoneda);
            this.Controls.Add(this.btnAgregarMoneda);
            this.Controls.Add(this.dgvMoneda);
            this.Controls.Add(this.btnQuitarBillete);
            this.Controls.Add(this.btnAgregarBillte);
            this.Controls.Add(this.txtCantidadMoneda);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.cboMoneda);
            this.Controls.Add(this.txtCantidadBillete);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cboBillete);
            this.Controls.Add(this.txtFecha);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtTotalRecaudado);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSaldoCheques);
            this.Controls.Add(this.txtSaldoTarjeta);
            this.Controls.Add(this.txtSaldoEfectivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dgvTarjetas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvBillete);
            this.Controls.Add(this.label1);
            this.Name = "frmCierreCaja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SIGA- Detalle Cierre de Caja";
            this.Load += new System.EventHandler(this.frmCierreCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillete)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTarjetas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMoneda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvBillete;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvTarjetas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtSaldoEfectivo;
        private System.Windows.Forms.TextBox txtSaldoTarjeta;
        private System.Windows.Forms.TextBox txtSaldoCheques;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTotalRecaudado;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFecha;
        private System.Windows.Forms.ComboBox cboBillete;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCantidadBillete;
        private System.Windows.Forms.TextBox txtCantidadMoneda;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cboMoneda;
        private System.Windows.Forms.Button btnAgregarBillte;
        private System.Windows.Forms.Button btnQuitarBillete;
        private System.Windows.Forms.DataGridView dgvMoneda;
        private System.Windows.Forms.Button btnQuitarMoneda;
        private System.Windows.Forms.Button btnAgregarMoneda;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtTotalBilletes;
        private System.Windows.Forms.TextBox txtTotalMoneda;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Codigo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Valor;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cantid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label label13;
    }
}