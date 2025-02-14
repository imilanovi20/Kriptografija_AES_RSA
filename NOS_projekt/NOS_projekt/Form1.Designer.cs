namespace NOS_projekt
{
    partial class Form1
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
            this.btnAES = new System.Windows.Forms.Button();
            this.btnRSA = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAES
            // 
            this.btnAES.Location = new System.Drawing.Point(57, 34);
            this.btnAES.Name = "btnAES";
            this.btnAES.Size = new System.Drawing.Size(75, 23);
            this.btnAES.TabIndex = 0;
            this.btnAES.Text = "AES";
            this.btnAES.UseVisualStyleBackColor = true;
            this.btnAES.Click += new System.EventHandler(this.btnAES_Click);
            // 
            // btnRSA
            // 
            this.btnRSA.Location = new System.Drawing.Point(57, 83);
            this.btnRSA.Name = "btnRSA";
            this.btnRSA.Size = new System.Drawing.Size(75, 23);
            this.btnRSA.TabIndex = 1;
            this.btnRSA.Text = "RSA";
            this.btnRSA.UseVisualStyleBackColor = true;
            this.btnRSA.Click += new System.EventHandler(this.btnRSA_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(217, 135);
            this.Controls.Add(this.btnRSA);
            this.Controls.Add(this.btnAES);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAES;
        private System.Windows.Forms.Button btnRSA;
    }
}

