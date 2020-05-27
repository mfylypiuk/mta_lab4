using System.Windows.Forms;
using System.Drawing;
using System;

namespace ImageConverter
{
    partial class ImageConverter
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
            this.path = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // path
            // 
            this.path.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.path.Location = new System.Drawing.Point(94, 15);
            this.path.Margin = new System.Windows.Forms.Padding(4);
            this.path.Name = "path";
            this.path.ReadOnly = true;
            this.path.Size = new System.Drawing.Size(349, 22);
            this.path.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Menu;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.path);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(909, 55);
            this.panel1.TabIndex = 2;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(12, 14);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 1;
            this.button4.Text = "Open";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(33, 81);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(123, 34);
            this.button3.TabIndex = 9;
            this.button3.Text = "To PNG";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(162, 81);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 34);
            this.button1.TabIndex = 10;
            this.button1.Text = "To JPG";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_2);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(291, 81);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(123, 34);
            this.button2.TabIndex = 11;
            this.button2.Text = "To BMP";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // ImageConverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 130);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "ImageConverter";
            this.Text = "Лаб 4";
            this.Load += new System.EventHandler(this.ImageConverter_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox path;
        private System.Windows.Forms.Panel panel1;
        private Button button3;
        private Button button1;
        private Button button2;
        private Button button4;
    }
}

