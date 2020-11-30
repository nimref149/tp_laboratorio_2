namespace WindowsForms
{
    partial class FrmDatosSmartPhone
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnGuardarTexto = new System.Windows.Forms.Button();
            this.btnLeerTexto = new System.Windows.Forms.Button();
            this.btnGuardarXml = new System.Windows.Forms.Button();
            this.labelInforma = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(54, 56);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(590, 139);
            this.dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(52, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Ventas";
            // 
            // btnAlta
            // 
            this.btnAlta.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnAlta.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAlta.Location = new System.Drawing.Point(510, 293);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(142, 48);
            this.btnAlta.TabIndex = 3;
            this.btnAlta.Text = "Agregar una venta";
            this.btnAlta.UseVisualStyleBackColor = false;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnGuardarTexto
            // 
            this.btnGuardarTexto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardarTexto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarTexto.Location = new System.Drawing.Point(54, 232);
            this.btnGuardarTexto.Name = "btnGuardarTexto";
            this.btnGuardarTexto.Size = new System.Drawing.Size(149, 48);
            this.btnGuardarTexto.TabIndex = 4;
            this.btnGuardarTexto.Text = "Guardar datos";
            this.btnGuardarTexto.UseVisualStyleBackColor = false;
            this.btnGuardarTexto.Click += new System.EventHandler(this.btnGuardarTexto_Click);
            // 
            // btnLeerTexto
            // 
            this.btnLeerTexto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLeerTexto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLeerTexto.Location = new System.Drawing.Point(56, 293);
            this.btnLeerTexto.Name = "btnLeerTexto";
            this.btnLeerTexto.Size = new System.Drawing.Size(147, 47);
            this.btnLeerTexto.TabIndex = 5;
            this.btnLeerTexto.Text = "Leer datos";
            this.btnLeerTexto.UseVisualStyleBackColor = false;
            this.btnLeerTexto.Click += new System.EventHandler(this.btnLeerTexto_Click);
            // 
            // btnGuardarXml
            // 
            this.btnGuardarXml.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnGuardarXml.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarXml.Location = new System.Drawing.Point(510, 232);
            this.btnGuardarXml.Name = "btnGuardarXml";
            this.btnGuardarXml.Size = new System.Drawing.Size(142, 48);
            this.btnGuardarXml.TabIndex = 7;
            this.btnGuardarXml.Text = "Guardar archivo xml";
            this.btnGuardarXml.UseVisualStyleBackColor = false;
            this.btnGuardarXml.Click += new System.EventHandler(this.btnGuardarXml_Click);
            // 
            // labelInforma
            // 
            this.labelInforma.Location = new System.Drawing.Point(227, 250);
            this.labelInforma.Name = "labelInforma";
            this.labelInforma.Size = new System.Drawing.Size(265, 57);
            this.labelInforma.TabIndex = 8;
            // 
            // FrmDatosSmartPhone
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MintCream;
            this.ClientSize = new System.Drawing.Size(712, 374);
            this.Controls.Add(this.labelInforma);
            this.Controls.Add(this.btnGuardarXml);
            this.Controls.Add(this.btnLeerTexto);
            this.Controls.Add(this.btnGuardarTexto);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmDatosSmartPhone";
            this.Text = "Smart phone";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmDatosSmartPhone_FormClosing);
            this.Load += new System.EventHandler(this.fmrDatosSmartPhone_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnGuardarTexto;
        private System.Windows.Forms.Button btnLeerTexto;
        private System.Windows.Forms.Button btnGuardarXml;
        private System.Windows.Forms.Label labelInforma;
    }
}

