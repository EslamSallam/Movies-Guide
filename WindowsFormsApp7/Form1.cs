using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
using System.Xml.Linq;

namespace WindowsFormsApp7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Opacity = 0;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            panel6.BringToFront();
            panel6.Show();
            remove1.Hide();
            update1.Hide();
            search1.Hide();
            add1.Hide();
            

            movie mvv = new movie();

            XmlDocument doc = new XmlDocument();
            if (File.Exists("movie.xml"))
                doc.Load("movie.xml");
            else
                return;
            XmlNodeList list = doc.GetElementsByTagName("Movie");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList children = list[i].ChildNodes;

                mvv.id = children[0].InnerText;

                mvv.title = children[1].InnerText;
                
                mvv.director = children[2].InnerText;

                mvv.poster = children[3].InnerText;
                
                mvv.year = children[4].InnerText;

                mvv.genres = children[5].InnerText;
                
                mvv.rating = children[6].InnerText;

                Show1 sh = new Show1(mvv);
                flowLayoutPanel1.Controls.Add(sh);
                
            }
            doc.Save("movie.xml");

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();
            panel6.BringToFront();
            panel6.Show();
            recommendation1.Hide();
            remove1.Hide();
            update1.Hide();
            search1.Hide();
            add1.Hide();

            movie mvv = new movie();
            XmlDocument doc = new XmlDocument();
            if (File.Exists("movie.xml"))
                doc.Load("movie.xml");
            else
                return;
            XmlNodeList list = doc.GetElementsByTagName("Movie");
            for (int i = 0; i < list.Count; i++)
            {
                XmlNodeList children = list[i].ChildNodes;

                mvv.id = children[0].InnerText;

                mvv.title = children[1].InnerText;

                mvv.director = children[2].InnerText;

                mvv.poster = children[3].InnerText;

                mvv.year = children[4].InnerText;

                mvv.genres = children[5].InnerText;

                mvv.rating = children[6].InnerText;

                Show1 sh = new Show1(mvv);
                flowLayoutPanel1.Controls.Add(sh);
            }
            doc.Save("movie.xml");
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            add1.BringToFront();
            add1.Show();
        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuImageButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            string str = WindowState.ToString();
            if (str.Equals("Normal"))
                WindowState = FormWindowState.Maximized;
            else
               WindowState = FormWindowState.Normal;
            
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            if (panel5.Visible == true)
                panel5.Visible = false;
            else
                panel5.Visible = true;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {

        }

        private void panel6_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            update1.BringToFront();
            update1.Show();
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            search1.BringToFront();
            search1.Show();
        }

        private void bunifuFlatButton5_Click(object sender, EventArgs e)
        {
            remove1.BringToFront();
            remove1.Show();
        }

        

        private void display11_Load(object sender, EventArgs e)
        {
            
        }

        private void remove1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuFlatButton7_Click_1(object sender, EventArgs e)
        {
            recommendation1.BringToFront();
            recommendation1.Show();

        }

        private void flowLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 100)
            {
                this.Opacity += 0.2;
            }
            else
            {
                timer1.Stop();
            }
        }

    
    }
}
