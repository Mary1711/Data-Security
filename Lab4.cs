using System;
using System.Security.Cryptography;
using System.Text;

public class CodeWars
{
    public static string crack(string hash)
    {
        for (int pin = 0; pin < 100000; pin++)
        {
            string pinString = pin.ToString("D5");

            string hashedPin = CalculateMD5Hash(pinString);

            if (hashedPin == hash)
            {
                return pinString;
            }
        }

        return "";
    }

    private static string CalculateMD5Hash(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }
    }

}
