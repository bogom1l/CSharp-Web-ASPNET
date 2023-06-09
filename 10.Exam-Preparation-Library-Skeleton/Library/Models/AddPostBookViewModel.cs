namespace Library.Models
{
    public class AddPostBookViewModel
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string Author { get; set; }

        public string Url { get; set; }

        public decimal Rating { get; set; }

        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

    }
}
