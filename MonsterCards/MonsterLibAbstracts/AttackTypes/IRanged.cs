using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibAbstracts.AttackTypes
{
    public interface IRanged
    {
        string Weapon { get; set; }
        string ROF { get; set; }
        string Reload { get; set; }
        string Skill { get; set; }
        string Damage { get; set; }
        string DamageType { get; set; }
        string HalfDmg { get; set; }
        string MaxRange { get; set; }
        string Bulk { get; set; }
    }
}
