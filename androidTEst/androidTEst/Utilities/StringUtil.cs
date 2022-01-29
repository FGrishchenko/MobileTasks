using System;
using System.Linq;

namespace androidTEst.Utils
{
    public static class StringUtil
    {
        private static readonly Random Random = new Random();
        public static string GetRandomString(int length = 10)
        {
            const string chars = "qwertyuiopasdfghjklzxcvbnm0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[Random.Next(s.Length)]).ToArray());
        }
    }
}
