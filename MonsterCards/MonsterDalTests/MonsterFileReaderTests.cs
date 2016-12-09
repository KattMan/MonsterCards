using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterDAL;
using Moq;
using MonsterLibAbstracts;
using System.Xml.Linq;
using System.Collections.Generic;
using MonsterLibAbstracts.AttackTypes;

namespace MonsterDalTests
{
    [TestClass]
    public class MonsterFileReaderTests
    {
        private MonsterFileReader GetMonsterFileReader()
        {
            var factoryMock = new Mock<IMonsterFactory>();

            var monsterMock = new Mock<IMonster>();
            monsterMock.SetupAllProperties();
            var monsterMock1 = new Mock<IMonster>();
            monsterMock1.SetupAllProperties();
            monsterMock1.SetupGet(g => g.ID).Returns(1);
            factoryMock.Setup(s => s.GetMonsterInstance(It.IsAny<int>())).Returns(monsterMock.Object);
            factoryMock.Setup(s => s.GetMonsterInstance(1)).Returns(monsterMock1.Object);

            var attacksMock = new Mock<IAttacks>();
            var meleeMock = new Mock<IMelee>();
            meleeMock.SetupAllProperties();
            factoryMock.Setup(s => s.GetMeleeInstance()).Returns(meleeMock.Object);

            var rangeMock = new Mock<IRanged>();
            rangeMock.SetupAllProperties();
            factoryMock.Setup(s => s.GetRangedInstance()).Returns(rangeMock.Object);

            var spellMock = new Mock<ISpell>();
            spellMock.SetupAllProperties();
            factoryMock.Setup(s => s.GetSpellInstance()).Returns(spellMock.Object);

            attacksMock.SetupGet(p => p.Melee).Returns(new List<IMelee>());
            attacksMock.SetupGet(p => p.Ranged).Returns(new List<IRanged>());
            attacksMock.SetupGet(p => p.Spell).Returns(new List<ISpell>());

            factoryMock.Setup(s => s.GetAttacksInstance()).Returns(attacksMock.Object);

            var bookMock = new Mock<IBook>();
            bookMock.SetupAllProperties();
            factoryMock.Setup(s => s.GetBookInstance()).Returns(bookMock.Object);

            var drMock = new Mock<IDamageResist>();
            drMock.SetupAllProperties();
            factoryMock.Setup(s => s.GetDRInstance()).Returns(drMock.Object);

            var dropMock = new Mock<IDrop>();
            dropMock.SetupAllProperties();
            factoryMock.Setup(s => s.GetDropInstance()).Returns(dropMock.Object);

            var habitatMock = new Mock<IHabitat>();
            habitatMock.SetupAllProperties();
            factoryMock.Setup(s => s.GetHabitatInstance()).Returns(habitatMock.Object);

            var skillMock = new Mock<ISkill>();
            skillMock.SetupAllProperties();
            factoryMock.Setup(s => s.GetSkillInstance()).Returns(skillMock.Object);

            var statMock = new Mock<IStats>();
            statMock.SetupAllProperties();
            factoryMock.Setup(s => s.GetStatsInstance()).Returns(statMock.Object);

            var traitMock = new Mock<ITrait>();
            traitMock.SetupAllProperties();
            factoryMock.Setup(s => s.GetTraitInstance()).Returns(traitMock.Object);

            return new MonsterFileReader(factoryMock.Object);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetInfoTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XAttribute("ID", "1")
                , new XAttribute("NAME", "MonsterName")
                );

            var result = reader.GetInfo(element);

            Assert.IsInstanceOfType(result, typeof(IMonster));
            Assert.AreEqual(1, result.ID);
            Assert.AreEqual("MonsterName", result.Name);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetAttacksTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("ATTACKS"
                    , new XElement("MELEEATTACKS")
                    , new XElement("RANGEDATTACKS")
                    , new XElement("SPELLATTACKS")
                    )
                );

            var result = reader.GetAttacks(element);

            Assert.IsInstanceOfType(result, typeof(IAttacks));
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetBookInfoTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("BOOK"
                    , new XAttribute("TITLE", "BookTitle")
                    , new XAttribute("PAGE", "BookPage")
                    )
                );

            var result = reader.GetBookInfo(element);

            Assert.IsInstanceOfType(result, typeof(IBook));
            Assert.AreEqual("BookTitle", result.Title);
            Assert.AreEqual("BookPage", result.Page);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetDescriptionTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("DESCRIPTION"
                    , "Monster Description"
                    )
                );

            var result = reader.GetDescription(element);

            Assert.AreEqual("Monster Description", result);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetDRTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("DAMAGERESISTANCE"
                    , new XAttribute("ARM", "1")
                    , new XAttribute("FOOT", "2")
                    , new XAttribute("HAND", "3")
                    , new XAttribute("HEAD", "4")
                    , new XAttribute("LEG", "5")
                    , new XAttribute("TAIL", "6")
                    , new XAttribute("TORSO", "7")
                    , new XAttribute("WING", "8")
                    )
                );

            var result = reader.GetDR(element);

            Assert.IsInstanceOfType(result, typeof(IDamageResist));
            Assert.AreEqual("1", result.Arm);
            Assert.AreEqual("2", result.Foot);
            Assert.AreEqual("3", result.Hand);
            Assert.AreEqual("4", result.Head);
            Assert.AreEqual("5", result.Leg);
            Assert.AreEqual("6", result.Tail);
            Assert.AreEqual("7", result.Torso);
            Assert.AreEqual("8", result.Wing);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetDropsTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("DROPS"
                    , new XElement("DROP"
                        , new XAttribute("NAME", "Drop 1")
                        )
                    )
                );

            var result = reader.GetDrops(element);

            Assert.IsInstanceOfType(result, typeof(List<IDrop>));
            Assert.AreEqual("Drop 1", result[0].Name);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetHabitatsTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("HABITATS"
                    , new XElement("HABITAT"
                        , new XAttribute("NAME", "Habitat 1")
                        )
                    )
                );

            var result = reader.GetHabitats(element);

            Assert.IsInstanceOfType(result, typeof(List<IHabitat>));
            Assert.AreEqual("Habitat 1", result[0].Name);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetMeleeAttacksTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("ATTACKS"
                    , new XElement("MELEEATTACKS"
                        , new XElement("MELEEATTACK"
                            , new XAttribute("WEAPON", "1")
                            , new XAttribute("USAGE", "2")
                            , new XAttribute("SKILL", "3")
                            , new XAttribute("BLOCK", "4")
                            , new XAttribute("DAMAGE", "5")
                            , new XAttribute("DAMAGETYPE", "6")
                            , new XAttribute("PARRY", "7")
                            , new XAttribute("REACH", "8")
                            )
                        )
                    , new XElement("RANGEDATTACKS")
                    , new XElement("SPELLATTACKS")
                    )
                );

            var result = reader.GetAttacks(element);

            Assert.IsInstanceOfType(result.Melee, typeof(List<IMelee>));
            Assert.AreEqual("1", result.Melee[0].Weapon);
            Assert.AreEqual("2", result.Melee[0].Usage);
            Assert.AreEqual("3", result.Melee[0].Skill);
            Assert.AreEqual("4", result.Melee[0].Block);
            Assert.AreEqual("5", result.Melee[0].Damage);
            Assert.AreEqual("6", result.Melee[0].DamageType);
            Assert.AreEqual("7", result.Melee[0].Parry);
            Assert.AreEqual("8", result.Melee[0].Reach);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetRangedAttacksTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("ATTACKS"
                    , new XElement("MELEEATTACKS")
                    , new XElement("RANGEDATTACKS"
                        , new XElement("RANGEDATTACK"
                            , new XAttribute("WEAPON", "1")
                            , new XAttribute("SKILL", "2")
                            , new XAttribute("BULK", "3")
                            , new XAttribute("DAMAGE", "4")
                            , new XAttribute("DAMAGETYPE", "5")
                            , new XAttribute("HALFDAMAGE", "6")
                            , new XAttribute("MAXRANGE", "7")
                            , new XAttribute("RELOAD", "8")
                            , new XAttribute("ROF", "9")
                            )
                        )
                    , new XElement("SPELLATTACKS")
                    )
                );

            var result = reader.GetAttacks(element);

            Assert.IsInstanceOfType(result.Ranged, typeof(List<IRanged>));
            Assert.AreEqual("1", result.Ranged[0].Weapon);
            Assert.AreEqual("2", result.Ranged[0].Skill);
            Assert.AreEqual("3", result.Ranged[0].Bulk);
            Assert.AreEqual("4", result.Ranged[0].Damage);
            Assert.AreEqual("5", result.Ranged[0].DamageType);
            Assert.AreEqual("6", result.Ranged[0].HalfDmg);
            Assert.AreEqual("7", result.Ranged[0].MaxRange);
            Assert.AreEqual("8", result.Ranged[0].Reload);
            Assert.AreEqual("9", result.Ranged[0].ROF);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetSpellAttacksTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("ATTACKS"
                    , new XElement("MELEEATTACKS")
                    , new XElement("RANGEDATTACKS")
                    , new XElement("SPELLATTACKS"
                        , new XElement("SPELLATTACK"
                            , new XAttribute("NAME", "1")
                            , new XAttribute("SKILL", "2")
                            , new XAttribute("COST", "3")
                            , new XAttribute("DURATION", "4")
                            , new XAttribute("MAINTAIN", "5")
                            , new XAttribute("TIMETOCAST", "6")
                            )
                        )
                    )
                );

            var result = reader.GetAttacks(element);

            Assert.IsInstanceOfType(result.Spell, typeof(List<ISpell>));
            Assert.AreEqual("1", result.Spell[0].Name);
            Assert.AreEqual("2", result.Spell[0].Skill);
            Assert.AreEqual("3", result.Spell[0].Cost);
            Assert.AreEqual("4", result.Spell[0].Duration);
            Assert.AreEqual("5", result.Spell[0].Maintain);
            Assert.AreEqual("6", result.Spell[0].TimeToCast);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetSkillsTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("SKILLS"
                    , new XElement("SKILL"
                        , new XAttribute("NAME", "Skill 1")
                        )
                    )
                );

            var result = reader.GetSkills(element);

            Assert.IsInstanceOfType(result, typeof(List<ISkill>));
            Assert.AreEqual("Skill 1", result[0].Name);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetStatsTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("STATS"
                    , new XAttribute("DEXTERITY", "1")
                    , new XAttribute("DODGE", "2")
                    , new XAttribute("FATIGUEPOINTS", "3")
                    , new XAttribute("HEALTH", "4")
                    , new XAttribute("HITPOINTS", "5")
                    , new XAttribute("IQ", "6")
                    , new XAttribute("MOVE", "7")
                    , new XAttribute("PERCEPTION", "8")
                    , new XAttribute("SIZEMODIFIER", "9")
                    , new XAttribute("SPEED", "10")
                    , new XAttribute("STRENGTH", "11")
                    , new XAttribute("WILL", "12")
                    , new XAttribute("WEIGHT", "13")
                    , new XAttribute("CLASSIFICATION", "14")
                    )
                );

            var result = reader.GetStats(element);

            Assert.IsInstanceOfType(result, typeof(IStats));
            Assert.AreEqual("1", result.Dexterity);
            Assert.AreEqual("2", result.Dodge);
            Assert.AreEqual("3", result.FatiguePoints);
            Assert.AreEqual("4", result.Health);
            Assert.AreEqual("5", result.HitPoints);
            Assert.AreEqual("6", result.IQ);
            Assert.AreEqual("7", result.Move);
            Assert.AreEqual("8", result.Perception);
            Assert.AreEqual("9", result.SizeModifier);
            Assert.AreEqual("10", result.Speed);
            Assert.AreEqual("11", result.Strength);
            Assert.AreEqual("12", result.Will);
            Assert.AreEqual("13", result.Weight);
            Assert.AreEqual("14", result.Classification);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetTacticsTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("TACTICS"
                    , "Monster Tactics"
                    )
                );

            var result = reader.GetTactics(element);

            Assert.AreEqual("Monster Tactics", result);
        }

        [TestMethod, TestCategory("MonsterFileReader")]
        public void GetTraitsTest()
        {
            var reader = GetMonsterFileReader();

            var element = new XElement("MONSTERINFO"
                , new XElement("TRAITS"
                    , new XElement("TRAIT"
                        , new XAttribute("NAME", "1")
                        )
                    )
                );

            var result = reader.GetTraits(element);

            Assert.IsInstanceOfType(result, typeof(List<ITrait>));
            Assert.AreEqual("1", result[0].Name);
        }

    }
}
