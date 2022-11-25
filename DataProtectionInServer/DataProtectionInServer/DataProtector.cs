using System.Security.Cryptography;
using System.Text;

namespace DataProtectionInServer
{
    public class DataProtector
    {
        /*
         * 1. Verinin şifrelenmesi - onaylanması (Encryption - Decryption)
         * 2. Dosyaların erişimlerini encrypt etmek...
         * 
         * https://learn.microsoft.com/en-us/aspnet/core/security/data-protection/using-data-protection?view=aspnetcore-7.0
         * Bcrypt için ideal bir nuget paketi - açık kaynak:
         * https://github.com/neoKushan/BCrypt.Net-Core
         *
         */

        private string path;
        private byte[] entropy;
        public DataProtector(string path)
        {
            this.path = path;
            entropy = new byte[16];
            //new RNGCryptoServiceProvider().GetBytes(entropy);
            entropy = RandomNumberGenerator.GetBytes(16);
            this.path += "EncryptedData.aktif";
        }

        public int EncryptData(string criticalData)
        {
            var encodedData = Encoding.ASCII.GetBytes(criticalData);
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            int length = encryptDataToFile(encodedData, entropy, DataProtectionScope.CurrentUser, fileStream);
            fileStream.Close();
            return length;
        }

        private int encryptDataToFile(byte[] encodedData, byte[] entropy, DataProtectionScope currentUser, FileStream fileStream)
        {
            int output = 0;
            byte[] encryptedData = ProtectedData.Protect(encodedData, entropy, currentUser);
            if (fileStream.CanWrite && encryptedData != null)
            {
                fileStream.Write(encryptedData, 0, encryptedData.Length);
                output = encryptedData.Length;
            }
            return output;


        }

        public string DecryptData(int length)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            byte[] decryptData = decryptFromFile(entropy, DataProtectionScope.CurrentUser, fileStream, length);
            fileStream.Close();
            return Encoding.ASCII.GetString(decryptData);

        }

        private byte[] decryptFromFile(byte[] entropy, DataProtectionScope currentUser, FileStream fileStream, int length)
        {
            byte[] inputBuffer = new byte[length];
            byte[] outputBuffer;

            if (fileStream.CanRead)
            {
                fileStream.Read(inputBuffer, 0, inputBuffer.Length);
                outputBuffer = ProtectedData.Unprotect(inputBuffer, entropy, currentUser);
            }
            else
            {
                throw new IOException("Stream okunamıyor");
            }

            return outputBuffer;
        }
    }
}
