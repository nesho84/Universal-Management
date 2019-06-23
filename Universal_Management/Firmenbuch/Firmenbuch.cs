using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Universal_Management
{
    public partial class Firmenbuch : Form
    {
        public Firmenbuch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var Firmenbuch_Add = new Firmenbuch_Add();

            this.Hide();

            Firmenbuch_Add.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var Firmenbuch_Table = new Firmenbuch_Table();

            this.Hide();
            
            Firmenbuch_Table.ShowDialog();
        }

        private void Firmenbuch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)27)
            {
                this.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var firmenbuch_extra = new Firmenbuch_Extra();
            this.Hide();
            firmenbuch_extra.ShowDialog();
        }
    }
}
