using System;

namespace DDOS_Attack
{
    internal static class Rnd
    {
        private static readonly Random RndRandom = new Random();

        public static int GetNumManual(int min, int max)
        {
            return RndRandom.Next(min, max);
        }

        public static byte[] GetRndByteArray()
        {
            var byteArrBytes = new byte[GetNumManual(byte.MinValue, byte.MaxValue)];
            RndRandom.NextBytes(byteArrBytes);
            return byteArrBytes;
        }
    }
}