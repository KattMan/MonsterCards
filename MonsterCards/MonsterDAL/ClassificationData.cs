using MonsterDALAbstracts;
using MonsterLibAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterDAL
{
    public class ClassificationData : IDataAccess<IClassification>
    {
        IFileReader<IClassification> _fileReader;
        IFileWriter<IClassification> _fileWriter;

        public ClassificationData(IFileReader<IClassification> fileReader, IFileWriter<IClassification> fileWriter)
        {
            _fileReader = fileReader;
            _fileWriter = fileWriter;
        }

        public List<IClassification> LoadData(string dataPath)
        {
            return _fileReader.LoadData(dataPath);
        }

        public void SaveData(string dataPath, List<IClassification> items)
        {
            _fileWriter.SaveData(dataPath, items);
        }
    }
}
