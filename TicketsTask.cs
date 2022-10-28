using System;
using System.Numerics;

namespace Tickets
{
    public static class TicketsTask
    {
        public static BigInteger Solve(int halfLen, int totalSum)
        {
            if (totalSum % 2 != 0)
                return 0;

            totalSum /= 2;
            BigInteger result = default;
            var opt = new BigInteger[totalSum + 1, halfLen];

            for (var i = 0; i <= Math.Min(totalSum, 9); ++i)
                opt[i, 0] = 1;
            
            for (var i = 0; i < halfLen; ++i)
                opt[0, i] = 1;

            for (var i = 1; i <= totalSum; i++)
            for (var j = 1; j < halfLen; j++)
            for (var k = 0; k <= Math.Min(i, 9); k++)
                opt[i, j] += opt[i - k, j - 1];
            
            result = opt[totalSum, halfLen - 1];
            
            return result * result;
        }
    }
}