﻿namespace SOS
{
    partial class Siralama
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
            this.SiralamaList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SiralamaList
            // 
            this.SiralamaList.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.SiralamaList.FullRowSelect = true;
            this.SiralamaList.GridLines = true;
            this.SiralamaList.HideSelection = false;
            this.SiralamaList.Location = new System.Drawing.Point(12, 32);
            this.SiralamaList.Name = "SiralamaList";
            this.SiralamaList.Size = new System.Drawing.Size(450, 400);
            this.SiralamaList.TabIndex = 0;
            this.SiralamaList.UseCompatibleStateImageBehavior = false;
            this.SiralamaList.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(372, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // Siralama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SiralamaList);
            this.Name = "Siralama";
            this.Text = "Siralama";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Siralama_FormClosing);
            this.Load += new System.EventHandler(this.Siralama_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView SiralamaList;
        public System.Windows.Forms.Label label1;
    }
}