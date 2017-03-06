using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterDAL;
using MonsterLibAbstracts;
using Moq;
using System.Collections.Generic;
using MonsterLibAbstracts.AttackTypes;

namespace MonsterDalTests
{
    [TestClass]
    public class MonsterFileWriterTests
    {

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildInfoTest()
        {
            var writer = new MonsterFileWriter();

            var elementMock = new Mock<IMonster>();
            elementMock.SetupGet(g => g.ID).Returns(1);
            elementMock.SetupGet(g => g.Name).Returns("Monster Name");


            var result = writer.BuildInfo(elementMock.Object);

            Assert.AreEqual("<MONSTERINFO ID=\"1\" NAME=\"Monster Name\" />", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildDescriptionTest()
        {
            var writer = new MonsterFileWriter();

            var result = writer.BuildDescription("This is a description.");

            Assert.AreEqual("<DESCRIPTION>This is a description.</DESCRIPTION>", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildTacticsTest()
        {
            //var writer = new MonsterFileWriter();

            //var result = writer.BuildTactics("This is a tactic.");

            //Assert.AreEqual("<TACTICS>This is a tactic.</TACTICS>", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildBookTest()
        {
            var writer = new MonsterFileWriter();

            var elementMock = new Mock<IBook>();
            elementMock.SetupGet(g => g.Title).Returns("Book Title");
            elementMock.SetupGet(g => g.Page).Returns("23");

            var result = writer.BuildBook(elementMock.Object);

            Assert.AreEqual("<BOOK TITLE=\"Book Title\" PAGE=\"23\" />", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildDRsTest()
        {
            var writer = new MonsterFileWriter();

            var elementMock = new Mock<IDamageResist>();
            elementMock.SetupGet(g => g.Arm).Returns("1");
            elementMock.SetupGet(g => g.Foot).Returns("2");
            elementMock.SetupGet(g => g.Hand).Returns("3");
            elementMock.SetupGet(g => g.Head).Returns("4");
            elementMock.SetupGet(g => g.Leg).Returns("5");
            elementMock.SetupGet(g => g.Tail).Returns("6");
            elementMock.SetupGet(g => g.Torso).Returns("7");
            elementMock.SetupGet(g => g.Wing).Returns("8");

            var result = writer.BuildDRs(elementMock.Object);

            Assert.AreEqual("<DAMAGERESISTANCE ARM=\"1\" FOOT=\"2\" HAND=\"3\" HEAD=\"4\" LEG=\"5\" TAIL=\"6\" TORSO=\"7\" WING=\"8\" />", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildDropsTest()
        {
            var writer = new MonsterFileWriter();

            var elementList = new List<IDrop>();
            var elementMock = new Mock<IDrop>();
            elementMock.SetupGet(g => g.Name).Returns("1");
            elementList.Add(elementMock.Object);

            elementMock = new Mock<IDrop>();
            elementMock.SetupGet(g => g.Name).Returns("2");
            elementList.Add(elementMock.Object);

            var result = writer.BuildDrops(elementList);

            Assert.AreEqual("<DROPS>\r\n  <DROP NAME=\"1\" />\r\n  <DROP NAME=\"2\" />\r\n</DROPS>", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildHabitatsTest()
        {
            var writer = new MonsterFileWriter();

            var elementList = new List<IHabitat>();
            var elementMock = new Mock<IHabitat>();
            elementMock.SetupGet(g => g.Name).Returns("1");
            elementList.Add(elementMock.Object);

            elementMock = new Mock<IHabitat>();
            elementMock.SetupGet(g => g.Name).Returns("2");
            elementList.Add(elementMock.Object);

            var result = writer.BuildHabitats(elementList);

            Assert.AreEqual("<HABITATS>\r\n  <HABITAT NAME=\"1\" />\r\n  <HABITAT NAME=\"2\" />\r\n</HABITATS>", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildSkillsTest()
        {
            var writer = new MonsterFileWriter();

            var elementList = new List<ISkill>();
            var elementMock = new Mock<ISkill>();
            elementMock.SetupGet(g => g.Name).Returns("1");
            elementList.Add(elementMock.Object);

            elementMock = new Mock<ISkill>();
            elementMock.SetupGet(g => g.Name).Returns("2");
            elementList.Add(elementMock.Object);

            var result = writer.BuildSkills(elementList);

            Assert.AreEqual("<SKILLS>\r\n  <SKILL NAME=\"1\" />\r\n  <SKILL NAME=\"2\" />\r\n</SKILLS>", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildTraitsTest()
        {
            var writer = new MonsterFileWriter();

            var elementList = new List<ITrait>();
            var elementMock = new Mock<ITrait>();
            elementMock.SetupGet(g => g.Name).Returns("1");
            elementList.Add(elementMock.Object);

            elementMock = new Mock<ITrait>();
            elementMock.SetupGet(g => g.Name).Returns("2");
            elementList.Add(elementMock.Object);

            var result = writer.BuildTraits(elementList);

            Assert.AreEqual("<TRAITS>\r\n  <TRAIT NAME=\"1\" />\r\n  <TRAIT NAME=\"2\" />\r\n</TRAITS>", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildStatsTest()
        {
            var writer = new MonsterFileWriter();

            var elementMock = new Mock<IStats>();
            elementMock.SetupGet(g => g.Dexterity).Returns("2");
            elementMock.SetupGet(g => g.Dodge).Returns("3");
            elementMock.SetupGet(g => g.FatiguePoints).Returns("4");
            elementMock.SetupGet(g => g.Health).Returns("5");
            elementMock.SetupGet(g => g.HitPoints).Returns("6");
            elementMock.SetupGet(g => g.IQ).Returns("7");
            elementMock.SetupGet(g => g.Move).Returns("8");
            elementMock.SetupGet(g => g.Perception).Returns("9");
            elementMock.SetupGet(g => g.SizeModifier).Returns("10");
            elementMock.SetupGet(g => g.Speed).Returns("11");
            elementMock.SetupGet(g => g.Strength).Returns("12");
            elementMock.SetupGet(g => g.Weight).Returns("13");
            elementMock.SetupGet(g => g.Will).Returns("14");

            var result = writer.BuildStats(elementMock.Object);

            Assert.AreEqual("<STATS DEXTERITY=\"2\" DODGE=\"3\" FATIGUEPOINTS=\"4\" HEALTH=\"5\" HITPOINTS=\"6\" IQ=\"7\" MOVE=\"8\" PERCEPTION=\"9\" SIZEMODIFIER=\"10\" SPEED=\"11\" STRENGTH=\"12\" WILL=\"14\" WEIGHT=\"13\" />", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildAttacksTest()
        {
            var writer = new MonsterFileWriter();

            var elementMock = new Mock<IAttacks>();
            elementMock.SetupGet(g => g.Melee).Returns(new List<IMelee>());
            elementMock.SetupGet(g => g.Ranged).Returns(new List<IRanged>());
            elementMock.SetupGet(g => g.Spell).Returns(new List<ISpell>());

            var result = writer.BuildAttacks(elementMock.Object);

            Assert.AreEqual("<ATTACKS>\r\n  <MELEEATTACKS />\r\n  <RANGEDATTACKS />\r\n  <SPELLATTACKS />\r\n</ATTACKS>", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildMeleeAttacksTest()
        {
            var writer = new MonsterFileWriter();

            var elementList = new List<IMelee>();
            var elementMock = new Mock<IMelee>();
            elementMock.SetupGet(g => g.Block).Returns("Block1");
            elementMock.SetupGet(g => g.Damage).Returns("Damage1");
            elementMock.SetupGet(g => g.DamageType).Returns("DamageType1");
            elementMock.SetupGet(g => g.Parry).Returns("Parry1");
            elementMock.SetupGet(g => g.Reach).Returns("Reach1");
            elementMock.SetupGet(g => g.Skill).Returns("Skill1");
            elementMock.SetupGet(g => g.Usage).Returns("Usage1");
            elementMock.SetupGet(g => g.Weapon).Returns("Weapon1");
            elementList.Add(elementMock.Object);

            elementMock = new Mock<IMelee>();
            elementMock.SetupGet(g => g.Block).Returns("Block2");
            elementMock.SetupGet(g => g.Damage).Returns("Damage2");
            elementMock.SetupGet(g => g.DamageType).Returns("DamageType2");
            elementMock.SetupGet(g => g.Parry).Returns("Parry2");
            elementMock.SetupGet(g => g.Reach).Returns("Reach2");
            elementMock.SetupGet(g => g.Skill).Returns("Skill2");
            elementMock.SetupGet(g => g.Usage).Returns("Usage2");
            elementMock.SetupGet(g => g.Weapon).Returns("Weapon2");
            elementList.Add(elementMock.Object);

            var result = writer.BuildMeleeAttacks(elementList);

            Assert.AreEqual("<MELEEATTACKS>\r\n  <MELEEATTACK WEAPON=\"Weapon1\" USAGE=\"Usage1\" SKILL=\"Skill1\" BLOCK=\"Block1\" DAMAGE=\"Damage1\" DAMAGETYPE=\"DamageType1\" PARRY=\"Parry1\" REACH=\"Reach1\" />\r\n  <MELEEATTACK WEAPON=\"Weapon2\" USAGE=\"Usage2\" SKILL=\"Skill2\" BLOCK=\"Block2\" DAMAGE=\"Damage2\" DAMAGETYPE=\"DamageType2\" PARRY=\"Parry2\" REACH=\"Reach2\" />\r\n</MELEEATTACKS>", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildRangedAttacksTest()
        {
            var writer = new MonsterFileWriter();

            var elementList = new List<IRanged>();
            var elementMock = new Mock<IRanged>();
            elementMock.SetupGet(g => g.Bulk).Returns("Bulk1");
            elementMock.SetupGet(g => g.Damage).Returns("Damage1");
            elementMock.SetupGet(g => g.DamageType).Returns("DamageType1");
            elementMock.SetupGet(g => g.HalfDmg).Returns("HalfDmg1");
            elementMock.SetupGet(g => g.MaxRange).Returns("MaxRange1");
            elementMock.SetupGet(g => g.Reload).Returns("Reload1");
            elementMock.SetupGet(g => g.ROF).Returns("ROF1");
            elementMock.SetupGet(g => g.Skill).Returns("Skill1");
            elementMock.SetupGet(g => g.Weapon).Returns("Weapon1");
            elementList.Add(elementMock.Object);

            elementMock = new Mock<IRanged>();
            elementMock.SetupGet(g => g.Bulk).Returns("Bulk2");
            elementMock.SetupGet(g => g.Damage).Returns("Damage2");
            elementMock.SetupGet(g => g.DamageType).Returns("DamageType2");
            elementMock.SetupGet(g => g.HalfDmg).Returns("HalfDmg2");
            elementMock.SetupGet(g => g.MaxRange).Returns("MaxRange2");
            elementMock.SetupGet(g => g.Reload).Returns("Reload2");
            elementMock.SetupGet(g => g.ROF).Returns("ROF2");
            elementMock.SetupGet(g => g.Skill).Returns("Skill2");
            elementMock.SetupGet(g => g.Weapon).Returns("Weapon2");
            elementList.Add(elementMock.Object);

            var result = writer.BuildRangedAttacks(elementList);

            Assert.AreEqual("<RANGEDATTACKS>\r\n  <RANGEDATTACK WEAPON=\"Weapon1\" SKILL=\"Skill1\" BULK=\"Bulk1\" DAMAGE=\"Damage1\" DAMAGETYPE=\"DamageType1\" HALFDAMAGE=\"HalfDmg1\" MAXRANGE=\"MaxRange1\" RELOAD=\"Reload1\" ROF=\"ROF1\" />\r\n  <RANGEDATTACK WEAPON=\"Weapon2\" SKILL=\"Skill2\" BULK=\"Bulk2\" DAMAGE=\"Damage2\" DAMAGETYPE=\"DamageType2\" HALFDAMAGE=\"HalfDmg2\" MAXRANGE=\"MaxRange2\" RELOAD=\"Reload2\" ROF=\"ROF2\" />\r\n</RANGEDATTACKS>", result.ToString());
        }

        [TestMethod, TestCategory("MonsterFileWriter")]
        public void BuildSpellAttacksTest()
        {
            var writer = new MonsterFileWriter();

            var elementList = new List<ISpell>();
            var elementMock = new Mock<ISpell>();
            elementMock.SetupGet(g => g.Cost).Returns("Cost1");
            elementMock.SetupGet(g => g.Duration).Returns("Duration1");
            elementMock.SetupGet(g => g.Maintain).Returns("Maintain1");
            elementMock.SetupGet(g => g.Name).Returns("Name1");
            elementMock.SetupGet(g => g.Skill).Returns("Skill1");
            elementMock.SetupGet(g => g.TimeToCast).Returns("TimeToCast1");
            elementList.Add(elementMock.Object);

            elementMock = new Mock<ISpell>();
            elementMock.SetupGet(g => g.Cost).Returns("Cost2");
            elementMock.SetupGet(g => g.Duration).Returns("Duration2");
            elementMock.SetupGet(g => g.Maintain).Returns("Maintain2");
            elementMock.SetupGet(g => g.Name).Returns("Name2");
            elementMock.SetupGet(g => g.Skill).Returns("Skill2");
            elementMock.SetupGet(g => g.TimeToCast).Returns("TimeToCast2");
            elementList.Add(elementMock.Object);

            var result = writer.BuildSpellAttacks(elementList);

            Assert.AreEqual("<SPELLATTACKS>\r\n  <SPELLATTACK NAME=\"Name1\" SKILL=\"Skill1\" COST=\"Cost1\" DURATION=\"Duration1\" MAINTAIN=\"Maintain1\" TIMETOCAST=\"TimeToCast1\" />\r\n  <SPELLATTACK NAME=\"Name2\" SKILL=\"Skill2\" COST=\"Cost2\" DURATION=\"Duration2\" MAINTAIN=\"Maintain2\" TIMETOCAST=\"TimeToCast2\" />\r\n</SPELLATTACKS>", result.ToString());
        }
    }
}
