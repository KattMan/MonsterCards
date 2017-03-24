using MonsterLibAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MonsterCards
{
    public partial class Tactics : Form
    {
        Func<IClassification, List<ITactic>, bool> _ChangeTactics;
        IClassification _classification;
        List<ITactic> _tactics;
        IMonsterFactory _monsterFactory;

        public Tactics(Func<IClassification, List<ITactic>, bool> ChangeTactics, IClassification classification, List<ITactic> tactics, IMonsterFactory monsterFactory)
        {
            InitializeComponent();
            _ChangeTactics = ChangeTactics;
            _tactics = tactics;
            _classification = classification;
            _monsterFactory = monsterFactory;
        }

        private void Tactics_Load(object sender, EventArgs e)
        {
            var sb = new StringBuilder();

            foreach(var tactic in _tactics)
            {
                sb.AppendLine(tactic.Text);
            }

            this.textBox1.Text = sb.ToString();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _tactics.Clear();

            var lines = Regex.Split(this.textBox1.Text, Environment.NewLine).ToList();

            foreach(var line in lines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                {
                    var tactic = _monsterFactory.GetTacticIntance();
                    tactic.Text = line;
                    tactic.Order = _tactics.Count() + 1;
                    _tactics.Add(tactic);
                }
            }

            _ChangeTactics(_classification, _tactics);
            this.Close();
        }
    }
}
