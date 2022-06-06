using System;
using Coursework.Structures.ElementStructure;

namespace Coursework.Structures.FacultyStructure
{
    class Faculty
    {
        private string _facultyName;
        private const int _MaxNumberOfGroups = 11;
        private int _groupCounter;
        private int _pHeadFree;
        private StaticListElement[] _groups;


        #region Get/set methods
        public void SetFacultyName(string facultyName)
        {
            _facultyName = facultyName;
        }

        public string GetFacultyName()
        {
            return _facultyName;
        }

        public static int GetMaxNumberOfGroups()
        {
            return _MaxNumberOfGroups - 1;
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
            _groups = new StaticListElement[_MaxNumberOfGroups];
            _facultyName = facultyName;
            _groups[0] = new StaticListElement();
            _groups[0].SetPNext(0);
            _pHeadFree = 1;
            for (int i = 1; i < _MaxNumberOfGroups; i++)
            {
                _groups[i] = new StaticListElement();
                int cell = (i == _MaxNumberOfGroups - 1) ? (0) : (i + 1);
                _groups[i].SetPNext(cell);
            }
            _groupCounter = 0;
        }
        #region Class methods
        public bool FacultyIsFull()
        {
            return (_groupCounter + 1 == _MaxNumberOfGroups);
        }

        public bool FacultyIsEmpty()
        {
            return (_groupCounter == 0);
        }

        public int FindBigger(ref int current, int addedGroupNumber)
        {
            int parent = 0;
            current = _groups[0].GetPNext();
            while (current != 0)
            {
                if(_groups[current].GetGroupStack().GetGroupNumber() >= addedGroupNumber) { break;}
                parent = current;
                current = _groups[current].GetPNext();
            }
            return parent;
        }

        public int SearchGroup(ref int currGroup, int searchedElement, ref bool check)
        {
            int prevGroup = 0;
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
            return prevGroup;
        }
        public bool SearchGroup(int searchedElement)
        {
            int currGroup = _groups[0].GetPNext();
            while (currGroup != 0)
            {
                if (_groups[currGroup].GetGroupStack().GetGroupNumber() == searchedElement)
                {
                    return true;
                }
                currGroup = _groups[currGroup].GetPNext();
            }
            return false;
        }
        public void AddGroup(Group group)
        {
            int freeCell = _pHeadFree;
            _pHeadFree = _groups[freeCell].GetPNext();
            _groups[freeCell].SetGroupStack(group);
            if (FacultyIsEmpty())
            {
                _groups[0].SetPNext(freeCell);
                _groups[freeCell].SetPNext(0);
                _groupCounter++;
                return;
            }
            int currGroup = 0;
            int prevGroup = FindBigger(ref currGroup, group.GetGroupNumber());
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
            _groups[currGroup].SetPNext(_pHeadFree);
            _pHeadFree = currGroup;
            _groupCounter--;
        }

        public void ShowFacultys()
        {
            Console.WriteLine($"   Название факультета: {_facultyName}");
            if (!(FacultyIsEmpty()))
            {
                int current = _groups[0].GetPNext();
                while (current != 0)
                {
                    _groups[current].GetGroupStack().ShowGroup();
                    current = _groups[current].GetPNext();
                }
            }
            else
                Console.WriteLine("Групп для вывода нет.");
        }

        public void ListClearMemory()
        {
            int current = _groups[0].GetPNext();
            while (current != 0)
            {
                _groups[current].GetGroupStack().StackClearMemory();
                current = _groups[current].GetPNext();
            }
            for (int i = 0; i < _MaxNumberOfGroups; i++)
            {
                _groups[i] = null;
            }
            _groups = null;
        }
        #endregion
    }
}
