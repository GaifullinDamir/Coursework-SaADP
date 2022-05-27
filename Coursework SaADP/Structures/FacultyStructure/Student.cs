using System;

namespace Coursework.Structures.FacultyStructure
{
    class Student
    {
        private string _surname, _dateOfBirth;

        public void SetSurname(string surname)
        {
            _surname = surname;
        }

        public string GetSurname()
        {
            return _surname;
        }

        public void SetDateOfBirth(string dateOfBirth)
        {
            _dateOfBirth = dateOfBirth;
        }

        public string GetDateOfBirht()
        {
            return _dateOfBirth;
        }

        public Student(string surname, string dateOfBirth)
        {
            _surname = surname;
            _dateOfBirth = dateOfBirth;
        }

    }
}
