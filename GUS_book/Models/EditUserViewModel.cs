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
    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            Books = new List<Book>();
        }

        [DataType(DataType.Text)]
        [ReadOnly(true)]
        public int Id { get; set; }
        [ReadOnly(true)]
        public string Name { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int BookQuantity { get; set; }

        public IEnumerable<Book> Books { get; set; }
    }
}
