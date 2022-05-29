using System;
using Coursework.Structures.FacultyStructure;

namespace Coursework.Structures.ElementStructure
{
    class StackElement
    {
        private Student _student;
        private StackElement _pNext;

        public void SetStudent(Student student)
        {
            _student = student;
        }

        public Student GetStudent()
        {
            return _student;
        }

        public void SetPNext(StackElement pNext)
        {
            _pNext = pNext;
        }

        public StackElement GetPNext()
        {
            return _pNext;
        }

        public StackElement(string surname, int yearOfBirth, StackElement pNext)
        {
            _student = new Student(surname, yearOfBirth);
            _pNext = pNext;
        }
    }
}
