using MonsterDALAbstracts;
using MonsterPDFAbstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MonsterLibAbstracts;
using MonsterLibAbstracts.AttackTypes;
using System.IO;

namespace MonsterCards
{
    public partial class Form1 : Form
    {
        IDataAccess<IMonster> _monsterDal;
        IDataAccess<IBook> _bookDal;
        IDataAccess<IClassification> _classDal;
        IMonsterCard _monsterCard;
        IMonsterFactory _monsterFactory;
        List<IMonster> _monsters;
        IMonster _selectedMonster;

        public Form1(IDataAccess<IMonster> monsterDal, IDataAccess<IBook> bookDal, IDataAccess<IClassification> classDal, IMonsterCard monsterCard, IMonsterFactory monsterFactory)
        {
            InitializeComponent();

            _bookDal = bookDal;
            _monsterDal = monsterDal;
            _monsterCard = monsterCard;
            _monsterFactory = monsterFactory;
            _monsters = _monsterDal.LoadData(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data"));
            _selectedMonster = _monsterFactory.GetMonsterInstance(0);
            _classDal = classDal;

            listMelee.View = View.Details;
            lstRanged.View = View.Details;
            listSpells.View = View.Details;

            UpdateForm(_selectedMonster);
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            SaveData();
        }

        public void SaveData()
        {
            _monsterDal.SaveData(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data"), _monsters);
        }

        public bool UpdateForm(IMonster monster)
        {
            UpdateDescription(monster.Description, monster.Name);
            UpdateDR(monster.DamageResist);
            UpdateBook(monster.Book);
            UpdateStats(monster.Stats, monster.Classification);
            UpdateSkills(monster.Skills);
            UpdateTactics(monster.Classification, monster.Tactics);
            UpdateTraits(monster.Traits);
            UpdateDrops(monster.Drops);
            UpdateHabitats(monster.Habitats);

            UpdateMeleeAttacks(monster.Attacks.Melee);
            UpdateRangedAttacks(monster.Attacks.Ranged);
            UpdateSpellAttacks(monster.Attacks.Spell);

            return true;
        }

        public bool ChangeMonster(IMonster monster)
        {
            _selectedMonster = monster;
            UpdateForm(_selectedMonster);
            return true;
        }
        public bool UpdateDescription(string description, string name)
        {
            this.txtDescription.Text = description;
            this.txtName.Text = name;
            return true;
        }

        public bool UpdateBook(IBook book)
        {
            if (book != null)
            {
                if(string.IsNullOrWhiteSpace(book.Page))
                {
                    this.txtBook.Text = book.Title;
                }
                else
                {
                    this.txtBook.Text = book.Title + " pg. " + book.Page;
                }

            }
            return true;
        }

        public bool UpdateDR(IDamageResist DamageResist)
        {
            if (DamageResist != null)
            {
                if (DamageResist.Winged && DamageResist.BodyType != BodyType.Avian)
                {
                    this.txtBodyType.Text = "Winged " + DamageResist.BodyType.ToString();
                }
                else
                {
                    this.txtBodyType.Text = DamageResist.BodyType.ToString();
                }

                this.txtDRArms.Text = DamageResist.Arm;
                this.txtDRFeet.Text = DamageResist.Foot;
                this.txtDRFins.Text = DamageResist.Fin;
                this.txtDRHands.Text = DamageResist.Hand;
                this.txtDRHead.Text = DamageResist.Head;
                this.txtDRLegs.Text = DamageResist.Leg;
                this.txtDRTail.Text = DamageResist.Tail;
                this.txtDRTorso.Text = DamageResist.Torso;
                this.txtDRWings.Text = DamageResist.Wing;
            }
            return true;
        }

        public bool UpdateStats(IStats Stats, IClassification Classification)
        {
            if (Stats != null)
            {
                this.txtDodge.Text = Stats.Dodge;
                this.txtDX.Text = Stats.Dexterity;
                this.txtFP.Text = Stats.FatiguePoints;
                this.txtHeight.Text = Stats.Height;
                this.txtHP.Text = Stats.HitPoints;
                this.txtHT.Text = Stats.Health;
                this.txtIQ.Text = Stats.IQ;
                this.txtMove.Text = Stats.Move;
                this.txtPer.Text = Stats.Perception;
                this.txtSM.Text = Stats.SizeModifier;
                this.txtSpeed.Text = Stats.Speed;
                this.txtST.Text = Stats.Strength;
                this.txtWeight.Text = Stats.Weight;
                this.txtWill.Text = Stats.Will;
            }

            this.txtClass.Text = Classification.Name;

            return true;
        }

        public bool UpdateSkills(List<ISkill> Skills)
        {
            if (Skills != null)
            {
                var itemList = new StringBuilder();
                var divider = "";
                foreach (var item in Skills)
                {
                    itemList.AppendFormat("{0}{1}:{2}", divider, item.Name, item.Level);
                    divider = ", ";
                }

                this.txtSkills.Text = itemList.ToString();
            }
            return true;
        }

        public bool UpdateTactics(IClassification Classificiation, List<ITactic> Tactics)
        {
            this.txtTactics.Text = Classificiation.Description;
            if (Tactics != null)
            {
                var itemList = new StringBuilder();
                var divider = "\r\n";
                foreach (var item in Tactics.OrderBy(x => x.Order))
                {
                    itemList.AppendFormat("{0}{1}", divider, item.Text);
                }

                this.txtTactics.Text += itemList.ToString();
            }
            return true;
        }

        public bool UpdateTraits(List<ITrait> Traits)
        {
            if (Traits != null)
            {
                var itemList = new StringBuilder();
                var divider = "";
                foreach (var item in Traits)
                {
                    itemList.AppendFormat("{0}{1}", divider, item.Name);
                    divider = ", ";
                }

                this.txtTraits.Text = itemList.ToString();
            }
            return true;
        }

        public bool UpdateDrops(List<IDrop> Drops)
        {
            if (Drops != null)
            {
                var itemList = new StringBuilder();
                var divider = "";
                foreach (var item in Drops)
                {
                    itemList.AppendFormat("{0}{1}", divider, item.Name);
                    divider = ", ";
                }

                this.txtDrops.Text = itemList.ToString();
            }
            return true;
        }

        public bool UpdateHabitats(List<IHabitat> Habitats)
        {
            if (Habitats != null)
            {
                var itemList = new StringBuilder();
                var divider = "";
                foreach (var item in Habitats)
                {
                    itemList.AppendFormat("{0}{1}", divider, item.Name);
                    divider = ", ";
                }

                this.txtHabitat.Text = itemList.ToString();
            }
            return true;
        }

        public bool UpdateMeleeAttacks(List<IMelee> Melees)
        {
            listMelee.Items.Clear();

            foreach(var item in Melees)
            {
                var listItem = new ListViewItem(new[] { item.Weapon, item.Usage, item.Skill, item.Parry, item.Block, item.Damage, item.DamageType, item.Reach});
                listMelee.Items.Add(listItem);
            }
            return true;
        }

        public bool UpdateRangedAttacks(List<IRanged> Ranged)
        {
            lstRanged.Items.Clear();

            foreach (var item in Ranged)
            {
                var listItem = new ListViewItem(new[] { item.Weapon, item.ROF, item.Reload, item.Skill, item.Damage, item.DamageType, item.HalfDmg, item.MaxRange, item.Bulk });
                lstRanged.Items.Add(listItem);
            }
            return true;
        }

        public bool UpdateSpellAttacks(List<ISpell> Spells)
        {
            listSpells.Items.Clear();

            foreach (var item in Spells)
            {
                var listItem = new ListViewItem(new[] { item.Name, item.Skill, item.Cost, item.TimeToCast, item.Duration, item.Maintain });
                listSpells.Items.Add(listItem);
            }
            return true;
        }

        private void selectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new MonsterList(ChangeMonster, UpdateForm, _monsters, _selectedMonster);
            subForm.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            _selectedMonster = _monsterFactory.GetMonsterInstance(0);
            UpdateForm(_selectedMonster);
        }

        private void descriptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new Description(UpdateDescription, UpdateBook, _selectedMonster, _bookDal);
            subForm.ShowDialog();

        }

        private void attributesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new Attributes(UpdateStats, UpdateTactics, _selectedMonster, _classDal);
            subForm.ShowDialog();
        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void dRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new DRConfig(UpdateDR, _selectedMonster.DamageResist);
            subForm.ShowDialog();
        }

    }
}
