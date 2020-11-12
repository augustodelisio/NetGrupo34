namespace UI.Desktop
{
    partial class ComisionDesktop
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
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.txtIdComision = new System.Windows.Forms.TextBox();
            this.lbIdComision = new System.Windows.Forms.Label();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lbAnioEsp = new System.Windows.Forms.Label();
            this.txtAnioEsp = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(86, 37);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(179, 20);
            this.txtDescripcion.TabIndex = 1;
            // 
            // txtIdComision
            // 
            this.txtIdComision.Location = new System.Drawing.Point(86, 11);
            this.txtIdComision.Margin = new System.Windows.Forms.Padding(2);
            this.txtIdComision.Name = "txtIdComision";
            this.txtIdComision.ReadOnly = true;
            this.txtIdComision.Size = new System.Drawing.Size(76, 20);
            this.txtIdComision.TabIndex = 2;
            // 
            // lbIdComision
            // 
            this.lbIdComision.AutoSize = true;
            this.lbIdComision.Location = new System.Drawing.Point(9, 11);
            this.lbIdComision.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbIdComision.Name = "lbIdComision";
            this.lbIdComision.Size = new System.Drawing.Size(63, 13);
            this.lbIdComision.TabIndex = 3;
            this.lbIdComision.Text = "ID Comision";
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(9, 41);
            this.lbDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lbDescripcion.TabIndex = 4;
            this.lbDescripcion.Text = "Descripción";
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(11, 98);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(2);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(184, 42);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancelar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.Location = new System.Drawing.Point(199, 98);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(80, 42);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbAnioEsp
            // 
            this.lbAnioEsp.AutoSize = true;
            this.lbAnioEsp.Location = new System.Drawing.Point(9, 67);
            this.lbAnioEsp.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lbAnioEsp.Name = "lbAnioEsp";
            this.lbAnioEsp.Size = new System.Drawing.Size(26, 13);
            this.lbAnioEsp.TabIndex = 7;
            this.lbAnioEsp.Text = "Año";
            // 
            // txtAnioEsp
            // 
            this.txtAnioEsp.Location = new System.Drawing.Point(86, 67);
            this.txtAnioEsp.Margin = new System.Windows.Forms.Padding(2);
            this.txtAnioEsp.Name = "txtAnioEsp";
            this.txtAnioEsp.Size = new System.Drawing.Size(76, 20);
            this.txtAnioEsp.TabIndex = 8;
            // 
            // ComisionDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(290, 151);
            this.Controls.Add(this.txtAnioEsp);
            this.Controls.Add(this.lbAnioEsp);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.lbDescripcion);
            this.Controls.Add(this.lbIdComision);
            this.Controls.Add(this.txtIdComision);
            this.Controls.Add(this.txtDescripcion);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ComisionDesktop";
            this.Text = "Comision";
            this.Load += new System.EventHandler(this.ComisionDesktop_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

#pragma warning disable CS0169 // El campo 'ComisionDesktop.tableLayoutPanel1' nunca se usa
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
#pragma warning restore CS0169 // El campo 'ComisionDesktop.tableLayoutPanel1' nunca se usa
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.TextBox txtIdComision;
        private System.Windows.Forms.Label lbIdComision;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbAnioEsp;
        private System.Windows.Forms.TextBox txtAnioEsp;
    }
}