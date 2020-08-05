using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using BookStore.Models;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            ViewBag.Title = "Ruddor";
            dynamic data = new ExpandoObject();
            data.Id = 1;
            data.Name = "Ruddor";
            ViewBag.Data = data;
            ViewBag.Type = new BookModel() { Id = 5, Author = "John Doe" };
            ViewData["Description"] = "This is description.";
            ViewData["Book"] = new BookModel() { Id = 6, Author = "John Smith" };
            return View();
        }

        public ViewResult AboutUs()
        {
            return View();
        }

        public ViewResult ContactUs()
        {
            return View();
        }
    }
}
