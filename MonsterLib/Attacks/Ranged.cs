using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterLibAbstracts.Attacks;

namespace MonsterLib.Attacks
{
    public class Ranged: IRanged
    {
        public string Weapon { get; set; }

        public string ROF { get; set; }

        public string Reload { get; set; }

        public string Skill { get; set; }

        public string Damage { get; set; }

        public string DamageType { get; set; }

        public string HalfDmg { get; set; }

        public string MaxRange { get; set; }

        public string Bulk { get; set; }
    }
}
