using MonsterLib.AttackTypes;
using MonsterLibAbstracts;
using MonsterLibAbstracts.AttackTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLib
{
    public class MonsterFactory : IMonsterFactory
    {
        public IMonster GetMonsterInstance(int ID)
        {
            return new Monster() { ID=ID };
        }

        public IHabitat GetHabitatInstance()
        {
            return new Habitat();
        }

        public ITrait GetTraitInstance()
        {
            return new Trait();
        }

        public ISkill GetSkillInstance()
        {
            return new Skill();
        }

        public IDrop GetDropInstance()
        {
            return new Drop();
        }

        public IMelee GetMeleeInstance()
        {
            return new Melee();
        }

        public IRanged GetRangedInstance()
        {
            return new Ranged();
        }

        public ISpell GetSpellInstance()
        {
            return new Spell();
        }

        public IBook GetBookInstance()
        {
            return new Book();
        }

        public IDamageResist GetDRInstance()
        {
            return new DamageResist();
        }

        public IStats GetStatsInstance()
        {
            return new Stats();
        }

        public IAttacks GetAttacksInstance()
        {
            return new Attacks();
        }

        public IClassification GetClassificationInstance()
        {
            return new Classification();
        }
    }
}
