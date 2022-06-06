using System;
using Coursework.Structures.FacultyStructure;

namespace Coursework.Structures.ElementStructure
{
    class StackElement
    {
        private Student _student;
        private StackElement _pNext;

        public Student GetStudent()
        {
            return _student;
        }

        public StackElement GetPNext()
        {
            return _pNext;
        }

        public StackElement(Student student, StackElement pNext)
        {
            _student = student;
            _pNext = pNext;
        }
    }
}
