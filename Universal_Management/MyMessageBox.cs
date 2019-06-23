using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;

namespace Universal_Management
{
    public partial class MyMessageBox : Form
    {
        public MyMessageBox()
        {
            InitializeComponent();
        }

        //Disable Close(x) Button on the form
        private const int CP_NOCLOSE_BUTTON = 0x200;
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams myCp = base.CreateParams;
                myCp.ClassStyle = myCp.ClassStyle | CP_NOCLOSE_BUTTON;
                return myCp;
            }
        }

        private void MyMessageBox_Load(object sender, EventArgs e)
        {
            this.btnNein.DialogResult = DialogResult.Cancel;
            this.btnJa.DialogResult = DialogResult.OK;
            this.AcceptButton = btnJa;
            this.CancelButton = btnNein;
        }

        private void MyMessageBox_Shown(object sender, EventArgs e)
        {
            SoundPlayer simpleSound = new SoundPlayer(@"c:\Windows\Media\notify.wav");
            simpleSound.Play();
        }

    }
}
