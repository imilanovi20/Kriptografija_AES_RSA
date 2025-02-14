using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NOS_projekt.Backend
{
    public class KeyGenerate
    {

        public void GenerateKey()
        {
            // RSA
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);

                File.WriteAllText("../../Backend/Keys/javni_kljuc.txt", publicKey);
                File.WriteAllText("../../Backend/Keys/privatni_kljuc.txt", privateKey);
            }

            // AES
            using (AesCryptoServiceProvider aes = new AesCryptoServiceProvider())
            {
                aes.GenerateKey();
                string aesKey = Convert.ToBase64String(aes.Key);

                aes.GenerateIV();
                string iv = Convert.ToBase64String(aes.IV);

                File.WriteAllText("../../Backend/Keys/tajni_kljuc.txt", aesKey);
                File.WriteAllText("../../Backend/Keys/iv.txt", iv);
            }

        }
    }
}
