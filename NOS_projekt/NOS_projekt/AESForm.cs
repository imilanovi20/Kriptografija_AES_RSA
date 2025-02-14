using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NOS_projekt.Backend;

namespace NOS_projekt
{
    public partial class AESForm : Form
    {
        public AESForm()
        {
            InitializeComponent();
        }

        Encription_Decription enc_dec = new Encription_Decription();
        HashClass hash = new HashClass();
        DigitalSign signature = new DigitalSign();

        private void btnPrilozi_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Svi dokumenti|*.*";
                openFileDialog.Title = "Odaberite dokument";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFilePath = openFileDialog.FileName;

                    string targetFolder = Path.Combine(Application.StartupPath, "../../Backend/Files/");

                    string targetFileName = Path.Combine(targetFolder, "PocetnaAESDatoteka.txt");

                    Directory.CreateDirectory(targetFolder);

                    File.Copy(selectedFilePath, targetFileName, true);

                    textBox.Text = Path.GetFileName(targetFileName);
                    string targetFileContent = File.ReadAllText("../../Backend/Files/PocetnaAESDatoteka.txt");
                    textBox2.Text = targetFileContent;
                }
            }
        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnPotvrsa_Click(object sender, EventArgs e)
        {
            if (!File.Exists("../../Backend/Files/SazetakAES.txt") || !File.Exists("../../Backend/Files/DigitalniPotpisAES.txt"))
            {
                MessageBox.Show("Ne postoje potrebne datoteke");
                return;
            }
            try
            {
                string inputFileName = "SazetakAES.txt";
                string inputFilePath = Path.Combine(Application.StartupPath, "../../Backend/Files", inputFileName);


                var isVerified = signature.VerifyDigitalSign(inputFilePath, false);

                if (isVerified)
                {
                    MessageBox.Show("Digitalni potpis je ispravan");
                }
                else
                {
                    MessageBox.Show("Digitalni potpis nije ispravan");
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPotpis_Click(object sender, EventArgs e)
        {
            if (!File.Exists("../../Backend/Files/SazetakAES.txt"))
            {
                MessageBox.Show("Ne postoje potrebne datoteke");
                return;
            }
            try
            {
                string inputFileName = "PocetnaAESDatoteka.txt";
                string inputFilePath = Path.Combine(Application.StartupPath, "../../Backend/Files", inputFileName);


                signature.CreateDigitalSign(inputFilePath, false);

                string hashContent = File.ReadAllText("../../Backend/Files/DigitalniPotpisAES.txt");
                textBox.Text = Path.GetFileName("../../Backend/Files/DigitalniPotpisAES.txt");
                textBox2.Text = hashContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGeneriranje_Click(object sender, EventArgs e)
        {
            if (!File.Exists("../../Backend/Files/PocetnaAESDatoteka.txt"))
            {
                MessageBox.Show("Ne postoje potrebne datoteke");
                return;
            }
            try
            {
                string inputFileName = "PocetnaAESDatoteka.txt";
                string inputFilePath = Path.Combine(Application.StartupPath, "../../Backend/Files", inputFileName);


                hash.CreateHash(inputFilePath, false);

                string hashContent = File.ReadAllText("../../Backend/Files/SazetakAES.txt");
                textBox.Text = Path.GetFileName("../../Backend/Files/SazetakAES.txt");
                textBox2.Text = hashContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDekripcija_Click(object sender, EventArgs e)
        {
            if (!File.Exists("../../Backend/Files/PocetnaAESDatoteka.txt") || !File.Exists("../../Backend/Files/EnkriptiranaAESDatoteka.txt"))
            {
                MessageBox.Show("Ne postoje potrebne datoteke");
                return;
            }
            try
            {
                string inputFileName = "EnkriptiranaAESDatoteka.txt";
                string inputFilePath = Path.Combine(Application.StartupPath, "../../Backend/Files", inputFileName);


                enc_dec.AESDecryptFile(inputFilePath);

                string decryptedContent = File.ReadAllText("../../Backend/Files/DekriptiranaAESDatoteka.txt");
                textBox.Text = Path.GetFileName("../../Backend/Files/DekriptiranaAESDatoteka.txt");
                textBox2.Text = decryptedContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEnkripcija_Click(object sender, EventArgs e)
        {
            if (!File.Exists("../../Backend/Files/PocetnaAESDatoteka.txt"))
            {
                MessageBox.Show("Ne postoje potrebne datoteke");
                return;
            }
            try
            {
                string inputFileName = "PocetnaAESDatoteka.txt";
                string inputFilePath = Path.Combine(Application.StartupPath, "../../Backend/Files", inputFileName);


                enc_dec.AESEncryptFile(inputFilePath);

                string encryptedContent = File.ReadAllText("../../Backend/Files/EnkriptiranaAESDatoteka.txt");
                textBox.Text = Path.GetFileName("../../Backend/Files/EnkriptiranaAESDatoteka.txt");
                textBox2.Text = encryptedContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void richTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void AESForm_Load(object sender, EventArgs e)
        {

        }
    }
}
