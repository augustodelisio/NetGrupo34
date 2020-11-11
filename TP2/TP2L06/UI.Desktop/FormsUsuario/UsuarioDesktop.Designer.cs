namespace UI.Desktop
{
    partial class UsuarioDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsuarioDesktop));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lbLegajo = new System.Windows.Forms.Label();
            this.txtLegajo = new System.Windows.Forms.TextBox();
            this.lbUsuario = new System.Windows.Forms.Label();
            this.txtUsuario = new System.Windows.Forms.TextBox();
            this.lbTipoUsuario = new System.Windows.Forms.Label();
            this.lbClave = new System.Windows.Forms.Label();
            this.txtClave = new System.Windows.Forms.TextBox();
            this.lbConfirmarClave = new System.Windows.Forms.Label();
            this.txtConfirmarClave = new System.Windows.Forms.TextBox();
            this.lbPersona = new System.Windows.Forms.Label();
            this.cbPersonas = new System.Windows.Forms.ComboBox();
            this.btnCrearPersona = new System.Windows.Forms.Button();
            this.cbTipoUsuario = new System.Windows.Forms.ComboBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 6;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.lbID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbLegajo, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtLegajo, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbUsuario, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtUsuario, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbTipoUsuario, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbClave, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtClave, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbConfirmarClave, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtConfirmarClave, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbPersona, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbPersonas, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.cbTipoUsuario, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnCrearPersona, 5, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 4, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 5;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(502, 184);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbID
            // 
            this.lbID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(59, 8);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(18, 13);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(83, 5);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(127, 20);
            this.txtID.TabIndex = 4;
            // 
            // lbLegajo
            // 
            this.lbLegajo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbLegajo.AutoSize = true;
            this.lbLegajo.Location = new System.Drawing.Point(259, 38);
            this.lbLegajo.Name = "lbLegajo";
            this.lbLegajo.Size = new System.Drawing.Size(39, 13);
            this.lbLegajo.TabIndex = 9;
            this.lbLegajo.Text = "Legajo";
            // 
            // txtLegajo
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtLegajo, 2);
            this.txtLegajo.Location = new System.Drawing.Point(304, 35);
            this.txtLegajo.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtLegajo.Name = "txtLegajo";
            this.txtLegajo.Size = new System.Drawing.Size(139, 20);
            this.txtLegajo.TabIndex = 12;
            // 
            // lbUsuario
            // 
            this.lbUsuario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbUsuario.AutoSize = true;
            this.lbUsuario.Location = new System.Drawing.Point(34, 38);
            this.lbUsuario.Name = "lbUsuario";
            this.lbUsuario.Size = new System.Drawing.Size(43, 13);
            this.lbUsuario.TabIndex = 10;
            this.lbUsuario.Text = "Usuario";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Location = new System.Drawing.Point(83, 35);
            this.txtUsuario.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(127, 20);
            this.txtUsuario.TabIndex = 13;
            // 
            // lbTipoUsuario
            // 
            this.lbTipoUsuario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTipoUsuario.AutoSize = true;
            this.lbTipoUsuario.Location = new System.Drawing.Point(252, 62);
            this.lbTipoUsuario.Name = "lbTipoUsuario";
            this.lbTipoUsuario.Size = new System.Drawing.Size(46, 26);
            this.lbTipoUsuario.TabIndex = 2;
            this.lbTipoUsuario.Text = "Tipo de Usuario";
            // 
            // lbClave
            // 
            this.lbClave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbClave.AutoSize = true;
            this.lbClave.Location = new System.Drawing.Point(43, 69);
            this.lbClave.Name = "lbClave";
            this.lbClave.Size = new System.Drawing.Size(34, 13);
            this.lbClave.TabIndex = 3;
            this.lbClave.Text = "Clave";
            // 
            // txtClave
            // 
            this.txtClave.Location = new System.Drawing.Point(83, 65);
            this.txtClave.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtClave.Name = "txtClave";
            this.txtClave.Size = new System.Drawing.Size(127, 20);
            this.txtClave.TabIndex = 7;
            // 
            // lbConfirmarClave
            // 
            this.lbConfirmarClave.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbConfirmarClave.AutoSize = true;
            this.lbConfirmarClave.Location = new System.Drawing.Point(26, 95);
            this.lbConfirmarClave.Name = "lbConfirmarClave";
            this.lbConfirmarClave.Size = new System.Drawing.Size(51, 26);
            this.lbConfirmarClave.TabIndex = 11;
            this.lbConfirmarClave.Text = "Confirmar Clave";
            this.lbConfirmarClave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtConfirmarClave
            // 
            this.txtConfirmarClave.Location = new System.Drawing.Point(83, 96);
            this.txtConfirmarClave.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtConfirmarClave.Name = "txtConfirmarClave";
            this.txtConfirmarClave.Size = new System.Drawing.Size(127, 20);
            this.txtConfirmarClave.TabIndex = 14;
            // 
            // lbPersona
            // 
            this.lbPersona.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbPersona.AutoSize = true;
            this.lbPersona.Location = new System.Drawing.Point(252, 101);
            this.lbPersona.Name = "lbPersona";
            this.lbPersona.Size = new System.Drawing.Size(46, 13);
            this.lbPersona.TabIndex = 17;
            this.lbPersona.Text = "Persona";
            // 
            // cbPersonas
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbPersonas, 2);
            this.cbPersonas.FormattingEnabled = true;
            this.cbPersonas.Location = new System.Drawing.Point(304, 96);
            this.cbPersonas.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.cbPersonas.Name = "cbPersonas";
            this.cbPersonas.Size = new System.Drawing.Size(139, 21);
            this.cbPersonas.TabIndex = 19;
            // 
            // btnCrearPersona
            // 
            this.btnCrearPersona.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCrearPersona.BackgroundImage")));
            this.btnCrearPersona.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearPersona.Location = new System.Drawing.Point(453, 91);
            this.btnCrearPersona.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.btnCrearPersona.Name = "btnCrearPersona";
            this.btnCrearPersona.Size = new System.Drawing.Size(40, 31);
            this.btnCrearPersona.TabIndex = 20;
            this.btnCrearPersona.UseVisualStyleBackColor = true;
            this.btnCrearPersona.Click += new System.EventHandler(this.btnCrearPersona_Click);
            // 
            // cbTipoUsuario
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.cbTipoUsuario, 2);
            this.cbTipoUsuario.FormattingEnabled = true;
            this.cbTipoUsuario.Location = new System.Drawing.Point(304, 65);
            this.cbTipoUsuario.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.cbTipoUsuario.Name = "cbTipoUsuario";
            this.cbTipoUsuario.Size = new System.Drawing.Size(139, 21);
            this.cbTipoUsuario.TabIndex = 19;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnCancelar, 2);
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(426, 134);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(73, 40);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnAceptar, 4);
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(3, 134);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(417, 40);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // UsuarioDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 184);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "UsuarioDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.UsuarioDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbTipoUsuario;
        private System.Windows.Forms.Label lbClave;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtClave;
        private System.Windows.Forms.Label lbLegajo;
        private System.Windows.Forms.Label lbUsuario;
        private System.Windows.Forms.Label lbConfirmarClave;
        private System.Windows.Forms.TextBox txtLegajo;
        private System.Windows.Forms.TextBox txtUsuario;
        private System.Windows.Forms.TextBox txtConfirmarClave;
        private System.Windows.Forms.Label lbPersona;
        private System.Windows.Forms.ComboBox cbPersonas;
        private System.Windows.Forms.Button btnCrearPersona;
        private System.Windows.Forms.ComboBox cbTipoUsuario;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
    }
}