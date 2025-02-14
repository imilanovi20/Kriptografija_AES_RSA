using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace NOS_projekt.Backend
{
    public class Encription_Decription
    {
        private string publicKeyPath = Path.Combine(Directory.GetCurrentDirectory(), "../../Backend/Keys/javni_kljuc.txt");
        private string privateKeyPath = Path.Combine(Directory.GetCurrentDirectory(), "../../Backend/Keys/privatni_kljuc.txt");

        private string AESKeyPath = Path.Combine(Directory.GetCurrentDirectory(), "../../Backend/Keys/tajni_kljuc.txt");
        private string ivKeyPath = Path.Combine(Directory.GetCurrentDirectory(), "../../Backend/Keys/iv.txt");

        public static event Action<string> ShowMessageBox;

        public  void RSAEncryptFile(string inputFile)
        {
            try
            {
                string publicKeyText = File.ReadAllText(publicKeyPath);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(publicKeyText);

                byte[] inputData = File.ReadAllBytes(inputFile);

                byte[] encryptedData = rsa.Encrypt(inputData, false);

                string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../Backend/Files/EnkriptiranaDatoteka.txt");
                File.WriteAllBytes(outputFilePath, encryptedData);

                ShowMessageBox?.Invoke("File encrypted successfully!");
            }
            catch (Exception ex)
            {
                ShowMessageBox?.Invoke($"Error encrypting file: {ex.Message}");
            }

        }
        public void RSADecryptFile(string inputFile)
        {
            try
            {
                string privateKeyText = File.ReadAllText(privateKeyPath);
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider();
                rsa.FromXmlString(privateKeyText);

                byte[] encryptedData = File.ReadAllBytes(inputFile);

                byte[] decryptedData = rsa.Decrypt(encryptedData, false);

                string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "../../Backend/Files/");

                string outputFilePath = Path.Combine(outputDirectory, "DekriptiranaDatoteka.txt");
                File.WriteAllBytes(outputFilePath, decryptedData);

                ShowMessageBox?.Invoke("File decrypted successfully!");
            }
            catch (Exception ex)
            {
                ShowMessageBox?.Invoke($"Error decrypting file: {ex.Message}");
            }

        }

        public void AESEncryptFile(string inputFile)
        {
            try
            {
                string aesKeyText = File.ReadAllText(AESKeyPath);
                string ivText = File.ReadAllText(ivKeyPath);

                byte[] aesKey = Convert.FromBase64String(aesKeyText);
                byte[] iv = Convert.FromBase64String(ivText);

                using (AesManaged aes = new AesManaged())
                {
                    aes.Key = aesKey;
                    aes.IV = iv;

                    using (FileStream inputFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                    {
                        using (MemoryStream outputStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(outputStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                            {
                                byte[] buffer = new byte[4096];
                                int bytesRead;
                                while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    cryptoStream.Write(buffer, 0, bytesRead);
                                }
                            }

                            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../Backend/Files/EnkriptiranaAESDatoteka.txt");
                            File.WriteAllBytes(outputFilePath, outputStream.ToArray());

                            ShowMessageBox?.Invoke("File encrypted successfully!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox?.Invoke($"Error encrypting file: {ex.Message}");
            }

        }

        public void AESDecryptFile(string inputFile)
        {
            try
            {
                string aesKeyText = File.ReadAllText(AESKeyPath);
                string ivText = File.ReadAllText(ivKeyPath);

                byte[] aesKey = Convert.FromBase64String(aesKeyText);
                byte[] iv = Convert.FromBase64String(ivText);

                using (AesManaged aes = new AesManaged())
                {
                    aes.Key = aesKey;
                    aes.IV = iv;

                    using (FileStream inputFileStream = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
                    {
                        using (MemoryStream outputStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(outputStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
                            {
                                byte[] buffer = new byte[4096];
                                int bytesRead;
                                while ((bytesRead = inputFileStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    cryptoStream.Write(buffer, 0, bytesRead);
                                }
                            }

                            string outputFilePath = Path.Combine(Directory.GetCurrentDirectory(), "../../Backend/Files/DekriptiranaAESDatoteka.txt");
                            File.WriteAllBytes(outputFilePath, outputStream.ToArray());

                            ShowMessageBox?.Invoke("File decrypted successfully!");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowMessageBox?.Invoke($"Error decrypting file: {ex.Message}");
            }

        }

    }
}
