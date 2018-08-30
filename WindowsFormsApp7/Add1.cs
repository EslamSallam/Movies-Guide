using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Xml;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class Add1 : UserControl
    {
        public int rateing2;
        public int rateing3;
        public Add1()
        {
            InitializeComponent();
            for (int i = 1950; i <= 2018; i++)
            {

                comboBox1.Items.Add(i);
            }
            if (!File.Exists("movie.xml") && !File.Exists("Director.xml"))
                textBox1.Text = "0";
            else
            {
                string id = "";
                XmlDocument Moviedoc = new XmlDocument();
                Moviedoc.Load("movie.xml");
                foreach (XmlNode XMN in Moviedoc.SelectNodes("MovieList/Movie"))
                {
                    id = XMN.SelectSingleNode("ID").InnerText;
                }
                int iid = int.Parse(id);
                id = (iid + 1).ToString();
                textBox1.Text = id;
            }
        }

        private void bunifuCustomLabel4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Add_Load(object sender, EventArgs e)
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

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {

            if (bunifuMetroTextbox2.Text == "" || bunifuMetroTextbox3.Text == "" || pictureBox1.ImageLocation == "" || comboBox2.Text == "" || comboBox1.Text == "" || string.IsNullOrEmpty(checkedListBox1.Text))
            {
                alert.AlertPob( " Please Fill All Data ",alert.AlertType.warning);
                return;
            }


            else
            {
                movie movie = new movie();
                movie.id = textBox1.Text;
                movie.title = bunifuMetroTextbox2.Text;
                movie.director = bunifuMetroTextbox3.Text;
                movie.year = comboBox1.SelectedItem.ToString();
                movie.genres = "";
                foreach (string item in checkedListBox1.CheckedItems)
                {
                    if (movie.genres == "")
                        movie.genres = item;
                    else
                        movie.genres += "," + item;
                }

                movie.rating = comboBox2.Text;
                movie.poster = pictureBox1.ImageLocation;
                if (!File.Exists("movie.xml"))
                {
                    XmlTextWriter xtw = new XmlTextWriter("movie.xml", Encoding.UTF8);
                    xtw.Formatting = Formatting.Indented;
                    xtw.WriteStartElement("MovieList");
                    xtw.WriteStartElement("Movie");
                    xtw.WriteStartElement("ID");
                    xtw.WriteString(movie.id);
                    xtw.WriteEndElement();
                    xtw.WriteStartElement("Title");
                    xtw.WriteString(movie.title);
                    xtw.WriteEndElement();
                    xtw.WriteStartElement("Director");
                    xtw.WriteString(movie.director);
                    xtw.WriteEndElement();
                    xtw.WriteStartElement("Poster");
                    xtw.WriteString(movie.poster);
                    xtw.WriteEndElement();
                    xtw.WriteStartElement("Year");
                    xtw.WriteString(movie.year);
                    xtw.WriteEndElement();
                    xtw.WriteStartElement("Geners");
                    xtw.WriteString(movie.genres);
                    xtw.WriteEndElement();
                    xtw.WriteStartElement("Rate");
                    xtw.WriteString(movie.rating);
                    xtw.WriteEndElement();
                    xtw.WriteEndElement();
                    xtw.WriteEndElement();
                    xtw.Close();

                    //Director file
                    XmlTextWriter directorwriter = new XmlTextWriter("Director.xml", Encoding.UTF8);
                    directorwriter.Formatting = Formatting.Indented;
                    directorwriter.WriteStartElement("DirectorList");
                    directorwriter.WriteStartElement("Director");
                    directorwriter.WriteStartElement("DirectorID");
                    directorwriter.WriteString("0");
                    directorwriter.WriteEndElement();
                    directorwriter.WriteStartElement("Directorname");
                    directorwriter.WriteString(movie.director);
                    directorwriter.WriteEndElement();
                    directorwriter.WriteEndElement();
                    directorwriter.WriteEndElement();
                    directorwriter.Close();
                    //movie of director file
                    XmlTextWriter moviedirectorwriter = new XmlTextWriter("MovieofDirector.xml", Encoding.UTF8);
                    moviedirectorwriter.Formatting = Formatting.Indented;
                    moviedirectorwriter.WriteStartDocument();
                    moviedirectorwriter.WriteStartElement("MovieofDirectorList");
                    moviedirectorwriter.WriteStartElement("MoviesofDirector");
                    moviedirectorwriter.WriteAttributeString("name", movie.director);
                    moviedirectorwriter.WriteStartElement("Moviename");
                    moviedirectorwriter.WriteString(movie.title);
                    moviedirectorwriter.WriteEndElement();
                    moviedirectorwriter.WriteEndElement();
                    moviedirectorwriter.WriteEndElement();
                    moviedirectorwriter.WriteEndDocument();
                    moviedirectorwriter.Close();
                }
                else
                {
                    XmlDocument Moviedoc = new XmlDocument();
                    Moviedoc.Load("movie.xml");
                    foreach (XmlNode XMN in Moviedoc.SelectNodes("MovieList/Movie"))
                    {
                        if (XMN.SelectSingleNode("Title").InnerText == movie.title)
                        {
                            alert.AlertPob( "This Title Was Used Before!!", alert.AlertType.error);
                            bunifuMetroTextbox2.Text = "";
                            return;
                        }
                    }

                    bool flag = false;

                    XmlDocument doc = new XmlDocument();
                    doc.Load("movie.xml");
                    XmlNodeList list = doc.GetElementsByTagName("Director");

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (movie.director == list[i].InnerText)
                        {
                            flag = true;
                        }
                    }
                    doc.Save("movie.xml");

                    if (flag)
                    {
                        var Newdoc = XDocument.Load("MovieofDirector.xml");
                        var node = Newdoc.Descendants("Movie").FirstOrDefault(MoviesofDirector => MoviesofDirector.Attribute("name").Value == movie.director);



                    }
                    else
                    {
                    //director file
                    int x = 0;
                    string did = "";
                    XmlDocument direcdoc = new XmlDocument();
                    direcdoc.Load("Director.xml");
                    foreach (XmlNode XDN in direcdoc.SelectNodes("DirectorList/Director"))
                    {
                        if (XDN.SelectSingleNode("Directorname").InnerText == movie.director)
                        {
                            x = 1;
                            break;
                        }
                        did = XDN.SelectSingleNode("DirectorID").InnerText;
                    }
                    if (x == 0)
                    {
                        int idid = int.Parse(did);
                        did = (idid + 1).ToString();
                        XmlNode director = direcdoc.CreateElement("Director");
                        XmlNode id = direcdoc.CreateElement("DirectorID");
                        id.InnerText = did;
                        director.AppendChild(id);
                        XmlNode name = direcdoc.CreateElement("Directorname");
                        name.InnerText = movie.director;
                        director.AppendChild(name);
                        direcdoc.DocumentElement.AppendChild(director);
                        direcdoc.Save("Director.xml");
                    }
                        //Movie of Director file
                        int y = 0;
                        XmlDocument movieofdirecdoc = new XmlDocument();
                        movieofdirecdoc.Load("MovieofDirector.xml");
                        foreach (XmlNode XMDN in movieofdirecdoc.SelectNodes("MovieofDirectorList/MovieofDirector"))
                        {
                            if (XMDN.SelectSingleNode("Directorname").InnerText == movie.director)
                            {
                                y = 1;
                                XmlNode moviename = movieofdirecdoc.CreateElement("Moviename");
                                moviename.InnerText = movie.title;
                                XMDN.AppendChild(moviename);
                                movieofdirecdoc.Save("MovieofDirector.xml");
                                break;
                            }
                        }
                        if (y == 0)
                        {
                            XmlNode movieof = movieofdirecdoc.CreateElement("MovieofDirector");
                            XmlNode dirname = movieofdirecdoc.CreateElement("Directorname");
                            dirname.InnerText = movie.director;
                            movieof.AppendChild(dirname);
                            XmlNode movname = movieofdirecdoc.CreateElement("Moviename");
                            movname.InnerText = movie.title;
                            movieof.AppendChild(movname);
                            movieofdirecdoc.DocumentElement.AppendChild(movieof);
                            movieofdirecdoc.Save("MovieofDirector.xml");
                        }
                    }
                    XmlDocument xmd = new XmlDocument();
                    xmd.Load("movie.xml");
                    XmlNode xmn = xmd.CreateElement("Movie");
                    XmlNode ID = xmd.CreateElement("ID");
                    ID.InnerText = movie.id;
                    xmn.AppendChild(ID);
                    XmlNode Title = xmd.CreateElement("Title");
                    Title.InnerText = movie.title;
                    xmn.AppendChild(Title);
                    XmlNode Director = xmd.CreateElement("Director");
                    Director.InnerText = movie.director;
                    xmn.AppendChild(Director);
                    XmlNode Poster = xmd.CreateElement("Poster");
                    Poster.InnerText = movie.poster;
                    xmn.AppendChild(Poster);
                    XmlNode Year = xmd.CreateElement("Year");
                    Year.InnerText = movie.year;
                    xmn.AppendChild(Year);
                    XmlNode Geners = xmd.CreateElement("Geners");
                    Geners.InnerText = movie.genres;
                    xmn.AppendChild(Geners);
                    XmlNode rate = xmd.CreateElement("Rate");
                    rate.InnerText = movie.rating;
                    xmn.AppendChild(rate);
                    xmd.DocumentElement.AppendChild(xmn);
                    xmd.Save("movie.xml");

                }
            }
            alert.AlertPob( " Successfully Added", alert.AlertType.success);
            textBox1.Text = "";
            bunifuMetroTextbox2.Text = "";
            bunifuMetroTextbox3.Text = "";
            pictureBox1.Image = null;
            comboBox1.Text = null;
            comboBox2.Text = "";
            for (int i = 0; i < checkedListBox1.Items.Count; i++)
            {
                checkedListBox1.SetItemChecked(i, false);
            }

            for (int i = 1950; i <= 2018; i++)
            {

                comboBox1.Items.Add(i);
            }
            if (!File.Exists("movie.xml") && !File.Exists("Director.xml"))
                textBox1.Text = "0";
            else
            {
                string id = "";
                XmlDocument Moviedoc = new XmlDocument();
                Moviedoc.Load("movie.xml");
                foreach (XmlNode XMN in Moviedoc.SelectNodes("MovieList/Movie"))
                {
                    id = XMN.SelectSingleNode("ID").InnerText;
                }
                int iid = int.Parse(id);
                id = (iid + 1).ToString();
                textBox1.Text = id;
            }
        }      
    }
}




