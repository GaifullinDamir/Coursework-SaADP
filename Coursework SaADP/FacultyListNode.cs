using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursework_SaADP
{
    class FacultyListNode
    {
        private GroupStack _group;
        private int _pNext;

        public FacultyListNode()
        {
            _group = null;
            _pNext = 0;
        }

        public void SetGroupStack(GroupStack group)
        {
            _group = group;
        }

        public GroupStack GetGroupStack()
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
