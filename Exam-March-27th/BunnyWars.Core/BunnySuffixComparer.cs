using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BunnyWars.Core
{
    public class BunnySuffixComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            int result = string.CompareOrdinal(this.ReverseString(x), this.ReverseString(y));

            if (result == 0)
            {
                result = x.Length.CompareTo(y.Length);
            }

            return result;
        }

        public string ReverseString(string sz)
        {
            var builder = new StringBuilder(sz.Length);
            for (int i = sz.Length - 1; i >= 0; i--)
            {
                builder.Append(sz[i]);
            }
            return builder.ToString();
        }
    }
}
