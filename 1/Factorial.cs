using System.Collections.Generic;
using System.Numerics;

namespace ConsoleApplication
{
    public static class Factorial
    {
        private static List<BigInteger> _memory;

        static Factorial()
        {
            _memory = new List<BigInteger>();
            _memory.Add(new BigInteger(1));
        }

        public static BigInteger Get(int n)
        {
            if (n > _memory.Count - 1)
            {
                for (int i = _memory.Count; i <= n; i++)
                {
                    _memory.Add(_memory[i - 1] * (new BigInteger(i)));
                }
            }

            return _memory[n];
        }
    }
}