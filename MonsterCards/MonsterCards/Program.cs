using Microsoft.Practices.Unity;
using MonsterDAL;
using MonsterDALAbstracts;
using MonsterLib;
using MonsterLib.AttackTypes;
using MonsterLibAbstracts;
using MonsterLibAbstracts.AttackTypes;
using MonsterPDF;
using MonsterPDFAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterCards
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var container = BuildUnityContainer();

            var startform = container.Resolve<Form>("Form1");
            Application.Run(startform);
        }

        public static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<Form, Form1>("Form1");

            currentContainer.RegisterType<IDataAccess<IMonster>, MonsterData>();
            currentContainer.RegisterType<IFileReader<IMonster>, MonsterFileReader>();
            currentContainer.RegisterType<IFileWriter<IMonster>, MonsterFileWriter>();

            currentContainer.RegisterType<IDataAccess<IBook>, BookData>();
            currentContainer.RegisterType<IFileReader<IBook>, BookFileReader>();
            currentContainer.RegisterType<IFileWriter<IBook>, BookFileWriter>();

            currentContainer.RegisterType<IDataAccess<IClassification>, ClassificationData>();
            currentContainer.RegisterType<IFileReader<IClassification>, ClassificationFileReader>();
            currentContainer.RegisterType<IFileWriter<IClassification>, ClassificationFileWriter>();

            currentContainer.RegisterType<IMonsterCard, MonsterCard>();

            currentContainer.RegisterType<IAttacks, Attacks>();
            currentContainer.RegisterType<IBook, Book>();
            currentContainer.RegisterType<IDamageResist, DamageResist>();
            currentContainer.RegisterType<IDrop, Drop>();
            currentContainer.RegisterType<IHabitat, Habitat>();
            currentContainer.RegisterType<IMonster, Monster>();
            currentContainer.RegisterType<IMonsterFactory, MonsterFactory>();
            currentContainer.RegisterType<ISkill, Skill>();
            currentContainer.RegisterType<IStats, Stats>();
            currentContainer.RegisterType<ITrait, Trait>();
            currentContainer.RegisterType<IMelee, Melee>();
            currentContainer.RegisterType<IRanged, Ranged>();
            currentContainer.RegisterType<ISpell, Spell>();
            
            return currentContainer;
        }
    }
}
