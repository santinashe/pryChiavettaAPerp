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
            this.txtDNI = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblApellido = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.gbDomicilio = new System.Windows.Forms.GroupBox();
            this.txtGeo = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lblGeo = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.gbUbicacion = new System.Windows.Forms.GroupBox();
            this.lblProvincia = new System.Windows.Forms.Label();
            this.lblLocalidad = new System.Windows.Forms.Label();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCerrar = new System.Windows.Forms.Button();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.gbPersona.SuspendLayout();
            this.gbDomicilio.SuspendLayout();
            this.gbUbicacion.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPersona
            // 
            this.gbPersona.Controls.Add(this.txtNombre);
            this.gbPersona.Controls.Add(this.txtApellido);
            this.gbPersona.Controls.Add(this.txtDNI);
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
            this.txtNombre.Location = new System.Drawing.Point(120, 100);
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
            // txtDNI
            // 
            this.txtDNI.Location = new System.Drawing.Point(120, 30);
            this.txtDNI.Name = "txtDNI";
            this.txtDNI.Size = new System.Drawing.Size(250, 23);
            this.txtDNI.TabIndex = 3;
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
            this.lblApellido.Location = new System.Drawing.Point(14, 100);
            this.lblApellido.Name = "lblApellido";
            this.lblApellido.Size = new System.Drawing.Size(61, 16);
            this.lblApellido.TabIndex = 1;
            this.lblApellido.Text = "Apellido:";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Arial", 10F);
            this.lblDNI.Location = new System.Drawing.Point(15, 33);
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
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(120, 25);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(250, 23);
            this.txtDireccion.TabIndex = 2;
            // 
            // lblGeo
            // 
            this.lblGeo.AutoSize = true;
            this.lblGeo.Font = new System.Drawing.Font("Arial", 10F);
            this.lblGeo.Location = new System.Drawing.Point(15, 63);
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
            this.btnGuardar.Location = new System.Drawing.Point(320, 436);
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
            this.btnLimpiar.Location = new System.Drawing.Point(169, 436);
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
            this.btnCerrar.Location = new System.Drawing.Point(28, 436);
            this.btnCerrar.Name = "btnCerrar";
            this.btnCerrar.Size = new System.Drawing.Size(100, 40);
            this.btnCerrar.TabIndex = 5;
            this.btnCerrar.Text = "CERRAR";
            this.btnCerrar.UseVisualStyleBackColor = false;
            this.btnCerrar.Click += new System.EventHandler(this.btnCerrar_Click);
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Location = new System.Drawing.Point(9, 45);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(121, 24);
            this.cmbLocalidad.TabIndex = 2;
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(239, 45);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(121, 24);
            this.cmbProvincia.TabIndex = 3;
            // 
            // FormPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 550);
            this.Controls.Add(this.btnCerrar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGuardar);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPersona;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtDNI;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblApellido;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.GroupBox gbDomicilio;
        private System.Windows.Forms.TextBox txtGeo;
        private System.Windows.Forms.TextBox txtDireccion;
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
    }
}
