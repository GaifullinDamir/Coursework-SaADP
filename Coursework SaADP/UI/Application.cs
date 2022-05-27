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

            while (!stop)
            {
                switch ((Cases)InputInteger())
                {
                    case Cases.Menu:
                        ShowMenu(); break;

                    case Cases.AddFaculty:
                        break;

                    case Cases.AddGroup:
                        break;

                    case Cases.AddStudent:
                        break;

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
    }
}
