namespace GuitarStrategiesApp.Models;

public class Student : User
{
    Teacher Teacher;
    List<LessonNote> LessonNotes;
}