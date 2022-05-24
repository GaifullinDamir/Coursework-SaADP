﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_SaADP
{
    class Student
    {
        private string _surname, _dateOfBirth;
        private Student _next;

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

        public void SetNext(Student next)
        {
            _next = next;
        }

        public Student GetNext()
        {
            return _next;
        }

        public Student()
        {

        }

        public Student(string surname, string dateOfBirth)
        {
            _surname = surname;
            _dateOfBirth = dateOfBirth;
        }

        
    }
}
