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
    public class MonsterFileWriter : IFileWriter<IMonster>
    {
        public void SaveData(string dataPath, List<IMonster> items)
        {
            var monsterPath = System.IO.Path.Combine(dataPath, "Monsters.xml");

            var root = new XElement("MONSTERS");

            foreach (var monster in items)
            {
                var monsterXml = BuildInfo(monster);

                monsterXml.Add(BuildDescription(monster.Description));
                monsterXml.Add(BuildTactics(monster.Tactics));
                monsterXml.Add(BuildBook(monster.Book));
                monsterXml.Add(BuildDRs(monster.DamageResist));
                monsterXml.Add(BuildDrops(monster.Drops));
                monsterXml.Add(BuildHabitats(monster.Habitats));
                monsterXml.Add(BuildSkills(monster.Skills));
                monsterXml.Add(BuildStats(monster.Stats));
                monsterXml.Add(BuildTraits(monster.Traits));
                monsterXml.Add(BuildAttacks(monster.Attacks));
                monsterXml.Add(BuildClassification(monster.Classification));
                
                root.Add(monsterXml);
            }


            var xdoc = new XDocument();
            xdoc.Add(root);
            xdoc.Save(monsterPath);
        }

        public XElement BuildInfo(IMonster monster)
        {
            var monsterXml = new XElement("MONSTERINFO");
            monsterXml.Add(new XAttribute("ID", monster.ID));
            monsterXml.Add(new XAttribute("NAME", monster.Name));

            return monsterXml;
        }

        public XElement BuildDescription(string description)
        {
            return new XElement("DESCRIPTION", description);
        }

        public XElement BuildTactics(List<ITactic> tactics)
        {
            var tacticsListXML = new XElement("TACTICS");
            foreach (var tactic in tactics)
            {
                var tacticXML = new XElement("TACTIC");
                tacticXML.Add(new XAttribute("ORDER", tactic.Order));
                tacticXML.Add(new XAttribute("TEXT", tactic.Text));
                tacticsListXML.Add(tacticXML);
            }

            return tacticsListXML;

        }

        public XElement BuildBook(IBook book)
        {
            var bookXML = new XElement("BOOK");
            bookXML.Add(new XAttribute("TITLE", book.Title));
            bookXML.Add(new XAttribute("PAGE", book.Page));

            return bookXML;
        }

        public XElement BuildDRs(IDamageResist drs)
        {
            var drXML = new XElement("DAMAGERESISTANCE");
            drXML.Add(new XAttribute("ARM", drs.Arm));
            drXML.Add(new XAttribute("FOOT", drs.Foot));
            drXML.Add(new XAttribute("HAND", drs.Hand));
            drXML.Add(new XAttribute("HEAD", drs.Head));
            drXML.Add(new XAttribute("LEG", drs.Leg));
            drXML.Add(new XAttribute("TAIL", drs.Tail));
            drXML.Add(new XAttribute("TORSO", drs.Torso));
            drXML.Add(new XAttribute("WING", drs.Wing));
            drXML.Add(new XAttribute("FIN", drs.Fin));
            drXML.Add(new XAttribute("WINGED", drs.Winged));
            drXML.Add(new XAttribute("BODYTYPE", drs.BodyType));

            return drXML;
        }

        public XElement BuildClassification(IClassification classification)
        {
            var classificationXML = new XElement("CLASSIFICATION");
            classificationXML.Add(new XAttribute("NAME", classification.Name));
            classificationXML.Add(new XAttribute("DESCRIPTION", classification.Description));

            return classificationXML;
        }

        public XElement BuildDrops(List<IDrop> drops)
        {
            var dropsListXML = new XElement("DROPS");
            foreach (var drop in drops)
            {
                var dropXML = new XElement("DROP");
                dropXML.Add(new XAttribute("NAME", drop.Name));
                dropsListXML.Add(dropXML);
            }

            return dropsListXML;
        }

        public XElement BuildHabitats(List<IHabitat> habitats)
        {
            var habitatsListXML = new XElement("HABITATS");
            foreach (var habitat in habitats)
            {
                var habitatXML = new XElement("HABITAT");
                habitatXML.Add(new XAttribute("NAME", habitat.Name));
                habitatsListXML.Add(habitatXML);
            }

            return habitatsListXML;
        }

        public XElement BuildSkills(List<ISkill> skills)
        {
            var skillsListXML = new XElement("SKILLS");
            foreach (var skill in skills)
            {
                var skillXML = new XElement("SKILL");
                skillXML.Add(new XAttribute("NAME", skill.Name));
                skillXML.Add(new XAttribute("LEVEL", skill.Level));
                skillsListXML.Add(skillXML);
            }

            return skillsListXML;
        }

        public XElement BuildStats(IStats stats)
        {
            var statsXML = new XElement("STATS");
            statsXML.Add(new XAttribute("DEXTERITY", stats.Dexterity));
            statsXML.Add(new XAttribute("DODGE", stats.Dodge));
            statsXML.Add(new XAttribute("FATIGUEPOINTS", stats.FatiguePoints));
            statsXML.Add(new XAttribute("HEALTH", stats.Health));
            statsXML.Add(new XAttribute("HITPOINTS", stats.HitPoints));
            statsXML.Add(new XAttribute("IQ", stats.IQ));
            statsXML.Add(new XAttribute("MOVE", stats.Move));
            statsXML.Add(new XAttribute("PERCEPTION", stats.Perception));
            statsXML.Add(new XAttribute("SIZEMODIFIER", stats.SizeModifier));
            statsXML.Add(new XAttribute("SPEED", stats.Speed));
            statsXML.Add(new XAttribute("STRENGTH", stats.Strength));
            statsXML.Add(new XAttribute("WILL", stats.Will));
            statsXML.Add(new XAttribute("WEIGHT", stats.Weight));
            statsXML.Add(new XAttribute("HEIGHT", stats.Height));

            return statsXML;
        }

        public XElement BuildTraits(List<ITrait> traits)
        {
            var traitsListXML = new XElement("TRAITS");
            foreach (var trait in traits)
            {
                var traitXML = new XElement("TRAIT");
                traitXML.Add(new XAttribute("NAME", trait.Name));
                traitsListXML.Add(traitXML);
            }
            return traitsListXML;
        }

        public XElement BuildAttacks(IAttacks attacks)
        {
            var attacksXML = new XElement("ATTACKS");
            attacksXML.Add(BuildMeleeAttacks(attacks.Melee));
            attacksXML.Add(BuildRangedAttacks(attacks.Ranged));
            attacksXML.Add(BuildSpellAttacks(attacks.Spell));
            
            return attacksXML;
        }

        public XElement BuildMeleeAttacks(List<IMelee> melees)
        {
            var meleeAttacksXML = new XElement("MELEEATTACKS");
            foreach (var melee in melees)
            {
                var meleeXML = new XElement("MELEEATTACK");
                meleeXML.Add(new XAttribute("WEAPON", melee.Weapon));
                meleeXML.Add(new XAttribute("USAGE", melee.Usage));
                meleeXML.Add(new XAttribute("SKILL", melee.Skill));
                meleeXML.Add(new XAttribute("BLOCK", melee.Block));
                meleeXML.Add(new XAttribute("DAMAGE", melee.Damage));
                meleeXML.Add(new XAttribute("DAMAGETYPE", melee.DamageType));
                meleeXML.Add(new XAttribute("PARRY", melee.Parry));
                meleeXML.Add(new XAttribute("REACH", melee.Reach));
                meleeAttacksXML.Add(meleeXML);
            }

            return meleeAttacksXML;
        }

        public XElement BuildRangedAttacks(List<IRanged> ranges)
        {
            var rangeAttacksXML = new XElement("RANGEDATTACKS");
            foreach (var ranged in ranges)
            {
                var rangedXML = new XElement("RANGEDATTACK");
                rangedXML.Add(new XAttribute("WEAPON", ranged.Weapon));
                rangedXML.Add(new XAttribute("SKILL", ranged.Skill));
                rangedXML.Add(new XAttribute("BULK", ranged.Bulk));
                rangedXML.Add(new XAttribute("DAMAGE", ranged.Damage));
                rangedXML.Add(new XAttribute("DAMAGETYPE", ranged.DamageType));
                rangedXML.Add(new XAttribute("HALFDAMAGE", ranged.HalfDmg));
                rangedXML.Add(new XAttribute("MAXRANGE", ranged.MaxRange));
                rangedXML.Add(new XAttribute("RELOAD", ranged.Reload));
                rangedXML.Add(new XAttribute("ROF", ranged.ROF));
                rangeAttacksXML.Add(rangedXML);
            }

            return rangeAttacksXML;
        }

        public XElement BuildSpellAttacks(List<ISpell> spells)
        {
            var spellAttacksXml = new XElement("SPELLATTACKS");
            foreach (var spell in spells)
            {
                var spellXML = new XElement("SPELLATTACK");
                spellXML.Add(new XAttribute("NAME", spell.Name));
                spellXML.Add(new XAttribute("SKILL", spell.Skill));
                spellXML.Add(new XAttribute("COST", spell.Cost));
                spellXML.Add(new XAttribute("DURATION", spell.Duration));
                spellXML.Add(new XAttribute("MAINTAIN", spell.Maintain));
                spellXML.Add(new XAttribute("TIMETOCAST", spell.TimeToCast));
                spellAttacksXml.Add(spellXML);
            }

            return spellAttacksXml;
        }
    }
}
