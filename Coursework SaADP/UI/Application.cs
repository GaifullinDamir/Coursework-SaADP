using System;
using Coursework.Structures.FacultyStructure;

namespace Coursework.UI
{
    enum Cases
    {
        Menu,
        AddFaculty,
        AddGroup,
        AddStudent,
        DeleteGroup,
        DeleteStudent,
        SearchGroup,
        SaveInXML,
        DownloadFromXML,
        ClearStructure,
        ShowStructure,
        Exit
    }
    class Application
    {
        public void ShowMenu()
        {
            Console.WriteLine(
                "1. Добавить факультет.\n"
               +"2. Добавить группу.\n"
               +"3. Добавить студента в группу.\n"
               +"4. Удалить группу.\n"
               +"5. Удалить студента (последнего добавленного).\n"
               +"6. Найти группу.\n"
               +"7. Сохранить структуру факультета в XML-файл.\n"
               +"8. Загрузить структуру факультета из XML-файла.\n"
               +"9. Очистить структуру.\n"
               +"10.Вывести структуру.\n"
               +"11.Завершить работу.");
        }

        public static int InputInteger()
        {
            string input; bool stop = false;
            int integer = -1;
            while (!stop)
            {
                try
                {
                    input = Console.ReadLine();
                    integer = int.Parse(input); stop = true;
                }
                catch (Exception)
                {
                    Console.WriteLine("Не верный ввод.");
                    stop = false;
                    break;
                }
            }
            return integer;
        }
        public void AppCycle(Faculty faculty)
        {
            bool stop = false; ShowMenu();
            bool facultyAvailable = false;
            while (!stop)
            {
                switch ((Cases)InputInteger())
                {
                    case Cases.Menu:
                        ShowMenu(); break;

                    case Cases.AddFaculty:
                        CaseAddFaculty(faculty, ref facultyAvailable); break;

                    case Cases.AddGroup:
                        CaseAddGroup(faculty, facultyAvailable); break;

                    case Cases.AddStudent:
                        CaseAddStudent(faculty); break;

                    case Cases.DeleteGroup:

                        break;

                    case Cases.DeleteStudent:
                        break;

                    case Cases.SearchGroup:
                        break;

                    case Cases.SaveInXML:
                        break;

                    case Cases.DownloadFromXML:
                        break;

                    case Cases.ClearStructure:
                        break;

                    case Cases.ShowStructure:
                        faculty.ShowFacultys();
                        break;

                    case Cases.Exit:
                        stop = true;
                        faculty.ListClearMemory();
                        break;

                    default:
                        Console.WriteLine("Такого пункта меню нет."); break;
                }
            }
        }
        public void CaseAddFaculty(Faculty faculty, ref bool facultyAvailable)
        {
            if(!facultyAvailable)
            {
                Console.Write("Введите название факультета: "); string facultyName = Console.ReadLine();
                faculty.SetFacultyName(facultyName);
                facultyAvailable = true;
            }
            else Console.WriteLine("Факультет уже добавлен.");
        }
        public void CaseAddGroup(Faculty faculty, bool facultyAvailable)
        {
            if(!(faculty.IsFull()) && facultyAvailable)
            {
                Group group = new Group();
                Console.Write("Введите номер группы: "); int groupNumber = InputInteger();
                group.SetGroupNumber(groupNumber);
                faculty.AddGroup(group);
                return;
            }
            if(faculty.IsFull())
            {
                Console.WriteLine("Факультет заполнен! Не более 10 групп.");
                return;
            }
            Console.WriteLine("Факультет не создан!");
        }

        public void CaseAddStudent(Faculty faculty)
        {
            if(!(faculty.IsEmpty()))
            {
                Console.Write("Введите номер группы в которую нужно добавить студента: "); int groupNumber = InputInteger();
                bool check = false; int prevGroup = 0; int currGroup = 0;
                faculty.SearchGroup(ref prevGroup, ref currGroup, groupNumber, ref check);
                if(check)
                {
                    Group group = faculty.GetGroupStackFromFaculty(currGroup);
                    Console.Write("Введите фамилия студента: ");string surname = Console.ReadLine();
                    Console.Write("Введите год рождения студента: "); string dateOfBirth = Console.ReadLine();
                    group.AddStudent(surname, dateOfBirth);
                    Console.WriteLine("\nСтудент добавлен.");
                }
                else
                {
                    Console.WriteLine("Такой группы нет.");
                }
            }
            else
            {
                Console.WriteLine("Добавьте факультет.");
            }
        }

        public void CaseDeleteGroup(Faculty faculty)
        {
            if(!(faculty.IsEmpty()))
            {
                Console.Write("Введите номер группы которую нужно удалить: "); int groupNumber = InputInteger();
                bool check = false; int prevGroup = 0; int currGroup = 0;
                faculty.SearchGroup(ref prevGroup, ref currGroup, groupNumber, ref check);
                if (check)
                {
                    faculty.DeleteGroup(prevGroup, currGroup);
                    Console.WriteLine("Группа удалена.");
                }
                else
                {
                    Console.WriteLine("Такой группы нет.");
                }
            }
        }
    }
}
