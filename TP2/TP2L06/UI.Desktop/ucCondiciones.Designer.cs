namespace UI.Desktop
{
    partial class ucCondiciones
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

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbCondiciones = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbCondiciones
            // 
            this.cmbCondiciones.FormattingEnabled = true;
            this.cmbCondiciones.Location = new System.Drawing.Point(0, 0);
            this.cmbCondiciones.Name = "cmbCondiciones";
            this.cmbCondiciones.Size = new System.Drawing.Size(164, 21);
            this.cmbCondiciones.TabIndex = 0;
            this.cmbCondiciones.SelectedIndexChanged += new System.EventHandler(this.cmbCondiciones_SelectedIndexChanged);
            // 
            // ucCondiciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.cmbCondiciones);
            this.Name = "ucCondiciones";
            this.Size = new System.Drawing.Size(210, 61);
            this.Load += new System.EventHandler(this.ucCondiciones_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbCondiciones;
    }
}
