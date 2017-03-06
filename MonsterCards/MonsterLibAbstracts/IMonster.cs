using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibAbstracts
{
    public interface IMonster
    {
        int ID { get; }
        string Name { get; set; }
        string Description { get; set; }
        List<ITactic> Tactics { get; set; }

        IBook Book { get; set; }
        IClassification Classification { get; set; }
        IStats Stats { get; set; }
        IDamageResist DamageResist { get; set; }
        List<IHabitat> Habitats { get; set; }
        List<ITrait> Traits { get; set; }
        List<ISkill> Skills { get; set; }
        List<IDrop> Drops { get; set; }
        IAttacks Attacks { get; set; }
    }
}
