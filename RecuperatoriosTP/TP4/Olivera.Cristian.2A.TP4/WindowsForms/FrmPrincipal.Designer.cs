namespace WindowsForms
{
    partial class FrmPrincipal
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btnSmartPhone = new System.Windows.Forms.Button();
            this.btnPantalla = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(88, 34);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(477, 88);
            this.dataGridView1.TabIndex = 2;
            // 
            // btnSmartPhone
            // 
            this.btnSmartPhone.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.btnSmartPhone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSmartPhone.Location = new System.Drawing.Point(232, 139);
            this.btnSmartPhone.Name = "btnSmartPhone";
            this.btnSmartPhone.Size = new System.Drawing.Size(152, 42);
            this.btnSmartPhone.TabIndex = 16;
            this.btnSmartPhone.Text = "Smarthpone";
            this.btnSmartPhone.UseVisualStyleBackColor = false;
            this.btnSmartPhone.Click += new System.EventHandler(this.btnSmartPhone_Click);
            // 
            // btnPantalla
            // 
            this.btnPantalla.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnPantalla.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPantalla.Location = new System.Drawing.Point(232, 203);
            this.btnPantalla.Name = "btnPantalla";
            this.btnPantalla.Size = new System.Drawing.Size(156, 42);
            this.btnPantalla.TabIndex = 17;
            this.btnPantalla.Text = "Pantalla";
            this.btnPantalla.UseVisualStyleBackColor = false;
            this.btnPantalla.Click += new System.EventHandler(this.btnPantalla_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Bahnschrift Condensed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(211, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(300, 23);
            this.label1.TabIndex = 18;
            this.label1.Text = "Cantidad total ventas";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(669, 257);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPantalla);
            this.Controls.Add(this.btnSmartPhone);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Historial de ventas";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmPrincipal_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPrincipal_FormClosed);
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnSmartPhone;
        private System.Windows.Forms.Button btnPantalla;
        private System.Windows.Forms.Label label1;
    }
}