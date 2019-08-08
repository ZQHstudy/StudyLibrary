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
        public StudyXml()
        {

        }
        public void Get()
        {
            string path = Directory.GetCurrentDirectory() + "Write.xml";
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
    }
}
