using airplane_management_system;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace airplane_management_system
{
    public partial class Form5 : Form
    {
        public static Form5 v;
        public Form5()
        {
            v = this;
            InitializeComponent();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = @"E:\Fourth Semester\Data Base\AIRLINE MANAGEMENT SYSTEM\airplane_management_system\aeroplane song status dubai flight.mp4";
            for (int i = 0; i < 20; i++)
            {
                axWindowsMediaPlayer1.Ctlcontrols.play();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form16 form = new Form16();
            form.Show();
            this.Hide();
        }
    }
}
