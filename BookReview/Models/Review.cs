using System;

namespace BookReview.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public DateTime Date { get; set; }
        public string Reviewer { get; set; }
        public string Body { get; set; }

        public int BookId { get; set; }
    }
}