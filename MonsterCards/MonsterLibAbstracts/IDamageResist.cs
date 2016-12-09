using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibAbstracts
{
    public interface IDamageResist
    {
        string Head { get; set; }
        string Torso { get; set; }
        string Arm { get; set; }
        string Hand { get; set; }
        string Leg { get; set; }
        string Foot { get; set; }
        string Wing { get; set; }
        string Tail { get; set; }
    }
}
