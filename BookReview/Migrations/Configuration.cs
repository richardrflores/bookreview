using BookReview.Models;

namespace BookReview.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BookReview.Models.BookReviewContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(BookReview.Models.BookReviewContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Books.AddOrUpdate(b => b.Id,
                                      new Book()
                                          {
                                              Author = "Casey B. Basset",
                                              Isbn = "978-0-557-89084-2",
                                              Title = "Z-SAT Zombie Survival Test",
                                              Id = 1
                                          },
                                          new Book()
                                          {
                                              Author = "Andrew Hunt & David Thomas",
                                              Isbn = "0-201-61622-X",
                                              Title = "The Pragmatic Programmer",
                                              Id = 2
                                          },
                                          new Book()
                                          {
                                              Author = "Eric Freeman & Elisabeth Freeman with Kathy Sierra & Bert Bates",
                                              Isbn = "0-596-00712-4",
                                              Title = "Head First Design Patterns",
                                              Id = 3
                                          }
                );
        }
    }
}
