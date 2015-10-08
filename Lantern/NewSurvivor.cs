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
    public partial class NewSurvivor : Form
    {
        public bool Confirm;
        public string NewName
        {
            get { return nameInput.Text; }
        }
        public bool IsBoy {
            get { return isMale.Checked; }
        }
        public NewSurvivor()
        {
            InitializeComponent();
            Confirm = false;
        }

        private void confirmBut_Click(object sender, EventArgs e)
        {
            if (NewName == "") MessageBox.Show("Please enter a name.");
            else
            {
                Confirm = true;
                this.Close();
            }
        }

        private void cancelBut_Click(object sender, EventArgs e)
        {
            Confirm = false;
            this.Close();
        }
    }
}
