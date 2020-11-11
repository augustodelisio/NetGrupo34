namespace UI.Desktop
{
    partial class CursosInscrip
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
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tlUsuarios = new System.Windows.Forms.TableLayoutPanel();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvCursosInscrip = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anioCalendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroCom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lbMateria = new System.Windows.Forms.Label();
            this.btnInscribirme = new System.Windows.Forms.Button();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tlUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosInscrip)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tlUsuarios);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(703, 389);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(703, 389);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // tlUsuarios
            // 
            this.tlUsuarios.ColumnCount = 2;
            this.tlUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlUsuarios.Controls.Add(this.btnSalir, 1, 2);
            this.tlUsuarios.Controls.Add(this.dgvCursosInscrip, 0, 1);
            this.tlUsuarios.Controls.Add(this.lbMateria, 0, 0);
            this.tlUsuarios.Controls.Add(this.btnInscribirme, 0, 2);
            this.tlUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tlUsuarios.Name = "tlUsuarios";
            this.tlUsuarios.RowCount = 3;
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlUsuarios.Size = new System.Drawing.Size(703, 388);
            this.tlUsuarios.TabIndex = 0;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Location = new System.Drawing.Point(600, 336);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(100, 45);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvCursosInscrip
            // 
            this.dgvCursosInscrip.AllowUserToAddRows = false;
            this.dgvCursosInscrip.AllowUserToDeleteRows = false;
            this.dgvCursosInscrip.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.dgvCursosInscrip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursosInscrip.BackgroundColor = System.Drawing.Color.Gray;
            this.dgvCursosInscrip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursosInscrip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.materia,
            this.anioCalendario,
            this.cupo,
            this.numeroCom,
            this.IdComision,
            this.habilitado});
            this.tlUsuarios.SetColumnSpan(this.dgvCursosInscrip, 2);
            this.dgvCursosInscrip.Location = new System.Drawing.Point(3, 41);
            this.dgvCursosInscrip.MultiSelect = false;
            this.dgvCursosInscrip.Name = "dgvCursosInscrip";
            this.dgvCursosInscrip.ReadOnly = true;
            this.dgvCursosInscrip.RowHeadersWidth = 51;
            this.dgvCursosInscrip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursosInscrip.Size = new System.Drawing.Size(697, 285);
            this.dgvCursosInscrip.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "IdCurso";
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // materia
            // 
            this.materia.DataPropertyName = "NombreMat";
            this.materia.HeaderText = "Materia";
            this.materia.MinimumWidth = 6;
            this.materia.Name = "materia";
            this.materia.ReadOnly = true;
            // 
            // anioCalendario
            // 
            this.anioCalendario.DataPropertyName = "Anio";
            this.anioCalendario.HeaderText = "Año";
            this.anioCalendario.MinimumWidth = 6;
            this.anioCalendario.Name = "anioCalendario";
            this.anioCalendario.ReadOnly = true;
            // 
            // cupo
            // 
            this.cupo.DataPropertyName = "Cupo";
            this.cupo.HeaderText = "Cupo";
            this.cupo.MinimumWidth = 6;
            this.cupo.Name = "cupo";
            this.cupo.ReadOnly = true;
            // 
            // numeroCom
            // 
            this.numeroCom.DataPropertyName = "numeroCom";
            this.numeroCom.HeaderText = "Comision";
            this.numeroCom.MinimumWidth = 6;
            this.numeroCom.Name = "numeroCom";
            this.numeroCom.ReadOnly = true;
            // 
            // IdComision
            // 
            this.IdComision.DataPropertyName = "IdComision";
            this.IdComision.HeaderText = "IdComision";
            this.IdComision.Name = "IdComision";
            this.IdComision.ReadOnly = true;
            this.IdComision.Visible = false;
            // 
            // habilitado
            // 
            this.habilitado.DataPropertyName = "Habilitado";
            this.habilitado.HeaderText = "Habilitado";
            this.habilitado.MinimumWidth = 6;
            this.habilitado.Name = "habilitado";
            this.habilitado.ReadOnly = true;
            this.habilitado.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.habilitado.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.habilitado.Visible = false;
            // 
            // lbMateria
            // 
            this.lbMateria.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbMateria.AutoSize = true;
            this.tlUsuarios.SetColumnSpan(this.lbMateria, 2);
            this.lbMateria.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbMateria.Location = new System.Drawing.Point(326, 9);
            this.lbMateria.Name = "lbMateria";
            this.lbMateria.Size = new System.Drawing.Size(51, 20);
            this.lbMateria.TabIndex = 3;
            this.lbMateria.Text = "label1";
            this.lbMateria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnInscribirme
            // 
            this.btnInscribirme.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnInscribirme.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnInscribirme.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInscribirme.Location = new System.Drawing.Point(3, 336);
            this.btnInscribirme.Name = "btnInscribirme";
            this.btnInscribirme.Size = new System.Drawing.Size(591, 45);
            this.btnInscribirme.TabIndex = 1;
            this.btnInscribirme.Text = "Inscribirme";
            this.btnInscribirme.UseVisualStyleBackColor = false;
            this.btnInscribirme.Click += new System.EventHandler(this.btnInscribirme_Click);
            // 
            // CursosInscrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 389);
            this.Controls.Add(this.toolStripContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CursosInscrip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cursos";
            this.Load += new System.EventHandler(this.CursosInscrip_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tlUsuarios.ResumeLayout(false);
            this.tlUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosInscrip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tlUsuarios;
        private System.Windows.Forms.DataGridView dgvCursosInscrip;
        private System.Windows.Forms.Button btnInscribirme;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label lbMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn anioCalendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroCom;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComision;
        private System.Windows.Forms.DataGridViewCheckBoxColumn habilitado;
    }
}

