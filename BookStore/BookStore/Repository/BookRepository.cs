using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Data;
using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Repository
{
    public class BookRepository
    {
        private readonly BookStoreContext _context = null;
        public BookRepository(BookStoreContext context)
        {
            _context = context;
        }
        public async Task<int> AddNewBook(BookModel model)
        {
            var newBook = new Books()
            {
                Author = model.Author,
                Description = model.Description,
                Title = model.Title,
                TotalPages = model.TotalPages ?? 0,
                UpdatedOn = DateTime.Now
            };
            await _context.Books.AddAsync(newBook);
            await _context.SaveChangesAsync();
            return newBook.Id;
        }
        public async Task<List<BookModel>> GetAllBooksAsync()
        {
            var books = new List<BookModel>();
            var allbooks = await _context.Books.ToListAsync();
            if (allbooks.Any())
            {
                foreach(var book in allbooks)
                {
                    books.Add(new BookModel()
                    {
                        Author = book.Author,
                        Category = book.Category,
                        Description = book.Description,
                        Id = book.Id,
                        Language = book.Language,
                        Title = book.Title,
                        TotalPages = book.TotalPages
                    });
                }
            }
            return books;
            //return DataSource();
        }

        public async Task<BookModel> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                var model = new BookModel()
                {
                    Author = book.Author,
                    Category = book.Category,
                    Description = book.Description,
                    Id = book.Id,
                    Language = book.Language,
                    Title = book.Title,
                    TotalPages = book.TotalPages
                };          
                return model;
            }
            return null;
            //return DataSource().Where(d=>d.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(d=>d.Title.ToLower().Contains(title.ToLower()) || d.Author.ToLower().Contains(authorName.ToLower())).ToList();
        }

        private List<BookModel> DataSource()
        {
            //var books = _context.Books;
            //var bookList = new List<BookModel>();
            //foreach (var book in books)
            //{
            //    BookModel 
            //}
            return new List<BookModel>()
            {
                new BookModel() { Id=1, Title = "MVC", Author="Ruddor", Description = "This is description of MVC book", Category = "Programming", Language="English", TotalPages=1067},
                new BookModel() { Id=2, Title = "Dot NET Core", Author="Monika", Description = "This is description of Dot NET Core book", Category = "Framework", Language="Chinese", TotalPages=567},
                new BookModel() { Id=3, Title = "C#", Author="John", Description = "This is description of C# book", Category = "Developer", Language="Hindi", TotalPages=897},
                new BookModel() { Id=4, Title = "Java", Author="Jack", Description = "This is description of Java book", Category = "Concept", Language="English", TotalPages=482},
                new BookModel() { Id=5, Title = "PHP", Author="Mar", Description = "This is description of PHP book", Category = "Programming", Language="English", TotalPages=200},
                new BookModel() { Id=6, Title = "Azure DevOps", Author="Ruddor", Description = "This is description of Azure DevOps book", Category = "DevOps", Language="English", TotalPages=800},
            };
        }
    }
}
