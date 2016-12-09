using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonsterLibAbstracts;

namespace MonsterLib
{
    public class Book: IBook
    {
        public string Title { get; set; }

        public string Page { get; set; }
    }
}
