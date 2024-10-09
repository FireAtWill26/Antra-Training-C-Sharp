using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    internal interface IPersonService
    {
        void CalculateAge();
        string[] GetAddress();
        void CalculateSalary();
    }

    internal interface IStudentService : IPersonService
    {
        void GetGPA();
        void EnrollInClasses(Course[] classes);
        void GradeCourse(Course course, char Grade);
    }
    internal interface IInstructorService : IPersonService
    {
        public void AssignDepartment(Department department);
        public void AssignHead();
    }
    public abstract class Person : IPersonService
    {
        public Person(string Name, DateTime Birthday)
        {
            birthDate = Birthday;
            name = Name;
        }
        public int age { get; protected set; }

        public string name { get; protected set; }

        public DateTime birthDate { get; protected set; }

        public decimal salary { get; protected set; }

        List<string> addresses { get; set; }

        public void CalculateAge() { age = DateTime.Now.Year - birthDate.Year; }
        public string[] GetAddress() 
        {
            if (addresses == null)
            {
                Console.WriteLine("There is no address record for this person.");
            }
            return addresses.ToArray(); 
        }
        public abstract void CalculateSalary();
    }
    public class Instructor : Person, IInstructorService
    {
        public Instructor(string Name, DateTime Birthday, DateTime JoinDate): base(Name, Birthday)
        {
            name = Name;
            birthDate = Birthday;
            joinDate = JoinDate;
            isHead = false;
        }
        public DateTime joinDate { get; protected set; }
        private decimal salary {  set; get; }
        public Department department { get; protected set; }
        public bool isHead { get; protected set; }

        public override void CalculateSalary()
        {
            salary = 50000 + 5000 * (DateTime.Now.Year - joinDate.Year);
        }
        public void AssignDepartment(Department department)
        {
            this.department = department;
        }
        public void AssignHead()
        {
            if(department == null)
            {
                Console.WriteLine("This instructor has no department yet.");
                return;
            }
            this.isHead = true;
            department.Head = this;
        }
    }
    public class Student : Person, IStudentService
    {
        public List<Course> courseTaken { get; protected set; }
        public Dictionary<Course, char> grade { get; protected set; }
        public double GPA { get; protected set; }
        public Student(string Name, DateTime Birthday) : base(Name, Birthday) 
        {
            name=Name;
            birthDate = Birthday;
        }
        public void EnrollInClasses(Course[] classes)
        {
            for (int i = 0; i < classes.Length; i++)
            {
                courseTaken.Add(classes[i]);
                grade[classes[i]] = 'N';
                classes[i].EnrollStudent(this);
            }
        }
        public void GradeCourse(Course course, char Grade)
        {
            if (!"ABCDF".Contains(Grade)){
                Console.WriteLine("The grade must be from A to F excluding E capitalized.");
            }
            if (grade.ContainsKey(course))
            {
                grade[course] = Grade;
            }
            else
            {
                Console.WriteLine($"The student is not enrolled in {course.CourseName}");
            }
        }
        public void GetGPA()
        {
            if (grade.Values.Contains('N'))
            {
                Console.WriteLine("There is at least one course not graded. Please wait until all grading is finished.");
                return;
            }
            double totalPoints = 0;
            int totalCourses = grade.Count;
            foreach(char res in grade.Values)
            {
                switch (res)
                {
                    case 'A': totalPoints += 4.0; break;
                    case 'B': totalPoints += 3.0; break;
                    case 'C': totalPoints += 2.0; break;
                    case 'D': totalPoints += 1.0; break;
                    case 'F': totalPoints += 0.0; break;
                }
            }
            GPA = totalPoints / totalCourses;
        }
        public override void CalculateSalary()
        {
            Console.WriteLine("Students have no salary.");
        }
    }
    
    public class Course
    {
        public string CourseName { get; set; }
        private List<Student> enrolledStudents = new List<Student>();

        public Course(string courseName)
        {
            CourseName = courseName;
        }

        public void EnrollStudent(Student student)
        {
            enrolledStudents.Add(student);
        }

        public List<Student> GetEnrolledStudents()
        {
            return enrolledStudents;
        }
    }

    // Department class
    public class Department
    {
        public string DepartmentName { get; set; }
        public Instructor Head { get; set; }
        public decimal Budget { get; set; }
        public DateTime SchoolYearStart { get; set; }
        public DateTime SchoolYearEnd { get; set; }
        public List<Course> OfferedCourses { get; set; }

        public Department(string departmentName, decimal budget, DateTime start, DateTime end)
        {
            DepartmentName = departmentName;
            Budget = budget;
            SchoolYearStart = start;
            SchoolYearEnd = end;
            OfferedCourses = new List<Course>();
        }
    }
}
