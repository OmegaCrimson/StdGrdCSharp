using System;
using System.Linq;
using System.Collections.Generic;
using UI;
using Models;

namespace Services
{
    public class ProgramService
    {
        public static void Start()
        {
            var students = StudentStorageService.Load();

            List<string> optionLines = new()
            {
                "Add Student",
                "View Student",
                "View All Students",
                "Delete Student",
                "Delete All Students",
                "Exit Program"
            };

            bool running = true;

            while (running)
            {
                UIHelper.BodyWithHeader("Student Grader", optionLines);
                Console.Write("Input: ");
                char input = Console.ReadKey(true).KeyChar;
                Console.WriteLine();

                switch (input)
                {
                    case '1':
                        var newStudent = StudentInputService.CreateStudent();
                        students.Add(newStudent);
                        LoggerService.LogSuccess("Student added.");
                        break;

                    case '2':
                        Console.Write("Enter student name: ");
                        string name = Console.ReadLine()?.Trim();
                        var found = students.FirstOrDefault(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
                        if (found != null)
                            StudentPrinterService.PrintStudent(found);
                        else
                            LoggerService.LogWarning("Student not found.");
                        break;

                    case '3':
                        if (students.Count == 0)
                            LoggerService.LogInfo("No students to display.");
                        else
                            foreach (var s in students)
                                StudentPrinterService.PrintStudent(s);
                        break;

                    case '4':
                        Console.Write("Enter student name to delete: ");
                        string toDelete = Console.ReadLine()?.Trim();
                        var removed = students.RemoveAll(s => s.Name.Equals(toDelete, StringComparison.OrdinalIgnoreCase));
                        LoggerService.LogInfo(removed > 0 ? "Student deleted." : "Student not found.");
                        break;

                    case '5':
                        Console.Write("Are you sure you want to delete all students? (y/n): ");
                        if (Console.ReadKey(true).KeyChar == 'y')
                        {
                            students.Clear();
                            LoggerService.LogInfo("All students deleted.");
                        }
                        break;

                    case '6':
                        StudentStorageService.Save(students);
                        LoggerService.LogSuccess("Data saved. Exiting...");
                        running = false;
                        break;

                    default:
                        LoggerService.LogWarning("Invalid input. Try 1–6.");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}
