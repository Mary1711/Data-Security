using System;
using System.Linq;
using System.Collections.Generic;

public class CodeWars {
    public static string Encode(string text) {
        string bits = "";
        foreach (char c in text) {
            string binary = Convert.ToString(c, 2).PadLeft(8, '0');  
            foreach (char b in binary) {
                bits += new string(b, 3);  
            }
        }
        return bits;
    }

    public static string Decode(string bits) {
        string text = "";
        for (int i = 0; i < bits.Length; i += 24) {
            string characterBits = "";
            for (int j = 0; j < 24; j += 3) {
                int ones = bits.Skip(i + j).Take(3).Count(b => b == '1');
                characterBits += ones > 1 ? '1' : '0';  // Corrected bits
            }
            char character = (char)Convert.ToInt32(characterBits, 2);  
            text += character;
        }
        return text;
    }
}
