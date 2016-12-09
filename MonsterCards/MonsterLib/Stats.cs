using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterLibAbstracts;

namespace MonsterLib
{
    public class Stats: IStats
    {
        public string Strength { get; set; }

        public string Dexterity { get; set; }

        public string IQ { get; set; }

        public string Health { get; set; }

        public string HitPoints { get; set; }

        public string FatiguePoints { get; set; }

        public string Will { get; set; }

        public string Perception { get; set; }

        public string Speed { get; set; }

        public string Move { get; set; }

        public string Dodge { get; set; }

        public string SizeModifier { get; set; }

        public string Classification { get; set; }

        public string Weight { get; set; }

    }
}
