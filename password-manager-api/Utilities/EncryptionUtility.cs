using Microsoft.Extensions.Options;

namespace password_manager_api.Utilities
{
    public class EncryptionUtility
    {
        public AppSettings _appSettings;
        public EncryptionUtility(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public static string Encrypt(string plainText)
        {
            string EncryptedText = plainText;
            return EncryptedText;
        }

        public static string Decrypt(string EncryptedText)
        {
            string plainText = EncryptedText;
            return plainText;
        }
    }
}
