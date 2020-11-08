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
            this.btnInscribirme = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.dgvCursosInscrip = new System.Windows.Forms.DataGridView();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anioCalendario = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cupo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMateria = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdComision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.lbMateria = new System.Windows.Forms.Label();
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(703, 399);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(703, 424);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // tlUsuarios
            // 
            this.tlUsuarios.ColumnCount = 2;
            this.tlUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.tlUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlUsuarios.Controls.Add(this.btnInscribirme, 0, 2);
            this.tlUsuarios.Controls.Add(this.btnSalir, 1, 2);
            this.tlUsuarios.Controls.Add(this.dgvCursosInscrip, 0, 1);
            this.tlUsuarios.Controls.Add(this.lbMateria, 0, 0);
            this.tlUsuarios.Location = new System.Drawing.Point(0, 0);
            this.tlUsuarios.Name = "tlUsuarios";
            this.tlUsuarios.RowCount = 3;
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tlUsuarios.Size = new System.Drawing.Size(703, 421);
            this.tlUsuarios.TabIndex = 0;
            // 
            // btnInscribirme
            // 
            this.btnInscribirme.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnInscribirme.Location = new System.Drawing.Point(519, 369);
            this.btnInscribirme.Name = "btnInscribirme";
            this.btnInscribirme.Size = new System.Drawing.Size(75, 39);
            this.btnInscribirme.TabIndex = 1;
            this.btnInscribirme.Text = "Inscribirme";
            this.btnInscribirme.UseVisualStyleBackColor = true;
            this.btnInscribirme.Click += new System.EventHandler(this.btnInscribirme_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnSalir.Location = new System.Drawing.Point(625, 369);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 39);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // dgvCursosInscrip
            // 
            this.dgvCursosInscrip.AllowUserToAddRows = false;
            this.dgvCursosInscrip.AllowUserToDeleteRows = false;
            this.dgvCursosInscrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCursosInscrip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursosInscrip.BackgroundColor = System.Drawing.SystemColors.ActiveCaption;
            this.dgvCursosInscrip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursosInscrip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.nombre,
            this.anioCalendario,
            this.cupo,
            this.IdMateria,
            this.IdComision,
            this.habilitado});
            this.tlUsuarios.SetColumnSpan(this.dgvCursosInscrip, 2);
            this.dgvCursosInscrip.Location = new System.Drawing.Point(3, 45);
            this.dgvCursosInscrip.MultiSelect = false;
            this.dgvCursosInscrip.Name = "dgvCursosInscrip";
            this.dgvCursosInscrip.ReadOnly = true;
            this.dgvCursosInscrip.RowHeadersWidth = 51;
            this.dgvCursosInscrip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursosInscrip.Size = new System.Drawing.Size(697, 308);
            this.dgvCursosInscrip.TabIndex = 0;
            // 
            // id
            // 
            this.id.DataPropertyName = "IdCurso";
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            // 
            // nombre
            // 
            this.nombre.DataPropertyName = "Descripcion";
            this.nombre.HeaderText = "Nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            // 
            // anioCalendario
            // 
            this.anioCalendario.DataPropertyName = "AnioCalendario";
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
            // IdMateria
            // 
            this.IdMateria.DataPropertyName = "IdMateria";
            this.IdMateria.HeaderText = "Materia";
            this.IdMateria.MinimumWidth = 6;
            this.IdMateria.Name = "IdMateria";
            this.IdMateria.ReadOnly = true;
            // 
            // IdComision
            // 
            this.IdComision.DataPropertyName = "IdComision";
            this.IdComision.HeaderText = "Comision";
            this.IdComision.MinimumWidth = 6;
            this.IdComision.Name = "IdComision";
            this.IdComision.ReadOnly = true;
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
            this.lbMateria.Location = new System.Drawing.Point(326, 11);
            this.lbMateria.Name = "lbMateria";
            this.lbMateria.Size = new System.Drawing.Size(51, 20);
            this.lbMateria.TabIndex = 3;
            this.lbMateria.Text = "label1";
            this.lbMateria.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CursosInscrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 424);
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
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn anioCalendario;
        private System.Windows.Forms.DataGridViewTextBoxColumn cupo;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMateria;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdComision;
        private System.Windows.Forms.DataGridViewCheckBoxColumn habilitado;
        private System.Windows.Forms.Label lbMateria;
    }
}

