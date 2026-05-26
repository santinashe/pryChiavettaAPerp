namespace pryChiavettaAPerp
{
    partial class frmPrinicipal
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.chkMostrar = new System.Windows.Forms.CheckBox();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.lblEstadoConexion = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTitulo.Location = new System.Drawing.Point(135, 17);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(337, 29);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "SISTEMA DE INICIO SESION";
            // 
            // lblUsuario
            // 
            this.lblUsuario.AutoSize = true;
            this.lblUsuario.Font = new System.Drawing.Font("Arial", 10F);
            this.lblUsuario.Location = new System.Drawing.Point(150, 81);
            this.lblUsuario.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblUsuario.Name = "lblUsuario";
            this.lblUsuario.Size = new System.Drawing.Size(59, 16);
            this.lblUsuario.TabIndex = 1;
            this.lblUsuario.Text = "Usuario:";
            this.lblUsuario.Click += new System.EventHandler(this.lblUsuario_Click);
            // 
            // txtUsuario
            // 
            this.txtUsuario.Font = new System.Drawing.Font("Arial", 10F);
            this.txtUsuario.Location = new System.Drawing.Point(150, 98);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(301, 23);
            this.txtUsuario.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Arial", 10F);
            this.lblPassword.Location = new System.Drawing.Point(150, 130);
            this.lblPassword.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(85, 16);
            this.lblPassword.TabIndex = 3;
            this.lblPassword.Text = "Contraseña:";
            // 
            // txtPassword
            // 
            this.txtPassword.Font = new System.Drawing.Font("Arial", 10F);
            this.txtPassword.Location = new System.Drawing.Point(150, 146);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(301, 23);
            this.txtPassword.TabIndex = 4;
            // 
            // chkMostrar
            // 
            this.chkMostrar.AutoSize = true;
            this.chkMostrar.Font = new System.Drawing.Font("Arial", 9F);
            this.chkMostrar.Location = new System.Drawing.Point(150, 171);
            this.chkMostrar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.chkMostrar.Name = "chkMostrar";
            this.chkMostrar.Size = new System.Drawing.Size(132, 19);
            this.chkMostrar.TabIndex = 5;
            this.chkMostrar.Text = "Mostrar contraseña";
            this.chkMostrar.UseVisualStyleBackColor = true;
            this.chkMostrar.CheckedChanged += new System.EventHandler(this.chkMostrar_CheckedChanged);
            // 
            // btnIngresar
            // 
            this.btnIngresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnIngresar.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold);
            this.btnIngresar.ForeColor = System.Drawing.Color.White;
            this.btnIngresar.Location = new System.Drawing.Point(225, 211);
            this.btnIngresar.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(150, 32);
            this.btnIngresar.TabIndex = 6;
            this.btnIngresar.Text = "INGRESAR";
            this.btnIngresar.UseVisualStyleBackColor = false;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // lblEstadoConexion
            // 
            this.lblEstadoConexion.AutoSize = true;
            this.lblEstadoConexion.Font = new System.Drawing.Font("Arial", 9F);
            this.lblEstadoConexion.ForeColor = System.Drawing.Color.Red;
            this.lblEstadoConexion.Location = new System.Drawing.Point(-3, 278);
            this.lblEstadoConexion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblEstadoConexion.Name = "lblEstadoConexion";
            this.lblEstadoConexion.Size = new System.Drawing.Size(168, 15);
            this.lblEstadoConexion.TabIndex = 7;
            this.lblEstadoConexion.Text = "Base de datos desconectada";
            this.lblEstadoConexion.Click += new System.EventHandler(this.lblEstadoConexion_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Location = new System.Drawing.Point(0, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 65);
            this.panel1.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 321);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblEstadoConexion);
            this.Controls.Add(this.btnIngresar);
            this.Controls.Add(this.chkMostrar);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.txtUsuario);
            this.Controls.Add(this.lblUsuario);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "AP ERP - Login";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.CheckBox chkMostrar;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Label lblEstadoConexion;
        private System.Windows.Forms.Panel panel1;
    }
}

