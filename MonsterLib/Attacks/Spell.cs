using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterLibAbstracts.Attacks;

namespace MonsterLib.Attacks
{
    public class Spell: ISpell
    {
        public string Name { get; set; }

        public string Skill { get; set; }

        public string Cost { get; set; }

        public string TimeToCast { get; set; }

        public string Duration { get; set; }

        public string Maintain { get; set; }
    }
}
