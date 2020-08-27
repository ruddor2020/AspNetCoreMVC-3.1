using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Models
{
    public class BookModel
    {

        public int Id { get; set; }
        [StringLength(100, MinimumLength = 2)]
        [Required(ErrorMessage = "Please enter the title of your book.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Please enter the author name.")]
        public string Author { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public string Language { get; set; }
        [Required(ErrorMessage = "Please enter the total page number.")]
        [Display(Name = "Total Pages")]
        public int? TotalPages { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Published Date")]
        [Required(ErrorMessage = "Please enter a published date.")]
        public DateTime? PublishedDate { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [Required(ErrorMessage = "Please enter a password.")]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Please enter a email.")]
        [EmailAddress]
        public string Email { get; set; }
    }
}
