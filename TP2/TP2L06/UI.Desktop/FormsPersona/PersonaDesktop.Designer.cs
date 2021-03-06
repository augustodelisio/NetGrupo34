﻿namespace UI.Desktop
{
    partial class PersonaDesktop
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
            this.lbEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lbNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lbTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.lbApellido = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.lbDireccion = new System.Windows.Forms.Label();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.lbFechaNac = new System.Windows.Forms.Label();
            this.txtFechaNac = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lbID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbEmail, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtEmail, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbNombre, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombre, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbTelefono, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtTelefono, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbApellido, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtApellido, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lbDireccion, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDireccion, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbFechaNac, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtFechaNac, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 0, 4);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(473, 180);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbID
            // 
            this.lbID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(45, 8);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(18, 13);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(69, 5);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(114, 20);
            this.txtID.TabIndex = 4;
            // 
            // lbEmail
            // 
            this.lbEmail.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbEmail.AutoSize = true;
            this.lbEmail.Location = new System.Drawing.Point(224, 38);
            this.lbEmail.Name = "lbEmail";
            this.lbEmail.Size = new System.Drawing.Size(32, 13);
            this.lbEmail.TabIndex = 9;
            this.lbEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtEmail, 2);
            this.txtEmail.Location = new System.Drawing.Point(262, 35);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(132, 20);
            this.txtEmail.TabIndex = 12;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnAceptar, 4);
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(3, 130);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(371, 40);
            this.btnAceptar.TabIndex = 15;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(380, 130);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 40);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbNombre
            // 
            this.lbNombre.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbNombre.AutoSize = true;
            this.lbNombre.Location = new System.Drawing.Point(19, 38);
            this.lbNombre.Name = "lbNombre";
            this.lbNombre.Size = new System.Drawing.Size(44, 13);
            this.lbNombre.TabIndex = 10;
            this.lbNombre.Text = "Nombre";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(69, 35);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(114, 20);
            this.txtNombre.TabIndex = 13;
            // 
            // lbTelefono
            // 
            this.lbTelefono.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbTelefono.AutoSize = true;
            this.lbTelefono.Location = new System.Drawing.Point(207, 68);
            this.lbTelefono.Name = "lbTelefono";
            this.lbTelefono.Size = new System.Drawing.Size(49, 13);
            this.lbTelefono.TabIndex = 2;
            this.lbTelefono.Text = "Telefono";
            // 
            // txtTelefono
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtTelefono, 2);
            this.txtTelefono.Location = new System.Drawing.Point(262, 65);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(132, 20);
            this.txtTelefono.TabIndex = 6;
            // 
            // lbApellido
            // 
            this.lbApellido.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbApellido.AutoSize = true;
            this.lbApellido.Location = new System.Drawing.Point(19, 68);
            this.lbApellido.Name = "lbApellido";
            this.lbApellido.Size = new System.Drawing.Size(44, 13);
            this.lbApellido.TabIndex = 3;
            this.lbApellido.Text = "Apellido";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(69, 65);
            this.txtApellido.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(114, 20);
            this.txtApellido.TabIndex = 7;
            // 
            // lbDireccion
            // 
            this.lbDireccion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDireccion.AutoSize = true;
            this.lbDireccion.Location = new System.Drawing.Point(11, 98);
            this.lbDireccion.Name = "lbDireccion";
            this.lbDireccion.Size = new System.Drawing.Size(52, 13);
            this.lbDireccion.TabIndex = 11;
            this.lbDireccion.Text = "Direccion";
            // 
            // txtDireccion
            // 
            this.txtDireccion.Location = new System.Drawing.Point(69, 95);
            this.txtDireccion.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(114, 20);
            this.txtDireccion.TabIndex = 14;
            // 
            // lbFechaNac
            // 
            this.lbFechaNac.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbFechaNac.AutoSize = true;
            this.lbFechaNac.Location = new System.Drawing.Point(196, 92);
            this.lbFechaNac.Name = "lbFechaNac";
            this.lbFechaNac.Size = new System.Drawing.Size(60, 26);
            this.lbFechaNac.TabIndex = 17;
            this.lbFechaNac.Text = "Fecha de\r\nNacimiento";
            this.lbFechaNac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFechaNac
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtFechaNac, 2);
            this.txtFechaNac.Location = new System.Drawing.Point(262, 95);
            this.txtFechaNac.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtFechaNac.Name = "txtFechaNac";
            this.txtFechaNac.Size = new System.Drawing.Size(132, 20);
            this.txtFechaNac.TabIndex = 18;
            // 
            // PersonaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 180);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PersonaDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Personas";
            this.Load += new System.EventHandler(this.PersonaDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbTelefono;
        private System.Windows.Forms.Label lbApellido;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label lbEmail;
        private System.Windows.Forms.Label lbNombre;
        private System.Windows.Forms.Label lbDireccion;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbFechaNac;
        private System.Windows.Forms.TextBox txtFechaNac;
    }
}