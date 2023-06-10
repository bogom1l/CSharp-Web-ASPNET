using Library.Contracts;
using Library.Models;

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
            var model = await _bookService.GetAllBooksAsync();

            return View(model);
        }

        public async Task<IActionResult> Mine()
        {
            var model = await _bookService.GetMyBooksAsync(GetUserId());

            return View(model);
        }


        public async Task<IActionResult> AddToCollection(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("All");
            }

            var userId = GetUserId();

            await _bookService.AddBookToCollectionAsync(userId, book);

            return RedirectToAction("All");

        }

        public async Task<IActionResult> RemoveFromCollection(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return RedirectToAction("All");
            }

            var userId = GetUserId();

            await _bookService.RemoveBookByIdAsync(userId, book);

            return RedirectToAction("Mine");

        }

        
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var categories = await _bookService.GetCategories();

            AddBookViewModel bookViewModel = new AddBookViewModel()
            {
                Categories = categories
            };

            return View(bookViewModel);
        }
        

         
        [HttpPost]
        public async Task<IActionResult> Add(AddPostBookViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return View(model);
            //}

            await _bookService.AddBooksPost(model);

            return RedirectToAction("All", "Book");
        }

        
        

    }

}
