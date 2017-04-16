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
    public partial class MeleeAttacks : Form
    {
        Func<List<IMelee>, bool> _changeMelees;
        List<IMelee> _melees;
        IMonsterFactory _monsterFactory;

        public MeleeAttacks(Func<List<IMelee>, bool> changeMelees, List<IMelee> melees, IMonsterFactory monsterFactory)
        {
            InitializeComponent();

            _changeMelees = changeMelees;
            _melees = melees;
            _monsterFactory = monsterFactory;

            _melees.Sort((h1, h2) => h1.Weapon.CompareTo(h2.Weapon));

            RefreshMeleeList();
        }

        private void RefreshMeleeList()
        {
            listView1.Items.Clear();

            foreach (var item in _melees)
            {
                var listItem = new ListViewItem(new[] { item.Weapon, item.Usage, item.Skill, item.Parry, item.Block, item.Damage, item.DamageType, item.Reach });
                listView1.Items.Add(listItem);
            }
            PaintList();
        }

        private void PaintList()
        {
            listView1.BackColor = Color.Cornsilk;

            foreach (ListViewItem item in listView1.Items)
            {
                if(item.Index % 2 != 0)
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
            _melees.Clear();

            foreach (ListViewItem item in listView1.Items)
            {
                var melee = _monsterFactory.GetMeleeInstance();

                melee.Weapon = item.SubItems[0].Text;
                melee.Usage = item.SubItems[1].Text;
                melee.Skill = item.SubItems[2].Text;
                melee.Parry = item.SubItems[3].Text;
                melee.Block = item.SubItems[4].Text;
                melee.Damage = item.SubItems[5].Text;
                melee.DamageType = item.SubItems[6].Text;
                melee.Reach = item.SubItems[7].Text;

                _melees.Add(melee);
            }

            _changeMelees(_melees);

            this.Close();

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            PaintList();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var listItem = new ListViewItem(new[] 
            {
                this.txtWeapon.Text,
                this.txtUsage.Text,
                this.txtSkill.Text,
                this.txtParry.Text,
                this.txtBlock.Text,
                this.txtDamage.Text,
                this.cboType.Text,
                this.txtReach.Text
            });
            listView1.Items.Add(listItem);
        }
    }
}
