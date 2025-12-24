using System.Linq;
using System.Collections.Generic;
using Exceptions;
using Validations;

namespace Models
{
    public class Student
    {
        private string name;
        private int age;

        public string Name
        {
            get => name;
            set
            {
                string trimmedName = value.Trim();
                StringValidator.ValidateRequired(trimmedName, "Student name");
                StringValidator.ValidateLength(trimmedName, 3, 30, "Student name");
                name = trimmedName;
            }
        }

        public int Age
        {
            get => age;
            set
            {
                RangeValidator.ValidateInt(value, 0, 30, "Student age");
                age = value;
            }
        }

        public List<Subject> Subjects { get; set; } = new();

        public void AddSubject(Subject subject)
        {
            Subjects.Add(subject);
        }

        public double AverageGrade()
        {
            return Subjects.Count == 0 ? 0 : Subjects.Average(s => s.Grade);
        }

        public override string ToString()
        {
            return $"{Name}, Age: {Age}, Subjects: {Subjects.Count}, Avg: {AverageGrade():0.##}";
        }

        public List<Subject> GetAllSubjects()
        {
            return Subjects;
        }

        public bool RemoveSubject(string name)
        {
            return Subjects.RemoveAll(s => s.Name == name.Trim()) > 0;
        }

        public void ClearSubjects()
        {
            Subjects.Clear();
        }
    }
}
