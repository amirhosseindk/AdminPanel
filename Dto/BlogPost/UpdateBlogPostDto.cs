namespace AdminPanel.Dto.BlogPost
{
    public class UpdateBlogPostDto
    {
        public int id { get; set; }
        public string author { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string text { get; set; } = string.Empty;
        public string imageLink { get; set; } = string.Empty;
        public DateTime editedAt { get; set; } = DateTime.Now;
    }
}
