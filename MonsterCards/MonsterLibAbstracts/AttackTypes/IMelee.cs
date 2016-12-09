using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibAbstracts.AttackTypes
{
    public interface IMelee
    {
        string Weapon { get; set; }
        string Usage { get; set; }
        string Skill { get; set; }
        string Parry { get; set; }
        string Block { get; set; }
        string Damage { get; set; }
        string DamageType { get; set; }
        string Reach { get; set; }
    }
}
