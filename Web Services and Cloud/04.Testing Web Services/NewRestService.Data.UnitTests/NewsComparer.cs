namespace NewRestService.Data.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;

    using NewsRestService.Model;

    class NewsComparer : System.Collections.IComparer
    {
        public int Compare(object first, object second)
        {
            var x = first as News;
            var y = second as News;
            if (string.Compare(x.Title, y.Title, StringComparison.Ordinal) == 0
                && string.Compare(x.Content, y.Content, StringComparison.Ordinal) == 0
                && string.Compare(
                x.PublishDate.ToString(CultureInfo.InvariantCulture),
                y.PublishDate.ToString(CultureInfo.InvariantCulture),
                StringComparison.Ordinal) == 0)
            {
                return 0;
            }
            else if (string.Compare(x.Title, y.Title, StringComparison.Ordinal) < 0
                || string.Compare(x.Content, y.Content, StringComparison.Ordinal) < 0
                || string.Compare(
                x.PublishDate.ToString(CultureInfo.InvariantCulture),
                y.PublishDate.ToString(CultureInfo.InvariantCulture),
                StringComparison.Ordinal) < 0)
            {
                return -1;
            }

            return 1;
        }
    }
}
