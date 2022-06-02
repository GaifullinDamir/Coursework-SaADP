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
                string facultyName = xRoot.GetAttribute("facultyName").ToString();
                faculty = new Faculty(facultyName);
                if (xRoot != null)
                {
                    foreach (XmlElement xnode in xRoot)
                    {
                        if(faculty.GetGroupCounter() == 10)
                        {
                            break;
                        }
                        int groupNumber = int.Parse(xnode.Attributes.GetNamedItem("groupNumber").Value);
                        if (faculty.SearchGroup(groupNumber))
                        {
                            Console.WriteLine($"Группа {groupNumber} уже есть в факультете.") ; continue; ;
                        }
                        Group group = new Group(groupNumber);
                        faculty.AddGroup(group);
                        foreach (XmlNode childNode in xnode.ChildNodes)
                        {
                            string surname = null;
                            string yearOfBirth = null;

                            foreach (XmlNode child in childNode.ChildNodes)
                            {
                                if (child.Name == "surname")
                                {
                                    surname = child.InnerText;
                                }

                                if (child.Name == "yearOfBirth")
                                {
                                    yearOfBirth = child.InnerText;
                                }
                            }
                            group.AddStudent(surname, Convert.ToInt32(yearOfBirth));
                        }
                    }
                }
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Указан не верный адрес либо некие другие проблемы.");
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
