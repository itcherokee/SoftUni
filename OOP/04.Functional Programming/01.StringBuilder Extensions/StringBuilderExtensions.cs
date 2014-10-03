namespace StringBuilderExtensions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public static class StringBuilderExtensions
    {
        public static StringBuilder Substring(this StringBuilder source, int startIndex, int length)
        {
            if (startIndex < 0 || startIndex >= source.Length)
            {
                throw new ArgumentOutOfRangeException("startIndex", string.Format("Start Index must be in the range [0..{0}]!", source.Length - 1));
            }

            if (startIndex + length > source.Length)
            {
                throw new ArgumentOutOfRangeException("length", string.Format("Length can be in the range [0..{0}]!", source.Length - startIndex));
            }

            return new StringBuilder(string.Join(string.Empty, source.ToString().Skip(startIndex).Take(length)));
        }

        public static StringBuilder RemoveText(this StringBuilder source, string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text", "Searched text cannot be of null value!");
            }

            return source.Replace(text, string.Empty);
        }

        public static StringBuilder AppendAll<T>(this StringBuilder source, IEnumerable<T> items)
        {
            items.ToList().ForEach(x => source.Append(x.ToString()));
            return source;
        }
    }
}
