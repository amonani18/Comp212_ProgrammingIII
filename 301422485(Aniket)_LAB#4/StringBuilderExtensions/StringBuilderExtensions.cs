using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StringBuilderExtensions
{
    public static class StringBuilderExtensions
    {
        public static int WordCount(this StringBuilder sb)
        {
            if (sb == null || sb.Length == 0)
            {
                return 0;
            }

            // Split the string into words based on whitespace, counting entries that are not empty strings.
            var words = sb.ToString().Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            return words.Length;
        }
    }
}
