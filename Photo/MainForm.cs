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
    public partial class MainForm : Form
    {
        public static MainForm instance;

        public MainForm()
        {
            InitializeComponent();
            instance = this;
            Button.CheckForIllegalCrossThreadCalls = false;
        }

        //оновити контент вікна
        public void RefreshContent()
        {
            if (Feed.GetInstance().index >= Feed.GetInstance().GetFeed().Count) return;
            pictureBox1.Load(Feed.GetInstance().GetFeed()[Feed.GetInstance().index].url);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

            author.Text = Feed.GetInstance().GetFeed()[Feed.GetInstance().index].author;
            title.Text = Feed.GetInstance().GetFeed()[Feed.GetInstance().index].title;

            button2.Enabled = Feed.GetInstance().index > 0;
            button1.Enabled = Feed.GetInstance().index < Feed.GetInstance().GetFeed().Count - 1;

        }

        private void PostButton_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Application.Run(new UploadForm()));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Feed.GetInstance().index++;
            RefreshContent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Feed.GetInstance().index--;
                        RefreshContent();
        }

        private void author_Click(object sender, EventArgs e)
        {

        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(() => Application.Run(new CommentsForm(Feed.GetInstance().index)));
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        private void Open_Click(object sender, EventArgs e)
        {
            Feed.GetInstance().Load();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Feed.GetInstance().Save();
        }
    }
}
