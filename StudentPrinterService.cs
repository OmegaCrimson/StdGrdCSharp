using System;
using Models;

namespace Services
{
    public static class StudentPrinterService
    {
        public static void PrintStudent(Student student)
        {
            Console.WriteLine("────────────────────────────────────────────");
            Console.WriteLine($"👤 Name: {student.Name}");
            Console.WriteLine($"🎓 Age: {student.Age}");
            Console.WriteLine($"📚 Subjects ({student.Subjects.Count}):");

            if (student.Subjects.Count == 0)
            {
                Console.WriteLine("   (No subjects)");
            }
            else
            {
                foreach (var subject in student.Subjects)
                {
                    Console.WriteLine($"   - {subject.Name} | Score: {subject.Grade}/{subject.MaxGrade} | Teacher: {subject.Teacher}");
                }
            }

            Console.WriteLine("────────────────────────────────────────────\n");
        }
    }
}