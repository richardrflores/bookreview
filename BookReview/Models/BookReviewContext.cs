using System.Data.Entity;

namespace BookReview.Models
{
    public class BookReviewContext : DbContext
    {
        public BookReviewContext() : base("name=DefaultConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Review> Reviews { get; set; } 
    }
}