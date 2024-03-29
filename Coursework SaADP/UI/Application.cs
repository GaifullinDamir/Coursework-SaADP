﻿using System;
using Coursework.Structures.FacultyStructure;
using Coursework.XML;

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
        private Faculty _faculty;
        public void CaseShowMenu()
        {
            Console.WriteLine(
                "1. Создать факультет.\n"
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
                    integer = int.Parse(input);
                    stop = true;
                }
                catch (Exception)
                {
                    Console.Write("Введите целое число: ");
                }
            }
            return integer;
        }
        public void AppCycle()
        {
            bool stop = false; 
            CaseShowMenu();
            while (!stop)
            {
                switch ((Cases)InputInteger())
                {
                    case Cases.Menu:
                        CaseShowMenu();
                        break;

                    case Cases.AddFaculty:
                        CaseAddFaculty();
                        break;

                    case Cases.AddGroup:
                        CaseAddGroup();
                        break;

                    case Cases.AddStudent:
                        CaseAddStudent();
                        break;

                    case Cases.DeleteGroup:
                        CaseDeleteGroup();
                        break;

                    case Cases.DeleteStudent:
                        CaseDeleteStudent();
                        break;

                    case Cases.SearchGroup:
                        CaseSearchGroup();
                        break;

                    case Cases.SaveInXML:
                        CaseUploadToXML();
                        break;

                    case Cases.DownloadFromXML:
                        CaseDownloadFromXML();
                        break;

                    case Cases.ClearStructure:
                        CaseClearStructure();
                        break;

                    case Cases.ShowStructure:
                        CaseShowStructure();
                        break;
                    case Cases.Exit:
                        CaseExit(ref stop);
                        break;
                    default:
                        break;
                }
                Console.WriteLine("0 - меню.");
            }
        }
        #region Case realisation
        public void CaseAddFaculty()
        {
            if(_faculty is null)
            {
                
                string facultyName ="";
                while (facultyName == String.Empty)
                {
                    Console.Write("Введите название факультета: ");
                    facultyName = Console.ReadLine();
                }
                _faculty = new Faculty(facultyName);
                Console.WriteLine("Факультет создан.");
                return;
            }
            else
                Console.WriteLine("Факультет уже создан.");
        }
        public void CaseAddGroup()
        {
            if (!(_faculty is null))
            {
                if (!(_faculty.FacultyIsFull()))
                {
                    int groupNumber = -1;
                    while (groupNumber < 0)
                    {
                        Console.Write("Введите номер группы: ");
                        groupNumber = InputInteger();
                    }
                    if (_faculty.SearchGroup(groupNumber))
                    {
                        Console.WriteLine($"Группа {groupNumber} уже есть в факультете."); return;
                    }
                    else
                    {
                        _faculty.AddGroup(groupNumber);
                        Console.WriteLine("Группа добавлена.");
                    }
                    return;
                }
                else if (_faculty.FacultyIsFull())
                    Console.WriteLine($"Факультет заполнен! Не более {Faculty.GetMaxNumberOfGroups()} групп.");
            }
            else 
                Console.WriteLine("Создайте факультет.");
        }

        public void CaseAddStudent()
        {
            if(!(_faculty is null))
            {
                if (!(_faculty.FacultyIsEmpty()))
                {
                    Console.Write("Введите номер группы в которую нужно добавить студента: "); int groupNumber = InputInteger();
                    bool checkSearch = false; int currGroup = 0;
                    _faculty.SearchGroup(ref currGroup, groupNumber, ref checkSearch);
                    if (checkSearch)
                    {
                        Group group = _faculty.GetGroup(currGroup);
                        string surname = "";
                        while (surname == String.Empty)
                        {
                            Console.Write("Введите Фамилию студента : ");
                            surname = Console.ReadLine();
                        }
                        int yearOfBirth = -1;
                        while(yearOfBirth < 0)
                        {
                            Console.Write("Введите год рождения студента: ");
                            yearOfBirth = InputInteger();
                        }
                        group.AddStudent(surname, yearOfBirth);
                        Console.WriteLine("Студент добавлен.");
                    }
                    else
                        Console.WriteLine("Такой группы нет.");
                }
                else
                    Console.WriteLine("Добавьте группу.");
            }
            else
                Console.WriteLine("Создайте факультет.");
        }

        public void CaseDeleteGroup()
        {
            if(!(_faculty is null))
            {
                if (!(_faculty.FacultyIsEmpty()))
                {
                    Console.Write("Введите номер группы которую нужно удалить: "); int groupNumber = InputInteger();
                    bool checkSearch = false; int currGroup = 0;
                    int prevGroup = _faculty.SearchGroup(ref currGroup, groupNumber, ref checkSearch);
                    if (checkSearch)
                    {
                        _faculty.DeleteGroup(prevGroup, currGroup);
                        Console.WriteLine("Группа удалена.");
                    }
                    else
                        Console.WriteLine("Такой группы нет.");
                }
            }
            else
                Console.WriteLine("Создайте факультет.");
        }

        public void CaseDeleteStudent()
        {
            if(!(_faculty is null))
            {
                if (!(_faculty.FacultyIsEmpty()))
                {
                    Console.Write("Введите номер группы из которой нужно удалить студента: "); int groupNumber = InputInteger();
                    bool checkSearch = false; int currGroup = 0;
                    _faculty.SearchGroup(ref currGroup, groupNumber, ref checkSearch);
                    if (checkSearch)
                    {
                        if (_faculty.GetGroup(currGroup).DeleteStudent())
                        {
                            Console.WriteLine("Студент удалён.");
                        }
                        else
                            Console.WriteLine("В группе нет студентов.");
                    }
                    else
                        Console.WriteLine("Такой группы нет.");
                }
            }
            else
                Console.WriteLine("Создайте факультет.");
        }

        public void CaseSearchGroup()
        {
            if(!(_faculty is null))
            {
                if (!(_faculty.FacultyIsEmpty()))
                {
                    Console.Write("Введите номер группы : "); int groupNumber = InputInteger();
                    bool checkSearch = false; int currGroup = 0;
                    _faculty.SearchGroup(ref currGroup, groupNumber, ref checkSearch);
                    if (checkSearch)
                    {
                        Console.WriteLine("Группа найдена.");
                        _faculty.GetGroup(currGroup).ShowGroup();
                    }
                    else
                        Console.WriteLine("Такой группы нет.");
                }
            }
            else
                Console.WriteLine("Создайте факультет.");
        }

        public void CaseUploadToXML()
        {
            if(!(_faculty is null))
            {
                XMLWork xmlWork = new XMLWork();
                Console.WriteLine("Введите путь к файлу: "); string filePath = Console.ReadLine();
                bool check = xmlWork.UploadFaculty(filePath, _faculty);
                if (check) { Console.WriteLine("Данные факультета выгружены в XML-файл."); }
            }
            else
                Console.WriteLine("Данные о факультете отсутствуют.");
        }
        public void CaseDownloadFromXML()
        {
            if(_faculty is null)
            {
                XMLWork xmlWork = new XMLWork();
                Console.WriteLine("Введите путь к файлу: "); string filePath = Console.ReadLine();
                bool check = xmlWork.DownloadFaculty(filePath, ref _faculty);
                if (check){ Console.WriteLine("Факультет загружен и добавлен."); }
            }
            else
                Console.WriteLine("Факультет уже создан.");
        }
        public void CaseClearStructure()
        {
            if(!(_faculty is null))
            {
                _faculty.ListClearMemory();
                _faculty = null;
                Console.WriteLine("Структура очищена.");
            }
            else
                Console.WriteLine("Нет данных для очистки.");
            
        }

        public void CaseShowStructure()
        {
            if(!(_faculty is null))
            {
                _faculty.ShowFacultys();
            }
            else
                Console.WriteLine("Создайте факультет.");
        }
        public void CaseExit(ref bool stop)
        {
            stop = true;
            if(!(_faculty is null))
            {
                _faculty.ListClearMemory();
                _faculty = null;
            }
        }
        #endregion
    }
}
