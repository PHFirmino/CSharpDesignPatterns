using api.Interfaces.HashPassword;
using System.Security.Cryptography;
using System.Text;

namespace api.Services.HashPasswordService
{
    public class HashPasswordService : IInterfaceHashPassword
    {
        public string HashPassword(string senha)
        {
            var sha256 = SHA256.Create();
            var hash = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));

            return BitConverter.ToString(hash).Replace("-", "").ToLower();
        }
    }
}
