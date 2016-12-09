using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MonsterDAL;
using MonsterDALAbstracts;
using MonsterLibAbstracts;
using Moq;
using System.Collections.Generic;

namespace MonsterDalTests
{
    [TestClass]
    public class MonsterDataTests
    {
        [TestMethod, TestCategory("MonsterData")]
        public void LoadDataTest()
        {
            var readerMock = new Mock<IMonsterFileReader>();
            readerMock.Setup(s => s.LoadData(It.IsAny<string>())).Returns(new List<IMonster>()).Verifiable();

            var writerMock = new Mock<IMonsterFileWriter>();
            writerMock.Setup(s => s.SaveData(It.IsAny<string>(), It.IsAny<List<IMonster>>())).Verifiable();

            var monsterData = new MonsterData(readerMock.Object, writerMock.Object);

            monsterData.LoadData("..\\..\\..\\Data");

            readerMock.Verify(v => v.LoadData(It.IsAny<string>()), Times.Once);
            writerMock.Verify(v => v.SaveData(It.IsAny<string>(), It.IsAny<List<IMonster>>()), Times.Never);

        }

        [TestMethod, TestCategory("MonsterData")]
        public void SaveDataTest()
        {
            var readerMock = new Mock<IMonsterFileReader>();
            readerMock.Setup(s => s.LoadData(It.IsAny<string>())).Returns(new List<IMonster>()).Verifiable();

            var writerMock = new Mock<IMonsterFileWriter>();
            writerMock.Setup(s => s.SaveData(It.IsAny<string>(), It.IsAny<List<IMonster>>())).Verifiable();

            var monsterData = new MonsterData(readerMock.Object, writerMock.Object);

            monsterData.SaveData("..\\..\\..\\Data", new List<IMonster>());

            readerMock.Verify(v => v.LoadData(It.IsAny<string>()), Times.Never);
            writerMock.Verify(v => v.SaveData(It.IsAny<string>(), It.IsAny<List<IMonster>>()), Times.Once);

        }

    }
}
