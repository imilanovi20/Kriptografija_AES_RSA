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
    public partial class RSAForm : Form
    {
        public RSAForm()
        {
            InitializeComponent();
        }

        private void RSAForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPovratak_Click(object sender, EventArgs e)
        {
            Close();
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

                    string targetFileName = Path.Combine(targetFolder, "PocetnaDatoteka.txt");

                    Directory.CreateDirectory(targetFolder);

                    File.Copy(selectedFilePath, targetFileName, true);

                    textBox.Text = Path.GetFileName(targetFileName);
                    string targetFileContent = File.ReadAllText("../../Backend/Files/PocetnaDatoteka.txt");
                    textBox2.Text = targetFileContent;
                }
            }
        }

        private void btnEnkripcija_Click(object sender, EventArgs e)
        {
            if (!File.Exists("../../Backend/Files/PocetnaDatoteka.txt"))
            {
                MessageBox.Show("Ne postoje potrebne datoteke");
                return;
            }
            try
            {
                string inputFileName = "PocetnaDatoteka.txt";
                string inputFilePath = Path.Combine(Application.StartupPath, "../../Backend/Files", inputFileName);


                enc_dec.RSAEncryptFile(inputFilePath);

                string encryptedContent = File.ReadAllText("../../Backend/Files/EnkriptiranaDatoteka.txt");
                textBox.Text = Path.GetFileName("../../Backend/Files/EnkriptiranaDatoteka.txt");
                textBox2.Text = encryptedContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDekripcija_Click(object sender, EventArgs e)
        {
            if (!File.Exists("../../Backend/Files/PocetnaDatoteka.txt") || !File.Exists("../../Backend/Files/EnkriptiranaDatoteka.txt"))
            {
                MessageBox.Show("Ne postoje potrebne datoteke");
                return;
            }
            try
            {
                string inputFileName = "EnkriptiranaDatoteka.txt";
                string inputFilePath = Path.Combine(Application.StartupPath, "../../Backend/Files", inputFileName);


                enc_dec.RSADecryptFile(inputFilePath);

                string decryptedContent = File.ReadAllText("../../Backend/Files/DekriptiranaDatoteka.txt");
                textBox.Text = Path.GetFileName("../../Backend/Files/DekriptiranaDatoteka.txt");
                textBox2.Text = decryptedContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnGeneriranje_Click(object sender, EventArgs e)
        {
            if (!File.Exists("../../Backend/Files/PocetnaDatoteka.txt"))
            {
                MessageBox.Show("Ne postoje potrebne datoteke");
                return;
            }
            try
            {
                string inputFileName = "PocetnaDatoteka.txt";
                string inputFilePath = Path.Combine(Application.StartupPath, "../../Backend/Files", inputFileName);


                hash.CreateHash(inputFilePath,true);

                string hashContent = File.ReadAllText("../../Backend/Files/Sazetak.txt");
                textBox.Text = Path.GetFileName("../../Backend/Files/Sazetak.txt");
                textBox2.Text = hashContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnPotpis_Click(object sender, EventArgs e)
        {
            if (!File.Exists("../../Backend/Files/PocetnaDatoteka.txt"))
            {
                MessageBox.Show("Ne postoje potrebne datoteke");
                return;
            }
            try
            {
                string inputFileName = "PocetnaDatoteka.txt";
                string inputFilePath = Path.Combine(Application.StartupPath, "../../Backend/Files", inputFileName);


                signature.CreateDigitalSign(inputFilePath, true);

                string hashContent = File.ReadAllText("../../Backend/Files/DigitalniPotpis.txt");
                textBox.Text = Path.GetFileName("../../Backend/Files/DigitalniPotpis.txt");
                textBox2.Text = hashContent;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPotvrsa_Click(object sender, EventArgs e)
        {
            if (!File.Exists("../../Backend/Files/Sazetak.txt") || !File.Exists("../../Backend/Files/DigitalniPotpis.txt"))
            {
                MessageBox.Show("Ne postoje potrebne datoteke");
                return;
            }
            try
            {
                string inputFileName = "Sazetak.txt";
                string inputFilePath = Path.Combine(Application.StartupPath, "../../Backend/Files", inputFileName);


                var isVerified = signature.VerifyDigitalSign(inputFilePath, true);

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
    }
}
