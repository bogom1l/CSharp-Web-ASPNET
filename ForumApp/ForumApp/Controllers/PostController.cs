using ForumApp.Data;
using ForumApp.Data.Models;
using ForumApp.ViewModels.Post;
using Microsoft.EntityFrameworkCore;

namespace ForumApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PostController : Controller
    {
        private readonly ForumDbContext _data;

        public PostController(ForumDbContext data)
        {
            this._data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> All()
        {
            var posts = await _data.Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                })
                .ToListAsync();

            return View(posts);
        }

        public async Task<IActionResult> Add()
            => View();

        [HttpPost]
        public async Task<IActionResult> Add(PostViewModel model)
        {
            var post = new Post()
            {
                Title = model.Title,
                Content = model.Content
            };

            await _data.Posts.AddAsync(post);
            await _data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var post = await _data.Posts.FindAsync(id);

            if (post == null)
            {
                return BadRequest("no id");
            }

            return View(new PostFormModel()
            {
                Title = post.Title,
                Content = post.Content
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, PostFormModel model)
        {
            var post = await _data.Posts.FindAsync(id);

            if (post == null)
            {
                return BadRequest("no id");
            }

            post.Title = model.Title;
            post.Content = model.Content;

            await _data.SaveChangesAsync();

            return RedirectToAction("All");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var post = await _data.Posts.FindAsync(id);

            _data.Posts.Remove(post);
            await _data.SaveChangesAsync();

            return RedirectToAction("All");
        }



    }
}
