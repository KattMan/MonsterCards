using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterLibAbstracts.Attacks;

namespace MonsterLib.Attacks
{
    public class Melee: IMelee
    {
        public string Weapon { get; set; }

        public string Usage { get; set; }

        public string Skill { get; set; }

        public string Parry { get; set; }

        public string Block { get; set; }

        public string Damage { get; set; }

        public string DamageType { get; set; }

        public string Reach { get; set; }
    }
}
