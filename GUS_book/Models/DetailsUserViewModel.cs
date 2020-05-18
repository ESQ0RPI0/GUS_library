using GUS_book.Models.Library;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUS_book.Models
{
    public class DetailsUserViewModel
    {
        public DetailsUserViewModel(int id, string name, IEnumerable<Book> books)
        {
            this.Id = id;
            this.Name = name;
            this.Books = books;
        }

        public DetailsUserViewModel()
        {
            Books = new List<Book>();
        }

        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        [DisplayName("Максимальное число книг")]
        [Range(0, 4, ErrorMessage = "{0} на одного пользователя - {2}")]
        public int MaxBooks { get; set; } = 4;
      
        [DisplayName("Имя пользователя")]
        public string Name { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
