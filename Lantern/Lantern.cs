using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lantern
{
    public partial class Lantern : Form
    {
        Survivor curSurv;

        public Lantern()
        {
            InitializeComponent();
        }

        /** DATA UTILITY ****************************************************************************/
        /** This handles most of the data such as saving/loading using XML formats.                **/
        private void saveSurvivor(object sender, EventArgs e)
        {
            if (!curSurv.saveSurvivor()) MessageBox.Show("Failed saving lol ur fucked");

        }

        private void loadSurvivor(object sender, EventArgs e)
        {
            LoadSurvivor loadSurvivor = new LoadSurvivor();
            loadSurvivor.ShowDialog();
            if (!loadSurvivor.Confirm) return;
            curSurv = Survivor.LoadSurvivor(loadSurvivor.LoadName);
            if (curSurv == null)
            {
                MessageBox.Show("Failed Loading.");
                return;
            }
            redrawScreen();
            MessageBox.Show("Successfuly Loaded");
        }
        private void newSurvivor(object sender, EventArgs e)
        {
            NewSurvivor newSurvivor = new NewSurvivor();
            newSurvivor.ShowDialog();
            if (!newSurvivor.Confirm) return;
            curSurv = new Survivor(newSurvivor.NewName, newSurvivor.IsBoy);
            redrawScreen();
        }
        //redrawScreen()
        //Initialize the screen after loading
        private void redrawScreen() {
            //Name and attributes
            nameDisplay.Text = curSurv.Name + ((curSurv.Gender)?"♂" : "♀");
            survivalDisplay.Value = curSurv.Attributes[(int) survivorAttributes.SUR];
            movDisplay.Value = curSurv.Attributes[(int) survivorAttributes.MOV];
            accDisplay.Value = curSurv.Attributes[(int)survivorAttributes.ACC];
            strDisplay.Value = curSurv.Attributes[(int)survivorAttributes.STR];
            lucDisplay.Value = curSurv.Attributes[(int)survivorAttributes.LUC];
            evaDisplay.Value = curSurv.Attributes[(int)survivorAttributes.EVA];
            spdDisplay.Value = curSurv.Attributes[(int)survivorAttributes.SPD];
            isInsane.Checked = curSurv.Attributes[(int)survivorAttributes.INS] >= 3;
            brainArmor.Value = curSurv.Attributes[(int)survivorAttributes.INS];

            //Statuses
            cantSurvival.Checked = (curSurv.Status & (int)survivorStatus.CANT_SURVIVE) != 0;
            survivalDisplay.Enabled = !cantSurvival.Checked;
            cantHunt.Checked = (curSurv.Status & (int)survivorStatus.CANT_HUNT) != 0;
            cantArt.Checked = (curSurv.Status & (int)survivorStatus.CANT_USE_ARTS) != 0;
            FightArtGroup.Enabled = !cantArt.Checked;
            Dodge.Checked = (curSurv.Status & (int)survivorStatus.CAN_DODGE) != 0;
            Encourage.Checked = (curSurv.Status & (int)survivorStatus.CAN_ENCOURAGE) != 0;
            Surge.Checked = (curSurv.Status & (int)survivorStatus.CAN_SURGE) != 0;
            Dash.Checked = (curSurv.Status & (int)survivorStatus.CAN_DASH) != 0;

            //HuntXP
            expBar.Value = curSurv.EXP[(int)experience.HUNT_XP];
            expLabel.Text = curSurv.EXP[(int)experience.HUNT_XP].ToString();
            Age1.Checked = expBar.Value >= 2;
            Age2.Checked = expBar.Value >= 6;
            Age3.Checked = expBar.Value >= 10;
            Age4.Checked = expBar.Value >= 15;
            Age5.Checked = expBar.Value >= 16;

            //WeaponProf
            WeaponGroup.Enabled = Age1.Checked;
            if(WeaponGroup.Enabled)
            {
                WeaponType.Text = curSurv.WeaponType;
                WeaponProfBar.Value = curSurv.EXP[(int)experience.WEAPON];
                weaponProfLabel.Text = WeaponProfBar.Value.ToString();
                Weapon1.Checked = WeaponProfBar.Value >= 3;
                Weapon2.Checked = WeaponProfBar.Value >= 8;
            }

            //Courage
            courageBar.Value = curSurv.EXP[(int)experience.COUR];
            courageLabel.Text = curSurv.EXP[(int)experience.COUR].ToString();
            Courage1.Checked = courageBar.Value >= 3;
            Courage2.Checked = courageBar.Value >= 9;
            BoldGroup.Enabled = Courage1.Checked;
            if (curSurv.BoldSkill == "Stalwart") Stalwart.Checked = true;
            if (curSurv.BoldSkill == "Prepared") Prepared.Checked = true;
            if (curSurv.BoldSkill == "Matchmaker") Matchmaker.Checked = true;

            //Understanding
            understandingBar.Value = curSurv.EXP[(int)experience.UNDERS];
            understandingLabel.Text = curSurv.EXP[(int)experience.UNDERS].ToString();
            Understanding1.Checked = understandingBar.Value >= 3;
            Understanding2.Checked = understandingBar.Value >= 9;
            InsightGroup.Enabled = Understanding1.Checked;
            if (curSurv.InsightSkill == "Analyze") Analyze.Checked = true;
            if (curSurv.InsightSkill == "Explore") Explore.Checked = true;
            if (curSurv.InsightSkill == "Tinker") Explore.Checked = true;

            //Fighting Arts
            Art1.Text = curSurv.FightArts[0];
            Art2.Text = curSurv.FightArts[1];
            Art3.Text = curSurv.FightArts[2];

            //Disorders
            Disorder1.Text = curSurv.Disorders[0];
            Disorder2.Text = curSurv.Disorders[1];
            Disorder3.Text = curSurv.Disorders[2];

            //Notes
            Notes.Text = curSurv.Notes;

            SurvivorGroup.Enabled = true;
        }
        /**                                                                                        **/
        /********************************************************************************************/

        /**Function Utility**************************************************************************/
        /** These are all the events that happen when buttons and shit are clicked                 **/

        /////////////////////////////
        /// Attribute handling logic
        /////////////////////////////
        private void survivalDisplay_ValueChanged(object sender, EventArgs e)
        {
            if (survivalDisplay.Value < 0) return;
            curSurv.Attributes[(int)survivorAttributes.SUR] = (int)survivalDisplay.Value;
        }
        private void movDisplay_ValueChanged(object sender, EventArgs e)
        {
            curSurv.Attributes[(int)survivorAttributes.MOV] = (int) movDisplay.Value;
        }
        private void accDisplay_ValueChanged(object sender, EventArgs e)
        {
            curSurv.Attributes[(int)survivorAttributes.ACC] = (int)accDisplay.Value;
        }
        private void strDisplay_ValueChanged(object sender, EventArgs e)
        {
            curSurv.Attributes[(int)survivorAttributes.STR] = (int)strDisplay.Value;
        }
        private void evaDisplay_ValueChanged(object sender, EventArgs e)
        {
            curSurv.Attributes[(int)survivorAttributes.EVA] = (int)evaDisplay.Value;
        }
        private void lucDisplay_ValueChanged(object sender, EventArgs e)
        {
            curSurv.Attributes[(int)survivorAttributes.LUC] = (int)lucDisplay.Value;
        }
        private void spdDisplay_ValueChanged(object sender, EventArgs e)
        {
            curSurv.Attributes[(int)survivorAttributes.SPD] = (int)spdDisplay.Value;
        }
        private void brainArmor_ValueChanged(object sender, EventArgs e)
        {
            curSurv.Attributes[(int)survivorAttributes.INS] = (int) brainArmor.Value;
            if (brainArmor.Value >= 3) isInsane.Checked = true;
            else isInsane.Checked = false;
        }

        /////////////////////////////
        /// Status handling logic
        /////////////////////////////
        private void cantHunt_CheckedChanged(object sender, EventArgs e)
        {
            if (cantHunt.Checked != ((curSurv.Status & (int)survivorStatus.CANT_HUNT) != 0))
            {
                curSurv.Status ^= (int)survivorStatus.CANT_HUNT;
                cantHunt.Checked = (curSurv.Status & (int)survivorStatus.CANT_HUNT) != 0;
            }
        }
        private void cantSurvival_CheckedChanged(object sender, EventArgs e)
        {
            if (cantSurvival.Checked != ((curSurv.Status & (int)survivorStatus.CANT_SURVIVE) != 0))
            {
                curSurv.Status ^= (int)survivorStatus.CANT_SURVIVE;
                cantSurvival.Checked = (curSurv.Status & (int)survivorStatus.CANT_SURVIVE) != 0;
            }
            survivalDisplay.Enabled = !cantSurvival.Checked;
        }

        private void cantArt_CheckedChanged(object sender, EventArgs e)
        {
            if (cantArt.Checked != ((curSurv.Status & (int)survivorStatus.CANT_USE_ARTS) != 0))
            {
                curSurv.Status ^= (int)survivorStatus.CANT_USE_ARTS;
                cantArt.Checked = (curSurv.Status & (int)survivorStatus.CANT_USE_ARTS) != 0;
            }
            FightArtGroup.Enabled = !cantArt.Checked;
        }
        private void Encourage_CheckedChanged(object sender, EventArgs e)
        {
            if (Encourage.Checked != ((curSurv.Status & (int)survivorStatus.CAN_ENCOURAGE) != 0))
            {
                curSurv.Status ^= (int)survivorStatus.CAN_ENCOURAGE;
                Encourage.Checked = (curSurv.Status & (int)survivorStatus.CAN_ENCOURAGE) != 0;
            }

        }
        private void Surge_CheckedChanged(object sender, EventArgs e)
        {
            if (Surge.Checked != ((curSurv.Status & (int)survivorStatus.CAN_SURGE) != 0))
            {
                curSurv.Status ^= (int)survivorStatus.CAN_SURGE;
                Surge.Checked = (curSurv.Status & (int)survivorStatus.CAN_SURGE) != 0;
            }
        }

        private void Dodge_CheckedChanged(object sender, EventArgs e)
        {
            if (Dodge.Checked != ((curSurv.Status & (int)survivorStatus.CAN_DODGE) != 0))
            {
                curSurv.Status ^= (int)survivorStatus.CAN_DODGE;
                Dodge.Checked = (curSurv.Status & (int)survivorStatus.CAN_DODGE) != 0;
            }
        }

        private void Dash_CheckedChanged(object sender, EventArgs e)
        {
            if (Dash.Checked != ((curSurv.Status & (int)survivorStatus.CAN_DASH) != 0))
            {
                curSurv.Status ^= (int)survivorStatus.CAN_DASH;
                Dash.Checked = (curSurv.Status & (int)survivorStatus.CAN_DASH) != 0;
            }
        }
        private void boldChecked(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false) return;
            curSurv.BoldSkill = ((RadioButton)sender).Text;
        }

        private void insightChecked(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false) return;
            curSurv.InsightSkill = ((RadioButton)sender).Text;
        }

        /////////////////////////////
        /// Experience handling logic
        /////////////////////////////
        private void expBar_Scroll(object sender, EventArgs e)
        {
            curSurv.EXP[(int) experience.HUNT_XP] = expBar.Value;
            expLabel.Text = expBar.Value.ToString();
            Age1.Checked = expBar.Value >= 2;
            WeaponGroup.Enabled = Age1.Checked;
            Age2.Checked = expBar.Value >= 6;
            Age3.Checked = expBar.Value >= 10;
            Age4.Checked = expBar.Value >= 15;
            Age5.Checked = expBar.Value >= 16;
        }
        private void courageBar_Scroll(object sender, EventArgs e)
        {
            curSurv.EXP[(int)experience.COUR] = courageBar.Value;
            courageLabel.Text = courageBar.Value.ToString();
            Courage1.Checked = courageBar.Value >= 3;
            BoldGroup.Enabled = courageBar.Value >= 3;
            Courage2.Checked = courageBar.Value >= 9;
        }
        private void understandingBar_Scroll(object sender, EventArgs e)
        {
            curSurv.EXP[(int)experience.UNDERS] = understandingBar.Value;
            understandingLabel.Text = understandingBar.Value.ToString();
            Understanding1.Checked = understandingBar.Value >= 3;
            InsightGroup.Enabled = understandingBar.Value >= 3;
            Understanding2.Checked = understandingBar.Value >= 9;
        }
        private void WeaponProfBar_Scroll(object sender, EventArgs e)
        {
            curSurv.EXP[(int)experience.WEAPON] = WeaponProfBar.Value;
            weaponProfLabel.Text = WeaponProfBar.Value.ToString();
            Weapon1.Checked = WeaponProfBar.Value >= 3;
            Weapon2.Checked = WeaponProfBar.Value >= 8;
        }

        /////////////////////////////
        /// Notes and textboxes
        /////////////////////////////
        //Weapon proficiency field
        private void WeaponType_TextChanged(object sender, EventArgs e)
        {
            curSurv.WeaponType = WeaponType.Text;
        }
        //Fighting art fields
        private void Art1_TextChanged(object sender, EventArgs e)
        {
            curSurv.FightArts[0] = Art1.Text;
        }

        private void Art2_TextChanged(object sender, EventArgs e)
        {
            curSurv.FightArts[1] = Art2.Text;
        }

        private void Art3_TextChanged(object sender, EventArgs e)
        {
            curSurv.FightArts[2] = Art3.Text;
        }
        //Disorder fields
        private void Disorder1_TextChanged(object sender, EventArgs e)
        {
            curSurv.Disorders[0] = Disorder1.Text;
        }

        private void Disorder2_TextChanged(object sender, EventArgs e)
        {
            curSurv.Disorders[1] = Disorder2.Text;
        }

        private void Disorder3_TextChanged(object sender, EventArgs e)
        {
            curSurv.Disorders[2] = Disorder3.Text;
        }
        //Notes
        private void Notes_TextChanged(object sender, EventArgs e)
        {
            curSurv.Notes = Notes.Text;
        }
        /**                                                                                        **/
        /********************************************************************************************/
    }
}
