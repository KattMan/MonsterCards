using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterDALAbstracts;
using MonsterLibAbstracts;
using System.Xml.Linq;

namespace MonsterDAL
{
    public class BookFileWriter : IFileWriter<IBook>
    {
        public void SaveData(string dataPath, List<IBook> items)
        {
            var monsterPath = System.IO.Path.Combine(dataPath, "Books.xml");

            var root = new XElement("Books");

            foreach (var book in items)
            {
                var bookXml = new XElement("Book");
                bookXml.Add(new XAttribute("name", book.Title));

                root.Add(bookXml);
            }


            var xdoc = new XDocument();
            xdoc.Add(root);
            xdoc.Save(monsterPath);
        }
    }
}
