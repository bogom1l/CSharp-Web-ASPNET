namespace ForumApp.ViewModels.Post
{
    public class PostViewModel
    {
        public Guid Id { get; set; } 
        public string Title { get; set; } = null!;
        public string Content { get; set; } = null!;
    }
}
