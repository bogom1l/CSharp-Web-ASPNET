using ForumApp.Data.Models;

namespace ForumApp.Seeding
{
    class PostSeeder
    {
        internal Post[] GeneratedPosts()
        {
            ICollection<Post> posts = new List<Post>(); //HashSet
            Post currentPost;

            currentPost = new Post()
            {
                Title = "My first post",
                Content = "First Content: wagmi"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My second post",
                Content = "Second Content - evala mujki"
            };
            posts.Add(currentPost);

            currentPost = new Post()
            {
                Title = "My third post",
                Content = "Third Content, mn sum gotin btw"
            };
            posts.Add(currentPost);

            return posts.ToArray();
        }
    }
}
