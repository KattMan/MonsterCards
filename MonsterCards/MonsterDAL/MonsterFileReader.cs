using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterDALAbstracts;
using MonsterLibAbstracts;
using System.Xml.Linq;
using MonsterLibAbstracts.AttackTypes;

namespace MonsterDAL
{
    public class MonsterFileReader : IFileReader<IMonster>
    {
        IMonsterFactory _monsterFactory;

        public MonsterFileReader(IMonsterFactory monsterFactory)
        {
            _monsterFactory = monsterFactory;
        }

        public List<IMonster> LoadData(string dataPath)
        {
           
            List<IMonster> monsters = new List<IMonster>();

            var monsterPath = System.IO.Path.Combine(dataPath, "Monsters.xml");

            var xdoc = XDocument.Load(monsterPath);
            var root = xdoc.Root;
            foreach (var infoElement in root.Elements("MONSTERINFO"))
            {
                var monster = GetInfo(infoElement);

                monster.Book = GetBookInfo(infoElement);
                monster.Classification = GetClassification(infoElement);
                monster.Description = GetDescription(infoElement);
                monster.Tactics = GetTactics(infoElement);
                monster.DamageResist = GetDR(infoElement);
                monster.Stats = GetStats(infoElement);
                monster.Habitats = GetHabitats(infoElement);
                monster.Traits = GetTraits(infoElement);
                monster.Skills = GetSkills(infoElement);
                monster.Drops = GetDrops(infoElement);
                monster.Attacks = GetAttacks(infoElement);

                monsters.Add(monster);
            }

            return monsters;
        }

        public IMonster GetInfo(XElement monsterInfo)
        {
            var monster = _monsterFactory.GetMonsterInstance(int.Parse(monsterInfo.Attribute("ID").Value));
            monster.Name = monsterInfo.Attribute("NAME").Value;

            return monster;
        }

        public IBook GetBookInfo(XElement monsterInfo)
        {
            var element = monsterInfo.Element("BOOK");
            var book = _monsterFactory.GetBookInstance();

            book.Title = element.Attribute("TITLE").Value;
            book.Page = element.Attribute("PAGE").Value;

            return book;
        }

        public IClassification GetClassification(XElement monsterInfo)
        {
            var classification = _monsterFactory.GetClassificationInstance();

            var element = monsterInfo.Element("CLASSIFICATION");

            classification.Name = element.Attribute("NAME").Value;
            classification.Description = element.Attribute("DESCRIPTION").Value;

            return classification;
        }

        public string GetDescription(XElement monsterInfo)
        {
            var element = monsterInfo.Element("DESCRIPTION");

            return element.Value;
        }

        public List<ITactic> GetTactics(XElement monsterInfo)
        {
            var items = new List<ITactic>();

            var group = monsterInfo.Element("TACTICS");
            foreach (var element in group.Elements("TACTIC"))
            {
                var item = _monsterFactory.GetTacticIntance();
                item.Order = int.Parse(element.Attribute("ORDER").Value);
                item.Text = element.Attribute("TEXT").Value;
                items.Add(item);
            }

            return items;
        }

        public IDamageResist GetDR(XElement monsterInfo)
        {
            var element = monsterInfo.Element("DAMAGERESISTANCE");
            var dr = _monsterFactory.GetDRInstance();

            dr.Arm = element.Attribute("ARM").Value;
            dr.Foot = element.Attribute("FOOT").Value;
            dr.Hand = element.Attribute("HAND").Value;
            dr.Head = element.Attribute("HEAD").Value;
            dr.Leg = element.Attribute("LEG").Value;
            dr.Tail = element.Attribute("TAIL").Value;
            dr.Torso = element.Attribute("TORSO").Value;
            dr.Wing = element.Attribute("WING").Value;
            dr.Fin = element.Attribute("FIN").Value;
            dr.Winged = bool.Parse(element.Attribute("WINGED").Value);

            var bodyType = element.Attribute("BODYTYPE").Value;

            switch(bodyType)
            {
                case "Arachnoid":
                    dr.BodyType = BodyType.Arachnoid;
                    break;
                case "Avian":
                    dr.BodyType = BodyType.Avian;
                    break;
                case "Cancroid":
                    dr.BodyType = BodyType.Cancroid;
                    break;
                case "Centaur":
                    dr.BodyType = BodyType.Centaur;
                    break;
                case "Hexapod":
                    dr.BodyType = BodyType.Hexapod;
                    break;
                case "Humanoid":
                    dr.BodyType = BodyType.Humanoid;
                    break;
                case "Hybrid":
                    dr.BodyType = BodyType.Hybrid;
                    break;
                case "Ichthyoid":
                    dr.BodyType = BodyType.Ichthyoid;
                    break;
                case "Octopod":
                    dr.BodyType = BodyType.Octopod;
                    break;
                case "Quadruped":
                    dr.BodyType = BodyType.Quadruped;
                    break;
                case "Vermiform":
                    dr.BodyType = BodyType.Vermiform;
                    break;
                default:
                    dr.BodyType = BodyType.Humanoid;
                    break;
            }

            return dr;
        }

        public IStats GetStats(XElement monsterInfo)
        {
            var element = monsterInfo.Element("STATS");
            var stats = _monsterFactory.GetStatsInstance();

            stats.Dexterity = element.Attribute("DEXTERITY").Value;
            stats.Dodge = element.Attribute("DODGE").Value;
            stats.FatiguePoints = element.Attribute("FATIGUEPOINTS").Value;
            stats.Health = element.Attribute("HEALTH").Value;
            stats.HitPoints = element.Attribute("HITPOINTS").Value;
            stats.IQ = element.Attribute("IQ").Value;
            stats.Move = element.Attribute("MOVE").Value;
            stats.Perception = element.Attribute("PERCEPTION").Value;
            stats.SizeModifier = element.Attribute("SIZEMODIFIER").Value;
            stats.Speed = element.Attribute("SPEED").Value;
            stats.Strength = element.Attribute("STRENGTH").Value;
            stats.Weight = element.Attribute("WEIGHT").Value;
            stats.Will = element.Attribute("WILL").Value;
            stats.Height = element.Attribute("HEIGHT").Value;

            return stats;
        }

        public List<IHabitat> GetHabitats(XElement monsterInfo)
        {
            var items = new List<IHabitat>();

            var group = monsterInfo.Element("HABITATS");
            foreach (var element in group.Elements("HABITAT"))
            {
                var item = _monsterFactory.GetHabitatInstance();
                item.Name = element.Attribute("NAME").Value;
                items.Add(item);
            }

            return items;
        }

        public List<ISkill> GetSkills(XElement monsterInfo)
        {
            var items = new List<ISkill>();

            var group = monsterInfo.Element("SKILLS");
            foreach (var element in group.Elements("SKILL"))
            {
                var item = _monsterFactory.GetSkillInstance();
                item.Name = element.Attribute("NAME").Value;
                item.Level = element.Attribute("LEVEL").Value;
                items.Add(item);
            }

            return items;
        }

        public List<ITrait> GetTraits(XElement monsterInfo)
        {
            var items = new List<ITrait>();

            var group = monsterInfo.Element("TRAITS");
            foreach (var element in group.Elements("TRAIT"))
            {
                var item = _monsterFactory.GetTraitInstance();
                item.Name = element.Attribute("NAME").Value;
                items.Add(item);
            }

            return items;
        }

        public List<IDrop> GetDrops(XElement monsterInfo)
        {
            var items = new List<IDrop>();

            var group = monsterInfo.Element("DROPS");
            foreach (var element in group.Elements("DROP"))
            {
                var item = _monsterFactory.GetDropInstance();
                item.Name = element.Attribute("NAME").Value;
                items.Add(item);
            }

            return items;
        }

        public IAttacks GetAttacks(XElement monsterInfo)
        {
            var attacksInfo = monsterInfo.Element("ATTACKS");

            var attacks = _monsterFactory.GetAttacksInstance();

            attacks = GetMelees(attacks, attacksInfo);
            attacks = GetRanged(attacks, attacksInfo);
            attacks = GetSpells(attacks, attacksInfo);

            return attacks;
        }

        public IAttacks GetMelees(IAttacks attacks, XElement attacksInfo)
        {

            var group = attacksInfo.Element("MELEEATTACKS");
            foreach (var element in group.Elements("MELEEATTACK"))
            {
                var item = _monsterFactory.GetMeleeInstance();
                item.Block = element.Attribute("BLOCK").Value;
                item.Damage = element.Attribute("DAMAGE").Value;
                item.DamageType = element.Attribute("DAMAGETYPE").Value;
                item.Parry = element.Attribute("PARRY").Value;
                item.Reach = element.Attribute("REACH").Value;
                item.Skill = element.Attribute("SKILL").Value;
                item.Usage = element.Attribute("USAGE").Value;
                item.Weapon = element.Attribute("WEAPON").Value;
                attacks.Melee.Add(item);
            }

            return attacks;
        }

        public IAttacks GetRanged(IAttacks attacks, XElement attacksInfo)
        {
            var group = attacksInfo.Element("RANGEDATTACKS");
            foreach (var element in group.Elements("RANGEDATTACK"))
            {
                var item = _monsterFactory.GetRangedInstance();
                item.Bulk = element.Attribute("BULK").Value;
                item.Damage = element.Attribute("DAMAGE").Value;
                item.DamageType = element.Attribute("DAMAGETYPE").Value;
                item.HalfDmg = element.Attribute("HALFDAMAGE").Value;
                item.MaxRange = element.Attribute("MAXRANGE").Value;
                item.Reload = element.Attribute("RELOAD").Value;
                item.ROF = element.Attribute("ROF").Value;
                item.Skill = element.Attribute("SKILL").Value;
                item.Weapon = element.Attribute("WEAPON").Value;
                attacks.Ranged.Add(item);
            }

            return attacks;
        }

        public IAttacks GetSpells(IAttacks attacks, XElement attacksInfo)
        {
            var group = attacksInfo.Element("SPELLATTACKS");
            foreach (var element in group.Elements("SPELLATTACK"))
            {
                var item = _monsterFactory.GetSpellInstance();
                item.Cost = element.Attribute("COST").Value;
                item.Duration = element.Attribute("DURATION").Value;
                item.Maintain = element.Attribute("MAINTAIN").Value;
                item.Name = element.Attribute("NAME").Value;
                item.Skill = element.Attribute("SKILL").Value;
                item.TimeToCast = element.Attribute("TIMETOCAST").Value;
                attacks.Spell.Add(item);
            }

            return attacks;
        }
    }
}
