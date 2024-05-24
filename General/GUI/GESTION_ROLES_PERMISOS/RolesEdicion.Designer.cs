namespace General.GUI
{
    partial class RolesEdicion
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
            this.components = new System.ComponentModel.Container();
            this.txbIDRol = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txbRol = new System.Windows.Forms.TextBox();
            this.bntGuardar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.Notificador = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.Notificador)).BeginInit();
            this.SuspendLayout();
            // 
            // txbIDRol
            // 
            this.txbIDRol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbIDRol.Location = new System.Drawing.Point(137, 101);
            this.txbIDRol.Name = "txbIDRol";
            this.txbIDRol.ReadOnly = true;
            this.txbIDRol.Size = new System.Drawing.Size(109, 26);
            this.txbIDRol.TabIndex = 2;
            this.txbIDRol.TextChanged += new System.EventHandler(this.txbIDRol_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(133, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "IDRol";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(133, 153);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rol";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // txbRol
            // 
            this.txbRol.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txbRol.Location = new System.Drawing.Point(137, 186);
            this.txbRol.Name = "txbRol";
            this.txbRol.Size = new System.Drawing.Size(320, 26);
            this.txbRol.TabIndex = 4;
            this.txbRol.TextChanged += new System.EventHandler(this.txbRol_TextChanged);
            // 
            // bntGuardar
            // 
            this.bntGuardar.Location = new System.Drawing.Point(218, 259);
            this.bntGuardar.Name = "bntGuardar";
            this.bntGuardar.Size = new System.Drawing.Size(90, 48);
            this.bntGuardar.TabIndex = 0;
            this.bntGuardar.Text = "Guardar";
            this.bntGuardar.UseVisualStyleBackColor = true;
            this.bntGuardar.Click += new System.EventHandler(this.bntGuardar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(343, 258);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(98, 49);
            this.btnCancelar.TabIndex = 1;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // Notificador
            // 
            this.Notificador.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.Notificador.ContainerControl = this;
            // 
            // RolesEdicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 370);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txbRol);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbIDRol);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.bntGuardar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RolesEdicion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edicion de Roles";
            this.Load += new System.EventHandler(this.RolesEdicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Notificador)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bntGuardar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.ErrorProvider Notificador;
        public System.Windows.Forms.TextBox txbIDRol;
        public System.Windows.Forms.TextBox txbRol;
    }
}