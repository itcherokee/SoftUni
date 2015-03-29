namespace EFCodeFirst
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Data;

    public class ListMountains
    {
        public static void Main()
        {
            using (var context = new MountainsContext())
            {
                var mountains = context.Mountains.Include(p => p.Peaks).Include(c => c.Countries).ToList();
                foreach (var mountain in mountains)
                {
                    Console.Write(mountain.Name);
                    Console.Write("; Peaks: " + string.Join(", ", mountain.Peaks.Select(m => m.Name)));
                    Console.WriteLine("; Countirues: " + string.Join(", ", mountain.Countries.Select(m => m.Name)));
                }
            }
        }
    }
}
