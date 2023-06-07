using Microsoft.AspNetCore.Identity;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data
{
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class TaskBoardAppDbContext : IdentityDbContext
    {
        public DbSet<Board> Boards { get; set; }
        public DbSet<Task> Tasks { get; set; }

        private IdentityUser TestUser { get; set; }
        private Board OpenBoard { get; set; }
        private Board InProgressBoard { get; set; }
        private Board DoneBoard { get; set; }


        public TaskBoardAppDbContext(DbContextOptions<TaskBoardAppDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            SeedUsers();
            builder.Entity<IdentityUser>()
                .HasData(TestUser);

            SeedBoard();
            builder.Entity<Board>()
                .HasData(OpenBoard, InProgressBoard, DoneBoard);

            builder.Entity<Task>()
                .HasData(new Task()
                    {
                        Id=1,
                        Title = "Title1",
                        Description = "Description1 aaaaaaaaaaaa",
                        CreatedOn = DateTime.Now.AddDays(-200),
                        OwnerId = TestUser.Id,
                        BoardId = OpenBoard.Id
                    },
                    new Task()
                    {
                        Id=2,
                        Title = "Title2",
                        Description = "Description2 bbbbbbbbbbb",
                        CreatedOn = DateTime.Now.AddDays(-10),
                        OwnerId = TestUser.Id,
                        BoardId = OpenBoard.Id
                    },
                    new Task()
                    {
                        Id=3,
                        Title = "Title3",
                        Description = "Description3 cccccccccccc",
                        CreatedOn = DateTime.Now.AddDays(-25),
                        OwnerId = TestUser.Id,
                        BoardId = InProgressBoard.Id
                    },
                    new Task()
                    {
                        Id=4,
                        Title = "Title4",
                        Description = "Description4 zzzzzzzz",
                        CreatedOn = DateTime.Now.AddMonths(-1),
                        OwnerId = TestUser.Id,
                        BoardId = DoneBoard.Id
                    });



            builder
                .Entity<Task>()
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(builder);
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            TestUser = new IdentityUser()
            {
                UserName = "test@softuni.bg",
                NormalizedUserName = "TEST@SOFTUNI.BG"
            };

            TestUser.PasswordHash = hasher.HashPassword(TestUser, "softuni");
        }

        private void SeedBoard()
        {
            OpenBoard = new Board()
            {
                Id = 1,
                Name = "Open"
            };

            InProgressBoard = new Board()
            {
                Id = 2,
                Name = "In Progress"
            };

            DoneBoard = new Board()
            {
                Id = 3,
                Name = "Done"
            };
        }

    }
}