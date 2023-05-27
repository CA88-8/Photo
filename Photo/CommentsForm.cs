using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Photo
{
    public partial class CommentsForm : Form
    {
        int index;

        public CommentsForm(int id)
        {
            InitializeComponent();
            index = id;
            Initialize();
        }

        //ініціалізація
        void Initialize()
        {
            pictureBox1.Load(Feed.GetInstance().GetFeed()[index].url);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            author.Text = Feed.GetInstance().GetFeed()[index].author;
            title.Text = Feed.GetInstance().GetFeed()[index].title;

            RefreshComments();
        }

        //оновлення списку коментарів
        void RefreshComments()
        {
            comments.Text = "";
            foreach (Comment comment in Feed.GetInstance().GetFeed()[index].comments)
            {
                string com = $" author: {comment.author}\n{comment.text}\n";
                comments.Text = comments.Text + com;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Feed.GetInstance().GetFeed()[index].AddComment(textBox1.Text, textBox2.Text);
            RefreshComments();
        }
    }
}
