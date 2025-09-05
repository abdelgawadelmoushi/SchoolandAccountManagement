namespace ShoolManagement
{
    internal class Program
    {
    
            static void Main(string[] args)
            {
                SchoolStudentManager school = new SchoolStudentManager();

                while (true)
                {
                    Console.WriteLine("\nChoose an action:");
                    Console.WriteLine("1. Add Student");
                    Console.WriteLine("2. Add Instructor");
                    Console.WriteLine("3. Add Course");
                    Console.WriteLine("4. Enroll Student in Course");
                    Console.WriteLine("5. Show All Students");
                    Console.WriteLine("6. Show All Courses");
                    Console.WriteLine("7. Show All Instructors");
                    Console.WriteLine("8. Find Student by ID");
                    Console.WriteLine("9. Find Course by ID");
                    Console.WriteLine("10. Exit");
                    Console.WriteLine("11. Check if Student enrolled in Course (Bonus)");
                    Console.WriteLine("12. Get Instructor Name by Course Name (Bonus)");
                    Console.WriteLine("Enter option number: ");

                    string choice = Console.ReadLine();



                    switch (choice)
                    {
                        case "1":
                            school.AddNewStudent();
                            break;
                        case "2":
                            school.AddNewInstructor();
                            break;
                        case "3":
                            school.AddNewCourse();
                            break;
                        case "4":
                            school.EnrollStudentInCourse();
                            break;
                        case "5":
                            school.PrintAllStudents();
                            break;
                        case "6":
                            school.PrintAllCourses();
                            break;
                        case "7":
                            school.PrintAllInstructors();
                            break;
                        case "8":
                            school.FindStudentById();
                            break;
                        case "9":
                            school.FindCourseById();
                            break;
                        case "10":
                            return;
                        case "11":
                            school.CheckStudentEnrollment();
                            break;
                        case "12":
                            school.GetInstructorByCourseName();
                            break;
                        default:
                            Console.WriteLine("Invalid choice");
                            break;
                    }
                }
            }
        }

        internal class Student
        {
            public int StudentId { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public List<Course> Courses { get; set; } = new List<Course>();

            public bool Enroll(Course course)
            {
                for (int i = 0; i < Courses.Count; i++)
                {
                    if (Courses[i].CourseId == course.CourseId)
                        return false;
                }
                Courses.Add(course);
                return true;
            }

            public string PrintDetails()
            {
                string enrolled = Courses.Count == 0 ? "No Courses" : "";
                for (int i = 0; i < Courses.Count; i++)
                {
                    enrolled += Courses[i].Title;
                    if (i < Courses.Count - 1)
                        enrolled += ", ";
                }
                return $"Student [ID={StudentId}, Name={Name}, Age={Age}, Courses={enrolled}]";
            }
        }

        internal class Instructor
        {
            public int InstructorId { get; set; }
            public string Name { get; set; }
            public string Specialization { get; set; }

            public string PrintDetails()
            {
                return $"Instructor [ID={InstructorId}, Name={Name}, Specialization={Specialization}]";
            }
        }

        internal class Course
        {
            public int CourseId { get; set; }
            public string Title { get; set; }
            public Instructor Instructor { get; set; }

            public string PrintDetails()
            {
                string instructorName = Instructor != null ? Instructor.Name : "No Instructor";
                return $"Course [ID={CourseId}, Title={Title}, Instructor={instructorName}]";
            }
        }

        internal class SchoolStudentManager
        {
            public List<Student> Students { get; set; } = new List<Student>();
            public List<Instructor> Instructors { get; set; } = new List<Instructor>();
            public List<Course> Courses { get; set; } = new List<Course>();

            public void AddNewStudent()
            {
                Console.Write("Enter Student Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Student Age: ");
                int age = Convert.ToInt32(Console.ReadLine());
                int id = Students.Count + 1;
                Students.Add(new Student { StudentId = id, Name = name, Age = age });
                Console.WriteLine("Student added successfully!");
            }

            public void AddNewInstructor()
            {
                Console.Write("Enter Instructor Name: ");
                string name = Console.ReadLine();
                Console.Write("Enter Instructor Specialization: ");
                string spec = Console.ReadLine();
                int id = Instructors.Count + 1;
                Instructors.Add(new Instructor { InstructorId = id, Name = name, Specialization = spec });
                Console.WriteLine("Instructor added successfully!");
            }

            public void AddNewCourse()
            {
                Console.Write("Enter Course Title: ");
                string title = Console.ReadLine();

                if (Instructors.Count == 0)
                {
                    Console.WriteLine("No instructors available. Add an instructor first.");
                    return;
                }

                Console.WriteLine("Select Instructor by ID:");
                for (int i = 0; i < Instructors.Count; i++)
                    Console.WriteLine($"{Instructors[i].InstructorId}. {Instructors[i].Name}");

                int instructorId = Convert.ToInt32(Console.ReadLine());
                Instructor selected = null;
                for (int i = 0; i < Instructors.Count; i++)
                {
                    if (Instructors[i].InstructorId == instructorId)
                    {
                        selected = Instructors[i];
                        break;
                    }
                }

                if (selected == null)
                {
                    Console.WriteLine("Instructor not found!");
                    return;
                }

                int courseId = Courses.Count + 1;
                Courses.Add(new Course { CourseId = courseId, Title = title, Instructor = selected });
                Console.WriteLine("Course added successfully!");
            }

            public void EnrollStudentInCourse()
            {
                if (Students.Count == 0 || Courses.Count == 0)
                {
                    Console.WriteLine("No students or courses available.");
                    return;
                }

                Console.WriteLine("Select Student by ID:");
                for (int i = 0; i < Students.Count; i++)
                    Console.WriteLine($"{Students[i].StudentId}. {Students[i].Name}");

                int studentId = Convert.ToInt32(Console.ReadLine());
                Student student = null;
                for (int i = 0; i < Students.Count; i++)
                {
                    if (Students[i].StudentId == studentId)
                    {
                        student = Students[i];
                        break;
                    }
                }

                Console.WriteLine("Select Course by ID:");
                for (int i = 0; i < Courses.Count; i++)
                    Console.WriteLine($"{Courses[i].CourseId}. {Courses[i].Title}");

                int courseId = Convert.ToInt32(Console.ReadLine());
                Course course = null;
                for (int i = 0; i < Courses.Count; i++)
                {
                    if (Courses[i].CourseId == courseId)
                    {
                        course = Courses[i];
                        break;
                    }
                }

                if (student == null || course == null)
                {
                    Console.WriteLine("Student or Course not found!");
                    return;
                }

                if (student.Enroll(course))
                    Console.WriteLine("Enrollment successful!");
                else
                    Console.WriteLine("Student already enrolled in this course.");
            }

            public void PrintAllStudents()
            {
                for (int i = 0; i < Students.Count; i++)
                    Console.WriteLine(Students[i].PrintDetails());
            }

            public void PrintAllCourses()
            {
                for (int i = 0; i < Courses.Count; i++)
                    Console.WriteLine(Courses[i].PrintDetails());
            }

            public void PrintAllInstructors()
            {
                for (int i = 0; i < Instructors.Count; i++)
                    Console.WriteLine(Instructors[i].PrintDetails());
            }

            public void FindStudentById()
            {
                Console.Write("Enter Student ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < Students.Count; i++)
                {
                    if (Students[i].StudentId == id)
                    {
                        Console.WriteLine(Students[i].PrintDetails());
                        return;
                    }
                }
                Console.WriteLine("Student not found.");
            }

            public void FindCourseById()
            {
                Console.Write("Enter Course ID: ");
                int id = Convert.ToInt32(Console.ReadLine());
                for (int i = 0; i < Courses.Count; i++)
                {
                    if (Courses[i].CourseId == id)
                    {
                        Console.WriteLine(Courses[i].PrintDetails());
                        return;
                    }
                }
                Console.WriteLine("Course not found.");
            }

            // Bonus 11
            public void CheckStudentEnrollment()
            {
                Console.Write("Enter Student ID: ");
                int studentId = Convert.ToInt32(Console.ReadLine());
                Student student = null;
                for (int i = 0; i < Students.Count; i++)
                {
                    if (Students[i].StudentId == studentId)
                    {
                        student = Students[i];
                        break;
                    }
                }

                if (student == null)
                {
                    Console.WriteLine("Student not found!");
                    return;
                }

                Console.Write("Enter Course Name: ");
                string courseName = Console.ReadLine();
                for (int i = 0; i < student.Courses.Count; i++)
                {
                    if (student.Courses[i].Title.Equals(courseName, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Student is enrolled in this course.");
                        return;
                    }
                }
                Console.WriteLine("Student is NOT enrolled in this course.");
            }

            // Bonus 12
            public void GetInstructorByCourseName()
            {
                Console.Write("Enter Course Name: ");
                string courseName = Console.ReadLine();
                for (int i = 0; i < Courses.Count; i++)
                {
                    if (Courses[i].Title.Equals(courseName, StringComparison.OrdinalIgnoreCase))
                    {
                        string instructorName = Courses[i].Instructor != null ? Courses[i].Instructor.Name : "No Instructor";
                        Console.WriteLine($"Instructor for {courseName}: {instructorName}");
                        return;
                    }
                }
                Console.WriteLine("Course not found.");
            }

        }
    }

