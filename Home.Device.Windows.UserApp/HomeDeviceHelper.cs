using Home.Common.Model;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Home.Device.Windows.UserApp
{
    public static class HomeDeviceHelper
    {
        public static Credentials GetSavedCredentials()
        {
            var pth = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "home-automation");
            if (!Directory.Exists(pth))
            {
                Directory.CreateDirectory(pth);
                return null;
            }

            pth = Path.Combine(pth, "sharedc.dat");
            if (!File.Exists(pth))
                return null;

            string s = File.ReadAllText(pth);
            s = DecryptString(s);

            if (s == null)
                return null;
            
            return JsonConvert.DeserializeObject<Credentials>(s);
        }

        public static void SaveCredentials(Credentials cred)
        {
            var pth = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "home-automation");
            if (!Directory.Exists(pth))
                Directory.CreateDirectory(pth);

            pth = Path.Combine(pth, "sharedc.dat");

            string s = JsonConvert.SerializeObject(cred);
            s = EncryptString(s);

            File.WriteAllText(pth, s);
        }

        private class LoginFromDeviceRequest
        {
            public string login { get; set; }
            public string pwd { get; set; }

            public string deviceInternalName { get; set; }
            public string deviceKind { get; set; }
        }
        private class LoginFromDeviceResponse
        {
            public User User { get; set; }
            public Home.Common.Model.Device Device { get; set; }
            public AutomationMesh Mesh { get; set; }
            public string DeviceApiKey { get; set; }
        }

        public async static Task<Credentials> TestConnection(string server, string user, string password)
        {
            try
            {
                using (var cli = new WebClient())
                {
                    cli.Headers.Add(HttpRequestHeader.ContentType, "application/json");
                    var req = new LoginFromDeviceRequest()
                    {
                        deviceKind = "mobiledevice",
                        deviceInternalName = Environment.MachineName,
                        login = user,
                        pwd = password
                    };
                    var ret = await cli.UploadStringTaskAsync($"https://{server}/v1.0/users/login/device",
                        "POST",
                        JsonConvert.SerializeObject(req));
                    var res = JsonConvert.DeserializeObject<LoginFromDeviceResponse>(ret);
                    if (res != null && res.User != null)
                    {
                        var cred = new Credentials()
                        {
                            ServerUrl = $"https://{server}/",
                            DeviceId = res.Device.Id,
                            Password = res.DeviceApiKey,
                            MeshId = res.Mesh.PublicId,
                            UserId = res.User.Id
                        };
                        SaveCredentials(cred);
                        return cred;
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
                return null;
            }
        }


        public class Credentials
        {
            public string ServerUrl { get; set; }
            public string DeviceId { get; set; }
            public string Password { get; set; }
            public string MeshId { get; set; }
            public string UserId { get; set; }

        }

        private const string initVector = "altazion--office";
        private const string passPhrase = "thisisalongphraseusedtogetrandomthings";
        private const int keysize = 256;

        private static string EncryptString(string plainText)
        {
            if (string.IsNullOrEmpty(plainText))
                return string.Empty;

            byte[] initVectorBytes = Encoding.UTF8.GetBytes(initVector);
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();
            byte[] cipherTextBytes = memoryStream.ToArray();
            memoryStream.Close();
            cryptoStream.Close();
            return Convert.ToBase64String(cipherTextBytes);
        }

        private static string DecryptString(string cipherText)
        {
            if (string.IsNullOrEmpty(cipherText))
                return string.Empty;

            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null);
            byte[] keyBytes = password.GetBytes(keysize / 8);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
        }
    }
}
