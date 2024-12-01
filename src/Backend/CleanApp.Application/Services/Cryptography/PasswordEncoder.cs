using System.Security.Cryptography;
using System.Text;

namespace CleanApp.Application.Services.Cryptography;
public class PasswordEncoder
{
    const string Secret = "F26C89";
    public string Encrypt(string password)
    {
        var codedPassword = $"{password}{Secret}";

        var bytes = Encoding.UTF8.GetBytes(codedPassword);
        var hashBytes = SHA512.HashData(bytes);
        return BytesToString(hashBytes);

    }

    private string BytesToString(byte[] bytes)
    {
        var sb = new StringBuilder();

        foreach (var b in bytes)
        {
            var hex = b.ToString("x2");
            sb.Append(hex);
        }
        return sb.ToString();
    }
}
