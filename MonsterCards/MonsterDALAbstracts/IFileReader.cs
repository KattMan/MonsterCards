using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using MonsterLibAbstracts;

namespace MonsterDALAbstracts
{
    public interface IFileReader<T>
    {
        List<T> LoadData(string dataPath);
    }
}
