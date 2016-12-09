using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterLibAbstracts.AttackTypes;

namespace MonsterLibAbstracts
{
    public interface IAttacks
    {
        List<IMelee> Melee { get; }
        List<IRanged> Ranged { get; }
        List<ISpell> Spell { get; }
    }
}
