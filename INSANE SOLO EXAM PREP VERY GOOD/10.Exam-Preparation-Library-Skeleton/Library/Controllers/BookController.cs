using Library.Services;
using Library.ViewModels;

namespace Library.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class BookController : BaseController
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        public async Task<IActionResult> All()
        {
            var books = await _bookService.GetAllBooksAsync();

            return View(books);
        }

        public async Task<IActionResult> Mine()
        {
            var userId = GetUserId();

            var books = await _bookService.GetMyBooks(userId);

            return View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            AddBookViewModel addBookViewModel = await _bookService.GetNewAddBookViewModelAsync();

            return View(addBookViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel addBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(addBookViewModel);
            }

            await _bookService.AddBookAsync(addBookViewModel);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> AddToCollection(int id)
        {
            int bookId = id;

            var book = await _bookService.GetBookByIdAsync(bookId);

            if(book == null)
            {
                return BadRequest("tolkoz mnogo noshti i pak ne si go doizpipal");
            }

            var userId = GetUserId();

            await _bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction("All");
        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            int bookId = id;

            var book = await _bookService.GetBookByIdAsync(bookId);

            if (book == null)
            {
                return BadRequest("failed to remove from collection");
            }

            var userId = GetUserId();

            await _bookService.RemoveBookFromCollectionAsync(userId, book);

            return RedirectToAction("Mine");
        }

        /*
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            int bookId = id;
            
        }
        */

    }
}
