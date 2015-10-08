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
    public partial class LoadSurvivor : Form
    {
        public bool Confirm;
        public string LoadName
        {
            get { return nameInput.Text; }
        }
        public LoadSurvivor()
        {
            InitializeComponent();
            Confirm = false;
        }

        private void confirmBut_Click(object sender, EventArgs e)
        {
            Confirm = true;
            this.Close();
        }

        private void cancelBut_Click(object sender, EventArgs e)
        {
            Confirm = false;
            this.Close();
        }
    }
}
