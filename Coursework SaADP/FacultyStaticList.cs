using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_SaADP
{
    enum Results : int
    {
        NotFound = -1
    }
    class FacultyStaticList
    {
        private string _facultyName;
        private const int _numberOfGroups = 10;
        private int _groupCounter = 0;

        private FacultyListNode[] _groups = new FacultyListNode[_numberOfGroups];

        public void SetFacultyName(string facultyName)
        {
            _facultyName = facultyName;
        }

        public string GetFacultyName()
        {
            return _facultyName;
        }

        public static int GetNumberOfGroups()
        {
            return _numberOfGroups;
        }

        public void IncreaseGroupCounter()
        {
            _groupCounter++;
        }

        public int GetGroupCounter()
        {
            return _groupCounter;
        }

        public FacultyStaticList()
        {
            _groups[0].SetPNext(0);
            for (int i = 1; i < _numberOfGroups; i++)
            {
                _groups[i].SetGroupStack(null);
                _groups[i].SetPNext(i - 1);
            }
        }

        public bool IsFull()
        {
            return (_groupCounter == _numberOfGroups);
        }

        public bool IsEmpty()
        {
            return (_groupCounter == 0);
        }

        public void ShowFacultys()
        {
            if(!(IsEmpty()))
            {
                Console.WriteLine($"Название факультета: {_facultyName}");
                int current = _groups[0].GetPNext();
                while(current != 0)
                {
                    _groups[current].GetGroupStack().ShowAll();
                }
            }
        }

        public int SearchGroup(int groupNumber)
        {
            if(!(IsEmpty()))
            {
                int current = 0;
                do
                {
                    if (groupNumber == _groups[_groups[current].GetPNext()].GetGroupStack().GetGroupNumber())
                    {
                        return current;
                    }
                } while (current != 0);
            }
            return (int)Results.NotFound;
        }

        public int FindBigger(int addedGroupNumber)
        {
            int current = _groups[0].GetPNext();
            while (current != 0)
            {
                if(addedGroupNumber > _groups[current].GetGroupStack().GetGroupNumber())
                {
                    current = _groups[current].GetPNext();
                }
                else if(addedGroupNumber <= _groups[current].GetGroupStack().GetGroupNumber())
                {
                    break;
                }
            }
            return current;
        }
    }
}
