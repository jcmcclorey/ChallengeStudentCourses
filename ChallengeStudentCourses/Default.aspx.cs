using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeStudentCourses
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void assignment1Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a List of Courses (add three example Courses ...
             * make up the details).  Each Course should have at least two
             * Students enrolled in them.  Use Object and Collection
             * Initializers.  Then, iterate through each Course and print
             * out the Course's details and the Students that are enrolled in
             * each Course.
             */
            resultLabel.Text = "";
            List<Course> courses = new List<Course>
            {
                new Course{CourseId=100, Name="English",
                    Students =new List<Student>{new Student {StudentId=33, Name="Ralph Cobol"},
                                                new Student{StudentId=02, Name="Joe McClorey"} } },
                new Course{CourseId=101, Name="Math",
                    Students=new List<Student>{new Student { StudentId=27, Name="Jim Valley"},
                                                new Student{StudentId=33, Name="Ralph Cobol"},
                                                new Student{StudentId=74, Name="Jill McGillicutty" } } },
                new Course{CourseId=102, Name="History",
                    Students=new List<Student>{new Student { StudentId=27, Name="Jim Valley"} }},
            };

            foreach (Course course in courses)
            {
                resultLabel.Text += String.Format("Course: {0}, ID: {1}<br>{2}",
                    course.Name, course.CourseId, formatStudentsList(course.Students));
            }
        }

        private string formatCoursesList(List<Course> list)
        {
            string courses = "Courses:<br>";
            foreach(Course course in list)
            {
                courses += String.Format("Course Name: {0}, ID: {1}<br>", course.Name, course.CourseId);
            }
            return courses;
        }

        private string formatStudentsList(List<Student> list)
        {
            string students = " Students:<br>";
            foreach(Student student in list)
            {
                students += String.Format("Name: {0}, ID: {1}<br>", student.Name, student.StudentId);
            }
            return students + "<br>";
        }

        protected void assignment2Button_Click(object sender, EventArgs e)
        {
            /*
             * Create a Dictionary of Students (add three example Students
             * ... make up the details).  Use the StudentId as the 
             * key.  Each student must be enrolled in two Courses.  Use
             * Object and Collection Initializers.  Then, iterate through
             * each student and print out to the web page each Student's
             * info and the Courses the Student is enrolled in.
             */
            resultLabel.Text = "";
            Dictionary<int, Student> students = new Dictionary<int, Student>
            {
                {58, new Student{Name="Jim Schwartz",
                    Courses =new List<Course>{ new Course { Name="English", CourseId=101},
                                                new Course{ Name="Chemistry", CourseId=109},
                                                new Course{Name="History", CourseId = 104} } } },
                {43, new Student{Name="Judy Garland",
                    Courses =new List<Course>{ new Course { Name="English", CourseId=101},
                                                new Course{ Name="Algebra", CourseId=111} } } },
                {21, new Student{Name="Bill Reilly",
                    Courses =new List<Course>{ new Course { Name="Physics", CourseId=102},
                                                new Course{ Name="Computer Science", CourseId=114},
                                                new Course{ Name="Finance", CourseId = 106} } } }

            };

            for (int i = 0; i < students.Count; i++)
            {
                resultLabel.Text += String.Format("Student Name: {0}, ID: {1}<br>{2}<br>",
                    students.ElementAt(i).Value.Name, students.ElementAt(i).Key, 
                    formatCoursesList(students.ElementAt(i).Value.Courses));
            }
        }
        

        protected void assignment3Button_Click(object sender, EventArgs e)
        {
            /*
             * We need to keep track of each Student's grade (0 to 100) in a 
             * particular Course.  This means at a minimum, you'll need to add 
             * another class, and depending on your implementation, you will 
             * probably need to modify the existing classes to accommodate this 
             * new requirement.  Give each Student a grade in each Course they
             * are enrolled in (make up the data).  Then, for each student, 
             * print out each Course they are enrolled in and their grade.
             */
            resultLabel.Text = "";
            Dictionary<int, Grades> grades = new Dictionary<int, Grades>
            {
                {1, new Grades{CourseId=101, StudentId=58, Grade=93} },
                {2, new Grades{CourseId=101, StudentId=43, Grade=87} },
                {3, new Grades{CourseId=102, StudentId=21, Grade=99} },
                {4, new Grades{CourseId=104, StudentId=58, Grade=77} },
                {5, new Grades{CourseId=106, StudentId=21, Grade=78} },
                {6, new Grades{CourseId=109, StudentId=58, Grade=98} },
                {7, new Grades{CourseId=111, StudentId=43, Grade=100} },
                {8, new Grades{CourseId=114, StudentId=21, Grade=95} }
            };

            Dictionary<int, Student> students = new Dictionary<int, Student>
            {
                {58, new Student{Name="Jim Schwartz", StudentId=58,
                    Courses =new List<Course>{ new Course { Name="English", CourseId=101},
                                                new Course{ Name="Chemistry", CourseId=109},
                                                new Course{Name="History", CourseId = 104} } } },
                {43, new Student{Name="Judy Garland", StudentId=43,
                    Courses =new List<Course>{ new Course { Name="English", CourseId=101},
                                                new Course{ Name="Algebra", CourseId=111} } } },
                {21, new Student{Name="Bill Reilly", StudentId=21,
                    Courses =new List<Course>{ new Course { Name="Physics", CourseId=102},
                                                new Course{ Name="Computer Science", CourseId=114},
                                                new Course{ Name="Finance", CourseId = 106} } } }

            };

            for (int i = 0; i < students.Count; i++)
            {
                resultLabel.Text += String.Format("Name: {0}, ID: {1}<br>{2}<br>",
                    students.ElementAt(i).Value.Name, students.ElementAt(i).Value.StudentId,
                    printInfo(students.ElementAt(i).Value.Courses, grades, students.ElementAt(i).Value));
            }
        }

        private string printInfo(List<Course> list, Dictionary<int, Grades> grades, Student student)
        {
            int x;
            string result = "";
            foreach(Course course in list)
            {
                for(int i = 0; i < grades.Count; i++)
                {
                    if((grades.ElementAt(i).Value.CourseId) == course.CourseId && 
                        (grades.ElementAt(i).Value.StudentId) == student.StudentId)
                    {
                        x = grades.ElementAt(i).Value.Grade;
                        result += course.Name + " -- " + x.ToString() + "<br>";
                    }
                }
                
            }
            return result;
        }
    }
}