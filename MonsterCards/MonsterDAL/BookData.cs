using MonsterDALAbstracts;
using MonsterLibAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterDAL
{
    public class BookData : IDataAccess<IBook>
    {
        IFileReader<IBook> _fileReader;
        IFileWriter<IBook> _fileWriter;

        public BookData(IFileReader<IBook> fileReader, IFileWriter<IBook> fileWriter)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }

        public List<IBook> LoadData(string dataPath)
        {
            return _fileReader.LoadData(dataPath);
        }

        public void SaveData(string dataPath, List<IBook> items)
        {
            _fileWriter.SaveData(dataPath, items);
        }
    }
}
