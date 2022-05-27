using System;
using Coursework.Structures.FacultyStructure;

namespace Coursework.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            Faculty faculty = new Faculty();
            Application application = new Application();
            application.AppCycle(faculty);
        }
    }
}
