using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using System.IO;

namespace WindowsFormsApp7
{
    public partial class Recommendation : UserControl
    {
        public Recommendation()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            //string genre="";
            flowLayoutPanel1.Controls.Clear();
            movie newmovie = new movie();
            XmlDocument doc = new XmlDocument();
            bool entered = false;
            if (File.Exists("movie.xml"))
                doc.Load("movie.xml");
            else
                return;
            XmlNodeList list = doc.GetElementsByTagName("Movie");
            List<string> genres = new List<string>();
            foreach (string item in checkedListBox1.CheckedItems)
            {
                genres.Add(item);
            }
            for (int rate = 10; rate > 0; rate--)
            {
                for (int i = 0; i < list.Count; i++)
                {
                    XmlNodeList children = list[i].ChildNodes;

                    string[] movieGenres = children[5].InnerText.Split(',');
                    string rating = children[6].InnerText;
                    int rvalue = Int32.Parse(children[6].InnerText);
                    if (rate == rvalue)
                    {
                        int counter = 0;
                        for (int j = 0; j < genres.Count; j++)
                        {
                            for (int k = 0; k < movieGenres.Length; k++)
                            {
                                if (movieGenres[k] == genres[j])
                                {
                                    counter++;
                                }
                            }
                            if (counter >= genres.Count)
                            {
                                newmovie.id = children[0].InnerText;
                                newmovie.title = children[1].InnerText;
                                newmovie.director = children[2].InnerText;
                                newmovie.poster = children[3].InnerText;
                                newmovie.year = children[4].InnerText;
                                newmovie.genres = children[5].InnerText;
                                newmovie.rating = children[6].InnerText;
                                
                                Show1 sh = new Show1(newmovie);
                                
                                flowLayoutPanel1.Controls.Add(sh);
                                entered = true;

                                break;
                            }
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

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
