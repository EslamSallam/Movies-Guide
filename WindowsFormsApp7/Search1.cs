using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml;
using System.Xml.Linq;

namespace WindowsFormsApp7
{
    public partial class Search1 : UserControl
    {
        public Search1()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            flowLayoutPanel1.Controls.Clear();

            
            movie newmovie = new movie();
            XmlDocument doc = new XmlDocument();
            doc.Load("movie.xml");
            XmlNodeList list = doc.GetElementsByTagName("Movie");
            bool flag = bunifuiOSSwitch1.Value;
            bool entered = false;
            int combo2=0;
            if (comboBox2.Text != "")
                combo2 = Int32.Parse(comboBox2.Text);
            for (int rate = 10; rate > 0; rate--)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList children = list[i].ChildNodes;

                    string id = children[0].Name;
                    string ivalue = children[0].InnerText;

                    string title = children[1].Name;
                    string tvalue = children[1].InnerText;

                    string director = children[2].Name;
                    string dvalue = children[2].InnerText;

                    string poster = children[3].Name;
                    string pvalue = children[3].InnerText;

                    string year = children[4].Name;
                    string yvalue = children[4].InnerText;

                    string genres = children[5].Name;
                    string gvalue = children[5].InnerText;

                    string rating = children[6].InnerText;
                    int rvalue = Int32.Parse(children[6].InnerText);
                    if (flag)
                    {
                        if ((tvalue == bunifuMetroTextbox1.Text || bunifuMetroTextbox1.Text == "") &&
                              (yvalue == comboBox1.Text || comboBox1.Text == "") &&
                              (rvalue >= combo2 && rvalue == rate))
                        {
                            newmovie.id = ivalue;
                            newmovie.title = tvalue;
                            newmovie.poster = pvalue;
                            newmovie.director = dvalue;
                            newmovie.genres = gvalue;
                            newmovie.rating = rating;
                            newmovie.year = yvalue;
                            Show1 sh = new Show1(newmovie);
                            flowLayoutPanel1.Controls.Add(sh);
                            entered = true;
                        }
                    }
                    else
                    {
                        if ((tvalue == bunifuMetroTextbox1.Text || bunifuMetroTextbox1.Text == "") &&
                              (yvalue == comboBox1.Text || comboBox1.Text == "") &&
                              (rvalue <= combo2 && rvalue == rate))
                        {
                            newmovie.id = ivalue;
                            newmovie.title = tvalue;
                            newmovie.poster = pvalue;
                            newmovie.director = dvalue;
                            newmovie.genres = gvalue;
                            newmovie.rating = rating;
                            newmovie.year = yvalue;
                            Show1 sh = new Show1(newmovie);
                            flowLayoutPanel1.Controls.Add(sh);
                            entered = true;
                        }
                    }
                }
            }
            if (!entered)
            {
                alert.AlertPob("No Thing Match Your request", alert.AlertType.info);
            }
            doc.Save("movie.xml");
           
        }

        private void bunifuMetroTextbox2_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuMetroTextbox1_OnValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
