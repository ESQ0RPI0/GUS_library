using GUS_book.Models.Library;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUS_book.Models
{
    public class BookSelectViewModel : Book
    {
        public BookSelectViewModel()
        {

        }

        public BookSelectViewModel(Book book, int? UserId)
        {
            Id = book.Id;
            Author = book.Author;
            Year = book.Year;
            Title = book.Title;
            OwnerId = UserId == null? book.OwnerId : UserId;

            IsSelected = false;

        }

        [Required]
        [DisplayName("Выбрать")]
        public bool IsSelected { get; set; }       
    }
}
