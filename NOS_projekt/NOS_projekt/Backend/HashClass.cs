using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NOS_projekt.Backend
{
    public class HashClass
    {
        public void CreateHash(string documentPath, bool isRSA)
        {
            try
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] documentBytes = File.ReadAllBytes(documentPath);

                    byte[] hashBytes = sha256.ComputeHash(documentBytes);

                    string outputDirectory = Path.Combine(Directory.GetCurrentDirectory(), "../../Backend/Files/");

                    if (!Directory.Exists(outputDirectory))
                    {
                        Console.WriteLine("Output directory does not exist.");
                        return;
                    }

                    string outputFilePath = Path.Combine(outputDirectory, isRSA ? "Sazetak.txt" : "SazetakAES.txt");

                    File.WriteAllText(outputFilePath, Convert.ToBase64String(hashBytes));

                    Console.WriteLine($"Hash saved to: {outputFilePath}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating hash: {ex.Message}");
            }
        }
    }
}
