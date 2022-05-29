using System;
using Coursework.Structures.ElementStructure;

namespace Coursework.Structures.FacultyStructure
{
    class Faculty
    {
        private string _facultyName;
        private const int _numberOfGroups = 11;
        private int _groupCounter;
        private int _pHeedFree;

        private StaticListElement[] _groups = new StaticListElement[_numberOfGroups];

        #region Get/set methods
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

        public StaticListElement[] GetGroupsArray()
        {
            return _groups;
        }

        public Group GetGroup(int currGroup)
        {
            return _groups[currGroup].GetGroupStack();
        }

        #endregion
        public Faculty(string facultyName)
        {
            _facultyName = facultyName;
            _groups[0] = new StaticListElement();
            _groups[0].SetPNext(0);
            _pHeedFree = 1;
            for (int i = 1; i < _numberOfGroups; i++)
            {
                _groups[i] = new StaticListElement();
                Group group = new Group(-1);
                _groups[i].SetGroupStack(group);
                int cell = (i == _numberOfGroups - 1) ? (0) : (i + 1);
                _groups[i].SetPNext(cell);
            }
            _groupCounter = 0;
        }
        #region Class methods
        public bool FacultyIsFull()
        {
            return (_groupCounter + 1 == _numberOfGroups);
        }

        public bool FacultyIsEmpty()
        {
            return (_groupCounter == 0);
        }

        public void FindBigger(ref int parent, ref int current, int addedElement)
        {
            parent = 0;
            current = _groups[0].GetPNext();
            while (current != 0)
            {
                if(_groups[current].GetGroupStack().GetGroupNumber() >= addedElement) { break;}
                parent = current;
                current = _groups[current].GetPNext();
            }
        }

        public void SearchGroup(ref int prevGroup, ref int currGroup, int searchedElement, ref bool check)
        {
            prevGroup = 0;
            currGroup = _groups[0].GetPNext();
            while(currGroup != 0)
            {
                if (_groups[currGroup].GetGroupStack().GetGroupNumber() == searchedElement)
                {
                    check = true;
                    break;
                }
                else check = false;
                prevGroup = currGroup;
                currGroup = _groups[currGroup].GetPNext();
            }
        }

        public void SearchGroup(int searchedElement, ref bool check)
        {
            int currGroup = _groups[0].GetPNext();
            while (currGroup != 0)
            {
                if (_groups[currGroup].GetGroupStack().GetGroupNumber() == searchedElement)
                {
                    check = true;
                    break;
                }
                else check = false;
                currGroup = _groups[currGroup].GetPNext();
            }
        }
        public void AddGroup(Group group)
        {
            int freeCell = _pHeedFree;
            _pHeedFree = _groups[freeCell].GetPNext();
            _groups[freeCell].SetGroupStack(group);
            if (FacultyIsEmpty())
            {
                _groups[0].SetPNext(freeCell);
                _groups[freeCell].SetPNext(0);
                _groupCounter++;
                return;
            }
            int prevGroup = 0; int currGroup = 0;
            FindBigger(ref prevGroup, ref currGroup, group.GetGroupNumber());
            _groups[prevGroup].SetPNext(freeCell);
            int pNext = currGroup == 0 ? 0 : currGroup;
            _groups[freeCell].SetPNext(pNext);
            _groupCounter++;
        }

        public void AddGroup(int groupNumber)
        {
            Group group = new Group(groupNumber);
            AddGroup(group);
        }

        public void DeleteGroup(int prevGroup, int currGroup)
        {
            _groups[currGroup].GetGroupStack().StackClearMemory();
            _groups[prevGroup].SetPNext(_groups[currGroup].GetPNext());
            _groups[currGroup].SetPNext(_pHeedFree);
            _pHeedFree = currGroup;
            _groupCounter--;
        }

        public void ShowFacultys()
        {
            if (!(FacultyIsEmpty()))
            {
                Console.WriteLine($"Название факультета: {_facultyName}");
                int current = _groups[0].GetPNext();
                while (current != 0)
                {
                    _groups[current].GetGroupStack().ShowGroup();
                    current = _groups[current].GetPNext();
                }
            }
        }

        public void ListClearMemory()
        {
            int current = _groups[0].GetPNext();
            while (current != 0)
            {
                _groups[current].GetGroupStack().StackClearMemory();
                current = _groups[current].GetPNext();
            }
            for (int i = 0; i < _numberOfGroups; i++)
            {
                _groups[i] = null;
            }
            _groups = null;
        }
        #endregion
    }
}
