namespace UI.Desktop
{
    partial class MiPerfil
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lbClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lbConfirmarClave = new System.Windows.Forms.Label();
            this.txtConfirmarClave = new System.Windows.Forms.TextBox();
            this.lbLegajo = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.lbTipoUsuario = new System.Windows.Forms.Label();
            this.cbTipoUsuario = new System.Windows.Forms.ComboBox();
            this.lbPersona = new System.Windows.Forms.Label();
            this.cbPersonas = new System.Windows.Forms.ComboBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.Controls.Add(this.lbID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbUsuario, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUsuario, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbClave, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtClave, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbConfirmarClave, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtConfirmarClave, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbLegajo, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtLegajo, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbTipoUsuario, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.cbTipoUsuario, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.lbPersona, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.cbPersonas, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 2, 7);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(285, 303);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbID
            // 
            this.lbID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(44, 15);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(44, 13);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "Mi Perfil";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtID, 2);
            this.txtID.Location = new System.Drawing.Point(94, 11);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(113, 20);
            this.txtID.TabIndex = 4;
            this.txtID.Visible = false;
            // 
            // lbUsuario
            // 
            this.lbUsuario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(45, 58);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(43, 13);
            this.lbUsuario.TabIndex = 10;
            this.lbUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtUsuario, 2);
            this.txtUsuario.Enabled = false;
            this.txtUsuario.Location = new System.Drawing.Point(94, 54);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(145, 20);
            this.txtUsuario.TabIndex = 13;
            // 
            // lbClave
            // 
            this.lbClave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbClave.AutoSize = true;
            this.lbClave.Location = new System.Drawing.Point(54, 101);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(34, 13);
            this.lbClave.TabIndex = 3;
            this.lbClave.Text = "Clave";
            // 
            // txtClave
            // 
            this.txtClave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtClave, 2);
            this.txtClave.Location = new System.Drawing.Point(94, 97);
            this.txtClave.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(145, 20);
            this.txtClave.TabIndex = 7;
            // 
            // lbConfirmarClave
            // 
            this.lbConfirmarClave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbConfirmarClave.AutoSize = true;
            this.lbConfirmarClave.Location = new System.Drawing.Point(7, 144);
            this.lbConfirmarClave.Name = "lbConfirmarClave";
            this.lbConfirmarClave.Size = new System.Drawing.Size(81, 13);
            this.lbConfirmarClave.TabIndex = 11;
            this.lbConfirmarClave.Text = "Confirmar Clave";
            // 
            // txtConfirmarClave
            // 
            this.txtConfirmarClave.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtConfirmarClave, 2);
            this.txtConfirmarClave.Location = new System.Drawing.Point(94, 140);
            this.txtConfirmarClave.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtConfirmarClave.Name = "txtConfirmarClave";
            this.txtConfirmarClave.Size = new System.Drawing.Size(145, 20);
            this.txtConfirmarClave.TabIndex = 14;
            // 
            // lbLegajo
            // 
            this.lbLegajo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbLegajo.AutoSize = true;
            this.lbLegajo.Location = new System.Drawing.Point(49, 187);
            this.lbLegajo.Name = "lbLegajo";
            this.lbLegajo.Size = new System.Drawing.Size(39, 13);
            this.lbLegajo.TabIndex = 9;
            this.lbLegajo.Text = "Legajo";
            // 
            // txtLegajo
            // 
            this.txtLegajo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtLegajo, 2);
            this.txtLegajo.Enabled = false;
            this.txtLegajo.Location = new System.Drawing.Point(94, 183);
            this.txtLegajo.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(145, 20);
            this.txtLegajo.TabIndex = 12;
            // 
            // lbTipoUsuario
            // 
            this.lbTipoUsuario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTipoUsuario.AutoSize = true;
            this.lbTipoUsuario.Location = new System.Drawing.Point(6, 218);
            this.lbTipoUsuario.Name = "lbTipoUsuario";
            this.lbTipoUsuario.Size = new System.Drawing.Size(82, 13);
            this.lbTipoUsuario.TabIndex = 2;
            this.lbTipoUsuario.Text = "Tipo de Usuario";
            this.lbTipoUsuario.Visible = false;
            // 
            // cbTipoUsuario
            // 
            this.cbTipoUsuario.Enabled = false;
            this.cbTipoUsuario.FormattingEnabled = true;
            this.cbTipoUsuario.Location = new System.Drawing.Point(94, 220);
            this.cbTipoUsuario.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.cbTipoUsuario.Name = "cbTipoUsuario";
            this.cbTipoUsuario.Size = new System.Drawing.Size(95, 21);
            this.cbTipoUsuario.TabIndex = 19;
            this.cbTipoUsuario.Visible = false;
            // 
            // lbPersona
            // 
            this.lbPersona.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPersona.AutoSize = true;
            this.lbPersona.Location = new System.Drawing.Point(42, 238);
            this.lbPersona.Name = "lbPersona";
            this.lbPersona.Size = new System.Drawing.Size(46, 13);
            this.lbPersona.TabIndex = 17;
            this.lbPersona.Text = "Persona";
            this.lbPersona.Visible = false;
            // 
            // cbPersonas
            // 
            this.cbPersonas.Enabled = false;
            this.cbPersonas.FormattingEnabled = true;
            this.cbPersonas.Location = new System.Drawing.Point(94, 240);
            this.cbPersonas.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.cbPersonas.Name = "cbPersonas";
            this.cbPersonas.Size = new System.Drawing.Size(95, 21);
            this.cbPersonas.TabIndex = 19;
            this.cbPersonas.Visible = false;
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnAceptar, 2);
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(3, 258);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(3, 3, 5, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(191, 37);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(202, 258);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 38);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // MiPerfil
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(285, 303);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MiPerfil";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Editar Mi Perfil";
            this.Load += new System.EventHandler(this.UsuarioDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.Label lbLegajo;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label lbConfirmarClave;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.Label lbTipoUsuario;
        private System.Windows.Forms.ComboBox cbTipoUsuario;
        private System.Windows.Forms.Label lbPersona;
        private System.Windows.Forms.ComboBox cbPersonas;
    }
}