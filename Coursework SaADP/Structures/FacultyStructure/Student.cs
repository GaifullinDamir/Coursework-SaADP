using System;

namespace Coursework.Structures.FacultyStructure
{
    class Student
    {
        private string _surname;
        private int _yearOfBirth;

        public string GetSurname()
        {
            return _surname;
        }

        public int GetDateOfBirth()
        {
            return _yearOfBirth;
        }

        public Student(string surname, int yearOfBirth)
        {
            _surname = surname;
            _yearOfBirth = yearOfBirth;
        }
    }
}
