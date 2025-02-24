namespace GuitarStrategiesApp.Models;

public class LessonNote
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public int StudentId { get; set; }  // Foreign Key
    public Student Student { get; set; }  // Navigation Property

    public int TeacherId { get; set; }  // Foreign Key
    public Teacher Teacher { get; set; }  // Navigation Property

    public string? URL { get; set; }
    public string? AttachmentPath { get; set; }
}