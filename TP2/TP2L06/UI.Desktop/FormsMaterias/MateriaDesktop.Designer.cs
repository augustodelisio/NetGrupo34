namespace UI.Desktop
{
    partial class MateriaDesktop
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
            this.lbDescripcion = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lbID = new System.Windows.Forms.Label();
            this.lbHsSemanales = new System.Windows.Forms.Label();
            this.lbHsTotales = new System.Windows.Forms.Label();
            this.txtHsSemanales = new System.Windows.Forms.TextBox();
            this.txtHsTotales = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.lblPlan = new System.Windows.Forms.Label();
            this.cbPlanes = new System.Windows.Forms.ComboBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 28F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 47F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Controls.Add(this.lbDescripcion, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lbID, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbHsSemanales, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.lbHsTotales, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtHsSemanales, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtHsTotales, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.lblPlan, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.cbPlanes, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 2, 9);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(354, 210);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lbDescripcion
            // 
            this.lbDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbDescripcion.AutoSize = true;
            this.lbDescripcion.Location = new System.Drawing.Point(33, 38);
            this.lbDescripcion.Name = "lbDescripcion";
            this.lbDescripcion.Size = new System.Drawing.Size(63, 13);
            this.lbDescripcion.TabIndex = 1;
            this.lbDescripcion.Text = "Descripcion";
            // 
            // txtID
            // 
            this.txtID.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtID.Location = new System.Drawing.Point(102, 5);
            this.txtID.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtID.Name = "txtID";
            this.txtID.ReadOnly = true;
            this.txtID.Size = new System.Drawing.Size(75, 20);
            this.txtID.TabIndex = 4;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescripcion, 2);
            this.txtDescripcion.Location = new System.Drawing.Point(102, 35);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(208, 20);
            this.txtDescripcion.TabIndex = 5;
            // 
            // lbID
            // 
            this.lbID.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbID.AutoSize = true;
            this.lbID.Location = new System.Drawing.Point(78, 8);
            this.lbID.Name = "lbID";
            this.lbID.Size = new System.Drawing.Size(18, 13);
            this.lbID.TabIndex = 0;
            this.lbID.Text = "ID";
            // 
            // lbHsSemanales
            // 
            this.lbHsSemanales.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbHsSemanales.AutoSize = true;
            this.lbHsSemanales.Location = new System.Drawing.Point(6, 68);
            this.lbHsSemanales.Name = "lbHsSemanales";
            this.lbHsSemanales.Size = new System.Drawing.Size(90, 13);
            this.lbHsSemanales.TabIndex = 17;
            this.lbHsSemanales.Text = "Horas Semanales";
            this.lbHsSemanales.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbHsTotales
            // 
            this.lbHsTotales.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lbHsTotales.AutoSize = true;
            this.lbHsTotales.Location = new System.Drawing.Point(23, 98);
            this.lbHsTotales.Name = "lbHsTotales";
            this.lbHsTotales.Size = new System.Drawing.Size(73, 13);
            this.lbHsTotales.TabIndex = 18;
            this.lbHsTotales.Text = "Horas Totales";
            // 
            // txtHsSemanales
            // 
            this.txtHsSemanales.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtHsSemanales.Location = new System.Drawing.Point(102, 65);
            this.txtHsSemanales.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtHsSemanales.Name = "txtHsSemanales";
            this.txtHsSemanales.Size = new System.Drawing.Size(75, 20);
            this.txtHsSemanales.TabIndex = 20;
            // 
            // txtHsTotales
            // 
            this.txtHsTotales.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtHsTotales.Location = new System.Drawing.Point(102, 95);
            this.txtHsTotales.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.txtHsTotales.Name = "txtHsTotales";
            this.txtHsTotales.Size = new System.Drawing.Size(75, 20);
            this.txtHsTotales.TabIndex = 21;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.tableLayoutPanel1.SetColumnSpan(this.btnAceptar, 2);
            this.btnAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAceptar.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.Location = new System.Drawing.Point(5, 159);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(5, 3, 3, 3);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(257, 42);
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
            this.btnCancelar.Location = new System.Drawing.Point(268, 159);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(83, 42);
            this.btnCancelar.TabIndex = 16;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // lblPlan
            // 
            this.lblPlan.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.lblPlan.AutoSize = true;
            this.lblPlan.Location = new System.Drawing.Point(68, 129);
            this.lblPlan.Name = "lblPlan";
            this.lblPlan.Size = new System.Drawing.Size(28, 13);
            this.lblPlan.TabIndex = 18;
            this.lblPlan.Text = "Plan";
            // 
            // cbPlanes
            // 
            this.cbPlanes.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanel1.SetColumnSpan(this.cbPlanes, 2);
            this.cbPlanes.FormattingEnabled = true;
            this.cbPlanes.Location = new System.Drawing.Point(102, 125);
            this.cbPlanes.Margin = new System.Windows.Forms.Padding(3, 5, 10, 5);
            this.cbPlanes.Name = "cbPlanes";
            this.cbPlanes.Size = new System.Drawing.Size(208, 21);
            this.cbPlanes.TabIndex = 22;
            // 
            // MateriaDesktop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 210);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MateriaDesktop";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Materia";
            this.Load += new System.EventHandler(this.MateriaDesktop_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lbID;
        private System.Windows.Forms.Label lbDescripcion;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lbHsSemanales;
        private System.Windows.Forms.Label lbHsTotales;
        private System.Windows.Forms.TextBox txtHsSemanales;
        private System.Windows.Forms.TextBox txtHsTotales;
        private System.Windows.Forms.Label lblPlan;
        private System.Windows.Forms.ComboBox cbPlanes;
    }
}