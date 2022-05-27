using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_SaADP
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

        public StackElement(string surname, string dateOfBirth, StackElement pNext)
        {
            _student = new Student(surname, dateOfBirth);
            _pNext = pNext;
        }
    }
}
