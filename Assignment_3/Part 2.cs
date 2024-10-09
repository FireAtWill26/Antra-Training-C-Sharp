using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_3
{
    internal interface IPersonService
    {
        DateTime birthDate { get; set; }
        int age { get; set; }
        List<string> Addresses { get; set; }

        internal int CalculateAge();
        internal string[] GetAddresses();

    }

    internal class Person : IPersonService
    {
        public DateTime birthDate { get; set; }
        public int age { get; set; }
        private decimal salary { get; set; }
        public List<string> Addresses { get; set; }

        public Person(DateTime birthday)
        {   
            birthDate = birthday;
            age = CalculateAge();
        }

        public int CalculateAge()
        {
            return (DateTime.Now.Year - birthDate.Year);
        }

    }
    internal interface IInstructorService : IPersonService
    {
        string department { get; set; }
        bool isHead { get; set; }
        DateTime joinDate { get; set; }
        decimal bonusSalary { get; set; }
    }

    internal interface IStudentService : IPersonService
    {
        List<string> courseTaking { get; set; }
        float GPA { get; set; }
        Dictionary<string, char> grade {  get; set; }
        internal float GetGPA();
    }
    internal interface ICourseService
    {
        List<string> studentsEnrolled { get; set; }
    }

    internal interface IDepartmentService
    {
        string head { get; set; }
        List<string> courseOffered { get; set; }
        
    }
}
