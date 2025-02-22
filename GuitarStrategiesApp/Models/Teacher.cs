namespace GuitarStrategiesApp.Models;

public class Teacher : User
{
    List<Student> Students;
    List<LessonNote> LessonNotes;
}