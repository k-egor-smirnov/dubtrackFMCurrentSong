using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Helpers;
using System.Windows.Forms;
using System.IO;
namespace dubtrackfmCurrentSong
{
    public partial class CurrentSongForm : System.Windows.Forms.Form
    {
        public CurrentSongForm()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(Properties.Settings.Default.file))
            {
                label1.Text = Properties.Settings.Default.file;
                InitializeTimer();
            }
            else
            {
                ChooseFileForm form = new ChooseFileForm();
                form.ShowDialog();
                label1.Text = Properties.Settings.Default.file;
                InitializeTimer();
                
            }
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        public void InitializeTimer()
        {
            timer1.Interval = 3000;
            timer1.Tick += new EventHandler(timer1_Tick);

            timer1.Enabled = !timer1.Enabled;
        }

        public void timer1_Tick(object sender, EventArgs e)
        
        {
            try
            {
                WebClient c = new WebClient();
                c.Encoding = Encoding.UTF8;
                var data = c.DownloadString("http://api.dubtrack.fm/room/" + Properties.Settings.Default.channel);
                //Console.WriteLine(data);
                JObject o = JObject.Parse(data);
                string song = (string)o["data"]["currentSong"]["name"];
                song = System.Net.WebUtility.HtmlDecode(song);
                label4.Text = song;
                System.IO.File.WriteAllText(Properties.Settings.Default.file, song);
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException er){
            }catch
            {
                label4.Text = " ";
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click_1(object sender, EventArgs e)
        {

        }


        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChooseFileForm form = new ChooseFileForm();
            this.timer1.Enabled = false;
            this.Enabled = false;
            form.Parent = this.Parent;
            form.Show();
            form.FormClosed += new FormClosedEventHandler(ChildFormClosed);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChooseFileForm form = new ChooseFileForm();
            this.timer1.Enabled = false;
            this.Enabled = false;
            form.Parent = this.Parent;
            form.Show();
            form.FormClosed += new FormClosedEventHandler(ChildFormClosed);
        }
        void ChildFormClosed(object sender, FormClosedEventArgs e)
        {
            this.timer1.Enabled = true;
            this.Enabled = true;
        }
    }

   
}
