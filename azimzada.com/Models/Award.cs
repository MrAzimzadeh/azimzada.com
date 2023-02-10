namespace azimzada.com.Models
{
    public class Award
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string? Url { get; set; }
        public DateTime DateTime { get; set; }
        public string PhotoUrl { get; set; }
    }
}
