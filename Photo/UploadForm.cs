using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Photo
{
    public partial class UploadForm : Form
    {

        string url;

        string author;
        string title;

        public UploadForm()
        {
            InitializeComponent();
        }

        //відкриття файлу
        private void select_button_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.InitialDirectory = "c:\\";
            openFileDialog.FilterIndex = 0;
            openFileDialog.RestoreDirectory = true;

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string selectedFileName = openFileDialog.FileName;
                TryOpenImage(selectedFileName);
            }
        }

        //спроба відкрити зображення
        private void TryOpenImage(string path)
        {
            try
            {
                pictureBox.Load(path);
                pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
                url = path;
            }
            catch (Exception ex) 
            {

                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show("Failed to open image", "Failed to open image", buttons);

            }

        }

        private void Confirm_Click(object sender, EventArgs e)
        {
            Feed.GetInstance().CreateImage(url, title, author);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            author = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            title = textBox2.Text;
        }
    }
}

