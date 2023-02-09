namespace azimzada.com.Models
{
    public class Award
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartingDate { get; set; }
        public DateTime? EndingDate { get; set; }
        public string? Url { get; set; }
        public string? IconUrl { get; set; }
    }
}
