using System;
using System.Collections.Generic;
using System.Numerics;

class Solution
{
    static BigInteger ModPow(BigInteger baseValue, BigInteger exponent, BigInteger modulus)
    {
        if (modulus == 1)
            return 0;

        BigInteger result = 1;
        baseValue = baseValue % modulus;

        while (exponent > 0)
        {
            if (exponent % 2 == 1)
                result = (result * baseValue) % modulus;

            exponent = exponent >> 1;
            baseValue = (baseValue * baseValue) % modulus;
        }

        return result;
    }

    static BigInteger DiscreteLogarithm(BigInteger G, BigInteger H, BigInteger Q)
    {
        BigInteger m = (BigInteger)Math.Ceiling(Math.Sqrt((double)(Q - 1)));
        var babyStep = new Dictionary<BigInteger, BigInteger>();

        for (BigInteger j = 0, val = 1; j < m; j++)
        {
            babyStep[val] = j;
            val = (val * G) % Q;
        }

        BigInteger inv = ModPow(ModPow(G, m, Q), Q - 2, Q);
        BigInteger giantStep = H;

        for (BigInteger i = 0; i < m; i++)
        {
            if (babyStep.TryGetValue(giantStep, out BigInteger j))
                return i * m + j;

            giantStep = (giantStep * inv) % Q;
        }

        return -1;
    }

    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        BigInteger G = BigInteger.Parse(inputs[0]);
        BigInteger H = BigInteger.Parse(inputs[1]);
        BigInteger Q = BigInteger.Parse(inputs[2]);

        BigInteger result = DiscreteLogarithm(G, H, Q);

        Console.WriteLine(result);
    }
}
