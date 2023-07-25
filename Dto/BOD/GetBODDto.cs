namespace AdminPanel.Dto.BOD
{
    public class GetBODDto
    {
        public int id { get; set; }
        public string name { get; set; } = string.Empty;
        public string position { get; set; } = string.Empty;
        public string? imageLink { get; set; }
    }
}
