using System.Collections.Generic;

namespace BookReview.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public byte[] Cover { get; set; }

        public ICollection<Review> Reviews { get; set; }
    }
}