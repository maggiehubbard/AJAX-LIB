using AjaxLibraryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AjaxLibraryApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetBooksByAuthor(string author)
        {
            LibraryEntities db = new LibraryEntities();

            List<book> list = db.books.Where(
               b => b.Author.Contains(author)
                ).ToList();

            return Json(list);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpPost]
        public ActionResult GetBooksByYear(int year)
        {
            
            LibraryEntities db = new LibraryEntities();

            List<book> list = db.books.Where(
               b => b.YearPublished == year
                ).ToList();

            return Json(list);
        }

        public ActionResult GetCombinedSearch(string author, string title, int year)
        {

            LibraryEntities db = new LibraryEntities();

            List<book> list = db.books.Where(
               b => b.YearPublished == year
               && b.Author.Contains(author)
               && b.Title.Contains(title)
                ).ToList();

            return Json(list);
        }

        public ActionResult CombinedSearch()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult GetBooksByTitle(string title)
        {
            LibraryEntities db = new LibraryEntities();

            List<book> list = db.books.Where(
               b => b.Title.Contains(title)
                ).ToList();

            return Json(list);
        }
    }
}