namespace PerformanceTests
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class PerformanceTestsClient
    {
        public static void Main()
        {
            //// -------------------------------------------------------
            //// Problem 1: Show Data from Related Tables
            //// -------------------------------------------------------
            //// slow version
            TaskOneSlow();

            //// optimized version
            TaskOneOptimized();

            //// -------------------------------------------------------
            //// Problem 2. Play with ToList()
            //// -------------------------------------------------------
            //// slow version
            TaskTwoSlow();

            //// optimized version
            TaskTwoOptimized();

            //// -------------------------------------------------------
            //// Problem 3. Select Everything vs. Select Certain Columns
            //// -------------------------------------------------------
            //// slow version
            TaskThreeSelectAll();

            //// optimized version
            TaskThreeSelectOnlyTitle();
        }

        private static void TaskOneSlow()
        {
            using (var context = new AdsEntities())
            {
                var ads = context.Ads.ToList();

                foreach (var ad in ads)
                {
                    Console.WriteLine(
                        "{0}:\n\t- Status: {1};\n\t- Category: {2};\n\t- Town: {3};\n\t- User: {4}",
                        ad.Title,
                        ad.AdStatus.Status,
                        ad.Category == null ? "(none)" : ad.Category.Name,
                        ad.Town == null ? "(none)" : ad.Town.Name,
                        ad.AspNetUser.Name);
                }
            }
        }

        private static void TaskOneOptimized()
        {
            using (var context = new AdsEntities())
            {
                var ads = context.Ads.Include(c => c.Category).Include(t => t.Town).Include(u => u.AspNetUser).ToList();

                foreach (var ad in ads)
                {
                    Console.WriteLine(
                        "{0}:\n\t- Status: {1};\n\t- Category: {2};\n\t- Town: {3};\n\t- User: {4}",
                        ad.Title,
                        ad.AdStatus.Status,
                        ad.Category == null ? "(none)" : ad.Category.Name,
                        ad.Town == null ? "(none)" : ad.Town.Name,
                        ad.AspNetUser.Name);
                }
            }
        }

        private static void TaskTwoSlow()
        {
            using (var context = new AdsEntities())
            {
                var ads = context.Ads
                    .ToList()
                    .Where(s => s.AdStatus.Status == "Published")
                    .Select(n => new
                    {
                        Title = n.Title,
                        Category = n.Category == null ? "(none)" : n.Category.Name,
                        Town = n.Town == null ? "(none)" : n.Town.Name,
                        PublishDate = n.Date
                    })
                    .ToList()
                    .OrderBy(o => o.PublishDate);

                foreach (var ad in ads)
                {
                    Console.WriteLine(
                        "{0} (Published on: {1}):\n\t- Category: {2};\n\t- Town: {3};",
                        ad.Title,
                        ad.PublishDate,
                        ad.Category,
                        ad.Town);
                }
            }
        }

        private static void TaskTwoOptimized()
        {
            using (var context = new AdsEntities())
            {
                var ads = context.Ads
                    .Where(s => s.AdStatus.Status == "Published")
                    .Select(n => new
                    {
                        Title = n.Title,
                        Category = n.Category == null ? "(none)" : n.Category.Name,
                        Town = n.Town == null ? "(none)" : n.Town.Name,
                        PublishDate = n.Date
                    })
                    .OrderBy(o => o.PublishDate)
                    .ToList();

                foreach (var ad in ads)
                {
                    Console.WriteLine(
                        "{0} (Published on: {1}):\n\t- Category: {2};\n\t- Town: {3};",
                        ad.Title,
                        ad.PublishDate,
                        ad.Category,
                        ad.Town);
                }
            }
        }

        private static void TaskThreeSelectAll()
        {
            using (var context = new AdsEntities())
            {
                var timeElapsed = DateTime.Now;
                var ads = context.Ads.ToList();

                // foreach (var ad in ads)
                // {
                //     Console.WriteLine("Ad title: {0}", ad.Title);
                // }
                Console.WriteLine("Time elapsed (selecting all): {0}", DateTime.Now - timeElapsed);
            }
        }

        private static void TaskThreeSelectOnlyTitle()
        {
            using (var context = new AdsEntities())
            {
                var timeElapsed = DateTime.Now;
                var ads = context.Ads.Select(t => t.Title).ToList();

                // foreach (var title in ads)
                // {
                //     Console.WriteLine("Ad title: {0}", title);
                // }
                Console.WriteLine("Time elapsed (selecting just Title): {0}", DateTime.Now - timeElapsed);
            }
        }
    }
}