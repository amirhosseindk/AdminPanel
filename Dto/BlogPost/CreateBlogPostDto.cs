namespace AdminPanel.Dto.BlogPost
{
    public class CreateBlogPostDto
    {
        public string author { get; set; } = string.Empty;
        public string title { get; set; } = string.Empty;
        public string text { get; set; } = string.Empty;
        public string imageLink { get; set; } = string.Empty;
    }
}
