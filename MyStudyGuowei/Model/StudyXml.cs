using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Model
{
    public class StudyXml
    {
        static string path = Directory.GetCurrentDirectory() + "Write.xml";
        public StudyXml()
        {

        }
        public void Get()
        {
            XElement root =
                new XElement("书籍",
                    new XElement("历史书",
                        new XElement("现代史","123"),
                        new XElement("近代史","456")),
                    new XElement("故事书",
                        new XElement("小说", "123"),
                        new XElement("文学", "456"))
                    );
            root.Save(path);
        }
        public static void CreateXDocument()
        {
            XDocument xdoc = new XDocument(
                    new XProcessingInstruction("xml-stylesheet", "title='EmpInfo'"),
                    new XComment("some comments"),
                    new XElement("Root",
                            new XElement("Employees",
                                    new XElement("Employee",
                                            new XAttribute("id", "1"),
                                            new XElement("Name", "Scott Klein"),
                                            new XElement("Title", "Geek"),
                                            new XElement("HireDate", "02/05/2007"),
                                            new XElement("Gender", "M")
                                        )
                                )
                        ),
                    new XComment("more comments")
                );
            xdoc.Save(path);
        }

    }
}
