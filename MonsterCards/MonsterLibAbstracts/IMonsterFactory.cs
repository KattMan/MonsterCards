using MonsterLibAbstracts.AttackTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibAbstracts
{
    public interface IMonsterFactory
    {
        IMonster GetMonsterInstance(int ID);
        IHabitat GetHabitatInstance();
        ITrait GetTraitInstance();
        ISkill GetSkillInstance();
        IDrop GetDropInstance();
        IMelee GetMeleeInstance();
        IRanged GetRangedInstance();
        ISpell GetSpellInstance();
        IBook GetBookInstance();
        IDamageResist GetDRInstance();
        IStats GetStatsInstance();
        IAttacks GetAttacksInstance();
        IClassification GetClassificationInstance();
        ITactic GetTacticIntance();

    }
}
