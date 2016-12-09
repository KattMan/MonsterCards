using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibAbstracts.AttackTypes
{
    public interface ISpell
    {
        string Name { get; set; }
        string Skill { get; set; }
        string Cost { get; set; }
        string TimeToCast { get; set; }
        string Duration { get; set; }
        string Maintain { get; set; }
    }
}
