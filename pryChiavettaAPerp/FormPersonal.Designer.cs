namespace pryChiavettaAPerp
{
    partial class FormPersonal
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbPersona = new System.Windows.Forms.GroupBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.gbDomicilio = new System.Windows.Forms.GroupBox();
            this.txtGeo = new System.Windows.Forms.TextBox();
            this.lblGeo = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.gbUbicacion = new System.Windows.Forms.GroupBox();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblMail = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.maskedTextBox1 = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox2 = new System.Windows.Forms.MaskedTextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.gbPersona.SuspendLayout();
            this.gbDomicilio.SuspendLayout();
            this.gbUbicacion.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPersona
            // 
            this.gbPersona.Controls.Add(this.maskedTextBox2);
            this.gbPersona.Controls.Add(this.txtNombre);
            this.gbPersona.Controls.Add(this.txtApellido);
            this.gbPersona.Controls.Add(this.lblNombre);
            this.gbPersona.Controls.Add(this.lblApellido);
            this.gbPersona.Controls.Add(this.lblDNI);
            this.gbPersona.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gbPersona.Location = new System.Drawing.Point(20, 20);
            this.gbPersona.Name = "gbPersona";
            this.gbPersona.Size = new System.Drawing.Size(400, 140);
            this.gbPersona.TabIndex = 0;
            this.gbPersona.TabStop = false;
            this.gbPersona.Text = "Datos Personales";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(120, 30);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(250, 23);
            this.txtNombre.TabIndex = 5;
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(120, 65);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(250, 23);
            this.txtApellido.TabIndex = 4;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Arial", 10F);
            this.lblNombre.Location = new System.Drawing.Point(15, 68);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(60, 16);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblApellido
            // 
            this.lblApellido.AutoSize = true;
            this.lblApellido.Font = new System.Drawing.Font("Arial", 10F);
            this.lblApellido.Location = new System.Drawing.Point(15, 37);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(61, 16);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDNI.Location = new System.Drawing.Point(25, 107);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(33, 16);
            this.lblDNI.TabIndex = 0;
            this.lblDNI.Text = "DNI:";
            // 
            // gbDomicilio
            // 
            this.gbDomicilio.Controls.Add(this.txtGeo);
            this.gbDomicilio.Controls.Add(this.txtDireccion);
            this.gbDomicilio.Controls.Add(this.lblGeo);
            this.gbDomicilio.Controls.Add(this.lblDireccion);
            this.gbDomicilio.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gbDomicilio.Location = new System.Drawing.Point(20, 297);
            this.gbDomicilio.Name = "gbDomicilio";
            this.gbDomicilio.Size = new System.Drawing.Size(400, 100);
            this.gbDomicilio.TabIndex = 1;
            this.gbDomicilio.TabStop = false;
            this.gbDomicilio.Text = "Domicilio";
            this.gbDomicilio.Enter += new System.EventHandler(this.gbDomicilio_Enter);
            // 
            // txtGeo
            // 
            this.txtGeo.Location = new System.Drawing.Point(120, 60);
            this.txtGeo.Name = "txtGeo";
            this.txtGeo.Size = new System.Drawing.Size(250, 23);
            this.txtGeo.TabIndex = 3;
            // 
            // lblGeo
            // 
            this.lblGeo.AutoSize = true;
            this.lblGeo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblGeo.Location = new System.Drawing.Point(6, 63);
            this.lblGeo.Name = "lblGeo";
            this.lblGeo.Size = new System.Drawing.Size(110, 16);
            this.lblGeo.TabIndex = 1;
            this.lblGeo.Text = "Geolocalización:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDireccion.Location = new System.Drawing.Point(15, 28);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(70, 16);
            this.lblDireccion.TabIndex = 0;
            this.lblDireccion.Text = "Dirección:";
            // 
            // gbUbicacion
            // 
            this.gbUbicacion.Controls.Add(this.cmbProvincia);
            this.gbUbicacion.Controls.Add(this.cmbLocalidad);
            this.gbUbicacion.Controls.Add(this.lblProvincia);
            this.gbUbicacion.Controls.Add(this.lblLocalidad);
            this.gbUbicacion.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.gbUbicacion.Location = new System.Drawing.Point(20, 176);
            this.gbUbicacion.Name = "gbUbicacion";
            this.gbUbicacion.Size = new System.Drawing.Size(400, 101);
            this.gbUbicacion.TabIndex = 2;
            this.gbUbicacion.TabStop = false;
            this.gbUbicacion.Text = "Ubicación";
            this.gbUbicacion.Enter += new System.EventHandler(this.gbUbicacion_Enter);
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(239, 45);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(121, 24);
            this.cmbProvincia.TabIndex = 3;
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(9, 45);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(121, 24);
            this.cmbLocalidad.TabIndex = 2;
            // 
            // lblProvincia
            // 
            this.lblProvincia.AutoSize = true;
            this.lblProvincia.Font = new System.Drawing.Font("Arial", 10F);
            this.lblProvincia.Location = new System.Drawing.Point(267, 18);
            this.lblProvincia.Name = "lblProvincia";
            this.lblProvincia.Size = new System.Drawing.Size(69, 16);
            this.lblProvincia.TabIndex = 1;
            this.lblProvincia.Text = "Provincia:";
            // 
            // lblLocalidad
            // 
            this.lblLocalidad.AutoSize = true;
            this.lblLocalidad.Font = new System.Drawing.Font("Arial", 10F);
            this.lblLocalidad.Location = new System.Drawing.Point(36, 18);
            this.lblLocalidad.Name = "lblLocalidad";
            this.lblLocalidad.Size = new System.Drawing.Size(72, 16);
            this.lblLocalidad.TabIndex = 0;
            this.lblLocalidad.Text = "Localidad:";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Green;
            this.btnGuardar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(516, 13);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(100, 40);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.Orange;
            this.btnLimpiar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(307, 13);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(100, 40);
            this.btnLimpiar.TabIndex = 4;
            this.btnLimpiar.Text = "LIMPIAR";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnCerrar
            // 
            this.btnCerrar.BackColor = System.Drawing.Color.Red;
            this.btnCerrar.Font = new System.Drawing.Font("Arial", 10F, System.Drawing.FontStyle.Bold);
            this.btnCerrar.ForeColor = System.Drawing.Color.White;
            this.btnCerrar.Location = new System.Drawing.Point(62, 13);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 40);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkBox2);
            this.groupBox2.Controls.Add(this.checkBox1);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(18, 302);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(239, 69);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Estado de ususario";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.LimeGreen;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Activo";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(77, 30);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(198, 26);
            this.textBox2.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 10F);
            this.label3.Location = new System.Drawing.Point(6, 114);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Redes sociales:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 10F);
            this.label2.Location = new System.Drawing.Point(6, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Telefono:";
            // 
            // lblMail
            // 
            this.lblMail.AutoSize = true;
            this.lblMail.Font = new System.Drawing.Font("Arial", 10F);
            this.lblMail.Location = new System.Drawing.Point(15, 34);
            this.lblMail.Name = "lblMail";
            this.lblMail.Size = new System.Drawing.Size(36, 16);
            this.lblMail.TabIndex = 6;
            this.lblMail.Text = "Mail:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.maskedTextBox1);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBox7);
            this.groupBox1.Controls.Add(this.textBox6);
            this.groupBox1.Controls.Add(this.textBox5);
            this.groupBox1.Controls.Add(this.textBox4);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.lblMail);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(426, 20);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(284, 377);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contactos";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(143, 164);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 26);
            this.textBox1.TabIndex = 6;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(143, 199);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(132, 26);
            this.textBox4.TabIndex = 9;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(143, 234);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(132, 26);
            this.textBox5.TabIndex = 10;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(143, 270);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(132, 26);
            this.textBox6.TabIndex = 11;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(143, 132);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(132, 26);
            this.textBox7.TabIndex = 12;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 10F);
            this.label4.Location = new System.Drawing.Point(43, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Instagram";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 10F);
            this.label5.Location = new System.Drawing.Point(43, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(70, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Facebook";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Arial", 10F);
            this.label6.Location = new System.Drawing.Point(51, 270);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Tiktok";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Arial", 10F);
            this.label7.Location = new System.Drawing.Point(48, 244);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(0, 16);
            this.label7.TabIndex = 14;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Arial", 10F);
            this.label8.Location = new System.Drawing.Point(-28, 232);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 16);
            this.label8.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial", 10F);
            this.label9.Location = new System.Drawing.Point(48, 238);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 15;
            this.label9.Text = "X(twiter)";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 10F);
            this.label10.Location = new System.Drawing.Point(44, 204);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "Telegram";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.panel1.Controls.Add(this.btnCerrar);
            this.panel1.Controls.Add(this.btnLimpiar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel1.Location = new System.Drawing.Point(58, 423);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(643, 72);
            this.panel1.TabIndex = 7;
            // 
            // maskedTextBox1
            // 
            this.maskedTextBox1.Location = new System.Drawing.Point(93, 72);
            this.maskedTextBox1.Mask = "000-000-0000";
            this.maskedTextBox1.Name = "maskedTextBox1";
            this.maskedTextBox1.Size = new System.Drawing.Size(173, 26);
            this.maskedTextBox1.TabIndex = 17;
            // 
            // maskedTextBox2
            // 
            this.maskedTextBox2.Location = new System.Drawing.Point(152, 100);
            this.maskedTextBox2.Mask = "9999999999";
            this.maskedTextBox2.Name = "maskedTextBox2";
            this.maskedTextBox2.Size = new System.Drawing.Size(136, 23);
            this.maskedTextBox2.TabIndex = 18;
            this.maskedTextBox2.ValidatingType = typeof(int);
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(120, 25);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(250, 23);
            this.txtDireccion.TabIndex = 2;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(127, 32);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(67, 18);
            this.label11.TabIndex = 1;
            this.label11.Text = "Inactivo";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(73, 35);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(215, 35);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 3;
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // FormPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbUbicacion);
            this.Controls.Add(this.gbDomicilio);
            this.Controls.Add(this.gbPersona);
            this.Font = new System.Drawing.Font("Arial", 10F);
            this.Name = "FormPersonal";
            this.Text = "Datos Personales";
            this.Load += new System.EventHandler(this.FormPersonal_Load);
            this.gbPersona.ResumeLayout(false);
            this.gbPersona.PerformLayout();
            this.gbDomicilio.ResumeLayout(false);
            this.gbDomicilio.PerformLayout();
            this.gbUbicacion.ResumeLayout(false);
            this.gbUbicacion.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPersona;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.GroupBox gbDomicilio;
        private System.Windows.Forms.TextBox txtGeo;
        private System.Windows.Forms.Label lblGeo;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.GroupBox gbUbicacion;
        private System.Windows.Forms.Label lblProvincia;
        private System.Windows.Forms.Label lblLocalidad;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCerrar;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblMail;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MaskedTextBox maskedTextBox2;
        private System.Windows.Forms.MaskedTextBox maskedTextBox1;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label label11;
    }
}
