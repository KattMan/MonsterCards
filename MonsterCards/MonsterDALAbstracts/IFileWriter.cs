using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterDALAbstracts;
using MonsterLibAbstracts;
using System.Xml.Linq;
using MonsterLibAbstracts.AttackTypes;

namespace MonsterDALAbstracts
{
    public interface IFileWriter<T>
    {
        void SaveData(string dataPath, List<T> items);
    }
}
