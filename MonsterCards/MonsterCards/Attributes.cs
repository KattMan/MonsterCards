using MonsterDALAbstracts;
using MonsterLibAbstracts;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonsterCards
{
    public partial class Attributes : Form
    {
        Func<IStats, IClassification, bool> _ChangeStats;
        Func<IClassification, List<ITactic>, bool> _ChangeTactics;
        IStats _stats;
        IClassification _classification;
        List<ITactic> _tactics;
        IDataAccess<IClassification> _classDal;

        public Attributes(Func<IStats, IClassification, bool> ChangeStats, Func<IClassification, List<ITactic>, bool> ChangeTactics, IMonster monsterInfo, IDataAccess<IClassification> classDal)
        {
            InitializeComponent();

            _ChangeStats = ChangeStats;
            _ChangeTactics = ChangeTactics;
            _stats = monsterInfo.Stats;
            _classification = monsterInfo.Classification;
            _tactics = monsterInfo.Tactics;
            _classDal = classDal;
            FillClassCombo();

            txtDX.Text = _stats.Dexterity;
            txtDodge.Text = _stats.Dodge;
            txtFP.Text= _stats.FatiguePoints;
            txtHT.Text = _stats.Health;
            txtHeight.Text = _stats.Height;
            txtHP.Text = _stats.HitPoints;
            txtIQ.Text = _stats.IQ;
            txtMove.Text = _stats.Move;
            txtPer.Text = _stats.Perception;
            txtSM.Text = _stats.SizeModifier;
            txtSpeed.Text = _stats.Speed;
            txtST.Text = _stats.Strength;
            txtWeight.Text = _stats.Weight;
            txtWill.Text = _stats.Will;

        }

        private void FillClassCombo()
        {
            var classes = _classDal.LoadData(Path.Combine(System.IO.Directory.GetCurrentDirectory(), "Data"));
            cbClassification.DisplayMember = "Name";
            cbClassification.ValueMember = "Description";

            foreach (var classItem in classes)
            {
                cbClassification.Items.Add(classItem);
                if (classItem.Name == _classification.Name)
                {
                    cbClassification.SelectedItem = classItem;
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _classification.Name = ((IClassification)cbClassification.SelectedItem).Name;
            _classification.Description = ((IClassification)cbClassification.SelectedItem).Description;

            _stats.Dexterity = txtDX.Text;
            _stats.Dodge = txtDodge.Text;
            _stats.FatiguePoints = txtFP.Text;
            _stats.Health = txtHT.Text;
            _stats.Height = txtHeight.Text;
            _stats.HitPoints = txtHP.Text;
            _stats.IQ = txtIQ.Text;
            _stats.Move = txtMove.Text;
            _stats.Perception = txtPer.Text;
            _stats.SizeModifier = txtSM.Text;
            _stats.Speed = txtSpeed.Text;
            _stats.Strength = txtST.Text;
            _stats.Weight = txtWeight.Text;
            _stats.Will = txtWill.Text;

            _ChangeStats(_stats, _classification);
            _ChangeTactics(_classification, _tactics);
            this.Close();
        }

        private void txtSM_TextChanged(object sender, EventArgs e)
        {
            int sizeValue;
            if(int.TryParse(txtSM.Text, out sizeValue))
            {
                if (sizeValue <= -10) 
                { 
                    txtHeight.Text = "Up to 1.8\"";
                    label16.Text = "Suggested ST = 1";
                }
                if (sizeValue == -9) 
                {
                    txtHeight.Text = "1.8\" - 2.5\"";
                    label16.Text = "Suggested ST = 1";
                }
                if (sizeValue == -8) 
                {
                    txtHeight.Text = "2.5\" - 3.5\"";
                    label16.Text = "Suggested ST = 1";
                }
                if (sizeValue == -7) 
                {
                    txtHeight.Text = "3.5\" - 5\"";
                    label16.Text = "Suggested ST = 1";
                }
                if (sizeValue == -6) 
                {
                    txtHeight.Text = "5\" - 7\"";
                    label16.Text = "Suggested ST = 1";
                }
                if (sizeValue == -5) 
                {
                    txtHeight.Text = "7\" - 10\"";
                    label16.Text = "Suggested ST = 1";
                }
                if (sizeValue == -4) 
                {
                    txtHeight.Text = "10\" - 18\"";
                    label16.Text = "Suggested ST = 2";
                }
                if (sizeValue == -3) 
                {
                    txtHeight.Text = "18\" - 2'";
                    label16.Text = "Suggested ST = 3";
                }
                if (sizeValue == -2) 
                {
                    txtHeight.Text = "2' - 3'";
                    label16.Text = "Suggested ST = 5";
                }
                if (sizeValue == -1) 
                {
                    txtHeight.Text = "3' - 4.5'";
                    label16.Text = "Suggested ST = 7";
                }
                if (sizeValue == 0) 
                {
                    txtHeight.Text = "4.5' - 6'";
                    label16.Text = "Suggested ST = 10";
                }
                if (sizeValue == 1) 
                {
                    txtHeight.Text = "6' - 9'";
                    label16.Text = "Suggested ST = 15";
                }
                if (sizeValue == 2) 
                {
                    txtHeight.Text = "9' - 15'";
                    label16.Text = "Suggested ST = 25";
                }
                if (sizeValue == 3) 
                {
                    txtHeight.Text = "15' - 21'";
                    label16.Text = "Suggested ST = 35";
                }
                if (sizeValue == 4) 
                {
                    txtHeight.Text = "21' - 30'";
                    label16.Text = "Suggested ST = 50";
                }
                if (sizeValue == 5) 
                {
                    txtHeight.Text = "30' - 45'";
                    label16.Text = "Suggested ST = 75";
                }
                if (sizeValue == 6) 
                {
                    txtHeight.Text = "45' - 60'";
                    label16.Text = "Suggested ST = 100";
                }
                if (sizeValue == 7) 
                {
                    txtHeight.Text = "60' - 90'";
                    label16.Text = "Suggested ST = 150";
                }
                if (sizeValue == 8) 
                {
                    txtHeight.Text = "90' - 150'";
                    label16.Text = "Suggested ST = 250";
                }
                if (sizeValue == 9) 
                {
                    txtHeight.Text = "150' - 210'";
                    label16.Text = "Suggested ST = 350";
                }
                if (sizeValue == 10) 
                {
                    txtHeight.Text = "210' - 300'";
                    label16.Text = "Suggested ST = 500";
                }
                if (sizeValue == 11) 
                {
                    txtHeight.Text = "300' - 450'";
                    label16.Text = "Suggested ST = 750";
                }
                if (sizeValue > 11) 
                { 
                    txtHeight.Text = "over 450'";
                    label16.Text = "Suggested ST = 1000";
                }
            }
            else
            {
                txtHeight.Text = string.Empty;
                label16.Text = string.Empty;
            }
        }
    }
}
