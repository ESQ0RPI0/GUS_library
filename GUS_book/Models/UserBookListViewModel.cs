using GUS_book.Models.Library;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUS_book.Models
{
    public class UserBookListViewModel
    {
        [Required]
        public List<BookSelectViewModel> BooksForSelection { get; set; }

        [Required]
        [DisplayName("Максимальное число книг")]
        [Range(0, 4, ErrorMessage = "{0} на одного пользователя - {2}")]
        public int MaxBooks { get; set; }
        public UserBookListViewModel()
        {
            BooksForSelection = new List<BookSelectViewModel>();
        }

        public UserBookListViewModel(List<BookSelectViewModel> bookSelectList, int Mb = 0)
        {
            BooksForSelection = bookSelectList;
            MaxBooks = Mb;
        }
    }
}
