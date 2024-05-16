namespace General.GUI.GESTION_ROLES_PERMISOS
{
    partial class GestionPermisos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GestionPermisos));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dtgAsignados = new System.Windows.Forms.DataGridView();
            this.dtgPermisos = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rolLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAsignados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPermisos)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(478, 29);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(179, 160);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // dtgAsignados
            // 
            this.dtgAsignados.AllowUserToAddRows = false;
            this.dtgAsignados.AllowUserToDeleteRows = false;
            this.dtgAsignados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgAsignados.BackgroundColor = System.Drawing.SystemColors.Info;
            this.dtgAsignados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgAsignados.Location = new System.Drawing.Point(478, 248);
            this.dtgAsignados.Name = "dtgAsignados";
            this.dtgAsignados.ReadOnly = true;
            this.dtgAsignados.Size = new System.Drawing.Size(362, 186);
            this.dtgAsignados.TabIndex = 2;
            // 
            // dtgPermisos
            // 
            this.dtgPermisos.AllowUserToAddRows = false;
            this.dtgPermisos.AllowUserToDeleteRows = false;
            this.dtgPermisos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgPermisos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgPermisos.Location = new System.Drawing.Point(12, 248);
            this.dtgPermisos.MultiSelect = false;
            this.dtgPermisos.Name = "dtgPermisos";
            this.dtgPermisos.ReadOnly = true;
            this.dtgPermisos.Size = new System.Drawing.Size(393, 186);
            this.dtgPermisos.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(109, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "Agregar permiso";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(127, 189);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(103, 42);
            this.button2.TabIndex = 5;
            this.button2.Text = "Quitar permiso";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(474, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 19);
            this.label1.TabIndex = 6;
            this.label1.Text = "Permisos asignados";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "Asignar permisos";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // rolLabel
            // 
            this.rolLabel.AutoSize = true;
            this.rolLabel.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rolLabel.Location = new System.Drawing.Point(474, 7);
            this.rolLabel.Name = "rolLabel";
            this.rolLabel.Size = new System.Drawing.Size(125, 19);
            this.rolLabel.TabIndex = 1;
            this.rolLabel.Text = "Administrador";
            this.rolLabel.Click += new System.EventHandler(this.label1_Click);
            // 
            // GestionPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 513);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dtgAsignados);
            this.Controls.Add(this.dtgPermisos);
            this.Controls.Add(this.rolLabel);
            this.Controls.Add(this.pictureBox1);
            this.Name = "GestionPermisos";
            this.Text = "GestionPermisos";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgAsignados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtgPermisos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridView dtgAsignados;
        private System.Windows.Forms.DataGridView dtgPermisos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label rolLabel;
    }
}