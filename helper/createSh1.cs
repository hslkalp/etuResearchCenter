using System.Security.Cryptography;
using System.Text;

public class createSh1
{
    public static string HashSh1(string password)
    {
        using (SHA1Managed sha1 = new SHA1Managed())
        {
            var hashSh1 = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));

            var sb = new StringBuilder(hashSh1.Length * 2);

            foreach (byte b in hashSh1)
            {
                sb.Append(b.ToString("X2").ToLower());
            }
            return sb.ToString();
        }
    }
}