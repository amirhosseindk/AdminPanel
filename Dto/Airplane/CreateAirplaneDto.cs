namespace AdminPanel.Dto.Airplane
{
    public class CreateAirplaneDto
    {
        public string model { get; set; } = string.Empty;
        public string register { get; set; } = string.Empty;
        public string? imageLink { get; set; }
    }
}
