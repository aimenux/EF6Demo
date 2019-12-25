using System;
using System.Linq;

namespace DataAccess.Helpers
{
    public class RandomGenerator : IRandomGenerator
    {
        private static readonly Random Random = new Random(Guid.NewGuid().GetHashCode());

        public decimal RandomRate()
        {
            return (decimal) Random.NextDouble();
        }

        public string RandomString(int length = 10)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}