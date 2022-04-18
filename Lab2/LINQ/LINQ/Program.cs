using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using LINQ.Models;


namespace LINQ
{
    public class Program
    {
        static void Main(string[] args)
        {
            
            using (var db = new LINQLab2())
            {
                var allTeachers = AllTeachers();
                var allCourses = AllCourses();
                var allStudents = AllStudents();
                var allStudentTeacher=AllStudentTeacher();
                var allStudentCourse = AllStudentCourse();
                var studentId = StudentId(allStudents);
                var courseId = CourseId(allCourses,"Programmering 1");

                do
                {
                    string optionMenu = MenuChoice();
                    Console.Clear();
                    switch (optionMenu)
                    {
                        case "1":

                            Console.Clear();
                            var teacherName = allTeachers.Where(p => p.CourseId==courseId).Select(x=> x.TeacherName).ToList();

                            teacherName.ForEach(x=> Console.WriteLine($"{x}\n"));  

                            break;

                        case "2":

                            Console.Clear();
                            foreach (var Id in studentId)
                            {
                                bool studentIdExist= allStudentTeacher.Any(x=> x.StudentId==Id);
                                if (studentIdExist == true)
                                {
                                    var student = allStudentTeacher.Find(x => x.StudentId == Id).Student.Name; 
                                    

                                    var teacherToStudent=allStudentTeacher.Where(x=> x.StudentId==Id).Select(p=>p.Teacher.TeacherName).ToList();
                                    Console.WriteLine($"\n{student} has the following teachers: ");
                                    teacherToStudent.ForEach(x => Console.WriteLine($"{x}\n"));

                                }
                                else { continue; }

                            }

                            break;

                        case "3":
                            Console.Clear();

                            //var nameStudent=allStudents.Where(x=> x.StudentCourse.Any(p=> p.CourseId==courseId))
                                //.Select(k=>k.Name).ToList();

                            //var teacherNames = allTeachers.Where(x => x.Course.CourseId == courseId)
                                //.Select(k => k.TeacherName).ToList();


                            //teacherNames.ForEach(x => Console.WriteLine(x));
                            //nameStudent.ForEach(x => Console.WriteLine(x));

                            
                            foreach (var Id in studentId)
                            {
                                bool studentIdExist = allStudentCourse.Any(x => x.StudentId == Id);
                                if (studentIdExist == true)
                                {

                                    var courseStudent = allStudentCourse.Find(x => (x.StudentId == Id)
                                    && (x.CourseId == courseId)).Student.Name;

                                    var teacherNameCourse = allTeachers.Where(p => p.CourseId == courseId)
                                        .Select(x => x.TeacherName).ToList();

                                    Console.WriteLine($"\n{courseStudent} has the following teachers in Programmering 1: ");
                                    teacherNameCourse.ForEach(x => Console.WriteLine($"{x}\n"));
                                }
                                else { continue; }

                            }

                            break;
                        case "4":
                            Console.Clear();

                            courseId = CourseId(allCourses, "Databaser2");

                            var courseName = allCourses.Find(x => x.CourseId == courseId);
                            var courseNewName = "Webbutveckling frontend";

                            courseName.Name = courseNewName;

                            db.Entry(courseName).State = EntityState.Modified;
                            db.SaveChanges();
                            Console.WriteLine("Done\n");
                            break;

                        case "5":
                            Console.Clear();

                            courseId = CourseId(allCourses, "Programmering 1");

                            var teacherObj=allTeachers.Find(x=> x.CourseId==courseId);

                            teacherObj.TeacherName = "Reidar";
                            db.Entry(teacherObj).State = EntityState.Modified;
                            db.SaveChanges();
                            Console.WriteLine("Done\n");
                            
                            break;

                    }

                } while (true);



            };







            //RegisterData();



        }

        public static string MenuChoice()
        {
            Console.WriteLine("Enter 1 for getting the of name teacher in Programmering 1\n" +
                "Enter 2 for getting information about all of the students\n" +
                "Enter 3 for getting information about students who read Programmering 1\n" +
                "Enter 4 for changing course name\n" +
                "Enter 5 for updating a pupils teacher name from anas to reidar");
            string optionMenu = Console.ReadLine();
            return optionMenu;
        }

        public static List<Student> AllStudents()
        {
            using (var db = new LINQLab2())
            {
                var allStudents = db.Student.Include(p => p.StudentCourse).ToList();

                return allStudents;

            };
        }

        public static List<Teacher> AllTeachers() 
        {
            using (var db = new LINQLab2())
            {
                var allTeachers = db.Teacher.Include(p => p.Course).Include(x=> x.StudentTeacher).ToList();

                return allTeachers;

            };
        }

        public static List<Course> AllCourses()
        {
            using (var db = new LINQLab2())
            {
                var allCourses = db.Course.Include(x=> x.Teachers).ToList();

                return allCourses;

            };
        }

        public static List<StudentTeacher> AllStudentTeacher()
        {
            using (var db = new LINQLab2())
            {
                var allStudentTeacher = db.StudentTeacher.Include(x=> x.Student).Include(p=>p.Teacher).ToList();

                return allStudentTeacher;

            };
        }

        public static List<StudentCourse> AllStudentCourse()
        {
            using (var db = new LINQLab2())
            {
                var allStudentCourse = db.StudentCourse.Include(x => x.Student).Include(p => p.Course).ToList();

                return allStudentCourse;

            };
        }


        public static List<int> StudentId(List<Student> allStudents)
        {
            var studentId = allStudents.Select(x => x.StudentId).ToList();
            return studentId;
        }

        public static int CourseId(List<Course> allCourses, string name)
        {
            var courseId = allCourses.Where(p => p.Name == name).SingleOrDefault().CourseId;
            return courseId;
        }

        public static void RegisterData()
        {

            using (var db = new LINQLab2())
            {


                List<Course> courses = new List<Course>{
                    new Course() {

                        Name="Programmering 1",
                        Teachers=new List<Teacher>
                        {
                            new Teacher()
                            {
                                TeacherName="Anas Alhussain",
                            },
                            new Teacher()
                            {
                                TeacherName="Tobias Landen"
                            },

                        },
                    },

                    new Course() 
                    { 
                        Name="Databaser",
                        Teachers=new List<Teacher>
                        {
                            new Teacher()
                            {
                                TeacherName="Christoffer Karlsson",
                            },

                            new Teacher()
                            {
                                TeacherName="David Boström"
                            },
                        },
                    },

                    new Course()
                    {
                        Name="Webbapplikationer i c#",
                        Teachers=new List<Teacher>
                        {
                            new Teacher()
                            {
                                TeacherName="Lillemor larsson",
                            },
                        },
                    },

                };

                List<Class> classes = new List<Class>()
                {
                    new Class()
                    {
                        Name="9B",
                        Student= new List<Student>()
                        {
                            new Student()
                            {
                                Name="Mojtaba Sarvari",
                                StudentCourse= new List<StudentCourse>()
                                {
                                    new StudentCourse(){ CourseId=1},

                                    new StudentCourse(){ CourseId = 2},

                                    new StudentCourse(){ CourseId = 3}

                                },
                                StudentTeacher= new List<StudentTeacher>()
                                {
                                    new StudentTeacher(){ TeacherId = 1 },
                                    new StudentTeacher(){ TeacherId = 2 },
                                }
                            },

                            new Student()
                            {

                                Name="Olof Parhammar",
                                StudentCourse= new List<StudentCourse>()
                                {
                                    new StudentCourse(){CourseId=1},

                                    new StudentCourse(){CourseId = 2},

                                    new StudentCourse(){ CourseId = 3}

                                },
                                StudentTeacher= new List<StudentTeacher>()
                                {
                                    new StudentTeacher(){ TeacherId = 1 },
                                    new StudentTeacher(){ TeacherId = 2 },
                                    new StudentTeacher(){ TeacherId = 3 },
                                }


                            },

                            new Student()
                            {
                                Name="Aron Larsson"
                            },
                        }
                    }
                };

                
                courses.ForEach(teacher => db.Add(teacher));
                classes.ForEach(classes => db.Add(classes));

                db.SaveChanges();
            };
        }
    }
}
