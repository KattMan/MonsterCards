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

namespace MonsterCards
{
    public partial class SpellAttacks : Form
    {
        Func<List<ISpell>, bool> _changeSpells;
        List<ISpell> _spells;
        IMonsterFactory _monsterFactory;

        public SpellAttacks(Func<List<ISpell>, bool> changeSpells, List<ISpell> spells, IMonsterFactory monsterFactory)
        {
            InitializeComponent();

            _changeSpells = changeSpells;
            _spells = spells;
            _monsterFactory = monsterFactory;

            _spells.Sort((h1, h2) => h1.Name.CompareTo(h2.Name));

            RefreshSpellList();
        }

        private void RefreshSpellList()
        {
            listView1.Items.Clear();

            foreach (var item in _spells)
            {
                var listItem = new ListViewItem(new[] { item.Name, item.Skill, item.Cost, item.TimeToCast, item.Duration, item.Maintain });
                listView1.Items.Add(listItem);
            }
            PaintList();
        }

        private void PaintList()
        {
            listView1.BackColor = Color.Cornsilk;

            foreach (ListViewItem item in listView1.Items)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            _spells.Clear();

            foreach (ListViewItem item in listView1.Items)
            {
                var spell = _monsterFactory.GetSpellInstance();

                spell.Name = item.SubItems[0].Text;
                spell.Skill = item.SubItems[1].Text;
                spell.Cost = item.SubItems[2].Text;
                spell.TimeToCast = item.SubItems[3].Text;
                spell.Duration = item.SubItems[4].Text;
                spell.Maintain = item.SubItems[5].Text;

                _spells.Add(spell);
            }

            _changeSpells(_spells);

            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var listItem = new ListViewItem(new[]
{
                this.txtName.Text,
                this.txtSkill.Text,
                this.txtCost.Text,
                this.txtTimeToCast.Text,
                this.txtDuration.Text,
                this.txtMaintain.Text,
            });
            listView1.Items.Add(listItem);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            PaintList();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
