using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterLibAbstracts;
using MonsterLibAbstracts.AttackTypes;

namespace MonsterLib
{
    public class Attacks: IAttacks
    {
        List<IMelee> _Melee = new List<IMelee>();
        List<IRanged> _Ranged = new List<IRanged>();
        List<ISpell> _Spell = new List<ISpell>();

        public List<IMelee> Melee
        {
            get { return _Melee; }
        }

        public List<IRanged> Ranged
        {
            get { return _Ranged; }
        }

        public List<ISpell> Spell
        {
            get { return _Spell; }
        }
    }
}
