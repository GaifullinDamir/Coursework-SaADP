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
        private int _pHeadFree;

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

        public FacultyStaticList(GroupStack group)
        {
            _groups[0].SetGroupStack(null);
            _groups[0].SetPNext(0);
            _pHeadFree = 1;
            for (int i = 0; i < _numberOfGroups; i++)
            {
                int cell = (i == _numberOfGroups - 1) ? (0) : (i + 1);
                _groups[i].SetPNext(cell);
            }
            _groupCounter = 1;
        }

        public bool IsFull()
        {
            return (_groupCounter == _numberOfGroups);
        }

        public bool IsEmpty()
        {
            return (_groupCounter - 1 == 0);
        }

        public void FindBigger(ref int parent, ref int current, int addedElement)
        {
            parent = 0;
            current = _groups[0].GetPNext();
            while (current != 0)
            {
                if(_groups[current].GetGroupStack().GetGroupNumber() >= addedElement)
                {
                    break;
                }
                parent = current;
                current = _groups[current].GetPNext();
            }
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

        public int SearchGroup(ref int parent, ref int current, int addedElement)
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
