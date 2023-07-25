namespace AdminPanel.Dto.BlogPost
{
    public class GetBlogPostDto
    {
        public int id { get; set; }
        public string author { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string text { get; set; } = string.Empty;
        public DateTime createdAt { get; set; }
        public DateTime? removedAt { get; set; }
        public DateTime? editedAt { get; set; }
        public string imageLink { get; set; } = string.Empty;
    }
}
