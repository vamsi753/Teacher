using System;

class Program
{
    static void Main(string[] args)
    {
        TeacherRepository teacherRepository = new TeacherRepository();
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("Teacher Record System");
            Console.WriteLine("1. Add Teacher");
            Console.WriteLine("2. Update Teacher");
            Console.WriteLine("3. Search Teacher by ID");
            Console.WriteLine("4. Search Teacher by Name");
            Console.WriteLine("5. Display All Teachers");
            Console.WriteLine("6. Exit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.Write("Enter Teacher ID: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.Write("Enter Teacher Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Enter Class: ");
                    string className = Console.ReadLine();
                    Console.Write("Enter Section: ");
                    string section = Console.ReadLine();

                    Teacher newTeacher = new Teacher { ID = id, Name = name, Class = className, Section = section };
                    teacherRepository.AddTeacher(newTeacher);
                    Console.WriteLine("Teacher added successfully.");
                    break;
                case 2:
                    Console.Write("Enter Teacher ID to update: ");
                    int updateId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new Teacher Name: ");
                    string updateName = Console.ReadLine();
                    Console.Write("Enter new Class: ");
                    string updateClassName = Console.ReadLine();
                    Console.Write("Enter new Section: ");
                    string updateSection = Console.ReadLine();

                    bool updated = teacherRepository.UpdateTeacher(updateId, updateName, updateClassName, updateSection);
                    if (updated)
                    {
                        Console.WriteLine("Teacher updated successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Teacher not found.");
                    }
                    break;
                case 3:
                    Console.Write("Enter Teacher ID to search: ");
                    int searchId = int.Parse(Console.ReadLine());
                    Teacher teacherByID = teacherRepository.GetTeacherByID(searchId);
                    if (teacherByID != null)
                    {
                        Console.WriteLine($"ID: {teacherByID.ID}, Name: {teacherByID.Name}, Class: {teacherByID.Class}, Section: {teacherByID.Section}");
                    }
                    else
                    {
                        Console.WriteLine("Teacher not found.");
                    }
                    break;
                case 4:
                    Console.Write("Enter Teacher Name to search: ");
                    string searchName = Console.ReadLine();
                    var teachersByName = teacherRepository.SearchTeacherByName(searchName);
                    if (teachersByName.Count > 0)
                    {
                        Console.WriteLine("Matching Teachers:");
                        foreach (var teacher in teachersByName)
                        {
                            Console.WriteLine($"ID: {teacher.ID}, Name: {teacher.Name}, Class: {teacher.Class}, Section: {teacher.Section}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No matching teachers found.");
                    }
                    break;
                case 5:
                    var allTeachers = teacherRepository.GetAllTeachers();
                    Console.WriteLine("All Teachers:");
                    foreach (var teacher in allTeachers)
                    {
                        Console.WriteLine($"ID: {teacher.ID}, Name: {teacher.Name}, Class: {teacher.Class}, Section: {teacher.Section}");
                    }
                    break;
                case 6:
                    exit = true;
                    Console.WriteLine("Exiting the program.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
