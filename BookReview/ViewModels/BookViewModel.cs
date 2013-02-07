using System;
using System.Collections.Generic;
using System.Linq;
using BookReview.Models;

namespace BookReview.ViewModels
{
    public class BookViewModel
    {
        private double _ratingAvg;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public byte[] Cover { get; set; }

        /// <summary>
        /// Calculate average rating for books index view
        /// </summary>
        public double RatingAvg
        {
            get
            {
                if (Reviews.Count > 0)
                {
                    var ratings = Reviews.Select(review => review.Rating).Select(dummy => (double) dummy).ToList();
                    _ratingAvg = ratings.Average();
                }
                else
                {
                    _ratingAvg = 0;
                }

                return _ratingAvg;
            }
        }

        public virtual IList<Review> Reviews { get; set; } 
    }
}