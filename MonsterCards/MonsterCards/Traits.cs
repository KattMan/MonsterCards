using MonsterLibAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MonsterCards
{
    public partial class Traits : Form
    {
        List<ITrait> _traits;
        List<ITrait> _newTraits = new List<ITrait>();
        Func<List<ITrait>, bool> _ChangeTraits;
        IMonsterFactory _monsterFactory;

        public Traits(Func<List<ITrait>, bool> ChangeTraits, List<ITrait> traits, IMonsterFactory monsterFactory)
        {
            InitializeComponent();

            _traits = traits;
            _ChangeTraits = ChangeTraits;
            _monsterFactory = monsterFactory;

            foreach (var item in _traits)
            {
                _newTraits.Add(item);
            }

            checkedListBox1.DataSource = _newTraits;
        }

        private void Traits_Load(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _traits.Clear();

            foreach (var item in _newTraits)
            {
                _traits.Add(item);
            }

            _ChangeTraits(_traits);
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var toDelete = new List<string>();

            foreach (var item in checkedListBox1.CheckedItems)
            {
                toDelete.Add(item.ToString());
            }

            _newTraits.RemoveAll(r => toDelete.Contains(r.Name));

            checkedListBox1.DataSource = null;
            checkedListBox1.DataSource = _newTraits;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                var newTrait = _monsterFactory.GetTraitInstance();
                newTrait.Name = textBox1.Text;
                if (_newTraits.FirstOrDefault(d => d.Name == newTrait.Name) == null)
                {
                    _newTraits.Add(newTrait);
                }
                textBox1.Text = string.Empty;

                _newTraits.Sort((h1, h2) => h1.Name.CompareTo(h2.Name));

                checkedListBox1.DataSource = null;
                checkedListBox1.DataSource = _newTraits;
            }
        }
    }
}
