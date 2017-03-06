using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterDALAbstracts;
using MonsterLibAbstracts;
using System.Xml.Linq;
using MonsterLibAbstracts.AttackTypes;

namespace MonsterDAL
{
    public class MonsterData: IDataAccess<IMonster>
    {
        IFileReader<IMonster> _monsterFileReader;
        IFileWriter<IMonster> _monsterFileWriter;

        public MonsterData(IFileReader<IMonster> monsterFileReader, IFileWriter<IMonster> monsterFileWriter)
        {
            _monsterFileReader = monsterFileReader;
            _monsterFileWriter = monsterFileWriter;
        }

        public List<IMonster> LoadData(string dataPath)
        {
           return _monsterFileReader.LoadData(dataPath);
        }

        public void SaveData(string dataPath, List<IMonster> items)
        {
            _monsterFileWriter.SaveData(dataPath, items);
        }
    }
}
