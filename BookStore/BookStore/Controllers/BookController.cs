using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;
using BookStore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        private readonly BookRepository _bookRepository = null;
        public BookController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<ViewResult> GetAllBooks()
        {
            var data = await _bookRepository.GetAllBooksAsync();
            return View(data);
        }

        //[Route("book-details/{id}/{nameOfBook}", Name = "bookDetailRoute")]
        //public ViewResult GetBook(int id, string nameOfBook)
        [Route("book-details/{id}", Name = "bookDetailRoute")]
        public async Task<ViewResult> GetBook(int id)
        {
            var data = await _bookRepository.GetBookByIdAsync(id);
            return View(data);
        }

        public async Task<ViewResult> GetDynamicBook(int id)
        {
            dynamic data = new System.Dynamic.ExpandoObject();
            data.Book = await _bookRepository.GetBookByIdAsync(id);
            data.Name = "Ruddor";
            return View(data);
        }

        public List<BookModel> SearchBook(string bookName, string authorName)
        {
            return _bookRepository.SearchBook(bookName, authorName);
        }

        public ViewResult AddNewBook(bool isSuccess=false, int bookId = 0)
        {
            //var model = new BookModel() { Language = "English" };
            ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId = bookId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewBook(BookModel bookModel)
        {
            ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");
            if (!ModelState.IsValid)
            {
                ViewBag.IsSuccess = false;
                ViewBag.BookId = 0;
                ModelState.AddModelError("", "This is first custom error for demo.");
                ModelState.AddModelError("", "This is second custom error for demo.");

                return View();
            }
            if (ModelState.IsValid)
            {
                int id = await _bookRepository.AddNewBook(bookModel);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewBook), new { isSuccess = true, bookId = id });
                }
            }
            return View();
        }

        private List<LanguageModel> GetLanguage()
        {
            return new List<LanguageModel>()
            {
                new LanguageModel() {Id  = 1, Text = "Hindi"},
                new LanguageModel() {Id  = 2, Text = "English"},
                new LanguageModel() {Id  = 3, Text = "Dutch"},
            };
        }
    }
}
