using System;

namespace Assets.Helpers
{
    public static class IntHelper
    {
        private static readonly Random _random = new Random();

        public static int Random(int min, int max)
        {
            return _random.Next(min, max);
        }
    }
}