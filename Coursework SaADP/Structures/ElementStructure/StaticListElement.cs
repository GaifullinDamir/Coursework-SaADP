using System;
using Coursework.Structures.FacultyStructure;

namespace Coursework.Structures.ElementStructure
{
    class StaticListElement
    {
        private Group _group;
        private int _pNext;

        public StaticListElement()
        {
            _group = null;
            _pNext = 0;
        }

        public void SetGroupStack(Group group)
        {
            _group = group;
        }

        public Group GetGroupStack()
        {
            return _group;
        }

        public void SetPNext(int pNext)
        {
            _pNext = pNext;
        }

        public int GetPNext()
        {
            return _pNext;
        }
    }
}
