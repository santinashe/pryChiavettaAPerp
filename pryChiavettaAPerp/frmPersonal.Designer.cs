namespace pryChiavettaAPerp
{
    partial class frmPersonal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmPersonal));
            this.grbContacto = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.lblUsuarioRedes = new System.Windows.Forms.Label();
            this.txtUsuarioRedes = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.mtbTelefono = new System.Windows.Forms.MaskedTextBox();
            this.grbConexion = new System.Windows.Forms.GroupBox();
            this.chkInactivo = new System.Windows.Forms.CheckBox();
            this.chkActivo = new System.Windows.Forms.CheckBox();
            this.lblEstadoInactivo = new System.Windows.Forms.Label();
            this.lblEstadoActivo = new System.Windows.Forms.Label();
            this.txtMail = new System.Windows.Forms.TextBox();
            this.lblRedes = new System.Windows.Forms.Label();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.lblmail = new System.Windows.Forms.Label();
            this.grbDatosPersonales = new System.Windows.Forms.GroupBox();
            this.mtbDNI = new System.Windows.Forms.MaskedTextBox();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblAPELLIDO = new System.Windows.Forms.Label();
            this.lblNOMBRE = new System.Windows.Forms.Label();
            this.lblDNI = new System.Windows.Forms.Label();
            this.btnAtras = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnCargar = new System.Windows.Forms.Button();
            this.cmbProvincia = new System.Windows.Forms.ComboBox();
            this.cmbLocalidad = new System.Windows.Forms.ComboBox();
            this.lblLOCALIDAD = new System.Windows.Forms.Label();
            this.grbUbicacion = new System.Windows.Forms.GroupBox();
            this.lblPROVINCIA = new System.Windows.Forms.Label();
            this.btnMapa = new System.Windows.Forms.Button();
            this.lblGeo = new System.Windows.Forms.Label();
            this.lblDireccion = new System.Windows.Forms.Label();
            this.grbDomicilio = new System.Windows.Forms.GroupBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.grbContacto.SuspendLayout();
            this.grbConexion.SuspendLayout();
            this.grbDatosPersonales.SuspendLayout();
            this.grbUbicacion.SuspendLayout();
            this.grbDomicilio.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbContacto
            // 
            this.grbContacto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.grbContacto.Controls.Add(this.checkedListBox1);
            this.grbContacto.Controls.Add(this.lblUsuarioRedes);
            this.grbContacto.Controls.Add(this.txtUsuarioRedes);
            this.grbContacto.Controls.Add(this.btnGuardar);
            this.grbContacto.Controls.Add(this.mtbTelefono);
            this.grbContacto.Controls.Add(this.grbConexion);
            this.grbContacto.Controls.Add(this.txtMail);
            this.grbContacto.Controls.Add(this.lblRedes);
            this.grbContacto.Controls.Add(this.lblTelefono);
            this.grbContacto.Controls.Add(this.lblmail);
            this.grbContacto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbContacto.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.grbContacto.Location = new System.Drawing.Point(403, 19);
            this.grbContacto.Name = "grbContacto";
            this.grbContacto.Size = new System.Drawing.Size(336, 356);
            this.grbContacto.TabIndex = 12;
            this.grbContacto.TabStop = false;
            this.grbContacto.Text = "Contacto";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.BackColor = System.Drawing.Color.White;
            this.checkedListBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Items.AddRange(new object[] {
            "Instagram",
            "Tiktok",
            "X",
            "Telegram",
            "Facebook"});
            this.checkedListBox1.Location = new System.Drawing.Point(103, 113);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(120, 84);
            this.checkedListBox1.TabIndex = 11;
            // 
            // lblUsuarioRedes
            // 
            this.lblUsuarioRedes.AutoSize = true;
            this.lblUsuarioRedes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUsuarioRedes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblUsuarioRedes.Location = new System.Drawing.Point(24, 206);
            this.lblUsuarioRedes.Name = "lblUsuarioRedes";
            this.lblUsuarioRedes.Size = new System.Drawing.Size(53, 14);
            this.lblUsuarioRedes.TabIndex = 10;
            this.lblUsuarioRedes.Text = "Usuario: ";
            // 
            // txtUsuarioRedes
            // 
            this.txtUsuarioRedes.BackColor = System.Drawing.Color.White;
            this.txtUsuarioRedes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUsuarioRedes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtUsuarioRedes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.txtUsuarioRedes.Location = new System.Drawing.Point(85, 203);
            this.txtUsuarioRedes.Name = "txtUsuarioRedes";
            this.txtUsuarioRedes.Size = new System.Drawing.Size(161, 23);
            this.txtUsuarioRedes.TabIndex = 8;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(122, 230);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(83, 27);
            this.btnGuardar.TabIndex = 7;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // mtbTelefono
            // 
            this.mtbTelefono.BackColor = System.Drawing.Color.White;
            this.mtbTelefono.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbTelefono.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.mtbTelefono.Location = new System.Drawing.Point(85, 75);
            this.mtbTelefono.Mask = "000-000-0000";
            this.mtbTelefono.Name = "mtbTelefono";
            this.mtbTelefono.Size = new System.Drawing.Size(161, 23);
            this.mtbTelefono.TabIndex = 6;
            // 
            // grbConexion
            // 
            this.grbConexion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(235)))), ((int)(((byte)(240)))));
            this.grbConexion.Controls.Add(this.chkInactivo);
            this.grbConexion.Controls.Add(this.chkActivo);
            this.grbConexion.Controls.Add(this.lblEstadoInactivo);
            this.grbConexion.Controls.Add(this.lblEstadoActivo);
            this.grbConexion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbConexion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.grbConexion.Location = new System.Drawing.Point(27, 263);
            this.grbConexion.Name = "grbConexion";
            this.grbConexion.Size = new System.Drawing.Size(285, 80);
            this.grbConexion.TabIndex = 4;
            this.grbConexion.TabStop = false;
            this.grbConexion.Text = "Conexión";
            // 
            // chkInactivo
            // 
            this.chkInactivo.AutoSize = true;
            this.chkInactivo.Location = new System.Drawing.Point(202, 41);
            this.chkInactivo.Name = "chkInactivo";
            this.chkInactivo.Size = new System.Drawing.Size(15, 14);
            this.chkInactivo.TabIndex = 5;
            this.chkInactivo.UseVisualStyleBackColor = true;
            // 
            // chkActivo
            // 
            this.chkActivo.AutoSize = true;
            this.chkActivo.Location = new System.Drawing.Point(79, 41);
            this.chkActivo.Name = "chkActivo";
            this.chkActivo.Size = new System.Drawing.Size(15, 14);
            this.chkActivo.TabIndex = 4;
            this.chkActivo.UseVisualStyleBackColor = true;
            // 
            // lblEstadoInactivo
            // 
            this.lblEstadoInactivo.AutoSize = true;
            this.lblEstadoInactivo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoInactivo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lblEstadoInactivo.Location = new System.Drawing.Point(131, 35);
            this.lblEstadoInactivo.Name = "lblEstadoInactivo";
            this.lblEstadoInactivo.Size = new System.Drawing.Size(65, 20);
            this.lblEstadoInactivo.TabIndex = 3;
            this.lblEstadoInactivo.Text = "Inactivo";
            // 
            // lblEstadoActivo
            // 
            this.lblEstadoActivo.AutoSize = true;
            this.lblEstadoActivo.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstadoActivo.ForeColor = System.Drawing.Color.Green;
            this.lblEstadoActivo.Location = new System.Drawing.Point(19, 35);
            this.lblEstadoActivo.Name = "lblEstadoActivo";
            this.lblEstadoActivo.Size = new System.Drawing.Size(54, 20);
            this.lblEstadoActivo.TabIndex = 2;
            this.lblEstadoActivo.Text = "Activo";
            // 
            // txtMail
            // 
            this.txtMail.BackColor = System.Drawing.Color.White;
            this.txtMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMail.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.txtMail.Location = new System.Drawing.Point(85, 35);
            this.txtMail.Name = "txtMail";
            this.txtMail.Size = new System.Drawing.Size(161, 23);
            this.txtMail.TabIndex = 3;
            // 
            // lblRedes
            // 
            this.lblRedes.AutoSize = true;
            this.lblRedes.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRedes.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblRedes.Location = new System.Drawing.Point(24, 153);
            this.lblRedes.Name = "lblRedes";
            this.lblRedes.Size = new System.Drawing.Size(44, 14);
            this.lblRedes.TabIndex = 2;
            this.lblRedes.Text = "Redes: ";
            // 
            // lblTelefono
            // 
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTelefono.Location = new System.Drawing.Point(18, 78);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(55, 14);
            this.lblTelefono.TabIndex = 1;
            this.lblTelefono.Text = "Telefono:";
            // 
            // lblmail
            // 
            this.lblmail.AutoSize = true;
            this.lblmail.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblmail.Location = new System.Drawing.Point(36, 42);
            this.lblmail.Name = "lblmail";
            this.lblmail.Size = new System.Drawing.Size(32, 14);
            this.lblmail.TabIndex = 0;
            this.lblmail.Text = "Mail:";
            // 
            // grbDatosPersonales
            // 
            this.grbDatosPersonales.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.grbDatosPersonales.Controls.Add(this.mtbDNI);
            this.grbDatosPersonales.Controls.Add(this.txtApellido);
            this.grbDatosPersonales.Controls.Add(this.txtNombre);
            this.grbDatosPersonales.Controls.Add(this.lblAPELLIDO);
            this.grbDatosPersonales.Controls.Add(this.lblNOMBRE);
            this.grbDatosPersonales.Controls.Add(this.lblDNI);
            this.grbDatosPersonales.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDatosPersonales.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.grbDatosPersonales.Location = new System.Drawing.Point(44, 19);
            this.grbDatosPersonales.Name = "grbDatosPersonales";
            this.grbDatosPersonales.Size = new System.Drawing.Size(353, 132);
            this.grbDatosPersonales.TabIndex = 7;
            this.grbDatosPersonales.TabStop = false;
            this.grbDatosPersonales.Text = "Datos Personales";
            // 
            // mtbDNI
            // 
            this.mtbDNI.BackColor = System.Drawing.Color.White;
            this.mtbDNI.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mtbDNI.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mtbDNI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.mtbDNI.Location = new System.Drawing.Point(85, 20);
            this.mtbDNI.Mask = "00000000";
            this.mtbDNI.Name = "mtbDNI";
            this.mtbDNI.Size = new System.Drawing.Size(161, 23);
            this.mtbDNI.TabIndex = 8;
            // 
            // txtApellido
            // 
            this.txtApellido.BackColor = System.Drawing.Color.White;
            this.txtApellido.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtApellido.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtApellido.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.txtApellido.Location = new System.Drawing.Point(85, 93);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(161, 23);
            this.txtApellido.TabIndex = 5;
            // 
            // txtNombre
            // 
            this.txtNombre.BackColor = System.Drawing.Color.White;
            this.txtNombre.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.txtNombre.Location = new System.Drawing.Point(85, 56);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(161, 23);
            this.txtNombre.TabIndex = 4;
            // 
            // lblAPELLIDO
            // 
            this.lblAPELLIDO.AutoSize = true;
            this.lblAPELLIDO.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAPELLIDO.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblAPELLIDO.Location = new System.Drawing.Point(19, 96);
            this.lblAPELLIDO.Name = "lblAPELLIDO";
            this.lblAPELLIDO.Size = new System.Drawing.Size(53, 14);
            this.lblAPELLIDO.TabIndex = 2;
            this.lblAPELLIDO.Text = "Apellido:";
            // 
            // lblNOMBRE
            // 
            this.lblNOMBRE.AutoSize = true;
            this.lblNOMBRE.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNOMBRE.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblNOMBRE.Location = new System.Drawing.Point(19, 59);
            this.lblNOMBRE.Name = "lblNOMBRE";
            this.lblNOMBRE.Size = new System.Drawing.Size(51, 14);
            this.lblNOMBRE.TabIndex = 1;
            this.lblNOMBRE.Text = "Nombre:";
            // 
            // lblDNI
            // 
            this.lblDNI.AutoSize = true;
            this.lblDNI.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDNI.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDNI.Location = new System.Drawing.Point(41, 23);
            this.lblDNI.Name = "lblDNI";
            this.lblDNI.Size = new System.Drawing.Size(29, 14);
            this.lblDNI.TabIndex = 0;
            this.lblDNI.Text = "DNI:";
            // 
            // btnAtras
            // 
            this.btnAtras.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnAtras.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAtras.ForeColor = System.Drawing.Color.White;
            this.btnAtras.Location = new System.Drawing.Point(97, 391);
            this.btnAtras.Name = "btnAtras";
            this.btnAtras.Size = new System.Drawing.Size(43, 41);
            this.btnAtras.TabIndex = 13;
            this.btnAtras.Text = "🡸";
            this.btnAtras.UseVisualStyleBackColor = false;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(158)))), ((int)(((byte)(158)))));
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLimpiar.ForeColor = System.Drawing.Color.White;
            this.btnLimpiar.Location = new System.Drawing.Point(547, 397);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 29);
            this.btnLimpiar.TabIndex = 11;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            // 
            // btnCargar
            // 
            this.btnCargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnCargar.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCargar.ForeColor = System.Drawing.Color.White;
            this.btnCargar.Location = new System.Drawing.Point(628, 397);
            this.btnCargar.Name = "btnCargar";
            this.btnCargar.Size = new System.Drawing.Size(75, 29);
            this.btnCargar.TabIndex = 10;
            this.btnCargar.Text = "Cargar";
            this.btnCargar.UseVisualStyleBackColor = false;
            // 
            // cmbProvincia
            // 
            this.cmbProvincia.BackColor = System.Drawing.Color.White;
            this.cmbProvincia.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProvincia.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cmbProvincia.FormattingEnabled = true;
            this.cmbProvincia.Location = new System.Drawing.Point(162, 45);
            this.cmbProvincia.Name = "cmbProvincia";
            this.cmbProvincia.Size = new System.Drawing.Size(121, 23);
            this.cmbProvincia.TabIndex = 3;
            // 
            // cmbLocalidad
            // 
            this.cmbLocalidad.BackColor = System.Drawing.Color.White;
            this.cmbLocalidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbLocalidad.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.cmbLocalidad.FormattingEnabled = true;
            this.cmbLocalidad.Items.AddRange(new object[] {
            "Buenos Aires",
            "Catamarca",
            "Chaco",
            "Chubut",
            "Córdoba",
            "Corrientes",
            "Entre Ríos",
            "Formosa",
            "Jujuy",
            "La Pampa",
            "La Rioja",
            "Mendoza",
            "Misiones",
            "Neuquén",
            "Río Negro",
            "Salta",
            "San Juan",
            "San Luis",
            "Santa Cruz",
            "Santa Fe",
            "Santiago del Estero",
            "Tierra del Fuego, Antártida e Islas del Atlántico Sur",
            "Tucumán"});
            this.cmbLocalidad.Location = new System.Drawing.Point(9, 45);
            this.cmbLocalidad.Name = "cmbLocalidad";
            this.cmbLocalidad.Size = new System.Drawing.Size(114, 23);
            this.cmbLocalidad.TabIndex = 2;
            // 
            // lblLOCALIDAD
            // 
            this.lblLOCALIDAD.AutoSize = true;
            this.lblLOCALIDAD.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLOCALIDAD.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblLOCALIDAD.Location = new System.Drawing.Point(168, 28);
            this.lblLOCALIDAD.Name = "lblLOCALIDAD";
            this.lblLOCALIDAD.Size = new System.Drawing.Size(56, 14);
            this.lblLOCALIDAD.TabIndex = 0;
            this.lblLOCALIDAD.Text = "Localidad";
            // 
            // grbUbicacion
            // 
            this.grbUbicacion.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.grbUbicacion.Controls.Add(this.cmbProvincia);
            this.grbUbicacion.Controls.Add(this.cmbLocalidad);
            this.grbUbicacion.Controls.Add(this.lblPROVINCIA);
            this.grbUbicacion.Controls.Add(this.lblLOCALIDAD);
            this.grbUbicacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbUbicacion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.grbUbicacion.Location = new System.Drawing.Point(44, 157);
            this.grbUbicacion.Name = "grbUbicacion";
            this.grbUbicacion.Size = new System.Drawing.Size(353, 86);
            this.grbUbicacion.TabIndex = 8;
            this.grbUbicacion.TabStop = false;
            this.grbUbicacion.Text = "Ubicaciòn";
            // 
            // lblPROVINCIA
            // 
            this.lblPROVINCIA.AutoSize = true;
            this.lblPROVINCIA.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPROVINCIA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblPROVINCIA.Location = new System.Drawing.Point(6, 28);
            this.lblPROVINCIA.Name = "lblPROVINCIA";
            this.lblPROVINCIA.Size = new System.Drawing.Size(53, 14);
            this.lblPROVINCIA.TabIndex = 1;
            this.lblPROVINCIA.Text = "Provincia";
            // 
            // btnMapa
            // 
            this.btnMapa.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(150)))), ((int)(((byte)(243)))));
            this.btnMapa.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMapa.ForeColor = System.Drawing.Color.White;
            this.btnMapa.Location = new System.Drawing.Point(116, 80);
            this.btnMapa.Name = "btnMapa";
            this.btnMapa.Size = new System.Drawing.Size(161, 23);
            this.btnMapa.TabIndex = 7;
            this.btnMapa.Text = "Mapa";
            this.btnMapa.UseVisualStyleBackColor = false;
            // 
            // lblGeo
            // 
            this.lblGeo.AutoSize = true;
            this.lblGeo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGeo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblGeo.Location = new System.Drawing.Point(19, 84);
            this.lblGeo.Name = "lblGeo";
            this.lblGeo.Size = new System.Drawing.Size(91, 14);
            this.lblGeo.TabIndex = 1;
            this.lblGeo.Text = "Geolocalizacion:";
            // 
            // lblDireccion
            // 
            this.lblDireccion.AutoSize = true;
            this.lblDireccion.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblDireccion.Location = new System.Drawing.Point(32, 36);
            this.lblDireccion.Name = "lblDireccion";
            this.lblDireccion.Size = new System.Drawing.Size(58, 14);
            this.lblDireccion.TabIndex = 0;
            this.lblDireccion.Text = "Direccion:";
            // 
            // grbDomicilio
            // 
            this.grbDomicilio.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(242)))), ((int)(((byte)(245)))));
            this.grbDomicilio.Controls.Add(this.btnMapa);
            this.grbDomicilio.Controls.Add(this.txtDireccion);
            this.grbDomicilio.Controls.Add(this.lblGeo);
            this.grbDomicilio.Controls.Add(this.lblDireccion);
            this.grbDomicilio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDomicilio.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.grbDomicilio.Location = new System.Drawing.Point(44, 249);
            this.grbDomicilio.Name = "grbDomicilio";
            this.grbDomicilio.Size = new System.Drawing.Size(353, 126);
            this.grbDomicilio.TabIndex = 9;
            this.grbDomicilio.TabStop = false;
            this.grbDomicilio.Text = "Domicilio";
            // 
            // txtDireccion
            // 
            this.txtDireccion.BackColor = System.Drawing.Color.White;
            this.txtDireccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDireccion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDireccion.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(33)))), ((int)(((byte)(33)))));
            this.txtDireccion.Location = new System.Drawing.Point(116, 33);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(161, 23);
            this.txtDireccion.TabIndex = 6;
            // 
            // frmPersonal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grbContacto);
            this.Controls.Add(this.grbDatosPersonales);
            this.Controls.Add(this.btnAtras);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnCargar);
            this.Controls.Add(this.grbUbicacion);
            this.Controls.Add(this.grbDomicilio);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmPersonal";
            this.Text = "frmPersonal";
            this.grbContacto.ResumeLayout(false);
            this.grbContacto.PerformLayout();
            this.grbConexion.ResumeLayout(false);
            this.grbConexion.PerformLayout();
            this.grbDatosPersonales.ResumeLayout(false);
            this.grbDatosPersonales.PerformLayout();
            this.grbUbicacion.ResumeLayout(false);
            this.grbUbicacion.PerformLayout();
            this.grbDomicilio.ResumeLayout(false);
            this.grbDomicilio.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbContacto;
        private System.Windows.Forms.Label lblUsuarioRedes;
        private System.Windows.Forms.TextBox txtUsuarioRedes;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.MaskedTextBox mtbTelefono;
        private System.Windows.Forms.GroupBox grbConexion;
        private System.Windows.Forms.CheckBox chkInactivo;
        private System.Windows.Forms.CheckBox chkActivo;
        private System.Windows.Forms.Label lblEstadoInactivo;
        private System.Windows.Forms.Label lblEstadoActivo;
        private System.Windows.Forms.TextBox txtMail;
        private System.Windows.Forms.Label lblRedes;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.Label lblmail;
        private System.Windows.Forms.GroupBox grbDatosPersonales;
        private System.Windows.Forms.MaskedTextBox mtbDNI;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblAPELLIDO;
        private System.Windows.Forms.Label lblNOMBRE;
        private System.Windows.Forms.Label lblDNI;
        private System.Windows.Forms.Button btnAtras;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnCargar;
        private System.Windows.Forms.ComboBox cmbProvincia;
        private System.Windows.Forms.ComboBox cmbLocalidad;
        private System.Windows.Forms.Label lblLOCALIDAD;
        private System.Windows.Forms.GroupBox grbUbicacion;
        private System.Windows.Forms.Label lblPROVINCIA;
        private System.Windows.Forms.Button btnMapa;
        private System.Windows.Forms.Label lblGeo;
        private System.Windows.Forms.Label lblDireccion;
        private System.Windows.Forms.GroupBox grbDomicilio;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}