using StudentSpace;
class Program
{
    static void Main()
    {
        Address studentAddress = new Address {Street = "Широкая", City = "Одесса",};

        Student student = new Student("Храмцов", "Дмитрий", "Алексеевіч", new DateTime(2006, 10, 25), studentAddress, "8-800-555-3535");

        student.HomeworkGrades = new int[] { 90, 85, 88, 92 };
        student.ProjectGrades = new int[] { 78, 80, 85 };
        student.ExamGrades = new int[] { 92, 88, 94 };

        student.DisplayStudentInfo();
    }
}
