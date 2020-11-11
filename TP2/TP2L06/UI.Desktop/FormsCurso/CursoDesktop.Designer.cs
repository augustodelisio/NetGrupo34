namespace UI.Desktop
{
    partial class CursoDesktop
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CursoDesktop));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lbID = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lbAnioCalendario = new System.Windows.Forms.Label();
            this.txtAnioCalendario = new System.Windows.Forms.TextBox();
            this.cbComision = new System.Windows.Forms.ComboBox();
            this.btnCrearComision = new System.Windows.Forms.Button();
            this.lbCupo = new System.Windows.Forms.Label();
            this.txtCupo = new System.Windows.Forms.TextBox();
            this.lbMateria = new System.Windows.Forms.Label();
            this.cbMateria = new System.Windows.Forms.ComboBox();
            this.lbComision = new System.Windows.Forms.Label();
            this.btnCrearMateria = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.lbID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbDescripcion, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbAnioCalendario, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtAnioCalendario, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.cbComision, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCrearComision, 4, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbCupo, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCupo, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lbMateria, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.cbMateria, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbComision, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.btnCrearMateria, 4, 1);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 186);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbID
            // 
            this.lbID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(46, 8);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(18, 13);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(70, 5);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(99, 20);
            this.txtID.TabIndex = 4;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnAceptar, 4);
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(3, 137);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(352, 39);
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
            this.btnCancelar.Location = new System.Drawing.Point(361, 137);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(85, 39);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(20, 40);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(44, 13);
            this.lbDescripcion.TabIndex = 10;
            this.lbDescripcion.Text = "Nombre";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(70, 35);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(99, 20);
            this.txtDescripcion.TabIndex = 13;
            // 
            // lbAnioCalendario
            // 
            this.lbAnioCalendario.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbAnioCalendario.AutoSize = true;
            this.lbAnioCalendario.Location = new System.Drawing.Point(38, 72);
            this.lbAnioCalendario.Name = "lbAnioCalendario";
            this.lbAnioCalendario.Size = new System.Drawing.Size(26, 13);
            this.lbAnioCalendario.TabIndex = 3;
            this.lbAnioCalendario.Text = "Año";
            // 
            // txtAnioCalendario
            // 
            this.txtAnioCalendario.Location = new System.Drawing.Point(70, 69);
            this.txtAnioCalendario.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtAnioCalendario.Name = "txtAnioCalendario";
            this.txtAnioCalendario.Size = new System.Drawing.Size(99, 20);
            this.txtAnioCalendario.TabIndex = 7;
            // 
            // cbComision
            // 
            this.cbComision.FormattingEnabled = true;
            this.cbComision.Location = new System.Drawing.Point(249, 99);
            this.cbComision.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.cbComision.Name = "cbComision";
            this.cbComision.Size = new System.Drawing.Size(99, 21);
            this.cbComision.TabIndex = 19;
            // 
            // btnCrearComision
            // 
            this.btnCrearComision.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCrearComision.BackgroundImage")));
            this.btnCrearComision.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearComision.Location = new System.Drawing.Point(358, 94);
            this.btnCrearComision.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.btnCrearComision.Name = "btnCrearComision";
            this.btnCrearComision.Size = new System.Drawing.Size(40, 31);
            this.btnCrearComision.TabIndex = 20;
            this.btnCrearComision.UseVisualStyleBackColor = true;
            this.btnCrearComision.Click += new System.EventHandler(this.btnCrearPersona_Click);
            // 
            // lbCupo
            // 
            this.lbCupo.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbCupo.AutoSize = true;
            this.lbCupo.Location = new System.Drawing.Point(32, 104);
            this.lbCupo.Name = "lbCupo";
            this.lbCupo.Size = new System.Drawing.Size(32, 13);
            this.lbCupo.TabIndex = 9;
            this.lbCupo.Text = "Cupo";
            // 
            // txtCupo
            // 
            this.txtCupo.Location = new System.Drawing.Point(70, 99);
            this.txtCupo.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtCupo.Name = "txtCupo";
            this.txtCupo.Size = new System.Drawing.Size(99, 20);
            this.txtCupo.TabIndex = 12;
            // 
            // lbMateria
            // 
            this.lbMateria.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbMateria.AutoSize = true;
            this.lbMateria.Location = new System.Drawing.Point(201, 40);
            this.lbMateria.Name = "lbMateria";
            this.lbMateria.Size = new System.Drawing.Size(42, 13);
            this.lbMateria.TabIndex = 2;
            this.lbMateria.Text = "Materia";
            // 
            // cbMateria
            // 
            this.cbMateria.FormattingEnabled = true;
            this.cbMateria.Location = new System.Drawing.Point(249, 35);
            this.cbMateria.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.cbMateria.Name = "cbMateria";
            this.cbMateria.Size = new System.Drawing.Size(99, 21);
            this.cbMateria.TabIndex = 19;
            // 
            // lbComision
            // 
            this.lbComision.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbComision.AutoSize = true;
            this.lbComision.Location = new System.Drawing.Point(194, 104);
            this.lbComision.Name = "lbComision";
            this.lbComision.Size = new System.Drawing.Size(49, 13);
            this.lbComision.TabIndex = 17;
            this.lbComision.Text = "Comisión";
            // 
            // btnCrearMateria
            // 
            this.btnCrearMateria.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCrearMateria.BackgroundImage")));
            this.btnCrearMateria.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCrearMateria.Location = new System.Drawing.Point(358, 30);
            this.btnCrearMateria.Margin = new System.Windows.Forms.Padding(0, 0, 3, 3);
            this.btnCrearMateria.Name = "btnCrearMateria";
            this.btnCrearMateria.Size = new System.Drawing.Size(40, 31);
            this.btnCrearMateria.TabIndex = 20;
            this.btnCrearMateria.UseVisualStyleBackColor = true;
            this.btnCrearMateria.Click += new System.EventHandler(this.btnCrearPersona_Click);
            // 
            // CursoDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 186);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CursoDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Curso";
            this.Load += new System.EventHandler(this.CursoDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbMateria;
        private System.Windows.Forms.Label lbAnioCalendario;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtAnioCalendario;
        private System.Windows.Forms.Label lbCupo;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.TextBox txtCupo;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label lbComision;
        private System.Windows.Forms.ComboBox cbComision;
        private System.Windows.Forms.Button btnCrearComision;
        private System.Windows.Forms.ComboBox cbMateria;
        private System.Windows.Forms.Button btnCrearMateria;
    }
}