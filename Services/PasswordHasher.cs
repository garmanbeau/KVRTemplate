using System.Security.Cryptography;
using System.Text;

namespace KVRTemplate.Services
{
    public static class PasswordHasher
    {
        public static string ComputeHash(string password, string pepper, int iteration)
        {
            if (iteration <= 0) return password;

            using var sha512 = SHA512.Create(); //declares and initializes sha512 object.

            string passwordPepper = $"{password}{pepper}"; //combines password cleartext with pepper
            byte[] byteValue = Encoding.UTF8.GetBytes(passwordPepper);//encode to a sequence of bytes
            byte[] byteHash = sha512.ComputeHash(byteValue); //takes the bytes and hashes them
            string hash = Convert.ToBase64String(byteHash); //convert back to string/characters from bytes.

            return ComputeHash(hash, pepper, iteration - 1); //calls itself if iteration is not 0.
        }
    }
}
