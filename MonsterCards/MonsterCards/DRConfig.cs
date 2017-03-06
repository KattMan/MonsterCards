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
    public partial class DRConfig : Form
    {
        IDamageResist _damageResist;
        Func<IDamageResist, bool> _ChangeDRs;

        public DRConfig(Func<IDamageResist, bool> ChangeDRs , IDamageResist damageResist)
        {
            InitializeComponent();

            _damageResist = damageResist;
            _ChangeDRs = ChangeDRs;

        }

        private void DRConfig_Load(object sender, EventArgs e)
        {
            PopulateBodyTypes();

            tbArms.Text = _damageResist.Arm;
            tbFeet.Text = _damageResist.Foot;
            tbFins.Text = _damageResist.Fin;
            tbHands.Text = _damageResist.Hand;
            tbHead.Text = _damageResist.Head;
            tbLegs.Text = _damageResist.Leg;
            tbTail.Text = _damageResist.Tail;
            tbTorso.Text = _damageResist.Torso;
            tbWings.Text = _damageResist.Wing;
            cbWinged.Checked = _damageResist.Winged;

            cbBodyType.SelectedItem = _damageResist.BodyType;
        }

        private void PopulateBodyTypes()
        {
            cbBodyType.Items.Add(BodyType.Arachnoid);
            cbBodyType.Items.Add(BodyType.Avian);
            cbBodyType.Items.Add(BodyType.Cancroid);
            cbBodyType.Items.Add(BodyType.Centaur);
            cbBodyType.Items.Add(BodyType.Hexapod);
            cbBodyType.Items.Add(BodyType.Humanoid);
            cbBodyType.Items.Add(BodyType.Hybrid);
            cbBodyType.Items.Add(BodyType.Ichthyoid);
            cbBodyType.Items.Add(BodyType.Octopod);
            cbBodyType.Items.Add(BodyType.Quadruped);
            cbBodyType.Items.Add(BodyType.Vermiform);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _damageResist.BodyType = (BodyType)cbBodyType.SelectedItem;
            _damageResist.Arm = tbArms.Enabled ? tbArms.Text : "";
            _damageResist.Fin = tbFins.Enabled ? tbFins.Text : "";
            _damageResist.Foot = tbFeet.Enabled ? tbFeet.Text : "";
            _damageResist.Hand = tbHands.Enabled ? tbHands.Text : "";
            _damageResist.Head = tbHead.Enabled ? tbHead.Text : "";
            _damageResist.Leg = tbLegs.Enabled ? tbLegs.Text : "";
            _damageResist.Tail = tbTail.Enabled ? tbTail.Text : "";
            _damageResist.Torso = tbTorso.Enabled ? tbTorso.Text : "";
            _damageResist.Wing = tbWings.Enabled ? tbWings.Text : "";
            _damageResist.Winged = cbWinged.Checked;

            _ChangeDRs(_damageResist);
            this.Close();
        }

        private void cbBodyType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch((BodyType)cbBodyType.SelectedItem)
            {
                case BodyType.Arachnoid:
                    //head torso legs
                    tbArms.Enabled = false;
                    tbFeet.Enabled = false;
                    tbFins.Enabled = false;
                    tbHands.Enabled = false;
                    tbHead.Enabled = true;
                    tbLegs.Enabled = true;
                    tbTail.Enabled = false;
                    tbTorso.Enabled = true;
                    cbWinged.Enabled = true;
                    break;
                case BodyType.Avian:
                    //head feet torso legs -- wings!
                    tbArms.Enabled = false;
                    tbFeet.Enabled = true;
                    tbFins.Enabled = false;
                    tbHands.Enabled = false;
                    tbHead.Enabled = true;
                    tbLegs.Enabled = true;
                    tbTail.Enabled = false;
                    tbTorso.Enabled = true;
                    cbWinged.Enabled = false;
                    cbWinged.Checked = true;
                    break;
                case BodyType.Cancroid:
                    // head arms torso
                    tbArms.Enabled = true;
                    tbFeet.Enabled = false;
                    tbFins.Enabled = false;
                    tbHands.Enabled = false;
                    tbHead.Enabled = true;
                    tbLegs.Enabled = false;
                    tbTail.Enabled = false;
                    tbTorso.Enabled = true;
                    cbWinged.Enabled = true;
                    //cbWinged.Checked = false;
                    break;
                case BodyType.Centaur:
                    // head torso arms leg feet hands
                    tbArms.Enabled = true;
                    tbFeet.Enabled = true;
                    tbFins.Enabled = false;
                    tbHands.Enabled = true;
                    tbHead.Enabled = true;
                    tbLegs.Enabled = true;
                    tbTail.Enabled = false;
                    tbTorso.Enabled = true;
                    cbWinged.Enabled = true;
                    break;
                case BodyType.Hexapod:
                    // head feet torso tail legs
                    tbArms.Enabled = false;
                    tbFeet.Enabled = true;
                    tbFins.Enabled = false;
                    tbHands.Enabled = false;
                    tbHead.Enabled = true;
                    tbLegs.Enabled = true;
                    tbTail.Enabled = true;
                    tbTorso.Enabled = true;
                    cbWinged.Enabled = true;
                    break;
                case BodyType.Humanoid:
                    // head hands torso legs arms feet 
                    tbArms.Enabled = true;
                    tbFeet.Enabled = true;
                    tbFins.Enabled = false;
                    tbHands.Enabled = true;
                    tbHead.Enabled = true;
                    tbLegs.Enabled = true;
                    tbTail.Enabled = false;
                    tbTorso.Enabled = true;
                    cbWinged.Enabled = true;
                    break;
                case BodyType.Ichthyoid:
                    // head fin torso tail
                    tbArms.Enabled = false;
                    tbFeet.Enabled = false;
                    tbFins.Enabled = true;
                    tbHands.Enabled = false;
                    tbHead.Enabled = true;
                    tbLegs.Enabled = false;
                    tbTail.Enabled = true;
                    tbTorso.Enabled = true;
                    cbWinged.Enabled = true;
                    break;
                case BodyType.Octopod:
                    // head arms torso
                    tbArms.Enabled = true;
                    tbFeet.Enabled = false;
                    tbFins.Enabled = false;
                    tbHands.Enabled = false;
                    tbHead.Enabled = true;
                    tbLegs.Enabled = false;
                    tbTail.Enabled = false;
                    tbTorso.Enabled = true;
                    cbWinged.Enabled = true;
                    break;
                case BodyType.Quadruped:
                    // head feet torso tail legs
                    tbArms.Enabled = false;
                    tbFeet.Enabled = true;
                    tbFins.Enabled = false;
                    tbHands.Enabled = false;
                    tbHead.Enabled = true;
                    tbLegs.Enabled = true;
                    tbTail.Enabled = true;
                    tbTorso.Enabled = true;
                    cbWinged.Enabled = true;
                    break;
                case BodyType.Vermiform:
                    // head torso
                    tbArms.Enabled = false;
                    tbFeet.Enabled = false;
                    tbFins.Enabled = false;
                    tbHands.Enabled = false;
                    tbHead.Enabled = true;
                    tbLegs.Enabled = false;
                    tbTail.Enabled = false;
                    tbTorso.Enabled = true;
                    cbWinged.Enabled = true;
                    break;
                case BodyType.Hybrid:
                    // head torso
                    tbArms.Enabled = true;
                    tbFeet.Enabled = true;
                    tbFins.Enabled = true;
                    tbHands.Enabled = true;
                    tbHead.Enabled = true;
                    tbLegs.Enabled = true;
                    tbTail.Enabled = true;
                    tbTorso.Enabled = true;
                    cbWinged.Enabled = true;
                    break;
            }
        }

        private void cbWinged_CheckedChanged(object sender, EventArgs e)
        {
            tbWings.Enabled = cbWinged.Checked;
        }
    }
}
