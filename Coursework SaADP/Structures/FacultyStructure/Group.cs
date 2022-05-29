﻿using System;
using Coursework.Structures.ElementStructure;

namespace Coursework.Structures.FacultyStructure
{
    class Group
    {
        private int _groupNumber;
        private StackElement _pHead;

        #region Get/set methods
        public StackElement GetHead()
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
        public Group()
        {
            _groupNumber = 0; 
            _pHead = null;
        }
        #region Class methods
        public bool GroupIsEmpty()
        {
            return (_pHead is null);
        }

        public void AddStudent(string surname, int yearOfBirth)
        {
            StackElement newElement = new StackElement(surname, yearOfBirth, _pHead);
            _pHead = newElement;
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
                        $" год рождения: {current.GetStudent().GetDateOfBirht()}");
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
