using MonsterLibAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MonsterCards
{
    public partial class Drops : Form
    {
        List<IDrop> _drops;
        List<IDrop> _newDrops = new List<IDrop>();
        Func<List<IDrop>, bool> _ChangeDrops;
        IMonsterFactory _monsterFactory;

        public Drops(Func<List<IDrop>, bool> ChangeDrops, List<IDrop> drops, IMonsterFactory monsterFactory)
        {
            InitializeComponent();

            _drops = drops;
            _ChangeDrops = ChangeDrops;
            _monsterFactory = monsterFactory;

            foreach (var item in _drops)
            {
                _newDrops.Add(item);
            }

            checkedListBox1.DataSource = _newDrops;
        }

        private void Drops_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _drops.Clear();

            foreach (var item in _newDrops)
            {
                _drops.Add(item);
            }

            _ChangeDrops(_drops);
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var toDelete = new List<string>();

            foreach(var item in checkedListBox1.CheckedItems)
            {
                toDelete.Add(item.ToString());
            }

            _newDrops.RemoveAll(r => toDelete.Contains(r.Name));

            checkedListBox1.DataSource = null;
            checkedListBox1.DataSource = _newDrops;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                var newDrop = _monsterFactory.GetDropInstance();
                newDrop.Name = textBox1.Text;
                if (_newDrops.FirstOrDefault(d => d.Name == newDrop.Name) == null)
                {
                    _newDrops.Add(newDrop);
                }
                textBox1.Text = string.Empty;

                _newDrops.Sort((h1, h2) => h1.Name.CompareTo(h2.Name));

                checkedListBox1.DataSource = null;
                checkedListBox1.DataSource = _newDrops;
            }
        }


    }
}
