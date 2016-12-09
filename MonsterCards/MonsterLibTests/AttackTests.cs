using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterLib;
using System.Collections.Generic;
using MonsterLibAbstracts.AttackTypes;

namespace MonsterLibTests
{
    [TestClass]
    public class AttackTests
    {
        [TestMethod, TestCategory("Attack")]
        public void CreationMeleeNotNull()
        {
            var attack = new Attacks();

            Assert.IsNotNull(attack.Melee);
            Assert.IsInstanceOfType(attack.Melee, typeof(List<IMelee>));
        }

        [TestMethod, TestCategory("Attack")]
        public void CreationRangedNotNull()
        {
            var attack = new Attacks();

            Assert.IsNotNull(attack.Ranged);
            Assert.IsInstanceOfType(attack.Ranged, typeof(List<IRanged>));
        }

        [TestMethod, TestCategory("Attack")]
        public void CreationSpellNotNull()
        {
            var attack = new Attacks();

            Assert.IsNotNull(attack.Spell);
            Assert.IsInstanceOfType(attack.Spell, typeof(List<ISpell>));
        }
    }
}
