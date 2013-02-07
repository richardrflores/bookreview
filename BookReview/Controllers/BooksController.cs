using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using AutoMapper;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookReview.Models;
using BookReview.ViewModels;

namespace BookReview.Controllers
{
    public class BooksController : Controller
    {
        private BookReviewContext db = new BookReviewContext();

        //
        // GET: /Book/

        public ActionResult Index()
        {
            var books = db.Books.Include(x => x.Reviews).ToList();
            var viewModel = Mapper.Map<IEnumerable<Book>, IList<BookViewModel>>(books);
 
            return View(viewModel);
        }

        //
        // GET: /Book/Details/5

        public ActionResult Details(int id = 0)
        {
            Book book = db.Books.Include(x => x.Reviews).FirstOrDefault(x => x.Id == id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Book/Create

        [HttpPost]
        public ActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        //
        // GET: /Book/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Book/Edit/5

        [HttpPost]
        public ActionResult Edit(Book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        //
        // GET: /Book/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        //
        // POST: /Book/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
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