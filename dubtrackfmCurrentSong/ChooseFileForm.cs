using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace dubtrackfmCurrentSong
{
    public partial class ChooseFileForm : System.Windows.Forms.Form
    {
       public ChooseFileForm()
        {
            InitializeComponent();
            saveFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }


        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            textBox1.Text = saveFileDialog1.FileName;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo file = new FileInfo(textBox1.Text);
            CurrentSongForm CurrentSongForm = new CurrentSongForm();
            ChooseFileForm ChooseFileForm = new ChooseFileForm();
            if (System.IO.File.Exists(textBox1.Text))
            {
                Properties.Settings.Default.file = textBox1.Text;
                Properties.Settings.Default.channel = textBox2.Text;
                Properties.Settings.Default.Save();
                if (!this.HasChildren)
                {
                    CurrentSongForm.Show();
                };
            }
            else
            {
                File.Create(textBox1.Text);
                Properties.Settings.Default.file = textBox1.Text;
                Properties.Settings.Default.channel = textBox2.Text;
                Properties.Settings.Default.Save();
            };
            
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.file;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void label2_Click(object sender, EventArgs e)
            
        {

        }
    }
}
