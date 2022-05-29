using System;
using System.Xml;
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
                        int groupNumber = int.Parse(xnode.Attributes.GetNamedItem("groupNumber").Value);
                        Group group = new Group(groupNumber);
                        faculty.AddGroup(group);
                        foreach (XmlNode childnode in xnode.ChildNodes)
                        {
                            string surname = null;
                            string yearOfBirth = null;

                            foreach (XmlNode ch in childnode.ChildNodes)
                            {
                                if (ch.Name == "surname")
                                {
                                    surname = ch.InnerText;
                                }

                                if (ch.Name == "yearOfBirth")
                                {
                                    yearOfBirth = ch.InnerText;
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
                Console.WriteLine("Указан неверный адрес, либо отсутствует файл.");
                return false;
            }
            
        }
    }
}
