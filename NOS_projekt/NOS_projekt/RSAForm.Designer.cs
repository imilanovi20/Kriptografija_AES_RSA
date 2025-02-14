namespace NOS_projekt
{
    partial class RSAForm
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
            this.btnPrilozi = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.RichTextBox();
            this.btnPotvrsa = new System.Windows.Forms.Button();
            this.btnPotpis = new System.Windows.Forms.Button();
            this.btnGeneriranje = new System.Windows.Forms.Button();
            this.btnDekripcija = new System.Windows.Forms.Button();
            this.btnEnkripcija = new System.Windows.Forms.Button();
            this.btnPovratak = new System.Windows.Forms.Button();
            this.textBox = new System.Windows.Forms.RichTextBox();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // btnPrilozi
            // 
            this.btnPrilozi.Location = new System.Drawing.Point(37, 61);
            this.btnPrilozi.Name = "btnPrilozi";
            this.btnPrilozi.Size = new System.Drawing.Size(167, 23);
            this.btnPrilozi.TabIndex = 17;
            this.btnPrilozi.Text = "Priloži";
            this.btnPrilozi.UseVisualStyleBackColor = true;
            this.btnPrilozi.Click += new System.EventHandler(this.btnPrilozi_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(502, 102);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(262, 225);
            this.textBox2.TabIndex = 16;
            this.textBox2.Text = "";
            // 
            // btnPotvrsa
            // 
            this.btnPotvrsa.Location = new System.Drawing.Point(305, 304);
            this.btnPotvrsa.Name = "btnPotvrsa";
            this.btnPotvrsa.Size = new System.Drawing.Size(172, 23);
            this.btnPotvrsa.TabIndex = 15;
            this.btnPotvrsa.Text = "Potvrda potpis";
            this.btnPotvrsa.UseVisualStyleBackColor = true;
            this.btnPotvrsa.Click += new System.EventHandler(this.btnPotvrsa_Click);
            // 
            // btnPotpis
            // 
            this.btnPotpis.Location = new System.Drawing.Point(305, 254);
            this.btnPotpis.Name = "btnPotpis";
            this.btnPotpis.Size = new System.Drawing.Size(172, 23);
            this.btnPotpis.TabIndex = 14;
            this.btnPotpis.Text = "Digitalni potpis";
            this.btnPotpis.UseVisualStyleBackColor = true;
            this.btnPotpis.Click += new System.EventHandler(this.btnPotpis_Click);
            // 
            // btnGeneriranje
            // 
            this.btnGeneriranje.Location = new System.Drawing.Point(305, 204);
            this.btnGeneriranje.Name = "btnGeneriranje";
            this.btnGeneriranje.Size = new System.Drawing.Size(172, 23);
            this.btnGeneriranje.TabIndex = 13;
            this.btnGeneriranje.Text = "Generiranje sažetka";
            this.btnGeneriranje.UseVisualStyleBackColor = true;
            this.btnGeneriranje.Click += new System.EventHandler(this.btnGeneriranje_Click);
            // 
            // btnDekripcija
            // 
            this.btnDekripcija.Location = new System.Drawing.Point(305, 157);
            this.btnDekripcija.Name = "btnDekripcija";
            this.btnDekripcija.Size = new System.Drawing.Size(172, 23);
            this.btnDekripcija.TabIndex = 12;
            this.btnDekripcija.Text = "Dekripcija";
            this.btnDekripcija.UseVisualStyleBackColor = true;
            this.btnDekripcija.Click += new System.EventHandler(this.btnDekripcija_Click);
            // 
            // btnEnkripcija
            // 
            this.btnEnkripcija.Location = new System.Drawing.Point(305, 102);
            this.btnEnkripcija.Name = "btnEnkripcija";
            this.btnEnkripcija.Size = new System.Drawing.Size(172, 23);
            this.btnEnkripcija.TabIndex = 11;
            this.btnEnkripcija.Text = "Enkripcija";
            this.btnEnkripcija.UseVisualStyleBackColor = true;
            this.btnEnkripcija.Click += new System.EventHandler(this.btnEnkripcija_Click);
            // 
            // btnPovratak
            // 
            this.btnPovratak.Location = new System.Drawing.Point(37, 366);
            this.btnPovratak.Name = "btnPovratak";
            this.btnPovratak.Size = new System.Drawing.Size(92, 23);
            this.btnPovratak.TabIndex = 10;
            this.btnPovratak.Text = "Povratak";
            this.btnPovratak.UseVisualStyleBackColor = true;
            this.btnPovratak.Click += new System.EventHandler(this.btnPovratak_Click);
            // 
            // textBox
            // 
            this.textBox.Location = new System.Drawing.Point(37, 102);
            this.textBox.Name = "textBox";
            this.textBox.Size = new System.Drawing.Size(262, 225);
            this.textBox.TabIndex = 9;
            this.textBox.Text = "";
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // RSAForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnPrilozi);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.btnPotvrsa);
            this.Controls.Add(this.btnPotpis);
            this.Controls.Add(this.btnGeneriranje);
            this.Controls.Add(this.btnDekripcija);
            this.Controls.Add(this.btnEnkripcija);
            this.Controls.Add(this.btnPovratak);
            this.Controls.Add(this.textBox);
            this.Name = "RSAForm";
            this.Text = "RSAForm";
            this.Load += new System.EventHandler(this.RSAForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrilozi;
        private System.Windows.Forms.RichTextBox textBox2;
        private System.Windows.Forms.Button btnPotvrsa;
        private System.Windows.Forms.Button btnPotpis;
        private System.Windows.Forms.Button btnGeneriranje;
        private System.Windows.Forms.Button btnDekripcija;
        private System.Windows.Forms.Button btnEnkripcija;
        private System.Windows.Forms.Button btnPovratak;
        private System.Windows.Forms.RichTextBox textBox;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}