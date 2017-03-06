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
    public class ClassificationFileWriter : IFileWriter<IClassification>
    {
        public void SaveData(string dataPath, List<IClassification> items)
        {
            var monsterPath = System.IO.Path.Combine(dataPath, "Classifications.xml");

            var root = new XElement("Classifications");

            foreach (var classification in items)
            {
                var classificationXml = new XElement("Classification");
                classificationXml.Add(new XAttribute("Name", classification.Name));
                classificationXml.Add(new XAttribute("Description", classification.Description));

                root.Add(classificationXml);
            }


            var xdoc = new XDocument();
            xdoc.Add(root);
            xdoc.Save(monsterPath);
        }
    }
}
