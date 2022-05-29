using System;
using Coursework.Structures.ElementStructure;

namespace Coursework.Structures.FacultyStructure
{
    class Group
    {
        private int _groupNumber;
        private StackElement _pHead;

        #region Get/set methods
        public StackElement GetPHead()
        {
            return _pHead;
        }

        public void SetGroupNumber(int groupNumber)
        {
            _groupNumber = groupNumber;
        }

        public int GetGroupNumber()
        {
            return _groupNumber;
        }
        #endregion
        public Group(int groupNumber)
        {
            _groupNumber = groupNumber; 
            _pHead = null;
        }

        #region Class methods
        public bool GroupIsEmpty()
        {
            return (_pHead is null);
        }

        public void AddStudent(string surname, int yearOfBirth)
        {
            Student student = new Student(surname, yearOfBirth);
            AddStudent(student);
        }

        private void AddStudent(Student student)
        {
            StackElement stackElement = new StackElement(student, _pHead);
            _pHead = stackElement;
        }

        public bool DeleteStudent()
        {
            if(!(GroupIsEmpty()))
            {
                StackElement current = _pHead;
                _pHead = _pHead.GetPNext();
                current = null;
                return true;
            }
            return false;
        }

        public bool ShowGroup()
        {
            if(!(GroupIsEmpty()))
            {
                StackElement current = _pHead;
                Console.WriteLine($" Группа №{_groupNumber}");
                while (current != null)
                {
                    Console.WriteLine($" Фамилия: {current.GetStudent().GetSurname()};" +
                        $" год рождения: {current.GetStudent().GetDateOfBirth()}");
                    current = current.GetPNext();
                }
                return true;
            }
            return false;
        }

        public void StackClearMemory()
        {
            StackElement current = _pHead;
            StackElement temp;
            while(current != null)
            {
                temp = current.GetPNext();
                current = null;
                current = temp;
            }
            _pHead = null;
        }
        #endregion
    }
}
