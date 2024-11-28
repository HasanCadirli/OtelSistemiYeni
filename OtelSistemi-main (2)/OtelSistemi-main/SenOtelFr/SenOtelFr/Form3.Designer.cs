namespace SenOtelFr
{
    partial class Personel
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
            this.btn_personelgiris = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_personelsifre = new System.Windows.Forms.TextBox();
            this.txt_personeladi = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_personelgiris
            // 
            this.btn_personelgiris.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.btn_personelgiris.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btn_personelgiris.Location = new System.Drawing.Point(129, 370);
            this.btn_personelgiris.Name = "btn_personelgiris";
            this.btn_personelgiris.Size = new System.Drawing.Size(159, 42);
            this.btn_personelgiris.TabIndex = 2;
            this.btn_personelgiris.Text = "Giriş";
            this.btn_personelgiris.UseVisualStyleBackColor = false;
            this.btn_personelgiris.Click += new System.EventHandler(this.btn_personelgiris_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(60, 310);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 23);
            this.label2.TabIndex = 19;
            this.label2.Text = "Şifre:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(2, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(111, 69);
            this.label1.TabIndex = 20;
            this.label1.Text = "Personel adı:\r\n\r\n\r\n";
            // 
            // txt_personelsifre
            // 
            this.txt_personelsifre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_personelsifre.Location = new System.Drawing.Point(129, 303);
            this.txt_personelsifre.Name = "txt_personelsifre";
            this.txt_personelsifre.Size = new System.Drawing.Size(159, 30);
            this.txt_personelsifre.TabIndex = 1;
            // 
            // txt_personeladi
            // 
            this.txt_personeladi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txt_personeladi.Location = new System.Drawing.Point(129, 241);
            this.txt_personeladi.Name = "txt_personeladi";
            this.txt_personeladi.Size = new System.Drawing.Size(159, 30);
            this.txt_personeladi.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::SenOtelFr.Properties.Resources.teamwork_6462892;
            this.pictureBox1.Location = new System.Drawing.Point(53, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(255, 182);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 21;
            this.pictureBox1.TabStop = false;
            // 
            // Personel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(335, 450);
            this.Controls.Add(this.btn_personelgiris);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_personelsifre);
            this.Controls.Add(this.txt_personeladi);
            this.Name = "Personel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel";
            this.Load += new System.EventHandler(this.Personel_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_personelgiris;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_personelsifre;
        private System.Windows.Forms.TextBox txt_personeladi;
    }
}