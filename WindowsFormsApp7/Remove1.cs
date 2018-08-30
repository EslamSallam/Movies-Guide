using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApp7
{
    public partial class Remove1 : UserControl
    {
        public Remove1()
        {
            InitializeComponent();
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            XmlDocument xmd = new XmlDocument();
            xmd.Load("movie.xml");
            foreach (XmlNode xmn in xmd.SelectNodes("MovieList/Movie"))
            {
                if (xmn.SelectSingleNode("Title").InnerText == bunifuMetroTextbox1.Text)
                {
                    xmn.ParentNode.RemoveChild(xmn);
                    alert.AlertPob("Successfully Removed", alert.AlertType.success);
                    xmd.Save("movie.xml");
                    bunifuMetroTextbox1.Text = "";
                    return;
                    
                }
            }
            alert.AlertPob("There is no Movie by This Title !!", alert.AlertType.error);
            bunifuMetroTextbox1.Text = "";
        }

        private void Remove1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
