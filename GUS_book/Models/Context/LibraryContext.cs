using GUS_book.Models.Library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GUS_book.Models;

namespace GUS_book.Models.Context
{
    public class LibraryContext : DbContext
    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User { Id=1, Name="Петя", Age=23},
                new User { Id=2, Name="Иван", Age=26},
                new User { Id=3, Name="Коля", Age=28}
            });

            modelBuilder.Entity<Book>().HasData(new Book[]
            {
                new Book { Id=1, Title="Анна Каренина", Author="Лев Толстой", Year = 1873},
                new Book { Id=2, Title="Евгений Онегин", Author="Александр Пушкин", Year = 1831},
                new Book { Id=3, Title="Герои нашего времени", Author="Михаил Лермонтов", Year = 1839},
                new Book { Id=4, Title="Братья Карамазовы", Author="Фёдор Достоевский", Year = 1880},
                new Book { Id=5, Title="Собачье сердце", Author="Михаил Булгаков", Year = 1925}
            });
        }

        public DbSet<GUS_book.Models.BookSelectViewModel> BookSelectViewModel { get; set; }

        //public DbSet<GUS_book.Models.UserViewModel> UserViewModel { get; set; }


    }
}
