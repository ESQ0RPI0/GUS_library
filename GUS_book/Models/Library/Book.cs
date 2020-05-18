using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace GUS_book.Models.Library
{
    public class Book
    {
        [Key]
        [Required]
        [DisplayName("Идентификатор")]
        public int Id { get; set; }

        [Required]
        [StringLength(40, ErrorMessage = "Название книги не может содержать больше 40 символов")]
        [DisplayName("Название")]
        public string Title { get; set; }

        [StringLength(20, ErrorMessage = "Имя автора не может содержать больше 20 символов")]
        [DisplayName("Автор")]
        public string  Author { get; set; }

        [Required]
        [DisplayName("Год издания")]
        public int Year { get; set; }

        [HiddenInput(DisplayValue = false)]
        [DefaultValue(0)]
        public int? OwnerId { get; set; } = 0;
    }
}
