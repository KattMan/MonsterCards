using MonsterLibAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterDALAbstracts
{
    public interface IDataAccess<T>
    {
        List<T> LoadData(string dataPath);
        void SaveData(string dataPath, List<T> items);
       
    }
}
