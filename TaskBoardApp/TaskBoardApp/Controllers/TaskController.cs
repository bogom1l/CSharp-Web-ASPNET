using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using TaskBoardApp.Data;
using TaskBoardApp.Models.Task;
using TaskBoardApp.Data.Models;

namespace TaskBoardApp.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    [Authorize]

    public class TaskController : Controller
    {
        private readonly TaskBoardAppDbContext _data;

        public TaskController(TaskBoardAppDbContext context)
        {
            _data = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            TaskFormModel taskModel = new TaskFormModel()
            {
                Boards = GetBoards()
            };
            return View(taskModel);
        }

        private IEnumerable<TaskBoardModel> GetBoards()
            => _data.Boards.Select(b => new TaskBoardModel()
            {
                Id = b.Id,
                Name = b.Name,
            });


        [HttpPost]
        public async Task<IActionResult> Create(TaskFormModel taskModel)
        {
            if (!GetBoards().Any(b => b.Id == taskModel.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist");
            }

            string currentUserId = GetUserId();

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();
                return View(taskModel);
            }

            TaskBoardApp.Data.Models.Task task = new TaskBoardApp.Data.Models.Task()
            {
                Title = taskModel.Title,
                Description = taskModel.Description,
                CreatedOn = DateTime.Now,
                BoardId = taskModel.BoardId,
                OwnerId = currentUserId
            };

            await _data.Tasks.AddAsync(task);
            await _data.SaveChangesAsync();

            var boards = _data.Boards;

            return RedirectToAction("All", "Board");
        }

        private string GetUserId()
            => User.FindFirstValue(ClaimTypes.NameIdentifier);

     
        public async Task<IActionResult> Details(int id)
        {
            var task = await _data
                .Tasks
                .Where(t => t.Id == id)
                .Select(t => new TaskDetailsViewModel()
                {
                    Id = t.Id,
                    Title = t.Title,
                    Description = t.Description,
                    CreatedOn = t.CreatedOn.ToString("dd/MM/yyyy HH:mm"),
                    Board = t.Board.Name,
                    Owner = t.OwnerId
                })
                .FirstOrDefaultAsync();

            if (task == null)
            {
                return BadRequest();
            }

            return View(task);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            TaskFormModel taskModel = new TaskFormModel
            {
                Title = task.Title,
                Description = task.Description,
                BoardId = task.BoardId,
                Boards = GetBoards()
            };

            return View(taskModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, TaskFormModel taskModel)
        {
            var task = await _data.Tasks.FindAsync(id);

            if (task == null)
            {
                return BadRequest();
            }

            string currentUserId = GetUserId();

            if (currentUserId != task.OwnerId)
            {
                return Unauthorized();
            }

            if (!GetBoards().Any(b => b.Id == task.BoardId))
            {
                ModelState.AddModelError(nameof(taskModel.BoardId), "Board does not exist");
            }

            if (!ModelState.IsValid)
            {
                taskModel.Boards = GetBoards();
                return View(taskModel);
            }

            task.Title = taskModel.Title;
            task.Description = taskModel.Description;
            task.BoardId = taskModel.BoardId;

            await _data.SaveChangesAsync();

            return RedirectToAction("All", "Board");
        }


    }
}
