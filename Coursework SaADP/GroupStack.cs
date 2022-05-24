using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_SaADP
{
    class GroupStack
    {
        private string _groupNumber;
        private Student _head;
        
        public Student GetHead()
        {
            return _head;
        }

        public void SetGroupNumber(string groupNumber)
        {
            _groupNumber = groupNumber;
        }

        public string GetGroupNumber()
        {
            return _groupNumber;
        }
        public GroupStack()
        {
            _groupNumber = null; 
            _head = null;
        }

        public bool IsEmpty()
        {
            return (_head is null);
        }

        public void AddStudent(string surname, string dateOfBirth)
        {
            Student newStudent = new Student();
            newStudent.SetNext(_head);
            newStudent.SetSurname(surname);
            newStudent.SetDateOfBirth(dateOfBirth);
            _head = newStudent;
        }

        public bool DeleteStudent()
        {
            if(!(IsEmpty()))
            {
                Student current = _head;
                _head = _head.GetNext();
                current = null;
                return true;
            }
            return false;
        }

        public bool ShowAll()
        {
            if(!(IsEmpty()))
            {
                Student current = _head;
                Console.WriteLine($" Группа №{_groupNumber}");
                while (current != null)
                {
                    Console.WriteLine($" Фамилия: {current.GetSurname()};" +
                        $" год рождения: {current.GetDateOfBirht()}");
                }
                return true;
            }
            return false;
        }

        public void ClearMemory()
        {
            Student current = _head;
            Student temp;
            while(current != null)
            {
                temp = current.GetNext();
                current = null;
                current = temp;
            }
        }
    }
}
