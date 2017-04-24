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
            var monster =  new Monster() { ID=ID };

            monster.Name = " New Monster";
            monster.Description = "";

            monster.Book = GetBookInstance();
            monster.Attacks = GetAttacksInstance();
            monster.Classification = GetClassificationInstance();
            monster.DamageResist = GetDRInstance();
            monster.Drops = new List<IDrop>();
            monster.Habitats = new List<IHabitat>();
            monster.Skills = new List<ISkill>();
            monster.Stats = GetStatsInstance();
            monster.Tactics = new List<ITactic>();
            monster.Traits = new List<ITrait>();
            
            return monster;
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
            var book = new Book();
            book.Title = string.Empty;
            book.Page = string.Empty;
            return book;
        }

        public IDamageResist GetDRInstance()
        {
            var dr = new DamageResist();

            dr.Arm = string.Empty;
            dr.Fin = string.Empty;
            dr.Foot = string.Empty;
            dr.Hand = string.Empty;
            dr.Head = string.Empty;
            dr.Leg = string.Empty;
            dr.Tail = string.Empty;
            dr.Torso = string.Empty;
            dr.Wing = string.Empty;
            dr.Winged = false;

            return dr;
        }

        public IStats GetStatsInstance()
        {
            var stats = new Stats();

            stats.Dexterity = string.Empty;
            stats.Dodge = string.Empty;
            stats.FatiguePoints = string.Empty;
            stats.Health = string.Empty;
            stats.Height = string.Empty;
            stats.HitPoints = string.Empty;
            stats.IQ = string.Empty;
            stats.Move = string.Empty;
            stats.Perception = string.Empty;
            stats.SizeModifier = string.Empty;
            stats.Speed = string.Empty;
            stats.Strength = string.Empty;
            stats.Weight = string.Empty;
            stats.Will = string.Empty;

            return stats;
        }

        public IAttacks GetAttacksInstance()
        {
            return new Attacks();
        }

        public IClassification GetClassificationInstance()
        {
            var classification = new Classification();

            classification.Description = string.Empty;
            classification.Name = string.Empty;

            return classification;
        }

        public ITactic GetTacticIntance()
        {
            return new Tactic();
        }
    }
}
