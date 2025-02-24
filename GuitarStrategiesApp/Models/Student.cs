namespace GuitarStrategiesApp.Models;

public class Student : User
{
    public int TeacherId { get; set; }  // Foreign Key
    public Teacher Teacher { get; set; }  // Navigation Property
    public List<LessonNote> LessonNotes { get; set; } = new();
}