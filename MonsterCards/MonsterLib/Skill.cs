using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterLibAbstracts;

namespace MonsterLib
{
    public class Skill: ISkill
    {
        public string Name { get; set; }

        public string Level { get; set; }

        public override string ToString()
        {
            return Name + "-" + Level;
        }
    }
}
