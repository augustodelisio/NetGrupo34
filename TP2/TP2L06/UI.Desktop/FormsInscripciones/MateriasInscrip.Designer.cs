namespace UI.Desktop
{
    partial class MateriasInscrip
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
            this.dgvCursosInscrip = new System.Windows.Forms.DataGridView();
            this.dgvMateriasInscrip = new System.Windows.Forms.DataGridView();
            this.btnInscribirse = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.materia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.condicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nota = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.año = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsSemanales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hsTotales = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdPlan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.habilitado = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tlUsuarios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosInscrip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriasInscrip)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tlUsuarios);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(854, 505);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(854, 505);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // tlUsuarios
            // 
            this.tlUsuarios.ColumnCount = 2;
            this.tlUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlUsuarios.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlUsuarios.Controls.Add(this.dgvCursosInscrip, 0, 1);
            this.tlUsuarios.Controls.Add(this.dgvMateriasInscrip, 0, 3);
            this.tlUsuarios.Controls.Add(this.btnSalir, 1, 4);
            this.tlUsuarios.Controls.Add(this.label1, 0, 0);
            this.tlUsuarios.Controls.Add(this.label2, 0, 2);
            this.tlUsuarios.Controls.Add(this.btnInscribirse, 0, 4);
            this.tlUsuarios.Location = new System.Drawing.Point(12, 12);
            this.tlUsuarios.Name = "tlUsuarios";
            this.tlUsuarios.RowCount = 5;
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 5F));
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tlUsuarios.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tlUsuarios.Size = new System.Drawing.Size(830, 481);
            this.tlUsuarios.TabIndex = 0;
            // 
            // dgvCursosInscrip
            // 
            this.dgvCursosInscrip.AllowUserToAddRows = false;
            this.dgvCursosInscrip.AllowUserToDeleteRows = false;
            this.dgvCursosInscrip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvCursosInscrip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCursosInscrip.BackgroundColor = System.Drawing.Color.Gray;
            this.dgvCursosInscrip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCursosInscrip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.materia,
            this.comision,
            this.condicion,
            this.nota,
            this.año});
            this.tlUsuarios.SetColumnSpan(this.dgvCursosInscrip, 2);
            this.dgvCursosInscrip.Location = new System.Drawing.Point(3, 25);
            this.dgvCursosInscrip.MultiSelect = false;
            this.dgvCursosInscrip.Name = "dgvCursosInscrip";
            this.dgvCursosInscrip.ReadOnly = true;
            this.dgvCursosInscrip.RowHeadersVisible = false;
            this.dgvCursosInscrip.RowHeadersWidth = 51;
            this.dgvCursosInscrip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCursosInscrip.Size = new System.Drawing.Size(827, 158);
            this.dgvCursosInscrip.TabIndex = 5;
            this.dgvCursosInscrip.SelectionChanged += new System.EventHandler(this.dgvCursosInscrip_SelectionChanged);
            // 
            // dgvMateriasInscrip
            // 
            this.dgvMateriasInscrip.AllowUserToAddRows = false;
            this.dgvMateriasInscrip.AllowUserToDeleteRows = false;
            this.dgvMateriasInscrip.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvMateriasInscrip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvMateriasInscrip.BackgroundColor = System.Drawing.Color.Gray;
            this.dgvMateriasInscrip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMateriasInscrip.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.id,
            this.descripcion,
            this.hsSemanales,
            this.hsTotales,
            this.IdPlan,
            this.habilitado});
            this.tlUsuarios.SetColumnSpan(this.dgvMateriasInscrip, 2);
            this.dgvMateriasInscrip.Location = new System.Drawing.Point(3, 217);
            this.dgvMateriasInscrip.MultiSelect = false;
            this.dgvMateriasInscrip.Name = "dgvMateriasInscrip";
            this.dgvMateriasInscrip.ReadOnly = true;
            this.dgvMateriasInscrip.RowHeadersWidth = 51;
            this.dgvMateriasInscrip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMateriasInscrip.Size = new System.Drawing.Size(827, 201);
            this.dgvMateriasInscrip.TabIndex = 0;
            // 
            // btnInscribirse
            // 
            this.btnInscribirse.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnInscribirse.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnInscribirse.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInscribirse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnInscribirse.Location = new System.Drawing.Point(3, 435);
            this.btnInscribirse.Name = "btnInscribirse";
            this.btnInscribirse.Size = new System.Drawing.Size(746, 46);
            this.btnInscribirse.TabIndex = 1;
            this.btnInscribirse.Text = "Inscribirse";
            this.btnInscribirse.UseVisualStyleBackColor = false;
            this.btnInscribirse.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSalir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnSalir.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSalir.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSalir.Location = new System.Drawing.Point(755, 435);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 46);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = false;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.tlUsuarios.SetColumnSpan(this.label1, 2);
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(374, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Mis cursos";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.tlUsuarios.SetColumnSpan(this.label2, 2);
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(373, 194);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Inscribirme";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "IdInscripcion";
            this.dataGridViewTextBoxColumn1.HeaderText = "ID";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // materia
            // 
            this.materia.DataPropertyName = "Materia";
            this.materia.HeaderText = "Materia";
            this.materia.MinimumWidth = 6;
            this.materia.Name = "materia";
            this.materia.ReadOnly = true;
            // 
            // comision
            // 
            this.comision.DataPropertyName = "Comision";
            this.comision.HeaderText = "Comision";
            this.comision.MinimumWidth = 6;
            this.comision.Name = "comision";
            this.comision.ReadOnly = true;
            // 
            // condicion
            // 
            this.condicion.DataPropertyName = "Condicion";
            this.condicion.HeaderText = "Condición";
            this.condicion.MinimumWidth = 6;
            this.condicion.Name = "condicion";
            this.condicion.ReadOnly = true;
            // 
            // nota
            // 
            this.nota.DataPropertyName = "Nota";
            this.nota.HeaderText = "Nota";
            this.nota.MinimumWidth = 6;
            this.nota.Name = "nota";
            this.nota.ReadOnly = true;
            // 
            // año
            // 
            this.año.DataPropertyName = "Anio";
            this.año.HeaderText = "Año";
            this.año.Name = "año";
            this.año.ReadOnly = true;
            // 
            // id
            // 
            this.id.DataPropertyName = "IdMateria";
            this.id.HeaderText = "ID";
            this.id.MinimumWidth = 6;
            this.id.Name = "id";
            this.id.ReadOnly = true;
            this.id.Visible = false;
            // 
            // descripcion
            // 
            this.descripcion.DataPropertyName = "Descripcion";
            this.descripcion.HeaderText = "Descripcion";
            this.descripcion.MinimumWidth = 6;
            this.descripcion.Name = "descripcion";
            this.descripcion.ReadOnly = true;
            // 
            // hsSemanales
            // 
            this.hsSemanales.DataPropertyName = "HsSemanales";
            this.hsSemanales.HeaderText = "Horas Semanales";
            this.hsSemanales.MinimumWidth = 6;
            this.hsSemanales.Name = "hsSemanales";
            this.hsSemanales.ReadOnly = true;
            // 
            // hsTotales
            // 
            this.hsTotales.DataPropertyName = "HsTotales";
            this.hsTotales.HeaderText = "Horas Totales";
            this.hsTotales.MinimumWidth = 6;
            this.hsTotales.Name = "hsTotales";
            this.hsTotales.ReadOnly = true;
            // 
            // IdPlan
            // 
            this.IdPlan.DataPropertyName = "IdPlan";
            this.IdPlan.HeaderText = "Plan";
            this.IdPlan.Name = "IdPlan";
            this.IdPlan.ReadOnly = true;
            this.IdPlan.Visible = false;
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
            // MateriasInscrip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(854, 505);
            this.Controls.Add(this.toolStripContainer1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MateriasInscrip";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Materias";
            this.Load += new System.EventHandler(this.MateriasInscrip_Load);
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tlUsuarios.ResumeLayout(false);
            this.tlUsuarios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCursosInscrip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMateriasInscrip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tlUsuarios;
        private System.Windows.Forms.DataGridView dgvMateriasInscrip;
        private System.Windows.Forms.Button btnInscribirse;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvCursosInscrip;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn materia;
        private System.Windows.Forms.DataGridViewTextBoxColumn comision;
        private System.Windows.Forms.DataGridViewTextBoxColumn condicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nota;
        private System.Windows.Forms.DataGridViewTextBoxColumn año;
        private System.Windows.Forms.DataGridViewTextBoxColumn id;
        private System.Windows.Forms.DataGridViewTextBoxColumn descripcion;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsSemanales;
        private System.Windows.Forms.DataGridViewTextBoxColumn hsTotales;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdPlan;
        private System.Windows.Forms.DataGridViewCheckBoxColumn habilitado;
    }
}

