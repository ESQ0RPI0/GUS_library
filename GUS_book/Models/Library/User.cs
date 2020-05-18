using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GUS_book.Models.Library
{
    public class User
    {
        [HiddenInput(DisplayValue = false)]       
        public int Id { get; set; }

        [Required]
        [DisplayName("Имя пользователя")]
        public string Name { get; set; }

        [Required]
        [DisplayName("Возраст")]
        public int Age { get; set; }

        [DataType(DataType.EmailAddress)]
        [DisplayName("Электронная почта")]
        public string Email { get; set; }

        //[Required]
        //[DataType(DataType.Password)]
        //public string Password { get; set; }
    }
}
