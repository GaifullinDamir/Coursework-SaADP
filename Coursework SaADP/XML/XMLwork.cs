using System;
using System.Xml;
using System.Xml.Linq;
using Coursework.Structures.ElementStructure;
using Coursework.Structures.FacultyStructure;

namespace Coursework.XML
{
    class XMLwork
    {
        public bool DownloadFaculty(string filePath, ref Faculty faculty)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(filePath);
                XmlElement xRoot = xDoc.DocumentElement;
                if (xRoot.Name != "faculty") { throw new Exception("Не найден тег faculty."); }
                if (xRoot.HasAttribute("facultyName") == false) { throw new Exception("Не найден аттрибут facultyName у тега faculty."); }
                string facultyName = xRoot.GetAttribute("facultyName").ToString();
                if (facultyName == String.Empty) { throw new Exception("Пустое название факультета."); }
                faculty = new Faculty(facultyName);
                if (xRoot != null)
                {
                    foreach (XmlElement xnode in xRoot)
                    {
                        if (faculty.GetGroupCounter() == 10)
                        {
                            break;
                        }
                        if (xnode.Name != "group") { throw new Exception("Не найден тег group."); }
                        if (xnode.HasAttribute("groupNumber") == false) { throw new Exception("Не найден аттрибут groupNumber у тега group."); }
                        string groupNumberString = xnode.Attributes.GetNamedItem("groupNumber").Value;
                        if (groupNumberString == String.Empty) { throw new Exception("Пустой номер группы."); }
                        int groupNumber;
                        bool GroupNumberIsDigit = Int32.TryParse(groupNumberString, out groupNumber);
                        if (!GroupNumberIsDigit) { throw new Exception($"Номер группы {groupNumberString} должен быть числом"); }
                        
                        if (faculty.SearchGroup(groupNumber))
                        {
                            Console.WriteLine($"Группа {groupNumber} уже есть в факультете. Повтор будет пропущен.") ; continue; ;
                        }
                        if (groupNumber < 0)
                        {
                            Console.WriteLine($"Группа {groupNumber} не должна иметь отрицательный номер."); continue;
                        }
                        Group group = new Group(groupNumber);
                        faculty.AddGroup(group);
                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            string surname = null;
                            string yearOfBirthString = null;
                            if (childNode.Name != "student") { throw new Exception($"В группе {groupNumber} не найден тег student."); }
                            foreach (XmlNode child in childNode.ChildNodes)
                            {
                                if (child.Name == "surname")
                                {
                                    surname = child.InnerText;
                                    if (surname == String.Empty) { throw new Exception($"В группе {groupNumber} есть пустое имя студента."); }
                                }

                                else if (child.Name == "yearOfBirth")
                                {
                                    yearOfBirthString = child.InnerText;
                                }
                                else
                                    throw new Exception($"В группе {groupNumber} неправильные дочерние узлы у одного из студентов.") ;
                            }
                            int yearOfBirth;
                            bool yearOfBirthIsDigit = Int32.TryParse(yearOfBirthString, out yearOfBirth);
                            if (!yearOfBirthIsDigit) { throw new Exception($"В группе {groupNumber} год рождения {yearOfBirthString} должен быть числом"); }
                            group.AddStudent(surname, Convert.ToInt32(yearOfBirthString));
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            
        }

        public bool UploadFaculty(string filePath, Faculty faculty)
        {
            try
            {
                XDocument xdoc = new XDocument();
                XElement facultyElement = new XElement("faculty");
                XAttribute facultiNameAttribute = new XAttribute("facultyName", faculty.GetFacultyName());
                facultyElement.Add(facultiNameAttribute);
                StaticListElement[] groups = faculty.GetGroupsArray();
                int current = groups[0].GetPNext();
                while (current != 0)
                {
                    XElement groupElement = new XElement("group");
                    XAttribute groupNumberAttribute = new XAttribute("groupNumber", groups[current].GetGroupStack().GetGroupNumber());
                    groupElement.Add(groupNumberAttribute);
                    StackElement currStack = groups[current].GetGroupStack().GetPHead();
                    while (currStack != null)
                    {
                        XElement studentElement = new XElement("student");
                        XElement surnameElement = new XElement("surname", currStack.GetStudent().GetSurname());
                        XElement yearOfBirthElement = new XElement("yearOfBirth", currStack.GetStudent().GetDateOfBirth());
                        studentElement.Add(surnameElement);
                        studentElement.Add(yearOfBirthElement);
                        groupElement.Add(studentElement);
                        currStack = currStack.GetPNext();
                    }
                    facultyElement.Add(groupElement);
                    current = groups[current].GetPNext();
                }
                xdoc.Add(facultyElement);
                xdoc.Save(filePath);
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Указан не верный адрес либо некие другие проблемы.");
                return false;
            }
        }
    }
}
