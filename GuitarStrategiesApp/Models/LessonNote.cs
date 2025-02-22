namespace GuitarStrategiesApp.Models;

public class LessonNote
{
    public int Id { get; set; } // Unique identifier
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    
    public string Student { get; set; } // Name of the student
    public string CreatedBy { get; set; } // Name of the teacher
    
    public string? URL { get; set; } // Optional URL for resources
    public string? AttachmentPath { get; set; } // Path for uploaded file
}