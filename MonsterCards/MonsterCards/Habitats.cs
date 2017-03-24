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

namespace MonsterCards
{
    public partial class Habitats : Form
    {
        List<IHabitat> _habitats;
        Func<List<IHabitat>, bool> _ChangeHabitats;
        IMonsterFactory _monsterFactory;

        public Habitats(Func<List<IHabitat>, bool> ChangeHabitats, List<IHabitat> habitats, IMonsterFactory monsterFactory)
        {
            InitializeComponent();

            _habitats = habitats;
            _ChangeHabitats = ChangeHabitats;
            _monsterFactory = monsterFactory;
        }

        private void Habitats_Load(object sender, EventArgs e)
        {
            foreach (var habitat in _habitats)
            {
                foreach (var control in this.Controls)
                {
                    if (control.GetType() == typeof(CheckBox))
                    {
                        if (habitat.Name == ((CheckBox)control).Text)
                        {
                            ((CheckBox)control).Checked = true;
                        }
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _habitats.Clear();

            foreach (var control in this.Controls)
            {
                if (control.GetType() == typeof(CheckBox))
                {
                    if (((CheckBox)control).Checked)
                    {
                        var habitat = _monsterFactory.GetHabitatInstance();
                        habitat.Name = ((CheckBox)control).Text;
                        _habitats.Add(habitat);
                    }
                }
            }

            _habitats.Sort((h1, h2) => h1.Name.CompareTo(h2.Name));

            _ChangeHabitats(_habitats);
            this.Close();
        }


    }
}
