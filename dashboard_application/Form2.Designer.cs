
namespace lastone1
{
    partial class Form2
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.antiName = new System.Windows.Forms.Label();
            this.antiStatus = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Niagara Solid", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(42, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "Connection";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Niagara Solid", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(178, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(20, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "..";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Niagara Solid", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(42, 190);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 35);
            this.label3.TabIndex = 3;
            this.label3.Text = "Drive Status";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Niagara Solid", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(42, 504);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 35);
            this.label4.TabIndex = 4;
            this.label4.Text = "AntiVirus Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Niagara Solid", 19.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(42, 580);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(166, 35);
            this.label6.TabIndex = 6;
            this.label6.Text = "McAfee VirusScan";
            // 
            // antiName
            // 
            this.antiName.AutoSize = true;
            this.antiName.Font = new System.Drawing.Font("Niagara Solid", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.antiName.Location = new System.Drawing.Point(220, 510);
            this.antiName.Name = "antiName";
            this.antiName.Size = new System.Drawing.Size(20, 28);
            this.antiName.TabIndex = 7;
            this.antiName.Text = "..";
            // 
            // antiStatus
            // 
            this.antiStatus.AutoSize = true;
            this.antiStatus.Font = new System.Drawing.Font("Niagara Solid", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.antiStatus.Location = new System.Drawing.Point(220, 586);
            this.antiStatus.Name = "antiStatus";
            this.antiStatus.Size = new System.Drawing.Size(20, 28);
            this.antiStatus.TabIndex = 8;
            this.antiStatus.Text = "..";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 668);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 9;
            this.button1.Text = "check";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1120, 709);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.antiStatus);
            this.Controls.Add(this.antiName);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Bapco MS";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label antiName;
        private System.Windows.Forms.Label antiStatus;
        private System.Windows.Forms.Button button1;
    }
}