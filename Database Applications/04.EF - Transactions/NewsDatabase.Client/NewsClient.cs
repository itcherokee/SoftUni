using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using NewsDatabase.Model;
using NewsDtabase.Data;

namespace NewsDatabase.Client
{
    public class NewsClient
    {
        public static void Main()
        {
            using (var context = new NewsDbContext())
            {
                // Problem 2:
                // Step 1.	At startup, the app should load from the DB the news text 
                //          and print it on the console.
                Console.WriteLine("Application started.");
                foreach (var item in context.News)
                {
                    Console.WriteLine("Text from DB: - {0}", item.Content);
                }

                bool isConcurrentConflict = true;
                while (isConcurrentConflict)
                {
                    // Step 2.	After that, the app should enter a new value for the news text 
                    //          from the console.
                    var lastNews = context.News.OrderByDescending(o => o.NewsId).FirstOrDefault();
                    Console.Write("Enter the corrected text (last news): ");
                    lastNews.Content = Console.ReadLine() ?? "New news";

                    // Step 3.	After entering a new value, the app should try to save it to the DB.
                    //          -   In case of success (no conflicting updates), the app should say that 
                    //              the changes were saved and should finish its work.
                    //          -   In case of concurrent update conflict, the app should display 
                    //              an error message, should display the new (changed) text from 
                    //              the DB and should go to Step 2.
                    try
                    {
                        context.SaveChanges();
                        Console.WriteLine("Changes successfully saved in the DB.");
                        isConcurrentConflict = false;
                    }
                    catch (DbUpdateConcurrencyException ex)
                    {
                        Console.Write("Conflict! Text from DB (last news): {0}.", lastNews.Content);
                        Console.ReadKey();
                    } 
                }
            }
        }
    }
}
