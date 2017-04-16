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
    public partial class RangedAttacks : Form
    {
        Func<List<IRanged>, bool> _changeRanged;
        List<IRanged> _ranged;
        IMonsterFactory _monsterFactory;

        public RangedAttacks(Func<List<IRanged>, bool> changeRanged, List<IRanged> ranged, IMonsterFactory monsterFactory)
        {
            InitializeComponent();

            _changeRanged = changeRanged;
            _ranged = ranged;
            _monsterFactory = monsterFactory;

            _ranged.Sort((h1, h2) => h1.Weapon.CompareTo(h2.Weapon));

            RefreshAttackList();
        }

        private void RefreshAttackList()
        {
            listView1.Items.Clear();

            foreach (var item in _ranged)
            {
                var listItem = new ListViewItem(new[] { item.Weapon, item.ROF, item.Reload, item.Skill, item.Damage, item.DamageType, item.HalfDmg, item.MaxRange, item.Bulk });
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ranged.Clear();

            foreach (ListViewItem item in listView1.Items)
            {
                var ranged = _monsterFactory.GetRangedInstance();

                ranged.Weapon = item.SubItems[0].Text;
                ranged.ROF = item.SubItems[1].Text;
                ranged.Reload = item.SubItems[2].Text;
                ranged.Skill = item.SubItems[3].Text;
                ranged.Damage = item.SubItems[4].Text;
                ranged.DamageType = item.SubItems[5].Text;
                ranged.HalfDmg = item.SubItems[6].Text;
                ranged.MaxRange = item.SubItems[7].Text;
                ranged.Bulk = item.SubItems[8].Text;

                _ranged.Add(ranged);
            }

            _changeRanged(_ranged);

            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var listItem = new ListViewItem(new[]
{
                this.txtWeapon.Text,
                this.txtROF.Text,
                this.txtReload.Text,
                this.txtSkill.Text,
                this.txtDamage.Text,
                this.cboType.Text,
                this.txtHalfDmg.Text,
                this.txtRange.Text,
                this.txtBulk.Text
            });
            listView1.Items.Add(listItem);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            listView1.Items.RemoveAt(listView1.SelectedIndices[0]);
            PaintList();
        }
    }
}
