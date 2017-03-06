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
    public class BookFileReader : IFileReader<IBook>
    {
        IMonsterFactory _monsterFactory;

        public BookFileReader(IMonsterFactory monsterFactory)
        {
            _monsterFactory = monsterFactory;
        }

        public List<IBook> LoadData(string dataPath)
        {
            List<IBook> books = new List<IBook>();

            var monsterPath = System.IO.Path.Combine(dataPath, "Books.xml");

            var xdoc = XDocument.Load(monsterPath);
            var root = xdoc.Root;
            foreach (var infoElement in root.Descendants())
            {
                var book = GetBookInfo(infoElement);

                books.Add(book);
            }

            return books;
        }

        public IBook GetBookInfo(XElement bookInfo)
        {
            var book = _monsterFactory.GetBookInstance();

            book.Title = bookInfo.Attribute("name").Value;

            return book;
        }
    }
}
