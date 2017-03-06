using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonsterLibAbstracts
{
    public interface ITactic
    {
        int Order { get; set; }
        string Text { get; set; }
    }
}
