using ForumV2.Data;
using ForumV2.Data.Models;
using ForumV2.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ForumV2.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class PostController : Controller
    {
        private readonly ApplicationDbContext _data;

        public PostController(ApplicationDbContext data)
        {
            _data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult All()
        {
            var posts = _data
                .Posts
                .Select(p => new PostViewModel()
                {
                    Id = p.Id,
                    Title = p.Title,
                    Content = p.Content
                }).ToList();

            return View(posts);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(AddPostViewModel post)
        {
            var postData = new Post()
            {
                Title = post.Title,
                Content = post.Content
            };

            _data.Posts.Add(postData);
            _data.SaveChanges();

            return RedirectToAction("All");
        }
    }
}
