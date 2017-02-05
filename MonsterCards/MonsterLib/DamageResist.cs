using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterLibAbstracts;

namespace MonsterLib
{
    public class DamageResist: IDamageResist
    {
        public string Head { get; set; }

        public string Torso { get; set; }

        public string Arm { get; set; }

        public string Hand { get; set; }

        public string Leg { get; set; }

        public string Foot { get; set; }

        public string Wing { get; set; }

        public string Tail { get; set; }

        public BodyType BodyType { get; set; }

        public bool Winged { get; set; }

        public string Fin { get; set; }
    }
}
