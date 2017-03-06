using MonsterLibAbstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterCards
{
    public partial class MonsterList : Form
    {

        Func<IMonster, bool> _ChangeMonster;
        Func<IMonster, bool> _ShowMonster;
        List<IMonster> _monsters;
        IMonster _currentMonster;

        public MonsterList(Func<IMonster, bool> ChangeMonster, Func<IMonster, bool> ShowMonster, List<IMonster> monsters, IMonster currentMonster)
        {
            InitializeComponent();
            _ChangeMonster = ChangeMonster;
            _ShowMonster = ShowMonster;
            _monsters = monsters;
            _currentMonster = currentMonster;

            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "ID";
            listBox1.DataSource = _monsters;

            listBox1.SelectedValue = currentMonster.ID;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedID = (int)listBox1.SelectedValue;
            var selectedMonster = _monsters.First(m => m.ID == selectedID);
            _ChangeMonster(selectedMonster);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _ChangeMonster(_currentMonster);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var selectedID = (int)listBox1.SelectedValue;
            var selectedMonster = _monsters.First(m => m.ID == selectedID);
            _ChangeMonster(selectedMonster);
            this.Close();
        }



    }
}
