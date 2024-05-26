namespace General.GUI.GESTION_USUARIOS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AgregarEditar));
            this.label2 = new System.Windows.Forms.Label();
            this.txbClave = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txbUsuario = new System.Windows.Forms.TextBox();
            this.cbEmpleado = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRol = new System.Windows.Forms.ComboBox();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.opfImagen = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(52, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Clave";
            // 
            // txbClave
            // 
            this.txbClave.Location = new System.Drawing.Point(52, 142);
            this.txbClave.Name = "txbClave";
            this.txbClave.Size = new System.Drawing.Size(190, 20);
            this.txbClave.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Usuario";
            // 
            // txbUsuario
            // 
            this.txbUsuario.Location = new System.Drawing.Point(52, 73);
            this.txbUsuario.Name = "txbUsuario";
            this.txbUsuario.Size = new System.Drawing.Size(190, 20);
            this.txbUsuario.TabIndex = 6;
            // 
            // cbEmpleado
            // 
            this.cbEmpleado.FormattingEnabled = true;
            this.cbEmpleado.Location = new System.Drawing.Point(281, 72);
            this.cbEmpleado.Name = "cbEmpleado";
            this.cbEmpleado.Size = new System.Drawing.Size(187, 21);
            this.cbEmpleado.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(278, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 16);
            this.label3.TabIndex = 11;
            this.label3.Text = "Empleado";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(278, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Rol";
            // 
            // cbRol
            // 
            this.cbRol.FormattingEnabled = true;
            this.cbRol.Location = new System.Drawing.Point(281, 141);
            this.cbRol.Name = "cbRol";
            this.cbRol.Size = new System.Drawing.Size(187, 21);
            this.cbRol.TabIndex = 12;
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.Location = new System.Drawing.Point(212, 364);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(88, 23);
            this.btnCargarImagen.TabIndex = 15;
            this.btnCargarImagen.Text = "Cargar imagen";
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // pbImagen
            // 
            this.pbImagen.Image = ((System.Drawing.Image)(resources.GetObject("pbImagen.Image")));
            this.pbImagen.Location = new System.Drawing.Point(182, 186);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(143, 156);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImagen.TabIndex = 14;
            this.pbImagen.TabStop = false;
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(268, 422);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(88, 33);
            this.btnCancelar.TabIndex = 22;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(160, 422);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(88, 33);
            this.btnGuardar.TabIndex = 21;
            this.btnGuardar.Text = "GUARDAR";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // opfImagen
            // 
            this.opfImagen.FileName = "openFileDialog1";
            // 
            // AgregarEditar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 467);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnCargarImagen);
            this.Controls.Add(this.pbImagen);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbRol);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbEmpleado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbClave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbUsuario);
            this.Name = "AgregarEditar";
            this.Text = "AgregarEditar";
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txbClave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbUsuario;
        private System.Windows.Forms.ComboBox cbEmpleado;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbRol;
        private System.Windows.Forms.Button btnCargarImagen;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.OpenFileDialog opfImagen;
    }
}