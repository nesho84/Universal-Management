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
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            progressBar1.Increment(1);

            if (progressBar1.Value == 50)
            {
                timer1.Stop();
                Login login = new Login();

                this.Hide();

                login.ShowDialog();
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            //Start timer
            timer1.Start();
        }
        
    }
}
