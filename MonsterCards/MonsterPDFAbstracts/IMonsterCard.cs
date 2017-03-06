using System;
using System.Collections.Generic;
using MonsterLibAbstracts;

namespace MonsterPDFAbstracts
{
    public interface IMonsterCard
    {
        void CreateMonsterCard(List<IMonster> monsterInfoList, string path);
    }
}
