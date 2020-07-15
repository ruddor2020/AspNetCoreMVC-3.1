using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.Models;

namespace BookStore.Repository
{
    public class BookRepository
    {
        public List<BookModel> GetAllBooks()
        {
            return DataSource();
        }

        public BookModel GetBookById(int id)
        {
            return DataSource().Where(d=>d.Id == id).FirstOrDefault();
        }

        public List<BookModel> SearchBook(string title, string authorName)
        {
            return DataSource().Where(d=>d.Title.ToLower().Contains(title.ToLower()) || d.Author.ToLower().Contains(authorName.ToLower())).ToList();
        }

        private List<BookModel> DataSource()
        {
            return new List<BookModel>()
            {
                new BookModel() { Id=1, Title = "MVC", Author="Ruddor"},
                new BookModel() { Id=2, Title = "Dot NET Core", Author="Monika"},
                new BookModel() { Id=3, Title = "C#", Author="John"},
                new BookModel() { Id=4, Title = "Java", Author="Jack"},
                new BookModel() { Id=5, Title = "PHP", Author="Mar"},
            };
        }
    }
}
