using System;
using System.Xml;
using Coursework.Structures.FacultyStructure;

namespace Coursework_SaADP.XMLwork
{
    class XMLwork
    {
        public void DownloadFaculty(string filePath)
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

                            Student student = new Student(surname, Convert.ToInt32(yearOfBirth));
                            group.AddStudent()
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            
        }
    }
}
