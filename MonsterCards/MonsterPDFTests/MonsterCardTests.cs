using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterPDF;
using System.Collections.Generic;
using MonsterLibAbstracts;
using System.Diagnostics;
using Moq;
using MonsterLibAbstracts.AttackTypes;

namespace MonsterPDFTests
{
    [TestClass]
    public class MonsterCardTests
    {
        [Ignore]
        [TestMethod, TestCategory("MonsterPDF")]
        public void CreateMonsterCards()
        {
            var pdf = new MonsterCard();
            var monsterList = new List<IMonster>();
            
            var monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateHumanoidDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateWingedHumanoidDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateArachnoidDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateWingedArachnoidDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateAvianDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateCancroidDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateWingedCancroidDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateCentaurDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateWingedCentaurDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateHexapodDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateWingedHexapodDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateIchthyoidDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateWingedIchthyoidDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateOctopodDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateWingedOctopodDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateQuadrupedDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateWingedQuadrupedDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateVermiformDRMock().Object);
            monsterList.Add(monsterMock.Object);

            monsterMock = CreateMonsterMock();
            monsterMock.SetupGet(s => s.DamageResist).Returns(CreateWingedVermiformDRMock().Object);
            monsterList.Add(monsterMock.Object);

            pdf.CreateMonsterCard(monsterList, "c:\\Users\\Patrick\\Desktop\\");

            Process.Start("c:\\Users\\Patrick\\Desktop\\MonsterCards.pdf");
        }

        private Mock<IMonster> CreateMonsterMock()
        {
            var monsterMock = new Mock<IMonster>();
            monsterMock.SetupGet(s => s.Description).Returns("Monster Description.");
            monsterMock.SetupGet(s => s.Name).Returns("Monster Name.");
            monsterMock.SetupGet(s => s.Tactics).Returns("Monster Tactics.");

            var meleeMock = new Mock<IMelee>();
            meleeMock.SetupGet(s => s.Block).Returns("B");
            meleeMock.SetupGet(s => s.Damage).Returns("D");
            meleeMock.SetupGet(s => s.DamageType).Returns("DT");
            meleeMock.SetupGet(s => s.Parry).Returns("P");
            meleeMock.SetupGet(s => s.Reach).Returns("R");
            meleeMock.SetupGet(s => s.Skill).Returns("S");
            meleeMock.SetupGet(s => s.Usage).Returns("U");
            meleeMock.SetupGet(s => s.Weapon).Returns("W");
            var meleeMock2 = new Mock<IMelee>();
            meleeMock2.SetupGet(s => s.Block).Returns("B2");
            meleeMock2.SetupGet(s => s.Damage).Returns("D2");
            meleeMock2.SetupGet(s => s.DamageType).Returns("DT2");
            meleeMock2.SetupGet(s => s.Parry).Returns("P2");
            meleeMock2.SetupGet(s => s.Reach).Returns("R2");
            meleeMock2.SetupGet(s => s.Skill).Returns("S2");
            meleeMock2.SetupGet(s => s.Usage).Returns("U2");
            meleeMock2.SetupGet(s => s.Weapon).Returns("W2");

            var rangeMock1 = new Mock<IRanged>();
            rangeMock1.SetupGet(s => s.Bulk).Returns("B");
            rangeMock1.SetupGet(s => s.Damage).Returns("D");
            rangeMock1.SetupGet(s => s.DamageType).Returns("DT");
            rangeMock1.SetupGet(s => s.HalfDmg).Returns("HD");
            rangeMock1.SetupGet(s => s.MaxRange).Returns("MR");
            rangeMock1.SetupGet(s => s.Reload).Returns("R");
            rangeMock1.SetupGet(s => s.ROF).Returns("ROF");
            rangeMock1.SetupGet(s => s.Skill).Returns("S");
            rangeMock1.SetupGet(s => s.Weapon).Returns("W");

            var spellMock1 = new Mock<ISpell>();
            spellMock1.SetupGet(s => s.Cost).Returns("C");
            spellMock1.SetupGet(s => s.Duration).Returns("D");
            spellMock1.SetupGet(s => s.Maintain).Returns("M");
            spellMock1.SetupGet(s => s.Name).Returns("N");
            spellMock1.SetupGet(s => s.Skill).Returns("S");
            spellMock1.SetupGet(s => s.TimeToCast).Returns("T");

            var attacksMock = new Mock<IAttacks>();
            attacksMock.SetupGet(s => s.Melee).Returns(new List<IMelee>() { meleeMock2.Object, meleeMock.Object });
            attacksMock.SetupGet(s => s.Ranged).Returns(new List<IRanged>() { rangeMock1.Object });
            attacksMock.SetupGet(s => s.Spell).Returns(new List<ISpell>() { spellMock1.Object });
            monsterMock.SetupGet(s => s.Attacks).Returns(attacksMock.Object);
            
            var bookMock = new Mock<IBook>();
            bookMock.SetupGet(s => s.Page).Returns("23");
            bookMock.SetupGet(s => s.Title).Returns("Book Name");
            monsterMock.SetupGet(s => s.Book).Returns(bookMock.Object);

            var dropsMock = new Mock<IDrop>();
            dropsMock.SetupGet(s => s.Name).Returns("Drop Item");
            monsterMock.SetupGet(s => s.Drops).Returns(new List<IDrop>() { dropsMock.Object });

            var habitatMock = new Mock<IHabitat>();
            habitatMock.SetupGet(s => s.Name).Returns("Habitat Item1");
            var habitatMock2 = new Mock<IHabitat>();
            habitatMock2.SetupGet(s => s.Name).Returns("Habitat Item2");
            var habitatMock3 = new Mock<IHabitat>();
            habitatMock3.SetupGet(s => s.Name).Returns("Habitat Item3");
            monsterMock.SetupGet(s => s.Habitats).Returns(new List<IHabitat>() { habitatMock2.Object, habitatMock3.Object, habitatMock.Object });

            var skillMock = new Mock<ISkill>();
            skillMock.SetupGet(s => s.Name).Returns("Skill Name");
            skillMock.SetupGet(s => s.Level).Returns("12");
            monsterMock.SetupGet(s => s.Skills).Returns(new List<ISkill>() { skillMock.Object });

            var statMock = new Mock<IStats>();
            statMock.SetupGet(s => s.Classification).Returns("CL");
            statMock.SetupGet(s => s.Dexterity).Returns("DX");
            statMock.SetupGet(s => s.Dodge).Returns("DO");
            statMock.SetupGet(s => s.FatiguePoints).Returns("FP");
            statMock.SetupGet(s => s.Health).Returns("HT");
            statMock.SetupGet(s => s.HitPoints).Returns("HP");
            statMock.SetupGet(s => s.IQ).Returns("IQ");
            statMock.SetupGet(s => s.Move).Returns("MO");
            statMock.SetupGet(s => s.Perception).Returns("PE");
            statMock.SetupGet(s => s.SizeModifier).Returns("SM");
            statMock.SetupGet(s => s.Speed).Returns("SP");
            statMock.SetupGet(s => s.Strength).Returns("ST");
            statMock.SetupGet(s => s.Weight).Returns("Weight");
            statMock.SetupGet(s => s.Will).Returns("WI");
            monsterMock.SetupGet(s => s.Stats).Returns(statMock.Object);

            var traitMock = new Mock<ITrait>();
            traitMock.SetupGet(s => s.Name).Returns("Trait Name");
            monsterMock.SetupGet(s => s.Traits).Returns(new List<ITrait>() { traitMock.Object });


            return monsterMock;
        }

        private Mock<IDamageResist> CreateHumanoidDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Humanoid);
            drMock.SetupGet(s => s.Winged).Returns(false);
            drMock.SetupGet(s => s.Arm).Returns("Ar");
            drMock.SetupGet(s => s.Foot).Returns("Fo");
            drMock.SetupGet(s => s.Hand).Returns("Ha");
            drMock.SetupGet(s => s.Head).Returns("He");
            drMock.SetupGet(s => s.Leg).Returns("Le");
            drMock.SetupGet(s => s.Tail).Returns("Ta");
            drMock.SetupGet(s => s.Torso).Returns("To");
            drMock.SetupGet(s => s.Wing).Returns("Wi");
            drMock.SetupGet(s => s.Fin).Returns("Fi");

            return drMock;
        }

        private Mock<IDamageResist> CreateWingedHumanoidDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Humanoid);
            drMock.SetupGet(s => s.Winged).Returns(true);
            drMock.SetupGet(s => s.Arm).Returns("WAr");
            drMock.SetupGet(s => s.Foot).Returns("WFo");
            drMock.SetupGet(s => s.Hand).Returns("WHa");
            drMock.SetupGet(s => s.Head).Returns("WHe");
            drMock.SetupGet(s => s.Leg).Returns("WLe");
            drMock.SetupGet(s => s.Tail).Returns("WTa");
            drMock.SetupGet(s => s.Torso).Returns("WTo");
            drMock.SetupGet(s => s.Wing).Returns("WWi");
            drMock.SetupGet(s => s.Fin).Returns("WFi");

            return drMock;
        }

        private Mock<IDamageResist> CreateArachnoidDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Arachnoid);
            drMock.SetupGet(s => s.Winged).Returns(false);
            drMock.SetupGet(s => s.Arm).Returns("Ar");
            drMock.SetupGet(s => s.Foot).Returns("Fo");
            drMock.SetupGet(s => s.Hand).Returns("Ha");
            drMock.SetupGet(s => s.Head).Returns("He");
            drMock.SetupGet(s => s.Leg).Returns("Le");
            drMock.SetupGet(s => s.Tail).Returns("Ta");
            drMock.SetupGet(s => s.Torso).Returns("To");
            drMock.SetupGet(s => s.Wing).Returns("Wi");
            drMock.SetupGet(s => s.Fin).Returns("Fi");

            return drMock;
        }

        private Mock<IDamageResist> CreateWingedArachnoidDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Arachnoid);
            drMock.SetupGet(s => s.Winged).Returns(true);
            drMock.SetupGet(s => s.Arm).Returns("WAr");
            drMock.SetupGet(s => s.Foot).Returns("WFo");
            drMock.SetupGet(s => s.Hand).Returns("WHa");
            drMock.SetupGet(s => s.Head).Returns("WHe");
            drMock.SetupGet(s => s.Leg).Returns("WLe");
            drMock.SetupGet(s => s.Tail).Returns("WTa");
            drMock.SetupGet(s => s.Torso).Returns("WTo");
            drMock.SetupGet(s => s.Wing).Returns("WWi");
            drMock.SetupGet(s => s.Fin).Returns("WFi");

            return drMock;
        }

        private Mock<IDamageResist> CreateAvianDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Avian);
            drMock.SetupGet(s => s.Winged).Returns(true);
            drMock.SetupGet(s => s.Arm).Returns("WAr");
            drMock.SetupGet(s => s.Foot).Returns("WFo");
            drMock.SetupGet(s => s.Hand).Returns("WHa");
            drMock.SetupGet(s => s.Head).Returns("WHe");
            drMock.SetupGet(s => s.Leg).Returns("WLe");
            drMock.SetupGet(s => s.Tail).Returns("WTa");
            drMock.SetupGet(s => s.Torso).Returns("WTo");
            drMock.SetupGet(s => s.Wing).Returns("WWi");
            drMock.SetupGet(s => s.Fin).Returns("WFi");

            return drMock;
        }

        private Mock<IDamageResist> CreateCancroidDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Cancroid);
            drMock.SetupGet(s => s.Winged).Returns(false);
            drMock.SetupGet(s => s.Arm).Returns("Ar");
            drMock.SetupGet(s => s.Foot).Returns("Fo");
            drMock.SetupGet(s => s.Hand).Returns("Ha");
            drMock.SetupGet(s => s.Head).Returns("He");
            drMock.SetupGet(s => s.Leg).Returns("Le");
            drMock.SetupGet(s => s.Tail).Returns("Ta");
            drMock.SetupGet(s => s.Torso).Returns("To");
            drMock.SetupGet(s => s.Wing).Returns("Wi");
            drMock.SetupGet(s => s.Fin).Returns("Fi");

            return drMock;
        }

        private Mock<IDamageResist> CreateWingedCancroidDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Cancroid);
            drMock.SetupGet(s => s.Winged).Returns(true);
            drMock.SetupGet(s => s.Arm).Returns("WAr");
            drMock.SetupGet(s => s.Foot).Returns("WFo");
            drMock.SetupGet(s => s.Hand).Returns("WHa");
            drMock.SetupGet(s => s.Head).Returns("WHe");
            drMock.SetupGet(s => s.Leg).Returns("WLe");
            drMock.SetupGet(s => s.Tail).Returns("WTa");
            drMock.SetupGet(s => s.Torso).Returns("WTo");
            drMock.SetupGet(s => s.Wing).Returns("WWi");
            drMock.SetupGet(s => s.Fin).Returns("WFi");

            return drMock;
        }

        private Mock<IDamageResist> CreateCentaurDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Centaur);
            drMock.SetupGet(s => s.Winged).Returns(false);
            drMock.SetupGet(s => s.Arm).Returns("Ar");
            drMock.SetupGet(s => s.Foot).Returns("Fo");
            drMock.SetupGet(s => s.Hand).Returns("Ha");
            drMock.SetupGet(s => s.Head).Returns("He");
            drMock.SetupGet(s => s.Leg).Returns("Le");
            drMock.SetupGet(s => s.Tail).Returns("Ta");
            drMock.SetupGet(s => s.Torso).Returns("To");
            drMock.SetupGet(s => s.Wing).Returns("Wi");
            drMock.SetupGet(s => s.Fin).Returns("Fi");

            return drMock;
        }

        private Mock<IDamageResist> CreateWingedCentaurDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Centaur);
            drMock.SetupGet(s => s.Winged).Returns(true);
            drMock.SetupGet(s => s.Arm).Returns("WAr");
            drMock.SetupGet(s => s.Foot).Returns("WFo");
            drMock.SetupGet(s => s.Hand).Returns("WHa");
            drMock.SetupGet(s => s.Head).Returns("WHe");
            drMock.SetupGet(s => s.Leg).Returns("WLe");
            drMock.SetupGet(s => s.Tail).Returns("WTa");
            drMock.SetupGet(s => s.Torso).Returns("WTo");
            drMock.SetupGet(s => s.Wing).Returns("WWi");
            drMock.SetupGet(s => s.Fin).Returns("WFi");

            return drMock;
        }

        private Mock<IDamageResist> CreateHexapodDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Hexapod);
            drMock.SetupGet(s => s.Winged).Returns(false);
            drMock.SetupGet(s => s.Arm).Returns("Ar");
            drMock.SetupGet(s => s.Foot).Returns("Fo");
            drMock.SetupGet(s => s.Hand).Returns("Ha");
            drMock.SetupGet(s => s.Head).Returns("He");
            drMock.SetupGet(s => s.Leg).Returns("Le");
            drMock.SetupGet(s => s.Tail).Returns("Ta");
            drMock.SetupGet(s => s.Torso).Returns("To");
            drMock.SetupGet(s => s.Wing).Returns("Wi");
            drMock.SetupGet(s => s.Fin).Returns("Fi");

            return drMock;
        }

        private Mock<IDamageResist> CreateWingedHexapodDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Hexapod);
            drMock.SetupGet(s => s.Winged).Returns(true);
            drMock.SetupGet(s => s.Arm).Returns("WAr");
            drMock.SetupGet(s => s.Foot).Returns("WFo");
            drMock.SetupGet(s => s.Hand).Returns("WHa");
            drMock.SetupGet(s => s.Head).Returns("WHe");
            drMock.SetupGet(s => s.Leg).Returns("WLe");
            drMock.SetupGet(s => s.Tail).Returns("WTa");
            drMock.SetupGet(s => s.Torso).Returns("WTo");
            drMock.SetupGet(s => s.Wing).Returns("WWi");
            drMock.SetupGet(s => s.Fin).Returns("WFi");

            return drMock;
        }

        private Mock<IDamageResist> CreateIchthyoidDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Ichthyoid);
            drMock.SetupGet(s => s.Winged).Returns(false);
            drMock.SetupGet(s => s.Arm).Returns("Ar");
            drMock.SetupGet(s => s.Foot).Returns("Fo");
            drMock.SetupGet(s => s.Hand).Returns("Ha");
            drMock.SetupGet(s => s.Head).Returns("He");
            drMock.SetupGet(s => s.Leg).Returns("Le");
            drMock.SetupGet(s => s.Tail).Returns("Ta");
            drMock.SetupGet(s => s.Torso).Returns("To");
            drMock.SetupGet(s => s.Wing).Returns("Wi");
            drMock.SetupGet(s => s.Fin).Returns("Fi");

            return drMock;
        }

        private Mock<IDamageResist> CreateWingedIchthyoidDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Ichthyoid);
            drMock.SetupGet(s => s.Winged).Returns(true);
            drMock.SetupGet(s => s.Arm).Returns("WAr");
            drMock.SetupGet(s => s.Foot).Returns("WFo");
            drMock.SetupGet(s => s.Hand).Returns("WHa");
            drMock.SetupGet(s => s.Head).Returns("WHe");
            drMock.SetupGet(s => s.Leg).Returns("WLe");
            drMock.SetupGet(s => s.Tail).Returns("WTa");
            drMock.SetupGet(s => s.Torso).Returns("WTo");
            drMock.SetupGet(s => s.Wing).Returns("WWi");
            drMock.SetupGet(s => s.Fin).Returns("WFi");

            return drMock;
        }

        private Mock<IDamageResist> CreateOctopodDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Octopod);
            drMock.SetupGet(s => s.Winged).Returns(false);
            drMock.SetupGet(s => s.Arm).Returns("Ar");
            drMock.SetupGet(s => s.Foot).Returns("Fo");
            drMock.SetupGet(s => s.Hand).Returns("Ha");
            drMock.SetupGet(s => s.Head).Returns("He");
            drMock.SetupGet(s => s.Leg).Returns("Le");
            drMock.SetupGet(s => s.Tail).Returns("Ta");
            drMock.SetupGet(s => s.Torso).Returns("To");
            drMock.SetupGet(s => s.Wing).Returns("Wi");
            drMock.SetupGet(s => s.Fin).Returns("Fi");

            return drMock;
        }

        private Mock<IDamageResist> CreateWingedOctopodDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Octopod);
            drMock.SetupGet(s => s.Winged).Returns(true);
            drMock.SetupGet(s => s.Arm).Returns("WAr");
            drMock.SetupGet(s => s.Foot).Returns("WFo");
            drMock.SetupGet(s => s.Hand).Returns("WHa");
            drMock.SetupGet(s => s.Head).Returns("WHe");
            drMock.SetupGet(s => s.Leg).Returns("WLe");
            drMock.SetupGet(s => s.Tail).Returns("WTa");
            drMock.SetupGet(s => s.Torso).Returns("WTo");
            drMock.SetupGet(s => s.Wing).Returns("WWi");
            drMock.SetupGet(s => s.Fin).Returns("WFi");

            return drMock;
        }

        private Mock<IDamageResist> CreateQuadrupedDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Quadruped);
            drMock.SetupGet(s => s.Winged).Returns(false);
            drMock.SetupGet(s => s.Arm).Returns("Ar");
            drMock.SetupGet(s => s.Foot).Returns("Fo");
            drMock.SetupGet(s => s.Hand).Returns("Ha");
            drMock.SetupGet(s => s.Head).Returns("He");
            drMock.SetupGet(s => s.Leg).Returns("Le");
            drMock.SetupGet(s => s.Tail).Returns("Ta");
            drMock.SetupGet(s => s.Torso).Returns("To");
            drMock.SetupGet(s => s.Wing).Returns("Wi");
            drMock.SetupGet(s => s.Fin).Returns("Fi");

            return drMock;
        }

        private Mock<IDamageResist> CreateWingedQuadrupedDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Quadruped);
            drMock.SetupGet(s => s.Winged).Returns(true);
            drMock.SetupGet(s => s.Arm).Returns("WAr");
            drMock.SetupGet(s => s.Foot).Returns("WFo");
            drMock.SetupGet(s => s.Hand).Returns("WHa");
            drMock.SetupGet(s => s.Head).Returns("WHe");
            drMock.SetupGet(s => s.Leg).Returns("WLe");
            drMock.SetupGet(s => s.Tail).Returns("WTa");
            drMock.SetupGet(s => s.Torso).Returns("WTo");
            drMock.SetupGet(s => s.Wing).Returns("WWi");
            drMock.SetupGet(s => s.Fin).Returns("WFi");

            return drMock;
        }

        private Mock<IDamageResist> CreateVermiformDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Vermiform);
            drMock.SetupGet(s => s.Winged).Returns(false);
            drMock.SetupGet(s => s.Arm).Returns("Ar");
            drMock.SetupGet(s => s.Foot).Returns("Fo");
            drMock.SetupGet(s => s.Hand).Returns("Ha");
            drMock.SetupGet(s => s.Head).Returns("He");
            drMock.SetupGet(s => s.Leg).Returns("Le");
            drMock.SetupGet(s => s.Tail).Returns("Ta");
            drMock.SetupGet(s => s.Torso).Returns("To");
            drMock.SetupGet(s => s.Wing).Returns("Wi");
            drMock.SetupGet(s => s.Fin).Returns("Fi");

            return drMock;
        }

        private Mock<IDamageResist> CreateWingedVermiformDRMock()
        {
            var drMock = new Mock<IDamageResist>();
            drMock.SetupGet(s => s.BodyType).Returns(BodyType.Vermiform);
            drMock.SetupGet(s => s.Winged).Returns(true);
            drMock.SetupGet(s => s.Arm).Returns("WAr");
            drMock.SetupGet(s => s.Foot).Returns("WFo");
            drMock.SetupGet(s => s.Hand).Returns("WHa");
            drMock.SetupGet(s => s.Head).Returns("WHe");
            drMock.SetupGet(s => s.Leg).Returns("WLe");
            drMock.SetupGet(s => s.Tail).Returns("WTa");
            drMock.SetupGet(s => s.Torso).Returns("WTo");
            drMock.SetupGet(s => s.Wing).Returns("WWi");
            drMock.SetupGet(s => s.Fin).Returns("WFi");

            return drMock;
        }

    }
}
