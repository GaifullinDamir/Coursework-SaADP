using System;
using System.Xml;
using Coursework.Structures.FacultyStructure;

namespace Coursework_SaADP.XMLwork
{
    class XMLwork
    {
        public Faculty DownloadFaculty(string filePath)
        {
            try
            {
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(filePath);

                XmlElement xRoot = xDoc.DocumentElement;

                string facultyName = xRoot.GetAttribute("facultyName").ToString();
                Faculty faculty = new Faculty(facultyName);
                if (xRoot != null)
                {
                    foreach (XmlElement xnode in xRoot)
                    {
                        int groupNumber = int.Parse(xnode.Attributes.GetNamedItem("groupNumber").Value);
                        faculty.AddGroup(groupNumber);
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
                            faculty.GetGroup(groupNumber).AddStudent(surname, Convert.ToInt32(yearOfBirth));
                        }
                    }
                }
                return faculty;
            }
            catch (Exception)
            {
                Console.WriteLine("Возникла ошибка при загрузке данных.");
            }

            
        }
    }
}
