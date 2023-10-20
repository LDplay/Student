using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace StudentSpace
{
    public class Address
    {
        public string City { get; set; }
        public string Street { get; set; }
        public override string ToString()
        {
            return $"{Street}, {City}";
        }
    }

    public class Student 
    {
        private string surName;
        private string firstName;
        private string lastName;
        private DateTime birthDate;
        private Address homeAddress;
        private string phoneNumber;

        public int[] HomeworkGrades { get; set; }
        public int[] ProjectGrades { get; set; }
        public int[] ExamGrades { get; set; }

        public Student(string surName, string firstName, string lastName, DateTime birthDate, Address homeAddress, string phoneNumber)
        {
            this.surName = surName;
            this.firstName = firstName;
            this.lastName = lastName;
            this.birthDate = birthDate;
            this.homeAddress = homeAddress;
            this.phoneNumber = phoneNumber;
        }

        public Student(string surName, string firstName, DateTime birthDate, Address homeAddress, string phoneNumber)
            : this(surName, firstName, null, birthDate, homeAddress, phoneNumber) { }
        public string SurName
        {
            get { return surName; }
            set { surName = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        public Address HomeAddress
        {
            get { return homeAddress; }
            set { homeAddress = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }

        private void DisplayGrades(string gradeType, int[] grades)
        {
            Console.Write($"{gradeType}: ");
            foreach (int grade in grades)
            {
                Console.Write(grade);
                Console.Write(", ");
            }
            Console.WriteLine();
        }
        public void DisplayStudentInfo()
        {
            Console.WriteLine($"Full Name: {firstName} {lastName} {surName}");
            Console.WriteLine($"Date of Birth: {birthDate.ToShortDateString()}");
            Console.WriteLine($"Home Address: {homeAddress}");
            Console.WriteLine($"Phone Number: {phoneNumber}");

            DisplayGrades("Homework Grades", HomeworkGrades);
            DisplayGrades("Project Grades", ProjectGrades);
            DisplayGrades("Exam Grades", ExamGrades);
        }
    }
    public class Group
    {
        private List<Student> students;
        public string GroupName { get; set; }
        public string Specialization { get; set; }
        public int CourseNumber { get; set; }

        public Group()
        {
            students = new List<Student>();
            GroupName = "P15 Group";
            Specialization = "Programming";
            CourseNumber = 1;
        }

        public Group(List<Student> initialStudents, string groupName, string specialization, int courseNumber)
        {
            students = initialStudents;
            GroupName = groupName;
            Specialization = specialization;
            CourseNumber = courseNumber;
        }

        public Group(Group otherGroup)
        {
            students = new List<Student>(otherGroup.students);
            GroupName = otherGroup.GroupName;
            Specialization = otherGroup.Specialization;
            CourseNumber = otherGroup.CourseNumber;
        }

        public void ShowStudents()
        {
            Console.WriteLine($"Group Name: {GroupName}");
            Console.WriteLine($"Specialization: {Specialization}");
            Console.WriteLine($"Course Number: {CourseNumber}");
            Console.WriteLine("Students:");

            var sortedStudents = students.OrderBy(s => s.SurName).ThenBy(s => s.FirstName).ToList();

            for (int i = 0; i < sortedStudents.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {sortedStudents[i].SurName} {sortedStudents[i].FirstName}");
            }
        }

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void EditGroupInfo(string groupName, string specialization, int courseNumber)
        {
            GroupName = groupName;
            Specialization = specialization;
            CourseNumber = courseNumber;
        }

        public void TransferStudent(Student student, Group newGroup)
        {
            if (students.Contains(student))
            {
                students.Remove(student);
                newGroup.AddStudent(student);
            }
        }

        public void ExpelFailedStudents()
        {
            students.RemoveAll(student =>
                student.ExamGrades.Average() < 60);
        }

        public void ExpelWorstStudent()
        {
            var worstStudent = students.OrderBy(student => student.ExamGrades.Average()).FirstOrDefault();
            if (worstStudent != null)
            {
                students.Remove(worstStudent);
            }
        }
    }
}
