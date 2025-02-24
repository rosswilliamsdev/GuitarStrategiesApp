namespace GuitarStrategiesApp.Models;

public class Teacher : User
{
    public List<Student> Students { get; set; } = new();
    public List<LessonNote> LessonNotes { get; set; } = new();
    public List<Recommendation> Recommendations { get; set; } = new();
}