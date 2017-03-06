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
        IClassification _Classification = new Classification();
        IStats _Stats = new Stats();
        IDamageResist _DamageResist = new DamageResist();
        List<IHabitat> _Habitats = new List<IHabitat>();
        List<ITrait> _Traits = new List<ITrait>();
        List<ISkill> _Skills = new List<ISkill>();
        List<IDrop> _Drops = new List<IDrop>();
        List<ITactic> _Tactics = new List<ITactic>();
        IAttacks _Attacks = new Attacks();

        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<ITactic> Tactics 
        {
            get { return _Tactics; }
            set { _Tactics = value; }
        }

        public IBook Book
        {
            get { return _Book; }
            set { _Book = value; }
        }

        public IClassification Classification
        {
            get { return _Classification; }
            set { _Classification = value; }
        }

        public IStats Stats
        {
            get { return _Stats; }
            set { _Stats = value; }
        }

        public IDamageResist DamageResist
        {
            get { return _DamageResist; }
            set { _DamageResist = value; }
        }

        public List<IHabitat> Habitats
        {
            get { return _Habitats; }
            set { _Habitats = value; }
        }

        public List<ITrait> Traits
        {
            get { return _Traits; }
            set { _Traits = value; }
        }

        public List<ISkill> Skills
        {
            get { return _Skills; }
            set { _Skills = value; }
        }

        public List<IDrop> Drops
        {
            get { return _Drops; }
            set { _Drops = value; }
        }

        public IAttacks Attacks
        {
            get { return _Attacks; }
            set { _Attacks = value; }
        }

    }
}
