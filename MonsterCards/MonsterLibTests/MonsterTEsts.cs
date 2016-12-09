using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterLib;
using MonsterLibAbstracts;
using System.Collections.Generic;

namespace MonsterLibTests
{
    [TestClass]
    public class MonsterTests
    {
        [TestMethod, TestCategory("Monster")]
        public void CreationBookNotNull()
        {
            var monster = new Monster();

            Assert.IsNotNull(monster.Book);
            Assert.IsInstanceOfType(monster.Book, typeof(Book));
        }

        [TestMethod, TestCategory("Monster")]
        public void CreationStatsNotNull()
        {
            var monster = new Monster();

            Assert.IsNotNull(monster.Stats);
            Assert.IsInstanceOfType(monster.Stats, typeof(Stats));
        }

        [TestMethod, TestCategory("Monster")]
        public void CreationDamageResistNotNull()
        {
            var monster = new Monster();

            Assert.IsNotNull(monster.DamageResist);
            Assert.IsInstanceOfType(monster.DamageResist, typeof(DamageResist));
        }

        [TestMethod, TestCategory("Monster")]
        public void CreationHabitatsNotNull()
        {
            var monster = new Monster();

            Assert.IsNotNull(monster.Habitats);
            Assert.IsInstanceOfType(monster.Habitats, typeof(List<IHabitat>));
        }

        [TestMethod, TestCategory("Monster")]
        public void CreationTraitsNotNull()
        {
            var monster = new Monster();

            Assert.IsNotNull(monster.Traits);
            Assert.IsInstanceOfType(monster.Traits, typeof(List<ITrait>));
        }

        [TestMethod, TestCategory("Monster")]
        public void CreationSkillsNotNull()
        {
            var monster = new Monster();

            Assert.IsNotNull(monster.Skills);
            Assert.IsInstanceOfType(monster.Skills, typeof(List<ISkill>));
        }

        [TestMethod, TestCategory("Monster")]
        public void CreationDropsNotNull()
        {
            var monster = new Monster();

            Assert.IsNotNull(monster.Drops);
            Assert.IsInstanceOfType(monster.Drops, typeof(List<IDrop>));
        }

        [TestMethod, TestCategory("Monster")]
        public void CreationAttacksNotNull()
        {
            var monster = new Monster();

            Assert.IsNotNull(monster.Attacks);
            Assert.IsInstanceOfType(monster.Attacks, typeof(IAttacks));
        }

    }
}
