using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        //натиснуто на кнопку
        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Application.Run(new MainForm()));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            Close();
        }
    }
}
