using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReview.Models;

namespace BookReview.Controllers
{
    public class BookReviewsController : Controller
    {
        private BookReviewContext db = new BookReviewContext();

        //
        // GET: /BookReviews/

        public ActionResult Index()
        {   
            return View(db.Reviews.ToList());
        }

        //
        // GET: /BookReviews/Details/5

        public ActionResult Details(int id = 0)
        {
            var review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        //
        // GET: /BookReviews/Create

        public ActionResult Create(int id)
        {
            ViewBag.BookTitle = db.Books.Find(id).Title;
            return View();
        }

        //
        // POST: /BookReviews/Create

        [HttpPost]
        public ActionResult Create(Review review)
        {
            if (ModelState.IsValid)
            {
                db.Reviews.Add(review);
                db.SaveChanges();
                return RedirectToAction("Details", "Books", new { id = review.BookId });
            }

            return View(review);
        }

        //
        // GET: /BookReviews/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        //
        // POST: /BookReviews/Edit/5

        [HttpPost]
        public ActionResult Edit(Review review)
        {
            if (ModelState.IsValid)
            {
                db.Entry(review).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(review);
        }

        //
        // GET: /BookReviews/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Review review = db.Reviews.Find(id);
            if (review == null)
            {
                return HttpNotFound();
            }
            return View(review);
        }

        //
        // POST: /BookReviews/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Review review = db.Reviews.Find(id);
            db.Reviews.Remove(review);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}