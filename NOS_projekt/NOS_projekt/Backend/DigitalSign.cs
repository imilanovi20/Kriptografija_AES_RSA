using System;
using System.IO;
using System.Security.Cryptography;
using Org.BouncyCastle.Security;

namespace NOS_projekt.Backend
{
    public class DigitalSign
    {
        private string privateKeyPath = Path.Combine(Directory.GetCurrentDirectory(), "../../Backend/Keys/privatni_kljuc.txt");
        private string publicKeyPath = Path.Combine(Directory.GetCurrentDirectory(), "../../Backend/Keys/javni_kljuc.txt");

        private RSACryptoServiceProvider rsa;

        public DigitalSign()
        {
            rsa = new RSACryptoServiceProvider();
            string privateKeyText = File.ReadAllText(privateKeyPath);
            rsa.FromXmlString(privateKeyText);
        }


        public void CreateDigitalSign(string documentPath, bool isRSA)
        {

            byte[] documentBytes = File.ReadAllBytes(documentPath);
            byte[] digitalSign = rsa.SignData(documentBytes, new SHA256CryptoServiceProvider());
            string base64DigitalSign = Convert.ToBase64String(digitalSign);

            string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "../../Backend/Files/");
            string outputFilePath = Path.Combine(outputDirectory, isRSA ? "DigitalniPotpis.txt" : "DigitalniPotpisAES.txt");

            File.WriteAllText(outputFilePath, base64DigitalSign);
        }

        public bool VerifyDigitalSign(string documentPath, bool isRSA)
        {
            byte[] documentBytes = Convert.FromBase64String(File.ReadAllText(documentPath));
            string base64DigitalSign = File.ReadAllText(isRSA ? "../../Backend/Files/DigitalniPotpis.txt" : "../../Backend/Files/DigitalniPotpisAES.txt");
            byte[] digitalSign = Convert.FromBase64String(base64DigitalSign);

            bool isSignatureValid = rsa.VerifyHash(documentBytes, nameof(SHA256), digitalSign);

            return isSignatureValid;
        }
    }
}