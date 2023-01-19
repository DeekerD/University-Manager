using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManager
{
    internal class UniversitiesManagerr
    {
        List<University> universities;
        List<Student> students;

        //constructor
        public UniversitiesManagerr()
        {
            universities = new List<University>();
            students = new List<Student>();

            //add some universities
            universities.Add(new University { Id = 1, Name = "NIIT" });
            universities.Add(new University { Id = 2, Name = "ApTech" });
            universities.Add(new University { Id = 3, Name = "HIIT" });

            //add some students
            students.Add(new Student
            {
                Id = 1,
                Name = "Jason",
                Gender = "male",
                Age = 20,
                UniversityId = 1
            });

            students.Add(new Student
            {
                Id = 2,
                Name = "Michel",
                Gender = "female",
                Age = 21,
                UniversityId = 2
            });

            students.Add(new Student
            {
                Id = 3,
                Name = "Tobi",
                Gender = "male",
                Age = 23,
                UniversityId = 2
            });

            students.Add(new Student
            {
                Id = 4,
                Name = "James",
                Gender = "male",
                Age = 20,
                UniversityId = 3
            });

            students.Add(new Student
            {
                Id = 5,
                Name = "Zainab",
                Gender = "female",
                Age = 19,
                UniversityId = 1
            });

            students.Add(new Student
            {
                Id = 6,
                Name = "Kunle",
                Gender = "male",
                Age = 24,
                UniversityId = 1
            });

        }

        //method to check for male students only
        public void MaleStudents()
        {
            IEnumerable<Student> maleStudents = from student in students where student.Gender == "male"
                                                select student;

            Console.WriteLine("Male Students: ");

            foreach (Student student in maleStudents)
            {
                student.Print();
            }
        }

        //method to check for female students only
        public void FemaleStudents()
        {
            IEnumerable<Student> femaleStudents = from student in students
                                                  where student.Gender == "female"
                                                  select student;

            Console.WriteLine("Female Students: ");

            foreach (Student student in femaleStudents)
            {
                student.Print();
            }
        }

        //method to sort students by Age
        public void StudentsByAge()
        {
            var studentsByAge = from student in students orderby student.Age select student;

            Console.WriteLine("Sorting Stdents by Age: ");
            foreach (var student in studentsByAge)
            {
                student.Print();
            }
        }

        //method to check for students from Aptech
        public void AllStudentsFromAptech()
        {
            IEnumerable<Student> aptStudents = from student in students
                                               join university in
                                               universities on student.UniversityId equals
                                               university.Id
                                               where university.Name == "ApTech"
                                               select student;

            Console.WriteLine("Students from Aptech only: ");
            foreach (Student student in aptStudents)
            {
                student.Print();
            }
        }

        public void AllStudentsFromThatUni(int Id)
        {
            IEnumerable<Student> thatUniStudents = from student in students
                                                   join university in
                                                   universities on student.UniversityId equals
                                                   university.Id
                                                   where university.Id == Id
                                                   select student;

            Console.WriteLine("Students from University with Id specified: ");
            foreach (Student student in thatUniStudents)
            {
                student.Print();
            }
        }

        //method that with generate a new collection which will jusw show Student name
        //and University name
        public void StudentAndUniversityNameCollection()
        {
            var newCollection = from student in students
                                join university in universities
                                on student.UniversityId equals 
                                university.Id orderby student.Name
                                //will put student name and it respective university name into a 
                                //new collectin
                                select new {StudentName = student.Name, UniversityName = university.Name};
            Console.WriteLine("New Collection: ");

            foreach (var col in newCollection)
            {
                Console.WriteLine("Students {0} from University {1}", col.StudentName,col.UniversityName);
            }
        }

    }
}
