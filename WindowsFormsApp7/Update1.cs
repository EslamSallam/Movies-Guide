using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Update1 : UserControl
    {
        public Update1()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            string title = bunifuMetroTextbox2.Text;
            bool flag = false;

            XmlDocument doc = new XmlDocument();
            doc.Load("movie.xml");
            XmlNodeList list = doc.GetElementsByTagName("Title");

            for (int i = 0; i < list.Count; i++)
            {
                if (title == list[i].InnerText)
                {
                    flag = true;
                }
            }
            doc.Save("movie.xml");
            if (flag)
            {
                
                var Newdoc = XDocument.Load("movie.xml");
                var node = Newdoc.Descendants("Movie").FirstOrDefault(movie => movie.Element("Title").Value == title);


                bunifuMetroTextbox1.Text = node.Element("ID").Value;
                bunifuMetroTextbox3.Text = node.Element("Director").Value;
                pictureBox1.ImageLocation = node.Element("Poster").Value;
                pictureBox1.Image = Image.FromFile(pictureBox1.ImageLocation);
                comboBox1.Text = node.Element("Year").Value;
                comboBox2.Text = node.Element("Rate").Value;
                string str = node.Element("Geners").Value;
                string[] geners = str.Split(',');
                int j = 0;
                List<int> arr=new List<int>();
                foreach (string item in checkedListBox1.Items)
                {
                    for (int i = 0; i < geners.Length; i++)
                    {
                        if (geners[i] == item)
                        {
                            arr.Add(j);
                            break;
                        }
                    }
                    j++;
                }
                foreach(int ele in arr)
                {
                    checkedListBox1.SetItemCheckState(ele, CheckState.Checked);
                }
                doc.Save("movie.xml");
                panel1.Show();
            }
            else
            {
                alert.AlertPob("The Movie Title you have Entered is not Valid.",alert.AlertType.error);
                return;
            }

        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Choose Image(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image = Image.FromFile(ofd.FileName);
                pictureBox1.ImageLocation = ofd.FileName;
            }
        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void Update1_Load(object sender, EventArgs e)
        {
            panel1.Hide();
        }

        private void bunifuFlatButton2_Click_1(object sender, EventArgs e)
        {
           

            movie updatedmovie = new movie();
            string title = bunifuMetroTextbox2.Text;

            var doc = XDocument.Load("movie.xml");
            var node = doc.Descendants("Movie").FirstOrDefault(movie => movie.Element("Title").Value == title);

            updatedmovie.title = title;
            updatedmovie.id = bunifuMetroTextbox1.Text;
            updatedmovie.director = bunifuMetroTextbox3.Text;
            updatedmovie.poster = pictureBox1.ImageLocation;
            updatedmovie.year = comboBox1.Text;
            updatedmovie.rating = comboBox2.Text;
            updatedmovie.genres = "";
            foreach (string item in checkedListBox1.CheckedItems)
            {
                if (updatedmovie.genres == "")
                    updatedmovie.genres = item;
                else
                    updatedmovie.genres += "," + item;
            }

            node.SetElementValue("ID", updatedmovie.id);
            node.SetElementValue("Title", updatedmovie.title);
            node.SetElementValue("Director", updatedmovie.director);
            node.SetElementValue("Poster", updatedmovie.poster);
            node.SetElementValue("Year", updatedmovie.year);
            node.SetElementValue("Geners", updatedmovie.genres);
            node.SetElementValue("Rate", updatedmovie.rating);
            doc.Save("movie.xml");

            if (updatedmovie.id=="" || updatedmovie.director==""
                || updatedmovie.poster=="" || updatedmovie.year=="" 
                || updatedmovie.genres=="" || updatedmovie.rating=="")
            {
                alert.AlertPob(" Please Fill All Data", alert.AlertType.warning);
                return;
            }

            alert.AlertPob(" Successfully Updated", alert.AlertType.success);

            bunifuMetroTextbox2.Text = "";
            bunifuMetroTextbox1.Text = "";
            bunifuMetroTextbox3.Text = "";
            pictureBox1.Image = null;
            comboBox1.Text = null;
            comboBox2.Text = null;

            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

        }
    }
}
