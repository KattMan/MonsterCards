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
using MonsterPDFAbstracts;

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
            _classDal = classDal;

            _selectedMonster = _monsterFactory.GetMonsterInstance(0);
            _selectedMonster.Name = string.Empty;
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

        private void PaintList(ListView listView)
        {
            listView.BackColor = Color.Cornsilk;

            foreach (ListViewItem item in listView.Items)
            {
                if (item.Index % 2 != 0)
                {
                    item.BackColor = Color.Cornsilk;
                }
                else
                {
                    item.BackColor = Color.BlanchedAlmond;
                }

            }
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
                    itemList.AppendFormat("{0}{1}", divider, item.ToString());
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

            PaintList(listMelee);

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
            PaintList(lstRanged);

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
            PaintList(listSpells);

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
            var newID = _monsters.Max(m => m.ID) + 1;
            _selectedMonster = _monsterFactory.GetMonsterInstance(newID);
            _monsters.Add(_selectedMonster);
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

        private void habitatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new Habitats(UpdateHabitats, _selectedMonster.Habitats, _monsterFactory);
            subForm.ShowDialog();
        }

        private void dropsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new Drops(UpdateDrops, _selectedMonster.Drops, _monsterFactory);
            subForm.ShowDialog();
        }

        private void skillsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new Skills(UpdateSkills, _selectedMonster.Skills, _monsterFactory);
            subForm.ShowDialog();
        }

        private void traitsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new Traits(UpdateTraits, _selectedMonster.Traits, _monsterFactory);
            subForm.ShowDialog();
        }

        private void tacticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new Tactics(UpdateTactics, _selectedMonster.Classification, _selectedMonster.Tactics, _monsterFactory);
            subForm.ShowDialog();
        }

        private void meleeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new MeleeAttacks(UpdateMeleeAttacks, _selectedMonster.Attacks.Melee, _monsterFactory);
            subForm.ShowDialog();
        }

        private void rangedToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new RangedAttacks(UpdateRangedAttacks, _selectedMonster.Attacks.Ranged, _monsterFactory);
            subForm.ShowDialog();
        }

        private void spellsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new SpellAttacks(UpdateSpellAttacks, _selectedMonster.Attacks.Spell, _monsterFactory);
            subForm.ShowDialog();
        }

        private void pDFToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new PDFExporter(_monsters, _monsterCard, _bookDal);
            subForm.ShowDialog();

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveData();
        }

        private void cloneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var newID = _monsters.Max(m => m.ID) + 1;
            var newMonster = _monsterFactory.GetMonsterInstance(newID);

            newMonster.Description = _selectedMonster.Description;
            newMonster.Name = _selectedMonster.Name + "(2)";

            CloneAttacks(newMonster);
            CloneBook(newMonster);
            CloneClassification(newMonster);
            CloneDR(newMonster);
            CloneDrops(newMonster);
            CloneHabitats(newMonster);
            CloneSkills(newMonster);
            CloneStats(newMonster);
            CloneTactics(newMonster);
            CloneTraits(newMonster);

            _selectedMonster = newMonster;

            _monsters.Add(_selectedMonster);
            UpdateForm(_selectedMonster);
        }

        private void CloneAttacks(IMonster newMonster)
        {
            foreach(var meleeAttack in _selectedMonster.Attacks.Melee)
            {
                var attack = _monsterFactory.GetMeleeInstance();
                attack.Block = meleeAttack.Block;
                attack.Damage = meleeAttack.Damage;
                attack.DamageType = meleeAttack.DamageType;
                attack.Parry = meleeAttack.Parry;
                attack.Reach = meleeAttack.Reach;
                attack.Skill = meleeAttack.Skill;
                attack.Usage = meleeAttack.Usage;
                attack.Weapon = meleeAttack.Weapon;

                newMonster.Attacks.Melee.Add(attack);
            }

            foreach (var rangeAttack in _selectedMonster.Attacks.Ranged)
            {
                var attack = _monsterFactory.GetRangedInstance();
                attack.Bulk = rangeAttack.Bulk;
                attack.Damage = rangeAttack.Damage;
                attack.DamageType = rangeAttack.DamageType;
                attack.HalfDmg = rangeAttack.HalfDmg;
                attack.MaxRange = rangeAttack.MaxRange;
                attack.Reload = rangeAttack.Reload;
                attack.ROF = rangeAttack.ROF;
                attack.Skill = rangeAttack.Skill;
                attack.Weapon = rangeAttack.Weapon;

                newMonster.Attacks.Ranged.Add(attack);
            }

            foreach (var spellAttack in _selectedMonster.Attacks.Spell)
            {
                var attack = _monsterFactory.GetSpellInstance();
                attack.Cost = spellAttack.Cost;
                attack.Duration = spellAttack.Duration;
                attack.Maintain = spellAttack.Maintain;
                attack.Name = spellAttack.Name;
                attack.Skill = spellAttack.Skill;
                attack.TimeToCast = spellAttack.TimeToCast;

                newMonster.Attacks.Spell.Add(attack);
            }
        }
        private void CloneBook(IMonster newMonster)
        {
            newMonster.Book = _monsterFactory.GetBookInstance();

            newMonster.Book.Page = _selectedMonster.Book.Page;
            newMonster.Book.Title = _selectedMonster.Book.Title;
        }
        private void CloneClassification(IMonster newMonster)
        {
            newMonster.Classification = _monsterFactory.GetClassificationInstance();

            newMonster.Classification.Description = _selectedMonster.Classification.Description;
            newMonster.Classification.Name = _selectedMonster.Classification.Name;
        }
        private void CloneDR(IMonster newMonster)
        {
            newMonster.DamageResist = _monsterFactory.GetDRInstance();

            newMonster.DamageResist.Arm = _selectedMonster.DamageResist.Arm;
            newMonster.DamageResist.Fin = _selectedMonster.DamageResist.Fin;
            newMonster.DamageResist.Foot = _selectedMonster.DamageResist.Foot;
            newMonster.DamageResist.Hand = _selectedMonster.DamageResist.Hand;
            newMonster.DamageResist.Head = _selectedMonster.DamageResist.Head;
            newMonster.DamageResist.Leg = _selectedMonster.DamageResist.Leg;
            newMonster.DamageResist.Tail = _selectedMonster.DamageResist.Tail;
            newMonster.DamageResist.Torso = _selectedMonster.DamageResist.Torso;
            newMonster.DamageResist.Wing = _selectedMonster.DamageResist.Wing;
            newMonster.DamageResist.Winged = _selectedMonster.DamageResist.Winged;

            newMonster.DamageResist.BodyType = _selectedMonster.DamageResist.BodyType;

        }
        private void CloneDrops(IMonster newMonster)
        {
            foreach(var drop in _selectedMonster.Drops)
            {
                var newDrop = _monsterFactory.GetDropInstance();

                newDrop.Name = drop.Name;
                newMonster.Drops.Add(newDrop);
            }
        }
        private void CloneHabitats(IMonster newMonster)
        {
            foreach(var habitat in _selectedMonster.Habitats)
            {
                var newHabitat = _monsterFactory.GetHabitatInstance();

                newHabitat.Name = habitat.Name;
                newMonster.Habitats.Add(newHabitat);
            }
        }
        private void CloneSkills(IMonster newMonster)
        {
            foreach(var skill in _selectedMonster.Skills)
            {
                var newSkill = _monsterFactory.GetSkillInstance();

                newSkill.Level = skill.Level;
                newSkill.Name = skill.Name;

                newMonster.Skills.Add(newSkill);
            }
        }
        private void CloneStats(IMonster newMonster)
        {
            newMonster.Stats = _monsterFactory.GetStatsInstance();

            newMonster.Stats.Dexterity = _selectedMonster.Stats.Dexterity;
            newMonster.Stats.Dodge = _selectedMonster.Stats.Dodge;
            newMonster.Stats.FatiguePoints = _selectedMonster.Stats.FatiguePoints;
            newMonster.Stats.Health = _selectedMonster.Stats.Health;
            newMonster.Stats.Height = _selectedMonster.Stats.Height;
            newMonster.Stats.HitPoints = _selectedMonster.Stats.HitPoints;
            newMonster.Stats.IQ = _selectedMonster.Stats.IQ;
            newMonster.Stats.Move = _selectedMonster.Stats.Move;
            newMonster.Stats.Perception = _selectedMonster.Stats.Perception;
            newMonster.Stats.SizeModifier = _selectedMonster.Stats.SizeModifier;
            newMonster.Stats.Speed = _selectedMonster.Stats.Speed;
            newMonster.Stats.Strength = _selectedMonster.Stats.Strength;
            newMonster.Stats.Weight = _selectedMonster.Stats.Weight;
            newMonster.Stats.Will = _selectedMonster.Stats.Will;
        }
        private void CloneTactics(IMonster newMonster)
        {
            foreach(var tactic in _selectedMonster.Tactics)
            {
                var newTactic = _monsterFactory.GetTacticIntance();

                newTactic.Order = tactic.Order;
                newTactic.Text = tactic.Text;

                newMonster.Tactics.Add(newTactic);
            }
        }
        private void CloneTraits(IMonster newMonster)
        {
            foreach (var trait in _selectedMonster.Traits)
            {
                var newTrait = _monsterFactory.GetTraitInstance();

                newTrait.Name = trait.Name;

                newMonster.Traits.Add(newTrait);
            }
        }
    }
}
