using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterLibAbstracts;

namespace MonsterLib
{
    public class Monster : IMonster
    {
        IBook _Book = new Book();
        IStats _Stats = new Stats();
        IDamageResist _DamageResist = new DamageResist();
        List<IHabitat> _Habitats = new List<IHabitat>();
        List<ITrait> _Traits = new List<ITrait>();
        List<ISkill> _Skills = new List<ISkill>();
        List<IDrop> _Drops = new List<IDrop>();
        IAttack _Attacks = new Attack();

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Classification { get; set; }

        public string Weight { get; set; }

        public string Tactics { get; set; }

        public IBook Book
        {
            get { return _Book; }
        }

        public IStats Stats
        {
            get { return _Stats; }
        }

        public IDamageResist DamageResist
        {
            get { return _DamageResist; }
        }

        public List<IHabitat> Habitats
        {
            get { return _Habitats; }
        }

        public List<ITrait> Traits
        {
            get { return _Traits; }
        }

        public List<ISkill> Skills
        {
            get { return _Skills; }
        }

        public List<IDrop> Drops
        {
            get { return _Drops; }
        }

        public IAttack Attacks
        {
            get { return _Attacks; }
        }

    }
}
