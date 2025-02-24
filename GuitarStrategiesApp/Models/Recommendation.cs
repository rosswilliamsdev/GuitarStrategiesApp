namespace GuitarStrategiesApp.Models
{
    public class Recommendation
    {
        public int Id { get; set; } 
        public int TeacherId { get; set; }  // Foreign Key
        public Teacher Teacher { get; set; }  // Navigation Property
        public string Category { get; set; }
        public string Title { get; set; } 
        public string Link { get; set; }
        public string ThumbnailUrl { get; set; } 
    }
}