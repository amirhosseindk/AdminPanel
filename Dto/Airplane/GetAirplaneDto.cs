namespace AdminPanel.Dto.Airplane
{
    public class GetAirplaneDto
    {
        public int id { get; set; }
        public string model { get; set; } = string.Empty;
        public string register { get; set; } = string.Empty;
        public string? imageLink { get; set; }
    }
}
