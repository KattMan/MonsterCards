using MonsterLibAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLib
{
    public class Tactic: ITactic
    {
        public int Order { get; set; }

        public string Text { get; set; }
    }
}
