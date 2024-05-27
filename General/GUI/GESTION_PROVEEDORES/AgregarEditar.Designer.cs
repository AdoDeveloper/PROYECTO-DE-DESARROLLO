namespace General.GUI.GESTION_PROVEEDORES
{
    partial class AgregarEditar
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
            this.label1 = new System.Windows.Forms.Label();
            this.txbProveedor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txbContacto = new System.Windows.Forms.TextBox();
            this.NIT = new System.Windows.Forms.Label();
            this.txbNIT = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txbDireccion = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(23, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Nombre del proveedor";
            // 
            // txbProveedor
            // 
            this.txbProveedor.Location = new System.Drawing.Point(23, 70);
            this.txbProveedor.Name = "txbProveedor";
            this.txbProveedor.Size = new System.Drawing.Size(190, 20);
            this.txbProveedor.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(23, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Contacto";
            // 
            // txbContacto
            // 
            this.txbContacto.Location = new System.Drawing.Point(23, 164);
            this.txbContacto.Name = "txbContacto";
            this.txbContacto.Size = new System.Drawing.Size(190, 20);
            this.txbContacto.TabIndex = 6;
            // 
            // NIT
            // 
            this.NIT.AutoSize = true;
            this.NIT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NIT.Location = new System.Drawing.Point(26, 216);
            this.NIT.Name = "NIT";
            this.NIT.Size = new System.Drawing.Size(32, 16);
            this.NIT.TabIndex = 9;
            this.NIT.Text = "NIT";
            // 
            // txbNIT
            // 
            this.txbNIT.Location = new System.Drawing.Point(26, 243);
            this.txbNIT.Name = "txbNIT";
            this.txbNIT.Size = new System.Drawing.Size(190, 20);
            this.txbNIT.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 303);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Direccion";
            // 
            // txbDireccion
            // 
            this.txbDireccion.Location = new System.Drawing.Point(26, 330);
            this.txbDireccion.Name = "txbDireccion";
            this.txbDireccion.Size = new System.Drawing.Size(365, 20);
            this.txbDireccion.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(566, 384);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(93, 41);
            this.button1.TabIndex = 12;
            this.button1.Text = "GUARDAR";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(677, 384);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(93, 41);
            this.button2.TabIndex = 13;
            this.button2.Text = "CANCELAR";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // AgregarEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txbDireccion);
            this.Controls.Add(this.NIT);
            this.Controls.Add(this.txbNIT);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbContacto);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbProveedor);
            this.Name = "AgregarEditar";
            this.Text = "AgregarEditar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbProveedor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbContacto;
        private System.Windows.Forms.Label NIT;
        private System.Windows.Forms.TextBox txbNIT;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txbDireccion;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}