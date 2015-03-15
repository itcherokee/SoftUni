using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NewsDatabase.Model;

namespace NewsDtabase.Data.Migrations
{
    class NewsDatabaseInitializer : DropCreateDatabaseIfModelChanges<NewsDbContext>
    {

        protected override void Seed(NewsDbContext context)
        {
            var news = new List<News>
            {
                new News { Content = "НАТО не смята да се намесва в конфликта в Източна Украйна"},
                new News { Content =  "Джип и автобус се сблъскаха, има загинал и ранени"},
                new News { Content =  "Обама е смаян от писмото на сенатори републиканци до Техеран"},
                new News { Content =  "Кремъл отрече, че Путин очаква бебе от Алина Кабаева"},
                new News { Content =  "За близо 60% от пенсионерите ще има великденски добавки"},
                new News { Content =  "Джип и автобус се сблъскаха, има загинал и ранени"},
                new News { Content =  "Хванаха шеф на кардиология с фалшива диплома"},
                new News { Content =  "Исландия се отказа от членство в Евросъюза"},
                new News { Content =  "Скандални твърдения на полицая, прегазил бебе"}
            };

            if (!context.News.Any())
            {
                context.News.AddOrUpdate(news.ToArray());
            }
                        context.SaveChanges();

            base.Seed(context);
        }
    }
}
