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
    public class ClassificationFileReader : IFileReader<IClassification>
    {
        IMonsterFactory _monsterFactory;

        public ClassificationFileReader(IMonsterFactory monsterFactory)
        {
            _monsterFactory = monsterFactory;
        }

        public List<IClassification> LoadData(string dataPath)
        {
            List<IClassification> classifications = new List<IClassification>();

            var monsterPath = System.IO.Path.Combine(dataPath, "Classifications.xml");

            var xdoc = XDocument.Load(monsterPath);
            var root = xdoc.Root;
            foreach (var infoElement in root.Descendants())
            {
                var classification = GetClassificationInfo(infoElement);

                classifications.Add(classification);
            }

            return classifications;
        }

        public IClassification GetClassificationInfo(XElement bookInfo)
        {
            var classification = _monsterFactory.GetClassificationInstance();

            classification.Name = bookInfo.Attribute("Name").Value;
            classification.Description = bookInfo.Attribute("Description").Value;

            return classification;
        }
    }
}
