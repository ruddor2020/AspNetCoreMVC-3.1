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
