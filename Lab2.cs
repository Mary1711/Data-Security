using System;
using System.Linq;
using System.Collections.Generic;

class Solution
{
    static void Main(string[] args)
    {
        string message = Console.ReadLine();

        Dictionary<int, int> counter = new Dictionary<int, int>();
        foreach (char c in message.ToUpper())
            if (char.IsLetter(c))
            {
                int shift = (c - 'E' + 26) % 26;
                if (counter.ContainsKey(shift))
                    counter[shift]++;
                else
                    counter[shift] = 1;
            }

        int mostCommonShift = counter.Aggregate((l, r) => l.Value > r.Value ? l : r).Key;

        string decoded = string.Empty;
        foreach (char c in message)
        {
            if (char.IsLetter(c))
            {
                char a = char.IsUpper(c) ? 'A' : 'a';
                decoded += (char)((c - mostCommonShift - a + 26) % 26 + a);
            }
            else
                decoded += c;
        }

        Console.WriteLine(decoded);
    }
}
