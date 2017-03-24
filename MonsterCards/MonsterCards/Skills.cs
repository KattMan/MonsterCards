using MonsterLibAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MonsterCards
{
    public partial class Skills : Form
    {
        List<ISkill> _skills;
        List<ISkill> _newSkills = new List<ISkill>();
        Func<List<ISkill>, bool> _ChangeSkills;
        IMonsterFactory _monsterFactory;

        public Skills(Func<List<ISkill>, bool> ChangeSkills, List<ISkill> skills, IMonsterFactory monsterFactory)
        {
            _skills = skills;
            _ChangeSkills = ChangeSkills;
            _monsterFactory = monsterFactory;

            InitializeComponent();

            foreach(var item in _skills)
            {
                _newSkills.Add(item);
            }

            checkedListBox1.DataSource = _newSkills;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _skills.Clear();

            foreach (var item in _newSkills)
            {
                _skills.Add(item);
            }

            _ChangeSkills(_skills);
            this.Close();
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            var toDelete = new List<string>();

            foreach (var item in checkedListBox1.CheckedItems)
            {
                toDelete.Add(item.ToString());
            }

            _newSkills.RemoveAll(r => toDelete.Contains(r.ToString()));

            checkedListBox1.DataSource = null;
            checkedListBox1.DataSource = _newSkills;
        }

        private void Add_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBox1.Text))
            {
                var newSkill = _monsterFactory.GetSkillInstance();
                newSkill.Name = textBox1.Text;
                newSkill.Level = textBox2.Text;
                if (_newSkills.FirstOrDefault(d => d.Name == newSkill.Name) == null)
                {
                    _newSkills.Add(newSkill);
                }
                textBox1.Text = string.Empty;
                textBox2.Text = string.Empty;

                _newSkills.Sort((h1, h2) => h1.Name.CompareTo(h2.Name));

                checkedListBox1.DataSource = null;
                checkedListBox1.DataSource = _newSkills;
            }
        }
    }
}
