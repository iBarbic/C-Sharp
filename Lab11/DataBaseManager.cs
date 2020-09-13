using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab11
{
    class DataBaseManager
    {
        public void AddNewStudent()
        {
            Studenti newStudent = new Studenti();

            Console.WriteLine("Please insert the new student's name");
            newStudent.Ime = Console.ReadLine().Trim();
            Console.WriteLine("Please insert the new student's last name");
            newStudent.Prezime = Console.ReadLine().Trim();
            
            using (StudentiEntities studentiEntities = new StudentiEntities())
            {
                studentiEntities.Studenti.Add(newStudent);
                studentiEntities.SaveChanges();
            }
        }
        
        public void DeleteStudent()
        {
            int idToBeDeleted = idInput("of the student to be deleted");
            

            using (StudentiEntities studentiEntities = new StudentiEntities())
            {
                Studenti studentToBeDeleted = studentiEntities.Studenti.FirstOrDefault(s => s.Id == idToBeDeleted);
                
                if(studentToBeDeleted != null)
                {

                    IEnumerable<Predmeti> predmetis =
                            from Predmeti in studentiEntities.Predmeti
                            select Predmeti;

                    foreach (Predmeti predmet in predmetis)
                    {
                        if (predmet.Studenti.Contains(studentToBeDeleted))
                        {
                            predmet.Studenti.Remove(studentToBeDeleted);
                        }
                    }
                    studentiEntities.Studenti.Remove(studentToBeDeleted);
                    studentiEntities.SaveChanges();
                }
                else if(studentToBeDeleted == null)
                {
                    Console.WriteLine("Student with given id does not exist!");
                }
            }

        }

        public void updateStudentInfo()
        {
            int idToBeUpdated = idInput("of the student to be updated");
            string firstNameUpdated, LastNameUpdated;


            using (StudentiEntities studentiEntities = new StudentiEntities())
            {

                Studenti studentToBeUpdated = studentiEntities.Studenti.FirstOrDefault(s => s.Id == idToBeUpdated);
                
                if(studentToBeUpdated != null)
                {
                    Console.WriteLine("Please insert the student's new name");
                    firstNameUpdated = Console.ReadLine().Trim();
                    Console.WriteLine("Please insert the student's new last name");
                    LastNameUpdated = Console.ReadLine().Trim();

                    studentToBeUpdated.Ime = firstNameUpdated;
                    studentToBeUpdated.Prezime = LastNameUpdated;

                    studentiEntities.SaveChanges();
                }
                else if (studentToBeUpdated == null)
                {
                    Console.WriteLine("Student with given id does not exist!");
                }

            }
        }

        public void updateStudentCourses()
        {
            int studentId, subjectId;
            string addOrRemoveCourses;
            studentId = idInput("of the student to be updated");


            while (true)
            {
                Console.WriteLine("Enter 1 to remove courses, enter 2 to add courses");
                addOrRemoveCourses = Console.ReadLine().Trim();

                if(addOrRemoveCourses == "1" || addOrRemoveCourses == "2")
                {
                    break;
                }
            }
            subjectId = idInput("of the subject");


            using (StudentiEntities studentiEntities = new StudentiEntities())
            {

                bool idExists = false;

                Studenti studentToBeUpdated = studentiEntities.Studenti.FirstOrDefault(s => s.Id == studentId);
                Predmeti subjectToBeAddedOrRemoved = studentiEntities.Predmeti.FirstOrDefault(p => p.Id == subjectId);

                if(studentToBeUpdated != null && subjectToBeAddedOrRemoved != null)
                {
                    idExists = true;
                }

                if(addOrRemoveCourses == "1" && idExists)
                {
                    studentToBeUpdated.Predmeti.Remove(subjectToBeAddedOrRemoved);
                    subjectToBeAddedOrRemoved.Studenti.Remove(studentToBeUpdated);
                    studentiEntities.SaveChanges();
                }
                else if(addOrRemoveCourses == "2" && idExists)
                {
                    studentToBeUpdated.Predmeti.Add(subjectToBeAddedOrRemoved);
                    subjectToBeAddedOrRemoved.Studenti.Add(studentToBeUpdated);
                    studentiEntities.SaveChanges();
                }

                if(!idExists)
                {
                    Console.WriteLine("Invalid IDs!");
                }
                
            }

        }

        public void addNewCourse()
        {
            Predmeti newCourse = new Predmeti();

            Console.WriteLine("Please insert the new subject name");
            newCourse.Naziv = Console.ReadLine().Trim();

            using (StudentiEntities studentiEntities = new StudentiEntities())
            {
                studentiEntities.Predmeti.Add(newCourse);
                studentiEntities.SaveChanges();
            }
        }

        public void removeCourse()
        {
            int idToBeDeleted = idInput("of the student to be deleted");


            using (StudentiEntities studentiEntities = new StudentiEntities())
            {
                Predmeti courseToBeDeleted = studentiEntities.Predmeti.FirstOrDefault(c => c.Id == idToBeDeleted);

                if(courseToBeDeleted != null)
                {

                    IEnumerable<Studenti> studentis =
                            from Studenti in studentiEntities.Studenti
                            select Studenti;

                    foreach (Studenti student in studentis)
                    {
                        if (student.Predmeti.Contains(courseToBeDeleted))
                        {
                            student.Predmeti.Remove(courseToBeDeleted);
                        }
                    }
                    studentiEntities.Predmeti.Remove(courseToBeDeleted);
                    studentiEntities.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Course with given ID does not exist!");
                }
                
            }
        }
        
        public void updateCourse()
        {
            int idToBeUpdated = idInput("of the course to be updated");
            string nameUpdated;

            
            Console.WriteLine("Please insert the new course name");
            nameUpdated = Console.ReadLine().Trim();

            using (StudentiEntities studentiEntities = new StudentiEntities())
            {
                Predmeti courseToBeUpdated = studentiEntities.Predmeti.FirstOrDefault(c => c.Id == idToBeUpdated);

                if(courseToBeUpdated != default)
                {
                    courseToBeUpdated.Naziv = nameUpdated;
                    studentiEntities.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Course with given Id does not exist!");
                }
            }

        }

        public void showAllStudentsEnrolled()
        {
            using (StudentiEntities studentiEntities = new StudentiEntities())
            {
                IEnumerable<Studenti> studentis =
                    from Studenti in studentiEntities.Studenti
                    select Studenti;

                foreach (Studenti student in studentis)
                {
                    Console.WriteLine("Student: ID:" + student.Id + " First Name: " + student.Ime.Trim() + " Last Name: " + student.Prezime + " ");

                    foreach (Predmeti predmet in student.Predmeti)
                    {
                        Console.WriteLine("subject: ID:" + predmet.Id + " Name: " + predmet.Naziv);
                    }
                    Console.WriteLine();
                }
            }
        }

        public void showAllCoursesEndrolled()
        {
            using (StudentiEntities studentiEntities = new StudentiEntities())
            {
                IEnumerable<Predmeti> predmetis =
                    from Predmeti in studentiEntities.Predmeti
                    select Predmeti;

                foreach (Predmeti predmet in predmetis)
                {
                    Console.WriteLine("subject: ID:" + predmet.Id + " Name: " + predmet.Naziv);

                    foreach (Studenti student in predmet.Studenti)
                    {
                        Console.WriteLine("Student: ID:" + student.Id + " First Name: " + student.Ime.Trim() + " Last Name: " + student.Prezime + " ");
                    }
                    Console.WriteLine();
                }
            }
        }

        int idInput(string inputDescription) 
        {
            int id;
            while (true)
            {
                Console.WriteLine("Please insert the id " + inputDescription);
                string input = Console.ReadLine().Trim();
                bool validInput = int.TryParse(input, out id);

                if (validInput)
                {
                    return id;
                }
            }
        }
    }
}
