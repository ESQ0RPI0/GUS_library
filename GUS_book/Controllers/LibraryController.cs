using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GUS_book.Models;
using GUS_book.Models.Context;
using GUS_book.Models.Library;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GUS_book.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILogger<LibraryController> _logger;
        private readonly LibraryContext database;

        public LibraryController(ILogger<LibraryController> logger, LibraryContext context)
        {
            _logger = logger;
            this.database = context;
        }

        #region Default actions
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        #endregion

        [HttpGet]
        public async Task<IActionResult> Users()
        {
            List<User> users = await database.Users.ToListAsync();
            if (users != null)
                return View(users);
            else
                return RedirectToAction("Error");
        }

        [HttpGet]
        public async Task<IActionResult> Books()
        {
            List<Book> books = await database.Books.ToListAsync();
            if (books != null)
                return View(books);
            else
                return RedirectToAction("Error");
        }

        [HttpGet("{controller}/Books/{action}")]
        [ActionName("Create")]
        public IActionResult CreateBook()
        {
            return View("CreateBook");
        }

        [HttpPost("{controller}/Books/{action}")]
        [ActionName("Create")]
        public async Task<IActionResult> CreateBook(Book book)
        {
            if (!ModelState.IsValid)
                return View("CreateBook");

            bool isMatch = await database.Books.AnyAsync(elem => elem.Title.ToLower() == book.Title.ToLower() && elem.Author.ToLower() == book.Author.ToLower());
            if (isMatch)
            {
                ModelState.AddModelError(string.Empty, "Данная книга уже существует");
                return View("CreateBook");
            }

            database.Books.Add(book);
            await database.SaveChangesAsync();

            return RedirectToAction("Books");
        }

        [HttpGet("/Users/{action}/{id?}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                ModelState.AddModelError(String.Empty, "Пустой идентификатор пользователя");
                return RedirectToAction("Error");
            }
            User user = await database.Users.FindAsync(id);

            if (user == null)
            {
                ModelState.AddModelError(String.Empty, "Пользователь не найден");
                return RedirectToAction("Error");
            }


            IEnumerable<Book> userBooks = await database.Books.Where(book => book.OwnerId == user.Id).ToListAsync();
            DetailsUserViewModel viewModel = new DetailsUserViewModel(user.Id, user.Name, userBooks);           
            if (TempData["BookList_Errors"] != null)
            {
                foreach (var item in (TempData["BookList_Errors"] as IEnumerable<object>))
                {
                    ModelState.AddModelError(String.Empty, item.ToString());
                }
                TempData["BookList_Errors_old"] = true;
            }

            return View(viewModel);
        }

        [HttpGet("{controller}/BookList/{id?}")]
        public async Task<IActionResult> BookList(int? Id, int? Mb)
        {
            List<Book> books = await database.Books.Where(book => book.OwnerId == 0 || book.OwnerId == null).ToListAsync();
            int UserId = Id??0;
            int MaxBooks = Mb??4;

            if (books.Count == 0)
                return Content("<p>Свободные книги отсутствуют</p>");

            List<BookSelectViewModel> booksForSelection = GetBooksForViewModel(books, UserId);
            UserBookListViewModel ListForDisplay = new UserBookListViewModel(booksForSelection, MaxBooks);
            return PartialView(ListForDisplay);
        }


        [HttpPost]
        public async Task<IActionResult> BookList(UserBookListViewModel model)
        {
            model.MaxBooks += model.BooksForSelection.Count;
            if (!TryValidateModel(model))
            {
                ModelState.AddModelError(String.Empty, "Ошибка создания списка книг или превышено максимальное число книг для данного пользователя");
                TempData["BookList_Errors"] = (from item in ModelState.Root.Errors select item.ErrorMessage).ToList();
                return RedirectToAction("Details", new {Id = model.BooksForSelection[0].OwnerId });
            }
            else
            {
                TempData.Remove("BookList_Errors");
            }

            List<Book> books = new List<Book>(model.BooksForSelection.FindAll(elem => elem.IsSelected == true));
            database.UpdateRange(books);
            await database.SaveChangesAsync();
            return RedirectToAction("Users");
        }
        private List<BookSelectViewModel> GetBooksForViewModel(List<Book> books, int? UserId)
        {
            List<BookSelectViewModel> listForView = new List<BookSelectViewModel>();

            Parallel.ForEach<Book, List<BookSelectViewModel>>((books), new ParallelOptions {MaxDegreeOfParallelism = 2 }, () =>
            {
                return new List<BookSelectViewModel>();
            },

            (localItem, options, localList) =>
            {
                localList.Add(new BookSelectViewModel(localItem, UserId));               

                return localList;
            },

            (results) =>
            {
                lock(listForView)
                    listForView.AddRange(results);
            });

            return listForView;
        }

    }
}
