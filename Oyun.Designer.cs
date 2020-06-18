namespace SOS
{
    partial class Oyun
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Oyuncu2 = new System.Windows.Forms.Label();
            this.Oyuncu1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SiraTimer = new System.Windows.Forms.Timer(this.components);
            this.Oyuncu1Skor = new System.Windows.Forms.Label();
            this.Oyuncu2Skor = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(753, 2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(753, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "label2";
            // 
            // Oyuncu2
            // 
            this.Oyuncu2.AutoSize = true;
            this.Oyuncu2.Location = new System.Drawing.Point(152, 9);
            this.Oyuncu2.Name = "Oyuncu2";
            this.Oyuncu2.Size = new System.Drawing.Size(52, 13);
            this.Oyuncu2.TabIndex = 2;
            this.Oyuncu2.Text = "Oyun ID: ";
            // 
            // Oyuncu1
            // 
            this.Oyuncu1.AutoSize = true;
            this.Oyuncu1.Location = new System.Drawing.Point(12, 9);
            this.Oyuncu1.Name = "Oyuncu1";
            this.Oyuncu1.Size = new System.Drawing.Size(50, 13);
            this.Oyuncu1.TabIndex = 3;
            this.Oyuncu1.Text = "Oyuncu1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(308, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 26);
            this.button1.TabIndex = 4;
            this.button1.Text = "Tamam";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SiraTimer
            // 
            this.SiraTimer.Interval = 300;
            this.SiraTimer.Tick += new System.EventHandler(this.SiraTimer_Tick);
            // 
            // Oyuncu1Skor
            // 
            this.Oyuncu1Skor.AutoSize = true;
            this.Oyuncu1Skor.Location = new System.Drawing.Point(82, 9);
            this.Oyuncu1Skor.Name = "Oyuncu1Skor";
            this.Oyuncu1Skor.Size = new System.Drawing.Size(64, 13);
            this.Oyuncu1Skor.TabIndex = 5;
            this.Oyuncu1Skor.Text = "Oyuncu ID: ";
            // 
            // Oyuncu2Skor
            // 
            this.Oyuncu2Skor.AutoSize = true;
            this.Oyuncu2Skor.Location = new System.Drawing.Point(210, 9);
            this.Oyuncu2Skor.Name = "Oyuncu2Skor";
            this.Oyuncu2Skor.Size = new System.Drawing.Size(52, 13);
            this.Oyuncu2Skor.TabIndex = 6;
            this.Oyuncu2Skor.Text = "Oyun ID: ";
            // 
            // Oyun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Oyuncu2Skor);
            this.Controls.Add(this.Oyuncu1Skor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Oyuncu1);
            this.Controls.Add(this.Oyuncu2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Oyun";
            this.Text = "Oyun";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Oyun_FormClosing);
            this.Load += new System.EventHandler(this.Oyun_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Oyuncu2;
        private System.Windows.Forms.Label Oyuncu1;
        private System.Windows.Forms.Button button1;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer SiraTimer;
        private System.Windows.Forms.Label Oyuncu1Skor;
        private System.Windows.Forms.Label Oyuncu2Skor;
    }
}