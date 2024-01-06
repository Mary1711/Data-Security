using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        string message1 = Console.ReadLine();
        string message2 = Console.ReadLine();
        string message3 = Console.ReadLine();

        byte[] bytes1 = Enumerable.Range(0, message1.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(message1.Substring(x, 2), 16))
                     .ToArray();
        byte[] bytes2 = Enumerable.Range(0, message2.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(message2.Substring(x, 2), 16))
                     .ToArray();
        byte[] bytes3 = Enumerable.Range(0, message3.Length)
                     .Where(x => x % 2 == 0)
                     .Select(x => Convert.ToByte(message3.Substring(x, 2), 16))
                     .ToArray();

        byte[] original = new byte[bytes1.Length];
        for (int i = 0; i < bytes1.Length; i++)
            original[i] = (byte)(bytes1[i] ^ bytes2[i] ^ bytes3[i]);

        string clearMessage = Encoding.ASCII.GetString(original);

        Console.WriteLine(clearMessage);
    }
}
