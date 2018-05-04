using System;
using System.Security.Cryptography;

namespace Ludo.Library
{
    public class CryptoRandom : RandomNumberGenerator
    {
        private static RandomNumberGenerator r;

        public CryptoRandom()
        {
            r = Create();
        }

        public override void GetBytes(byte[] buffer)
        {
            r.GetBytes(buffer);
        }

        public double NextDouble()
        {
            byte[] b = new byte[4];
            r.GetBytes(b);
            return (double)BitConverter.ToUInt32(b, 0) / UInt32.MaxValue;
        }

        public int Next(int minValue, int maxValue)
        {
            return (int)Math.Floor(NextDouble() * (maxValue - minValue)) + minValue;
        }
    }
}
