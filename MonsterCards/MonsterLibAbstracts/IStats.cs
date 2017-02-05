using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibAbstracts
{
    public interface IStats
    {
        string Strength { get; set; }
        string Dexterity { get; set; }
        string IQ { get; set; }
        string Health { get; set; }
        string HitPoints { get; set; }
        string FatiguePoints { get; set; }
        string Will { get; set; }
        string Perception { get; set; }
        string Speed { get; set; }
        string Move { get; set; }
        string Dodge { get; set; }
        string SizeModifier { get; set; }
        string Classification { get; set; }
        string Weight { get; set; }
        string Height { get; set; }

    }
}
