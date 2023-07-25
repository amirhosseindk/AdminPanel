namespace AdminPanel.Dto
{
    public class BlogPostDto
    {
        public int Id { get; set; }
        public string Author { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Text { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime? RemovedAt { get; set; }
        public DateTime? EditedAt { get; set; }
        public string ImageLink { get; set; } = string.Empty;
    }

}
