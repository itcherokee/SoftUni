namespace CustomLinq
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class CustomLinq
    {
        public static IEnumerable<T> WhereNot<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            return collection.Where(x => !predicate(x));
        }

        public static IEnumerable<T> Repeat<T>(this IEnumerable<T> collection, int count)
        {
            var enumerable = collection.ToList<T>();
            for (int i = 0; i < count; i++)
            {
                foreach (var item in enumerable)
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<string> WhereEndsWith(this IEnumerable<string> collection, IEnumerable<string> suffixes)
        {
            var query = from suffix in suffixes
                        from item in collection
                        where item.EndsWith(suffix)
                        select item;
            return query;
        }
    }
}
