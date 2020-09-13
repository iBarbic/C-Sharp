using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Predmeti newPredmet = new Predmeti();
            DataBaseManager dataBaseManager = new DataBaseManager();
            
            while(true)
            {
                string input;

                Console.WriteLine("Select one of the options");
                Console.WriteLine("1 - add a new student");
                Console.WriteLine("2 - delete a student");
                Console.WriteLine("3 - update a student personal information");
                Console.WriteLine("4 - update the courses a student in enrolled to");
                Console.WriteLine("5 - add a new course");
                Console.WriteLine("6 - delete a course");
                Console.WriteLine("7 - update a course");
                Console.WriteLine("8 - show all students and classes they are enrolled to");
                Console.WriteLine("9 - show all courses where a student is enrolled");
                Console.WriteLine("10 - exit");

                input = Console.ReadLine().Trim();

                switch (input)
                {
                    case "1":
                        dataBaseManager.AddNewStudent();
                        break;
                    case "2":
                        dataBaseManager.DeleteStudent();
                        break;
                    case "3":
                        dataBaseManager.updateStudentInfo();
                        break;
                    case "4":
                        dataBaseManager.updateStudentCourses();
                        break;
                    case "5":
                        dataBaseManager.addNewCourse();
                        break;
                    case "6":
                        dataBaseManager.removeCourse();
                        break;
                    case "7":
                        dataBaseManager.updateCourse();
                        break;
                    case "8":
                        dataBaseManager.showAllStudentsEnrolled();
                        break;
                    case "9":
                        dataBaseManager.showAllCoursesEndrolled();
                        break;
                    default:
                        Environment.Exit(0);
                        break;
                }

            }
        }
    }
}
